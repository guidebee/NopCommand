namespace NopCommand.Domain.Orders
{
    /// <summary>
    /// Order paid event
    /// </summary>
    public class OrderPaidEvent
    {
        public OrderPaidEvent(Order order)
        {
            Order = order;
        }

        /// <summary>
        /// Order
        /// </summary>
        public Order Order { get; private set; }
    }

    /// <summary>
    /// Order placed event
    /// </summary>
    public class OrderPlacedEvent
    {
        public OrderPlacedEvent(Order order)
        {
            Order = order;
        }

        /// <summary>
        /// Order
        /// </summary>
        public Order Order { get; private set; }
    }

    /// <summary>
    /// Order cancelled event
    /// </summary>
    public class OrderCancelledEvent
    {
        public OrderCancelledEvent(Order order)
        {
            Order = order;
        }

        /// <summary>
        /// Order
        /// </summary>
        public Order Order { get; private set; }
    }

    /// <summary>
    /// Order refunded event
    /// </summary>
    public class OrderRefundedEvent
    {
        public OrderRefundedEvent(Order order, decimal amount)
        {
            Order = order;
            Amount = amount;
        }

        /// <summary>
        /// Order
        /// </summary>
        public Order Order { get; private set; }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount { get; private set; }
    }

}