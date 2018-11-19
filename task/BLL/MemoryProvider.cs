using System.Collections.Generic;
using Common;
using DAL;
using PL;

namespace BLL
{
    public class MemoryProvider : IMemory
    {
        public bool AddUser(Users user)
        {
            return UserAndRewardList.AddUser(user);
        }

        public bool DeleteUser(int id)
        {
            return UserAndRewardList.DeleteUser(id);
        }

        public SortableList<Rewards> GetRewards()
        {
            return new SortableList<Rewards>(UserAndRewardList.GetRewards());
        }

        public SortableList<Users> GetUsers()
        {
            var rewards = new SortableList<Users>(UserAndRewardList.GetUsers());
            return rewards;
        }

        public SortableList<Rewards> GetUserRewardsByID(int id)
        {
            return new SortableList<Rewards>(UserAndRewardList.GetRewardsByID(id));
        }

        public bool UpdateUser(Users user)
        {
            return UserAndRewardList.UpdateUser(user);
        }

        public bool UpdateReward(Rewards reward)
        {
            return UserAndRewardList.UpdateReward(reward);
        }

        public bool AddReward(Rewards reward)
        {
            return UserAndRewardList.AddReward(reward);
        }

        public bool DeleteReward(int id)
        {
            return UserAndRewardList.DeleteReward(id);
        }

        public bool AddRewardToUser(int id, IEnumerable<int> rewardIds)
        {
            return UserAndRewardList.AddRewardToUser(id, rewardIds);
        }

        public bool DeleteRewardFromUser(int id, int rewardId)
        {
            return UserAndRewardList.DeleteRewardFromUser(id, rewardId);
        }
    }
}
