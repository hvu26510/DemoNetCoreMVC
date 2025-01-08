using DemoNetCoreMVC.CustomMiddlewareDemo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//Middleware 1
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("<div> Hello FPoly from the middleware 1 </div>");
    await next.Invoke();
    await context.Response.WriteAsync("<div> Returning from the middleware 1 </div>");
});
//Middleware 2
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("<div> Hello FPoly from the middleware 2 </div>");
    await next.Invoke();
    await context.Response.WriteAsync("<div> Returning from the middleware 2 </div>");
});
//Middleware 3
app.UseMiddleware<CustomMiddleware>();
app.Run(async (context) =>
{
    await context.Response.WriteAsync("<div> Hello FPoly from the middleware 3 </div>");
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
