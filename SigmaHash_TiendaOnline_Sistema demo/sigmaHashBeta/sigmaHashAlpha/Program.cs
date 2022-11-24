using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using sigmaHashAlpha;
using sigmaHashAlpha.Core.Interfaces;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Infrastructure.Email;
using sigmaHashAlpha.Infrastructure.HosttedService;
using sigmaHashAlpha.Infrastructure.Roles;
using sigmaHashAlpha.Infrastructure.StockHostedService;
using sigmaHashAlpha.Models.Products;
using sigmaHashAlpha.Repositories;
using sigmaHashAlpha.Utilities;
using sigmaHashAlpha.Utilities.IUtilities;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("hashConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddTransient<StoreCache<ProductList>>();
builder.Services.AddTransient<ICache, Cache>();
builder.Services.AddTransient<IPaging, Paging>();
builder.Services.AddTransient<IFiltering, Filtering>();

builder.Services.AddSingleton<StockHostedService>();
builder.Services.AddSingleton<EmailHostedService>();


builder.Services.AddHostedService(provider => provider.GetService<StockHostedService>());
builder.Services.AddHostedService(provider => provider.GetService<EmailHostedService>());


builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    
}).AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddTransient<UserManager<ApplicationUser>>();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ManagerOnly",
         policy => policy.RequireRole("Manager"));
    options.AddPolicy("AdminOnly  Role",
         policy => policy.RequireRole("Administrator"));
    options.AddPolicy("AssistantOnly",
         policy => policy.RequireRole("Assistant"));
});



builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
AddScoped();

builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

app.UseSession();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


//app.MapGet("/test-email", async (EmailHostedService hostedService) =>
//{

//    await hostedService.SendEmailAsync(new EmailModel
//    {
//        EmailAddress = "agustinmancini100@gmail.com",
//        Subject = "Hello from mvc",
//        //Body = "<strong> Hello from hosted service </strong>",
//        Attachments = null,

//    });

//}).WithName("TestEmail");


app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();


app.Lifetime.ApplicationStarted.Register(async () =>
{
    using var scope = app.Services.CreateScope();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var manager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var pwhasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher<ApplicationUser>>();

    var rolecheck = new List<string> { "Manager", "Administrator", "Assistant" };
    
    foreach(var obj in rolecheck)
    {
        var check = await db.Roles.FirstOrDefaultAsync(r => r.Name == obj);
        if(check == null)
        {
            var role = new IdentityRole();
            role.Name = obj;
            await roleManager.CreateAsync(role);
        }
    }


    var User = await db.Users.FirstOrDefaultAsync(x => x.Email == "sigma.hash@gobs.com.ar");
    if (User == null)
    {



        var user = new ApplicationUser {
            UserName = "sigma.hash@gobs.com.ar",
            Email = "sigma.hash@gobs.com.ar",
            NormalizedUserName = "SIGMA.HASH@GOBS.COM.AR",
            NormalizedEmail = "SIGMA.HASH@GOBS.COM.AR",
            EmailConfirmed = true,
            TwoFactorEnabled = false,
            LockoutEnabled = false,    
        };
        var result = await manager.CreateAsync(user, "Sigmasoldier_2030");

        var PasswordHash = pwhasher.HashPassword(user, "Sigmasoldier_2030");
        await manager.AddPasswordAsync(user, PasswordHash);


        await manager.UpdateSecurityStampAsync(user);
        await manager.UpdateNormalizedEmailAsync(user);
        await manager.UpdateNormalizedUserNameAsync(user);
        await manager.SetLockoutEnabledAsync(user, true);

        await db.Users.AddAsync(user);
        //await db.SaveChangesAsync();

        var DefaultUser = await db.Users.FirstOrDefaultAsync(x => x.UserName == "sigma.hash@gobs.com.ar");

        await manager.AddToRoleAsync(DefaultUser, "Manager");
        await manager.AddToRoleAsync(DefaultUser, "Administrator");
        await manager.AddToRoleAsync(DefaultUser, "Assistant");

        RoledUsers roleduser = new RoledUsers();
        roleduser.UserId = DefaultUser.Id;
        await db.RoledUsers.AddAsync(roleduser);
    }
    else
    {
        var roles = await manager.GetRolesAsync(User);
        var Roles = new List<string> { "Manager", "Administrator", "Assistant" };

        var RolesToAssign = Roles.Except(roles);
        if (RolesToAssign != null)
        {
            foreach (var role in RolesToAssign)
            {
                await manager.AddToRoleAsync(User, role);
            } 
        }
        RoledUsers check = await db.RoledUsers.FirstOrDefaultAsync(x => x.UserId == User.Id);
        if(check == null)
		{
            RoledUsers roledUser = new RoledUsers();
            roledUser.UserId = User.Id;
            await db.RoledUsers.AddAsync(roledUser);
		}
    }
    await db.SaveChangesAsync();
});

app.Run();

void AddScoped()
{
    builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
    builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
}