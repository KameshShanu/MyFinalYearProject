namespace Domain.Users
{
    using Domin.Common;

    public class User : BaseEntity
    {
        public int UserId
        {
            get;
            protected set;
        }

        public string IdentityUserId
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string PasswordSalt
        {
            get;
            set;
        }

        public int RoleId
        {
            get;
            set;
        }

        public string Role
        {
            get;
            set;
        }

        public string ContactNumber
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }

        public override bool IsTransient()
        {
            return UserId == 0;
        }
    }
}
