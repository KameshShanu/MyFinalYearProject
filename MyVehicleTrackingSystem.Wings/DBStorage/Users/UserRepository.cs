namespace DBStorage.Users
{
    using Common;
    using Domain.Roles;
    using Domain.Users;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using IdentityConfigurations;
    using Domain.DTO;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security.DataProtection;
    using Microsoft.AspNet.Identity.Owin;

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(WingsContext context)
            : base(context)
        {
        }

        public bool IsUserExists(string UserEmail)
        {
            return !Context.User.Any(x => x.Email == UserEmail && x.IsDeleted != true);
        }

        public IEnumerable<User> RetrieveAllUsers()
        {
            return Context.Set<User>();
        }
        public User RetrieveByKey(string id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var applicationUser = context.Users.Where(r => r.Id == id).FirstOrDefault();
                UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(context);
                UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(store);
                string roleName = UserManager.GetRoles(id).FirstOrDefault();

                User user = new User();
                user.IdentityUserId = applicationUser.Id;
                user.FirstName = applicationUser.FirstName;
                user.LastName = applicationUser.LastName;
                user.Email = applicationUser.Email;
                user.ContactNumber = applicationUser.PhoneNumber;
                user.Role = roleName;

                return user;
            }
        }
        public User RetrieveUserByEmail(string UserEmail)
        {
            return Context.Set<User>().Where(u => u.Email == UserEmail && u.IsDeleted == false).SingleOrDefault();
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return Context.Set<Role>();
        }

        public void UpdateUser(string id, User user)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(context);
                UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(store);
                var currentUser = UserManager.FindById(id);
                currentUser.FirstName = user.FirstName;
                currentUser.LastName = user.LastName;
                currentUser.Email = user.Email;
                currentUser.PhoneNumber = user.ContactNumber;
                UserManager.Update(currentUser);

                var currerntRole = UserManager.GetRoles(id).FirstOrDefault();
                if (currerntRole != user.Role)
                {
                    UserManager.RemoveFromRole(id, currerntRole);
                    UserManager.AddToRole(id, user.Role);
                }

                if (!String.IsNullOrEmpty(user.Password))
                {
                    var provider = new DpapiDataProtectionProvider("MyVehicleTracker");
                    UserManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(provider.Create("PasswordResetByAdmin"));
                    var code = UserManager.GeneratePasswordResetToken(id);
                    var result = UserManager.ResetPassword(id, code, user.Password);
                }                
            }
        }

        public void DeleteMultipleUsers(IEnumerable<string> usersToDelete)
        {            
            using (ApplicationDbContext appDBcontext = new ApplicationDbContext())
            {
                UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(appDBcontext);
                UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(store);
                foreach (var userId in usersToDelete)
                {
                    var user = UserManager.FindById(userId);
                    var logins = user.Logins;
                    var rolesForUser = UserManager.GetRoles(userId);

                    using (var transaction = appDBcontext.Database.BeginTransaction())
                    {
                        foreach (var login in logins.ToList())
                        {
                            UserManager.RemoveLogin(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                        }

                        if (rolesForUser.Count() > 0)
                        {
                            foreach (var item in rolesForUser.ToList())
                            {
                                // item should be the name of the role
                                var result = UserManager.RemoveFromRole(user.Id, item);
                            }
                        }
                        UserManager.Delete(user);
                        transaction.Commit();
                    }
                }
            }
        }

        public void SaveUser(User user)
        {
            Save(user);
        }

        public void DeleteUser(int userId)
        {
            User user = Retrieve(u => u.UserId == userId).FirstOrDefault();
            Delete(user);
        }

        public IEnumerable<UserDto> RetrieveAllUsersWithRole()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var allUsers = context.Users.ToList();
                var allRoles = context.Roles.ToList();

                return allUsers.Select(u => new UserDto { IdentityUserId = u.Id ,FirstName = u.FirstName, LastName = u.LastName, ContactNumber = u.PhoneNumber, Email = u.Email, Role = string.Join(",", allRoles.Where(role => role.Users.Any(user => user.UserId == u.Id)).Select(r => r.Name)) }).ToList();
            }
        }
    }
}
