using MassTransit;
using Mouts.Sale.Domain.MassageBroker.Events;
using System.Text.Json;

namespace Mouts.Sale.Domain.MassageBroker.Consumer
{
    public class StockManagementConsumer : IConsumer<SaleCreated>
    {

        public async Task Consume(ConsumeContext<SaleCreated> context)
        {
            var serializedMessage = JsonSerializer.Serialize(context.Message, new JsonSerializerOptions { });

            Console.WriteLine($"SaleCreated event consumed. Stock Menagement completed Message: {serializedMessage}");
        }

    }
}
