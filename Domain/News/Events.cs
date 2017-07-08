namespace NopCommand.Domain.News
{
    /// <summary>
    /// News comment approved event
    /// </summary>
    public class NewsCommentApprovedEvent
    {
        public NewsCommentApprovedEvent(NewsComment newsComment)
        {
            NewsComment = newsComment;
        }

        /// <summary>
        /// News comment
        /// </summary>
        public NewsComment NewsComment { get; private set; }
    }
}