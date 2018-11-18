using Common;
using PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MemoryProvider : IMemory
    {
        public bool AddUser()
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public SortableList<Rewards> GetRewards()
        {
            throw new NotImplementedException();
        }

        public SortableList<Rewards> GetUserRewardsByID(int id)
        {
            throw new NotImplementedException();
        }

        public SortableList<Users> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
