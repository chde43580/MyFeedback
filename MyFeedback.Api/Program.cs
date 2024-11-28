using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using MyFeedback.Api.Data;
using MyFeedback.Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using MyFeedback.Application;
using MyFeedback.Api.TypedClients.Interfaces;
using MyFeedback.Api.TypedClients.Implementations;


// Database-migrationer kommandoer:

// Add-Migration [MigrationNAVN] -Context MyFeedbackContext -Project MyFeedback.DatabaseMigration
// Update-Database -Context MyFeedbackContext -Project MyFeedback.DatabaseMigration

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorizationBuilder()
    .AddPolicy(
"IsTeacher",
policyBuilder => policyBuilder
    .RequireClaim("IsTeacher"))
   .AddPolicy(
"IsLoggedIn",
policyBuilder => policyBuilder
    .RequireAuthenticatedUser());

// Tilføjer vores to separate Dependency Injection-klasser fra Application-, Infrastructure-lagene
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration); // TODO: Kan vi undgå at Razor Page-projektet kender til Infrastructure - siden vi persisterer vores identity-data i vores ENE sql-database (ie. vi skal bruge infr-referencen til Identity..)

// IHTTPClientFactory
builder.Services.AddHttpClient<IExitSlipClient, ExitSlipClient>(client =>
    client.BaseAddress = new Uri(builder.Configuration["MyFeedbackBaseUrl"]));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Lockout.AllowedForNewUsers = true;
    options.Password.RequiredLength = 12;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
}
    )
    .AddEntityFrameworkStores<MyFeedbackContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(15);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});


builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

app.MapRazorPages();

app.Run();
