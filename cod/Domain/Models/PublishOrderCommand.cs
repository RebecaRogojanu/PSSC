using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Models
{
    public record PublishOrderCommand
    {
        public PublishOrderCommand(IReadOnlyCollection<ComandaNevalidata> inputOrders)
        {
            InputOrders = inputOrders;
        }

        public IReadOnlyCollection<ComandaNevalidata> InputOrders { get; }
    }
}