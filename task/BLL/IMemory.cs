using Common;
using System.Collections.Generic;

namespace PL
{
    public interface IMemory
    {
        bool AddUser(Users user);
        bool UpdateUser(Users user);
        bool UpdateReward(Rewards reward);
        bool AddReward(Rewards reward);
        bool DeleteReward(int id);
        bool AddRewardToUser(int id, IEnumerable<int> rewardIds);
        bool DeleteRewardFromUser(int id, int rewardId);
        SortableList<Users> GetUsers();
        SortableList<Rewards> GetUserRewardsByID(int id);
        SortableList<Rewards> GetRewards();
        bool DeleteUser(int id);
    }
}
