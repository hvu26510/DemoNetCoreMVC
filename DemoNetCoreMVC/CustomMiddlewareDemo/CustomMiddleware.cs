namespace DemoNetCoreMVC.CustomMiddlewareDemo
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("<div>Hello Thepv! from Simple middleware </div>");
            await _next(context);
            await context.Response.WriteAsync("<div>Hello Thepv! from Simple middleware </div>");
        }
    }

}
