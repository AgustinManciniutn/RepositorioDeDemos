using System.Threading.Tasks.Dataflow;
using Microsoft.EntityFrameworkCore;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Infrastructure.Reservations;
using sigmaHashAlpha.Utilities.IUtilities;

namespace sigmaHashAlpha.Infrastructure.StockHostedService;


public class StockHostedService : IHostedService, IDisposable
{
    private Task? _stockTask;
    private readonly BufferBlock<string> stockQueue;
    private readonly IServiceProvider provider;
    private CancellationTokenSource? _cancellationToken;

    public readonly int TICK;
    public readonly int TIMESPAN;

    public StockHostedService(IServiceProvider _provider)
    {
        stockQueue = new BufferBlock<string>();

        _cancellationToken = new CancellationTokenSource();
        provider = _provider;

        TICK = 1; // Timer tick from Minutes
        TIMESPAN = 1; //Reservation Duration Span in hours
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


    private async Task BackgroundCheckReservationsAsync(CancellationToken stoppingToken)
    {
        PeriodicTimer timer = new PeriodicTimer(TimeSpan.FromMinutes(TICK)); // TIMER TICK SPAN
        Console.WriteLine("RESERVATION HOST executed");
        List<string> CurrentReservations = new();
        
        
        while(await timer.WaitForNextTickAsync(stoppingToken))
        {
            using(IServiceScope scope = provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var memorycache = scope.ServiceProvider.GetRequiredService<ICache>();

                IList<string> Reservations;
                if (stockQueue.TryReceiveAll(out Reservations))
                {
                    CurrentReservations.AddRange(Reservations);
                }

                var ReservationList = await db.Reservations.Where(x => CurrentReservations.Contains(x.ReservationId)).ToListAsync();

                foreach (var Reservation in ReservationList)
                {
                    DateTime CreationDate = DateTime.Parse(Reservation.Created);

                    if ((DateTime.Now - CreationDate).TotalMinutes > TIMESPAN) // 
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
                               memorycache.UpdateFromCache(Product);
                           }
                       }
                       db.Reservations.Update(Reservation);
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
