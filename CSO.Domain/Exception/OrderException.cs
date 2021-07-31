using System;

namespace OrderService.Domain.Exceptions
{
    public class OrderException : CustomException
    {
        public OrderException(string message) : base(message)
        {

        }
    }
}
