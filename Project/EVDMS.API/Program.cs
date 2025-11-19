using EVDMS.Application;
using EVDMS.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddInfrastructureServices();
builder.Services.AddApplication();
builder.Services.AddAutoMapper(configAction =>
{
    // Add all profiles in the current assembly
    configAction.AddMaps(typeof(Program).Assembly);
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    // Specify the OpenAPI version to use
    options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_0;
});

// Add Infrastructure layer services (uncomment after adding project reference)
// builder.Services.AddInfrastructure(builder.Configuration);
// builder.Services.AddInfrastructureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("openai/v1.json", "EVDMS API V1 testing");
    });
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Hello world!");

app.Run();
