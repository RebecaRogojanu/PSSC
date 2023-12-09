using Exemple.Domain;
using StareCarucior.Domain;
using System;
using static Exemple.Domain.OrderPublishEvent;
using static Exemple.Domain.Orders;
using LanguageExt;

namespace StareCarucior.Domain {
        public class PublishOrderWorkflow {
            public async Task<IOrderPublishedEvent> ExecuteAsync(PublishOrderCommand publishOrderCommand, Func<CheckOrderValidation, TryAsync<bool>>checkOrderExists) {
            UnvalidatedOrders unvalidatedOrder = new UnvalidatedOrders(publishOrderCommand.InputOrders);
            StareComanda.iStareComanda comanda = await ValidatedOrders(checkOrderExists, unvalidatedOrder);

            // comanda=CalculateTotal(comanda);
            // comanda=PublishComanda(comanda);
            
            return comanda.Match(
                whenNevalidata: unvalidatedOrder => new OrderPublishFailedEvent("Unexpected unvalid state") as IOrderGradesPublishedEvent,
                whenValidata: validatatedOrder => new OrderPublishFailedEvent("Unexpected unvalid state"),
                whenAnulata: canceledOrder => new OrderCancelEvent(),
                whenEmisa: emissedOrder => new OrderPublishSuccededEvent()
            );
        }
    }
}