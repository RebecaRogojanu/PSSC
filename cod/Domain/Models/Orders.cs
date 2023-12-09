using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    [AsChoice]
    public static partial class Orders {
        public interface IOrders { }

        public record UnvalidatedOrders : IOrders
        {
            public UnvalidatedOrders(IReadOnlyCollection<UnvalidatedOrders> orderList)
            {
                OrderList = orderList;
            }

            public IReadOnlyCollection<UnvalidatedOrders> OrderList { get; }
        }

        public record InvalidExamGrades: IOrders
        {
            internal InvalidExamGrades(IReadOnlyCollection<UnvalidatedOrders> orderList, string reason)
            {
                OrderList = orderList;
                Reason = reason;
            }

            public IReadOnlyCollection<UnvalidatedOrders> OrderList { get; }
            public string Reason { get; }
        }

        public record ValidatedOrders : IOrders
        {
            internal ValidatedOrders(IReadOnlyCollection<ValidatedOrders> orderList)
            {
                OrderList = orderList;
            }

            public IReadOnlyCollection<ValidatedOrders> OrderList { get; }
        }

        public record CalculatedOrders : IOrders
        {
            internal CalculatedOrders(IReadOnlyCollection<CalculatedOrders> orderList)
            {
                OrderList = orderList;
            }

            public IReadOnlyCollection<CalculatedOrders> OrderList { get; }
        }

        public record PublishedOrders : IOrders
        {
            internal PublishedOrders(IReadOnlyCollection<CalculatedOrders> gradesList, string csv, DateTime publishedDate)
            {
                GradeList = gradesList;
                PublishedDate = publishedDate;
                Csv = csv;
            }

            public IReadOnlyCollection<CalculatedOrders> GradeList { get; }
            public DateTime PublishedDate { get; }
            public string Csv { get; }
        }
    }
}