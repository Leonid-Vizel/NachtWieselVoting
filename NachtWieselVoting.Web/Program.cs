using NachtWieselVoting.BusinessLogic.DependencyInjectionExtensions;
using NachtWieselVoting.Web.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSignalR();

builder.AddDatabase();

builder.Services.AddDataServices()
    .AddCookieAuth();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapLogout();

app.MapRazorPages();
app.MapHub<VoteHub>("/Votes/Live");

app.Services.MigrateDatabase();

app.Run();
