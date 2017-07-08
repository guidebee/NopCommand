
namespace NopCommand.Domain.Orders
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class GiftCardExtensions
    {
        /// <summary>
        /// Gets a gift card remaining amount
        /// </summary>
        /// <returns>Gift card remaining amount</returns>
        public static decimal GetGiftCardRemainingAmount(this GiftCard giftCard)
        {
            var result = giftCard.Amount;

            foreach (var gcuh in giftCard.GiftCardUsageHistory)
                result -= gcuh.UsedValue;

            if (result < decimal.Zero)
                result = decimal.Zero;

            return result;
        }

        /// <summary>
        /// Is gift card valid
        /// </summary>
        /// <param name="giftCard">Gift card</param>
        /// <returns>Result</returns>
        public static bool IsGiftCardValid(this GiftCard giftCard)
        {
            if (!giftCard.IsGiftCardActivated)
                return false;

            var remainingAmount = giftCard.GetGiftCardRemainingAmount();
            if (remainingAmount > decimal.Zero)
                return true;

            return false;
        }
    }
}
