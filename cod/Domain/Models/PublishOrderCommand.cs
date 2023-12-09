using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Models.Orders;
namespace Domain.Models
{
    public record PublishOrderCommand
    {
        public PublishOrderCommand(IReadOnlyCollection<UnvalidatedOrders> inputOrders)
        {
            InputOrders = inputOrders;
        }

        public IReadOnlyCollection<UnvalidatedOrders> InputOrders { get; }
    }
}