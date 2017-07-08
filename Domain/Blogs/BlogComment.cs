using System;
using NopCommand.Domain.Customers;
using NopCommand.Domain.Stores;

namespace NopCommand.Domain.Blogs
{
    /// <summary>
    /// Represents a blog comment
    /// </summary>
    public partial class BlogComment : BaseEntity
    {
        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the comment text
        /// </summary>
        public string CommentText { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the comment is approved
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        /// Gets or sets the store identifier
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// Gets or sets the blog post identifier
        /// </summary>
        public int BlogPostId { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the customer
        /// </summary>
        public  Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the blog post
        /// </summary>
        public  BlogPost BlogPost { get; set; }

        /// <summary>
        /// Gets or sets the store
        /// </summary>
        public  Store Store { get; set; }
    }
}