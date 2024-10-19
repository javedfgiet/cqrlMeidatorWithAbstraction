var builder = WebApplication.CreateBuilder(args);
//Add dependency Injection
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});



var app = builder.Build();



//Add Processing Pipelines
app.MapCarter();
app.Run();
