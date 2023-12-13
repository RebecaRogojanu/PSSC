using System.Data;
using System.Security.AccessControl;
using Data.Context;
using Data.Repository;
using Domain;
using Domain.Models;
using Domain.Workflows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using static LanguageExt.Prelude;
using LanguageExt;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Program
{
    class Program 
    {
        private static string ConnectionString = "Server=LAPTOP-5O6G7HEC\\DEVELOPER;Database=PSSC-sample;Trusted_Connection=True;MultipleActiveResultSets=true"; //replace

        static async Task Main(string[] args) {
            using ILoggerFactory loggerFactory = ConfigureLoggerFactory();
            ILogger<PublishOrderWorkflow> logger = loggerFactory.CreateLogger<PublishOrderWorkflow>();
            
            var listaComenzi = ReadListOfOrders().ToList();
            PublishOrderCommand command = new PublishOrderCommand(listaComenzi);
            var dbContextBuilder = new DbContextOptionsBuilder<OrderContext>()
                                                .UseSqlServer(ConnectionString)
                                                .UseLoggerFactory(loggerFactory);
            OrderContext orderContext = new OrderContext(dbContextBuilder.Options);
            OrderRepository orderRepository = new OrderRepository(orderContext);

            PublishOrderWorkflow workflow = new PublishOrderWorkflow(orderRepository, logger);
            var result = await workflow.ExecuteAsync(command);

             result.Match(
                whenOrderPublishedFailedEvent: @event => 
                {
                    Console.WriteLine($"Publish failed: {@event.Reason}");
                    return @event;
                },
                whenOrderPublishedScucceededEvent: @event =>
                {
                    Console.WriteLine($"Publish succeeded.");
                    return @event;
                }
             );
        }

        private static ILoggerFactory ConfigureLoggerFactory()
        {
            return LoggerFactory.Create(builder =>
                                builder.AddSimpleConsole(options =>
                                {
                                    options.IncludeScopes = true;
                                    options.SingleLine = true;
                                    options.TimestampFormat = "hh:mm:ss ";
                                })
                                .AddProvider(new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()));
        }

        private static List<ComandaNevalidata> ReadListOfOrders()
        {
            List<ComandaNevalidata> listOfOrders = new();
            do
            {
                var strada = ReadValue("Strada: ");
                if (string.IsNullOrEmpty(strada))
                {
                    break;
                }

                var oras = ReadValue("Oras: ");
                if (string.IsNullOrEmpty(oras))
                {
                    break;
                }

                listOfOrders.Add(new(strada, oras));
            } while (true);
            return listOfOrders;
        }

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
