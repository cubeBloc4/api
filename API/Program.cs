using DependencyInjection;
using Infrastructure.Context;
using DotEnv = dotenv.net.DotEnv;

DotEnv.Load(options: new dotenv.net.DotEnvOptions(
    envFilePaths: new[] {
        Path.Combine(Directory.GetCurrentDirectory(), ".env"),   // API root
        Path.Combine(AppContext.BaseDirectory, ".env")           // build output folder
    },
    overwriteExistingVars: false // do not overwrite real environment variables
));

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRepositories(builder.Configuration);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Initial DB connection test
using (var scope = app.Services.CreateScope())
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    var db = scope.ServiceProvider.GetRequiredService<StiveDbContext>();
    var canConnect = await db.Database.CanConnectAsync();
    logger.LogInformation("DB connection test success? {CanConnect}", canConnect);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

