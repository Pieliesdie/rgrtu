using Common;
using DAL;
using System;
using PL;
using System.Windows.Forms;

namespace BLL
{
    public class DBProvider : IMemory
    {
        public bool AddUser()
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int id)
        {
            return DataBaseUserAndReward.DeleteUser(id);
        }
        public SortableList<Rewards> GetRewards()
        {
            return new SortableList<Rewards>(DataBaseUserAndReward.GetRewards());
        }

        public SortableList<Users> GetUsers()
        {
            var rewards = new SortableList<Users>(DataBaseUserAndReward.GetUsers());
            return rewards;
        }

        public SortableList<Rewards> GetUserRewardsByID(int id)
        {
            return new SortableList<Rewards>(DataBaseUserAndReward.GetRewardsByID(id));
        }
    }
}
