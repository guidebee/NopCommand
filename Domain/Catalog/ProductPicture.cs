using NopCommand.Domain.Media;

namespace NopCommand.Domain.Catalog
{
    /// <summary>
    /// Represents a product picture mapping
    /// </summary>
    public partial class ProductPicture : BaseEntity
    {
        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the picture identifier
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }
        
        /// <summary>
        /// Gets the picture
        /// </summary>
        public  Picture Picture { get; set; }

        /// <summary>
        /// Gets the product
        /// </summary>
        public  Product Product { get; set; }
    }

}
