using BusinessSoftware.Core.Entity.Contracts;

namespace BusinessSoftware.Core.Entity
{
    public class Admin : IUser
    {
		public bool IsAdmin
		{
			get { return true; }
		}

        public List<Permission> Permissions => new();

        public string UserName => throw new NotImplementedException();

        public string Password => throw new NotImplementedException();
    }
}
