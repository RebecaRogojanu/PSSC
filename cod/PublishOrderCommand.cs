using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exemple.Domain.Orders;

namespace Exemple.Domain
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