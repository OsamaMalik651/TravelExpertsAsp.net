using System;
using System.Collections.Generic;

#nullable disable

namespace Travel_Experts__Workshop_4.Domain
{
    public partial class Reward
    {
        public Reward()
        {
            CustomersRewards = new HashSet<CustomersReward>();
        }

        public int RewardId { get; set; }
        public string RwdName { get; set; }
        public string RwdDesc { get; set; }

        public virtual ICollection<CustomersReward> CustomersRewards { get; set; }
    }
}
