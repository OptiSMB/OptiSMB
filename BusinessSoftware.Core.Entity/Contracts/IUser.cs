namespace BusinessSoftware.Core.Entity.Contracts
{
    public interface IUser
    {
        public bool IsAdmin {  get; }
        public List<Permission> Permissions { get; }
        public string UserName { get; }
        public string Password { get; }
    }
}
