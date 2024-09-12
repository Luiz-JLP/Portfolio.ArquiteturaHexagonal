using Application.Startup;
using Infrastructure.Data.Startup;
using Infrastructure.Email.Startup;
using WebApi.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDataInfrastructure();
builder.Services.ConfigureEmailInfrastructure();
builder.Services.ConfigureApplication();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

DataInitialization.InitializeDatabase(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
