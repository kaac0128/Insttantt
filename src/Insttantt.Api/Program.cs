using Insttantt.Api.Mapper;
using Insttantt.Data.DataAccess;
using Insttantt.Data.Entities;
using Insttantt.Data.Repositories;
using Insttantt.Data.Repositories.ProjectName.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IFieldRepository, FieldRepository>();
builder.Services.AddScoped<IStepRepository, StepRepository>();
builder.Services.AddScoped<IFlowRepository, FlowRepository>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(MappingProfiles)); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog(((ctx, config) => config.ReadFrom.Configuration(ctx.Configuration)));

builder.Services.AddDbContext<InsttanttDataDBContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("InsttanttConnection")); });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<InsttanttDataDBContext>();
    dataContext.Database.EnsureCreated();
    SeedData(dataContext);
}

void SeedData(InsttanttDataDBContext dataContext)
{
    try
    {
        var inputField1 = new Field { FieldName = "Primer nombre" };
        var inputField2 = new Field { FieldName = "Segundo nombre" };
        var inputField3 = new Field { FieldName = "Primer apellido" };
        var inputField4 = new Field { FieldName = "Segundo apellido" };
        var inputField5 = new Field { FieldName = "Tipo de documento" };
        var inputField6 = new Field { FieldName = "N�mero de documento" };

        var outputField1 = new Field { FieldName = "Campo de salida 1" };
        var outputField2 = new Field { FieldName = "Campo de salida 2" };
        var outputField3 = new Field { FieldName = "Campo de salida 3" };

        var flow1 = new Flow { FlowName = "Flujo de ejemplo 1" };
        var flow2 = new Flow { FlowName = "Flujo de ejemplo 2" };
        var flow3 = new Flow { FlowName = "Flujo de ejemplo 3" };

        var step1 = new Step { StepName = "Paso 1", Flow = flow1 };
        step1.InputField = inputField1;
        step1.OutputField = outputField1;

        var step2 = new Step { StepName = "Paso 2", Flow = flow1 };
        step2.InputField = inputField2;
        step2.OutputField = outputField2;

        var step3 = new Step { StepName = "Paso 3", Flow = flow2 };
        step3.InputField = inputField3;
        step3.OutputField = outputField3;

        dataContext.Flows.AddRange(flow1, flow2, flow3);
        dataContext.Steps.AddRange(step1, step2, step3);

        dataContext.SaveChanges();
    }
    catch (Exception ex)
    {
        throw ex;
    }
}

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
