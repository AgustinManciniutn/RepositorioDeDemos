using System.Threading.Tasks.Dataflow;
using Microsoft.EntityFrameworkCore;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Infrastructure.Reservations;


namespace sigmaHashAlpha.Infrastructure.StockHostedService;


public class StockHostedService : IHostedService, IDisposable
{
    private Task? _stockTask;
    private readonly BufferBlock<string> stockQueue;
    private readonly IServiceProvider provider;
    private CancellationTokenSource? _cancellationToken;
    public StockHostedService(IServiceProvider _provider)
    {
        stockQueue = new BufferBlock<string>();

        _cancellationToken = new CancellationTokenSource();
        provider = _provider;
    }

    public async Task MakeReservation(string ReservationId) => await stockQueue.SendAsync(ReservationId);

    public void Dispose()
    {
        DestroyTask();
    }

    private void DestroyTask()
    {
        try
        {
            if (_cancellationToken != null)
            {
                _cancellationToken.Cancel();
                _cancellationToken = null;
            }
            Console.WriteLine("[RESERVATION SERVICE] DESTROY SERVICE");
        }
        catch
        {

        }
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("[RESERVATION SERVICE] START SERVICE");
        _stockTask = BackgroundCheckReservationsAsync(_cancellationToken!.Token);
        return Task.CompletedTask;
    }

    PeriodicTimer timer = new PeriodicTimer(TimeSpan.FromMinutes(5));

    private async Task BackgroundCheckReservationsAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("RESERVATION HOST executed");
        List<string> CurrentReservations = new();
        
        
        while(await timer.WaitForNextTickAsync(stoppingToken))
        {
            using(IServiceScope scope = provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                IList<string> Reservations;
                if (stockQueue.TryReceiveAll(out Reservations))
                {
                    foreach (var id in Reservations)
                    {
                        CurrentReservations.Add(id);
                    }
                }

                var ReservationList = await db.Reservations.Where(x => CurrentReservations.Contains(x.ReservationId)).ToListAsync();

                foreach (var Reservation in ReservationList)
                {
                    DateTime CreationDate = DateTime.Parse(Reservation.Created);

                    if ((DateTime.Now - CreationDate).TotalHours > 8)
                    {

                       Reservation.IsExpired = true;
                       var ItemsRestock = await db.ReservationItems.Where(x => x.ReservationItemId == Reservation.ReservationId).ToListAsync();
                       foreach (var obj in ItemsRestock)
                       {
                           var Product = await db.Products.FindAsync(obj.ProductId);
                           if (Product != null)
                           {
                               Product.Stock += obj.Amount;
                               db.Products.Update(Product);
                           }
                       }
                       await db.SaveChangesAsync();
                       CurrentReservations.Remove(Reservation.ReservationId);
                    }
                }
            }
        }
    }
    public async Task StopAsync(CancellationToken cancellationToken)
    {
        DestroyTask();
        await Task.WhenAny(_stockTask!, Task.Delay(Timeout.Infinite, cancellationToken));
    }

}
