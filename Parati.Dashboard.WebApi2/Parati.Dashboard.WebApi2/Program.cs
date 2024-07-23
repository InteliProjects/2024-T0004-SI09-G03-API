
using Parari.Dashboard.Repository;
using Parati.Dashboard.Repository;
using Parati.Dashboard.Services;

var builder = WebApplication.CreateBuilder(args);
var configBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

IConfigurationRoot configuration = configBuilder.Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGptwService, GptwServiceImpl>();
builder.Services.AddScoped<IMedicalTreatmentService, MedicalTreatmentServiceImpl>();
builder.Services.AddScoped<IGptwVWService, GptwVWServiceImpl>();
builder.Services.AddScoped<IGeneralDataService, GeneralDataService>();
builder.Services.AddScoped<IQuestionScoreService, QuestionScoreService>();
builder.Services.AddScoped<IPlantSumService, PlantSumServiceImpl>();
builder.Services.AddScoped<IEngagementeService, EngagementServiceImpl>();

builder.Services.AddScoped<IPlantSumRepository>(_ => new PlantSumRepository(configuration["DB_CONFIG"]));
builder.Services.AddScoped<IGeneralDataRepository>(_ => new GeneralDatasRepository(configuration["DB_CONFIG"]));
builder.Services.AddScoped<IEngagementRepository>(_ => new EngagementRepositoryImpl(configuration["DB_CONFIG"]));
builder.Services.AddScoped<IGPTWRepository>(_ => new GPTWsRepository(configuration["DB_CONFIG"]));
builder.Services.AddScoped<IMedicalTreatmentRepository>(_ => new MedicalTreatmentRepository(configuration["DB_CONFIG"]));
builder.Services.AddScoped<IGPTWVWRepository>(_ => new GPTWsVWRepository(configuration["DB_CONFIG"]));
builder.Services.AddScoped<IQuestionScoreRepository>(_ => new QuestionScoresRepository(configuration["DB_CONFIG"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();