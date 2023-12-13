using Domain.Models;
using LanguageExt;
using static Domain.Models.OrderPublishEvent;
using static Domain.Models.Comanda;
using static Domain.Models.StareComanda;
using static LanguageExt.Prelude;
using Domain.Operations;
using Microsoft.Extensions.Logging;
using Domain.Repositories;

namespace Domain.Workflows {
        public class PublishOrderWorkflow {
            //validare
            private readonly IOrderRepository orderRepository;
            private readonly ILogger<PublishOrderWorkflow> logger;

            public PublishOrderWorkflow(IOrderRepository orderRepository, ILogger<PublishOrderWorkflow> logger)
            {
                this.orderRepository = orderRepository;
                this.logger = logger;
            }
            public async Task<IOrderPublishedEvent> ExecuteAsync(PublishOrderCommand command)
            {
                Invalida comenziNevalidate = new Invalida(command.InputOrders);
                var result = from comenzi in orderRepository.TryGetExistingOrders()
                                .ToEither(ex => new Esuata(comenziNevalidate.listaComenzi, ex) as IStareComanda)
                                let checkOrderExists = (Func<CheckOrderValidation, Option<CheckOrderValidation>>)(comanda => CheckOrderExists(comenzi,comanda))
                                from publishedOrders in ExecuteWorkflowAsync
            }

        private async Task<Either<IStareComanda, ComandaValidata>> ExecuteWorkflowAsync(ComandaNevalidata comandaNevalidata, IEnumerable<Comanda> existingOrders, Func<CheckOrderValidation,Option<CheckOrderValidation>>checkOrderExists) {
            //al doilea termen de schimbat
            IStareComanda comanda = await ValidateOrders(checkOrderExists, comandaNevalidata);

        }
        private Option<CheckOrderValidation> CheckOrderExists(IEnumerable<CheckOrderValidation> comenzi, CheckOrderValidation orderValidation)
        {
            if(comenzi.Any(c=> c == orderValidation))
            {
                return Some(orderValidation);
            }
            else
            {
                return None;
            }
        }
    }
}