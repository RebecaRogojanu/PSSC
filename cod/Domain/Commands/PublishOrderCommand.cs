using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
namespace Domain.Commands
{
    public record PublishOrderCommand
    {
        public PublishOrderCommand(IReadOnlyCollection<Orders.UnvalidatedOrders> inputOrders)
        {
            InputOrders = inputOrders;
        }

        public IReadOnlyCollection<Orders.UnvalidatedOrders> InputOrders { get; }
    }
}