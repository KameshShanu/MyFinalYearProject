namespace Application.Users
{
    using DBStorage.Users;
    using Domain.Roles;
    using Domain.Users;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using Domain.DTO;

    public class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _repository.RetrieveAllUsers();
        }

        public User GetById(int id)
        {
            return _repository.RetrieveByKey(id);
        }

        public User GetById(string id)
        {
            return _repository.RetrieveByKey(id);
        }
        public User GetUserByEmail(string UserEmail)
        {
            return _repository.RetrieveUserByEmail(UserEmail);
        }

        public bool IsUserExists(string UserEmail)
        {
            return _repository.IsUserExists(UserEmail);
        }

        public void SaveUser(User user)
        {
            _repository.SaveUser(user);
        }

        public void UpdateUser(string id, User user)
        {
            _repository.UpdateUser(id, user);
        }

        public void DeleteUser(int userId)
        {
            _repository.DeleteUser(userId);
        }

        public void DeleteMultipleUsers(IEnumerable<string> usersToDelete)
        {
            _repository.DeleteMultipleUsers(usersToDelete);
        }

        public IEnumerable<UserDto> RetrieveAllUsersWithRole()
        {
            return _repository.RetrieveAllUsersWithRole();
        }
    }
}
