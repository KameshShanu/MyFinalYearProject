namespace Application.Users
{
    using Domain.DTO;
    using Domain.Roles;
    using Domain.Users;
    using System.Collections.Generic;

    public interface IUserService
    {
        User GetById(int id);
        User GetById(string id);
        User GetUserByEmail(string UserEmail);
        IEnumerable<User> GetAllUsers();
        IEnumerable<UserDto> RetrieveAllUsersWithRole();
        void SaveUser(User user);
        void UpdateUser(string id, User user);
        void DeleteUser(int userId);
        bool IsUserExists(string UserEmail);
        void DeleteMultipleUsers(IEnumerable<string> usersToDelete);
    }
}
