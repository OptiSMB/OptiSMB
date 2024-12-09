using BusinessSoftware.Core.Entity.Contracts;

namespace BusinessSoftware.Core.Entity
{
    public class Organization
    {
        public string OrganizationName { get; set; }
        public string OrganizationGuid { get; set; }
        public List<IUser> Users { get; set; }
    }
}
