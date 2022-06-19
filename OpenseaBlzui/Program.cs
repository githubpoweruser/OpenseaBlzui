using OpenseaBlzui.Helper;
using OpenseaBlzui.Helper.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAntDesign();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient("OpenseaAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:44351/");
    client.Timeout = new TimeSpan(0,0,15);
});

builder.Services.AddScoped<IHttpClientHelper, HttpClientHelper>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
