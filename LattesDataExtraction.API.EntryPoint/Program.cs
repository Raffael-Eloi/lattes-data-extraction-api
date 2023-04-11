using AutoMapper;
using LattesDataExtraction.Infraestructure.Ioc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddServicesDependency();

var mapperConfiguration = new MapperConfiguration(mc =>
{
    mc.AddMappersProfiles();
});

IMapper mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();