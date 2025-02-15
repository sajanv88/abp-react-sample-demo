
using SimpleTodoApp;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseAutofac();

await builder.AddApplicationAsync<ApiModule>();

var app = builder.Build();

await app.InitializeApplicationAsync();
await app.RunAsync();
