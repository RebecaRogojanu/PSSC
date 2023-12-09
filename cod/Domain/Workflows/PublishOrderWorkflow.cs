using Domain.Models;
using Domain.Commands;
using System;
using LanguageExt;
using static Domain.Models.OrderPublishEvent;
using static Domain.Models.Orders;
using static Domain.Models.StareComanda;

namespace Domain.Workflows {
        public class PublishOrderWorkflow {
            public async Task<IOrderPublishedEvent> ExecuteAsync(PublishOrderCommand publishOrderCommand, Func<CheckOrderValidation, TryAsync<bool>>checkOrderExists) {
            UnvalidatedOrders unvalidatedOrder = new UnvalidatedOrders(publishOrderCommand.InputOrders);
            IStareComanda comanda = await ValidateOrders(checkOrderExists, unvalidatedOrder);

            // comanda=CalculateTotal(comanda);
            // comanda=PublishComanda(comanda);
            
            return comanda.Match(
                whenNevalidata: unvalidatedOrder => new OrderPublishedFailedEvent("Unexpected unvalid state") as IOrderGradesPublishedEvent,
                whenValidata: validatatedOrder => new OrderPublishedFailedEvent("Unexpected unvalid state"),
                whenAnulata: canceledOrder => new OrderCancelEvent(),
                whenEmisa: emissedOrder => new OrderPublishSuccededEvent()
            );
        }
    }
}