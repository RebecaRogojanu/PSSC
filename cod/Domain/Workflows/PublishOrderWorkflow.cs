using Domain.Models;
using Domain.Operations;
using System;
using LanguageExt;
using static Domain.Models.OrderPublishEvent;
using static Domain.Models.Comanda;
using static Domain.Models.StareComanda;
using Microsoft.Extensions.Logging;

namespace Domain.Workflows {
        public class PublishOrderWorkflow {
            //validare
            // private readonly IStudentsRepository studentsRepository; -- liste
            // private readonly IGradesRepository gradesRepository; -- liste
             private readonly ILogger<PublishOrderWorkflow> logger;

            //  public PublishOrderWorkflow(IStudentsRepository studentsRepository, IGradesRepository gradesRepository, ILogger<PublishGradeWorkflow> logger)
            //     {
            //         this.studentsRepository = studentsRepository;
            //         this.gradesRepository = gradesRepository;
            //         this.logger = logger;
            //     }
            public async Task<IOrderPublishedEvent> ExecuteAsync(PublishOrderCommand command)
            {
                Invalida comenziNevalidate = new Invalida(command.InputOrders);
                var result = 
            }
            // public async Task<
            //calcul total

            //trimitere la urm. workflow
        
        //     public async Task<IOrderPublishedEvent> ExecuteAsync(PublishOrderCommand publishOrderCommand, Func<CheckOrderValidation, TryAsync<bool>>checkOrderExists) {
        //     UnvalidatedOrders unvalidatedOrder = new UnvalidatedOrders(publishOrderCommand.InputOrders);
        //     IStareComanda comanda = await ValidateOrders(checkOrderExists, unvalidatedOrder);

        //     // comanda=CalculateTotal(comanda);
        //     // comanda=PublishComanda(comanda);
            
        //     return comanda.Match(
        //         whenNevalidata: unvalidatedOrder => new OrderPublishedFailedEvent("Unexpected unvalid state") as IOrderGradesPublishedEvent,
        //         whenValidata: validatatedOrder => new OrderPublishedFailedEvent("Unexpected unvalid state"),
        //         whenAnulata: canceledOrder => new OrderCancelEvent(),
        //         whenEmisa: emissedOrder => new OrderPublishSuccededEvent()
        //     );
        // }


    }
}