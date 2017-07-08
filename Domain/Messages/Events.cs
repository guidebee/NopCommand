using System.Collections.Generic;

namespace NopCommand.Domain.Messages
{
    public class EmailSubscribedEvent
    {
        private readonly NewsLetterSubscription _subscription;

        public EmailSubscribedEvent(NewsLetterSubscription subscription)
        {
            _subscription = subscription;
        }

        public NewsLetterSubscription Subscription
        {
            get { return _subscription; }
        }

        public bool Equals(EmailSubscribedEvent other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._subscription, _subscription);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(EmailSubscribedEvent)) return false;
            return Equals((EmailSubscribedEvent)obj);
        }

        public override int GetHashCode()
        {
            return (_subscription != null ? _subscription.GetHashCode() : 0);
        }
    }

    public class EmailUnsubscribedEvent
    {
        private readonly NewsLetterSubscription _subscription;

        public EmailUnsubscribedEvent(NewsLetterSubscription subscription)
        {
            _subscription = subscription;
        }

        public NewsLetterSubscription Subscription
        {
            get { return _subscription; }
        }

        public bool Equals(EmailUnsubscribedEvent other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._subscription, _subscription);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(EmailUnsubscribedEvent)) return false;
            return Equals((EmailUnsubscribedEvent)obj);
        }

        public override int GetHashCode()
        {
            return (_subscription != null ? _subscription.GetHashCode() : 0);
        }
    }

    /// <summary>
    /// A container for tokens that are added.
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <typeparam name="U"></typeparam>
    public class EntityTokensAddedEvent<T, U> where T : BaseEntity
    {
        private readonly T _entity;
        private readonly IList<U> _tokens;

        public EntityTokensAddedEvent(T entity, IList<U> tokens)
        {
            _entity = entity;
            _tokens = tokens;
        }

        public T Entity { get { return _entity; } }
        public IList<U> Tokens { get { return _tokens; } }
    }

    /// <summary>
    /// A container for tokens that are added.
    /// </summary>
    /// <typeparam name="U"></typeparam>
    public class MessageTokensAddedEvent<U>
    {
        private readonly MessageTemplate _message;
        private readonly IList<U> _tokens;

        public MessageTokensAddedEvent(MessageTemplate message, IList<U> tokens)
        {
            _message = message;
            _tokens = tokens;
        }

        public MessageTemplate Message { get { return _message; } }
        public IList<U> Tokens { get { return _tokens; } }
    }

    public class AdditionTokensAddedEvent
    {
        private readonly IList<string> _tokens;

        public AdditionTokensAddedEvent()
        {
            _tokens=new List<string>();
        }

        public void AddTokens(params string[] additionTokens)
        {
            foreach (var additionToken in additionTokens)
            {
                _tokens.Add(additionToken);
            }
        }

        public IList<string> AdditionTokens { get { return _tokens; } }
    }

    public class CampaignAdditionTokensAddedEvent : AdditionTokensAddedEvent
    {
    }
}