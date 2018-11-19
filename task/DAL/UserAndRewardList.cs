using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserAndRewardList
    { 
        class UsersAndRewards
        {
            public int UserId;
            public int RewardId;
        }

        private static int UserId;
        private static int RewardId;
        private static List<UsersAndRewards> usersAndRewards = new List<UsersAndRewards>();
        private static List<Users> users = new List<Users>();
        private static List<Rewards> rewards = new List<Rewards>();

        public static bool DeleteRewardFromUser(int id, int rewardId)
        {
            return usersAndRewards.Remove(usersAndRewards.Find(x => x.UserId == id && x.RewardId == rewardId));
        }

        public static bool AddRewardToUser(int id, IEnumerable<int> rewardIds)
        {
            foreach (int i in rewardIds)
            {
                if (rewards.Find(x => x.ID == i) == null)
                {
                    return false;
                }
                if (usersAndRewards.Find(x => x.UserId == id && x.RewardId == i) != null)
                {
                    return false;
                }
            }
            foreach (int i in rewardIds)
            {
                usersAndRewards.Add(new UsersAndRewards() { UserId = id, RewardId = i });
            }
            return true;
        }

        public static bool DeleteReward(int id)
        {
            rewards.Remove(rewards.Find(x => x.ID == id));
            return true;
        }

        public static bool AddReward(Rewards reward)
        {
            rewards.Add(new Rewards()
            {
                ID = RewardId++,
                Title = reward.Title,
                Decription = reward.Decription
            });
            return true;
        }

        public static bool UpdateReward(Rewards reward)
        {
            var _reward = rewards.Find(x => x.ID == reward.ID);
            _reward.Title = reward.Title;
            _reward.Decription = reward.Decription;
            return true;
        }

        public static bool UpdateUser(Users user)
        {
            var _user = users.Find(x => x.ID == user.ID);
            _user.FirstName = user.FirstName;
            _user.LastName = user.LastName;
            _user.Birthday = user.Birthday;
            return true;
        }

        public static bool AddUser(Users user)
        {
            users.Add(new Users()
            {
                ID = UserId++,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birthday = user.Birthday
            });
            return true;
        }

        public static bool DeleteUser(int id)
        {
            users.Remove(users.Find(x => x.ID == id));
            return true;
        }

        public static List<Rewards> GetRewards()
        {
            return rewards;
        }

        public static List<Rewards> GetRewardsByID(int id)
        {
            var _rewards = usersAndRewards.Join(rewards,
                p => p.RewardId,
                t => t.ID,
                (p, t) => new Rewards() { ID = p.RewardId, Title = t.Title, Decription = t.Decription });
            return _rewards.ToList();
        }

        public static List<Users> GetUsers()
        {
            return users;
        }
    }
}
