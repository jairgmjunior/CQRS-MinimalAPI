using Archer.Application.Input.Receivers;
using Archer.Application.Input.Repositories;
using Archer.Application.Output.Interfaces;
using Archer.Infrastructure.Input.Factory;
using Archer.Infrastructure.Input.Repositories;
using Archer.Infrastructure.Output.Factory;
using Archer.Infrastructure.Output.Repositories;
using Microsoft.AspNetCore.Mvc;
using Archer.Application.Input.Commands;
using Archer.Application.Input.Commands.VehicleContext;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddScoped<SqlFactoryInput>();
        builder.Services.AddScoped<SqlFactoryOutput>();
        builder.Services.AddTransient<IWriteVehicleRepository, WriteVehicleRepository>();
        builder.Services.AddTransient<IReadVehicleRepository, ReadVehicleRepository>();
        builder.Services.AddTransient<InsertVehicleReceiver>();

        var app = builder.Build();

        app.MapGet("/vehicle/GetAll/", ([FromServices] IReadVehicleRepository repository) => 
        {
            return repository.GetVehicles();
        });

        app.MapGet("/vehicle/GetById/", ([FromQuery] int id, [FromServices] IReadVehicleRepository repository) =>
        {
            return repository.FindById(id);
        });

        app.MapGet("/vehicle/GetByCategoryId/", ([FromQuery] int categoryId, [FromServices] IReadVehicleRepository repository) =>
        {
            return repository.FindByCategoryId(categoryId);
        });

        app.MapPost("/vehicle/PostVehicle/", ([FromServices] InsertVehicleReceiver receiver, [FromBody] VehicleCommand command) => {
            return receiver.Action(command);
        });

        app.Run();
    }
}