using System.Collections.Generic;
using Common;
using DAL;
using PL;

namespace BLL
{
    public class DBProvider : IMemory
    {
        public bool AddUser(Users user)
        {
            try
            {
                return DataBaseUserAndReward.AddUser(user);
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                return DataBaseUserAndReward.DeleteUser(id);
            }
            catch
            {
                return false;
            }
        }

        public SortableList<Rewards> GetRewards()
        {
            try
            {
                return new SortableList<Rewards>(DataBaseUserAndReward.GetRewards());
            }
            catch
            {
                return null;
            }
        }

        public SortableList<Users> GetUsers()
        {
            try
            {
                var rewards = new SortableList<Users>(DataBaseUserAndReward.GetUsers());
                return rewards;
            }
            catch
            {
                return null;
            }
        }

        public SortableList<Rewards> GetUserRewardsByID(int id)
        {
            try
            {
                return new SortableList<Rewards>(DataBaseUserAndReward.GetRewardsByID(id));
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateUser(Users user)
        {
            try
            {
                return DataBaseUserAndReward.UpdateUser(user);
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateReward(Rewards reward)
        {
            try
            {
                return DataBaseUserAndReward.UpdateReward(reward);
            }
            catch
            {
                return false;
            }
        }

        public bool AddReward(Rewards reward)
        {
            try
            {
                return DataBaseUserAndReward.AddReward(reward);
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteReward(int id)
        {
            try
            {
                return DataBaseUserAndReward.DeleteReward(id);
            }
            catch
            {
                return false;
            }
        }

        public bool AddRewardToUser(int id, IEnumerable<int> rewardIds)
        {
            try
            {
                return DataBaseUserAndReward.AddRewardToUser(id, rewardIds);
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteRewardFromUser(int id, int rewardId)
        {
            try
            {
                return DataBaseUserAndReward.DeleteRewardFromUser(id, rewardId);
            }
            catch
            {
                return false;
            }
        }
    }
}
