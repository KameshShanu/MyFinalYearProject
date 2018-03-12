namespace Domain.Users
{
    using Domin.Common;
    using DTO;
    using System.Collections.Generic;

    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> RetrieveAllUsers();
        User RetrieveByKey(string id);
        IEnumerable<UserDto> RetrieveAllUsersWithRole();
        User RetrieveUserByEmail(string UserEmail);
        void UpdateUser(string id, User user);
        bool IsUserExists(string UserEmail);
        void DeleteMultipleUsers(IEnumerable<string> usersToDelete);
        void SaveUser(User user);
        void DeleteUser(int userId);
    }
}
