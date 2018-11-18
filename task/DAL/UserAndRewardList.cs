using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class UserAndRewardList
    { 
        private List<Users> users = new List<Users>();

        public bool AddUser()
        {
            throw new NotImplementedException();
        }

        public List<Users> GetUsers()
        {
            return users;
        }
    }
}
