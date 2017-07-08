﻿using Nop.Core.Configuration;

namespace NopCommand.Domain.Customers
{
    public class RewardPointsSettings : ISettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether Reward Points Program is enabled
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets a value of Reward Points exchange rate
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the minimum reward points to use
        /// </summary>
        public int MinimumRewardPointsToUse { get; set; }

        /// <summary>
        /// Gets or sets a number of points awarded for registration
        /// </summary>
        public int PointsForRegistration { get; set; }

        /// <summary>
        /// Gets or sets a number of points awarded for purchases (amount in primary store currency)
        /// </summary>
        public decimal PointsForPurchases_Amount { get; set; }

        /// <summary>
        /// Gets or sets a number of points awarded for purchases
        /// </summary>
        public int PointsForPurchases_Points { get; set; }

        /// <summary>
        /// Gets or sets a delay before activation points
        /// </summary>
        public int ActivationDelay { get; set; }

        /// <summary>
        /// Gets or sets the period of activation delay
        /// </summary>
        public int ActivationDelayPeriodId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether "You will earn" message should be displayed
        /// </summary>
        public bool DisplayHowMuchWillBeEarned { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether all reward points are accumulated in one balance for all stores and they can be used in any store. Otherwise, each store has its own rewards points and they can only be used in that store.
        /// </summary>
        public bool PointsAccumulatedForAllStores { get; set; }

        /// <summary>
        /// Gets or sets the page size is for history of reward points on my account page
        /// </summary>
        public int PageSize { get; set; }
    }
}