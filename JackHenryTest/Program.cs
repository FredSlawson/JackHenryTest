var AllowedOrigins = "_AllowedOrigins";


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowedOrigins,
                      policy =>
                      {
                          policy.WithOrigins("twitter.com");
                                              
                      });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();
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
app.UseCors(AllowedOrigins);
app.UseAuthorization();
app.MapControllerRoute(
    name: "Twitter",
    pattern: "{controller=Twitter}");
app.MapRazorPages();

app.Run();
