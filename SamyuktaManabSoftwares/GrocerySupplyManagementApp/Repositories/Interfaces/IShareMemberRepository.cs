using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IShareMemberRepository
    {
        ShareMember GetShareMember(long id);

        ShareMember AddShareMember(ShareMember shareMember);

        ShareMember UpdateShareMember(long id, ShareMember shareMember);

        bool DeleteShareMember(long id);
    }
}
