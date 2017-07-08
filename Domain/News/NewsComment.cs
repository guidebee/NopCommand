using System;
using NopCommand.Domain.Customers;
using NopCommand.Domain.Stores;

namespace NopCommand.Domain.News
{
    /// <summary>
    /// Represents a news comment
    /// </summary>
    public partial class NewsComment : BaseEntity
    {
        /// <summary>
        /// Gets or sets the comment title
        /// </summary>
        public string CommentTitle { get; set; }

        /// <summary>
        /// Gets or sets the comment text
        /// </summary>
        public string CommentText { get; set; }

        /// <summary>
        /// Gets or sets the news item identifier
        /// </summary>
        public int NewsItemId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the comment is approved
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        /// Gets or sets the store identifier
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the customer
        /// </summary>
        public  Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the news item
        /// </summary>
        public  NewsItem NewsItem { get; set; }

        /// <summary>
        /// Gets or sets the store
        /// </summary>
        public  Store Store { get; set; }
    }
}