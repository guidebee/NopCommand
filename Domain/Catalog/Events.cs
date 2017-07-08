namespace NopCommand.Domain.Catalog
{
    /// <summary>
    /// Product review approved event
    /// </summary>
    public class ProductReviewApprovedEvent
    {
        public ProductReviewApprovedEvent(ProductReview productReview)
        {
            ProductReview = productReview;
        }

        /// <summary>
        /// Product review
        /// </summary>
        public ProductReview ProductReview { get; private set; }
    }
}