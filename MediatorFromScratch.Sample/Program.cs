using MediatorFromScratch.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorFromScratch.Sample;

public class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddMediator(ServiceLifetime.Scoped, typeof(Program))
            .BuildServiceProvider();
        //.AddTransient<PrintToConsoleHandler>()

        // var handlerDetails = new Dictionary<Type, Type>
        // {
        //     { typeof(PrintToConsoleRequest), typeof(PrintToConsoleHandler) }
        // };
        
        // request

        
        //handler
        //IMediator mediator = new Mediator(serviceProvider.GetRequiredService, handlerDetails);

        // mediator
        var mediator = serviceProvider.GetRequiredService<IMediator>();
        var request = new PrintToConsoleRequest()
        {
            Text = "Hello from mediator"
        };
        await mediator.SendAsync(request);

        var result = mediator.SendAsync(new GiveMeAValueRequest());
        // request => mediator => handler => response
    }
}