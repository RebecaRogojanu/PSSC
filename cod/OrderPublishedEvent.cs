using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    [AsChoice]
    public static partial class OrderPublishEvent
    {
        public interface IOrderPublishedEvent { }

        public record OrderPublishedScucceededEvent : IOrderPublishedEvent 
        {
            public string Csv{ get;}
            public DateTime PublishedDate { get; }

            internal OrderPublishedScucceededEvent(string csv, DateTime publishedDate)
            {
                Csv = csv;
                PublishedDate = publishedDate;
            }
        }

        public record OrderPublishedFailedEvent : IOrderPublishedEvent 
        {
            public string Reason { get; }

            internal OrderPublishedFailedEvent(string reason)
            {
                Reason = reason;
            }
        }
    }
}