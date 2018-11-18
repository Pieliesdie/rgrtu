using Common;

namespace PL
{
    public interface IMemory
    {
        bool AddUser();
        SortableList<Users> GetUsers();
        SortableList<Rewards> GetUserRewardsByID(int id);
        SortableList<Rewards> GetRewards();
        bool DeleteUser(int id);
    }
}
