using Microsoft.AspNetCore.Identity;
using MyFeedback.Infrastructure;
using MyFeedback.Frontend.TypedClients.Interfaces;
using MyFeedback.Frontend.TypedClients.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Authorization policies
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("IsTeacher", policyBuilder => policyBuilder.RequireClaim("IsTeacher"))
    .AddPolicy("IsAdmin", policyBuilder => policyBuilder.RequireClaim("IsAdmin"))
    .AddPolicy("IsLoggedIn", policyBuilder => policyBuilder.RequireAuthenticatedUser());

// Infrastructure services
builder.Services.AddInfrastructure(builder.Configuration);

// HTTP clients
builder.Services.AddHttpClient<IExitSlipClient, ExitSlipClient>(client =>
    client.BaseAddress = new Uri(builder.Configuration["MyFeedbackBaseUrl"]));
builder.Services.AddHttpClient<ILessonClient, LessonClient>(client =>
    client.BaseAddress = new Uri(builder.Configuration["MyFeedbackBaseUrl"]));

// Identity and authentication
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Lockout.AllowedForNewUsers = true;
    options.Password.RequiredLength = 12;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
})
.AddEntityFrameworkStores<MyFeedbackContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});

// Blazor and Razor Pages
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

