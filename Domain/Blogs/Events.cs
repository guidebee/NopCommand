namespace NopCommand.Domain.Blogs
{
    /// <summary>
    /// Blog post comment approved event
    /// </summary>
    public class BlogCommentApprovedEvent
    {
        public BlogCommentApprovedEvent(BlogComment blogComment)
        {
            BlogComment = blogComment;
        }

        /// <summary>
        /// Blog post comment
        /// </summary>
        public BlogComment BlogComment { get; private set; }
    }
}