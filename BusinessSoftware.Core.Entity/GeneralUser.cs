using BusinessSoftware.Core.Entity.Contracts;

namespace BusinessSoftware.Core.Entity
{
    public class GeneralUser : IUser
    {
        public bool IsAdmin
		{
			get { return false; }
		}

        public List<Permission> Permissions => new();

        public string UserName => throw new NotImplementedException();

        public string Password => throw new NotImplementedException();
    }
}
