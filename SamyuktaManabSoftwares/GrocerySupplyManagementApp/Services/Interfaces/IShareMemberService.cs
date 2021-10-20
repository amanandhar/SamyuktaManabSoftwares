using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IShareMemberService
    {
        ShareMember GetShareMember(long id);

        ShareMember AddShareMember(ShareMember shareMember);

        ShareMember UpdateShareMember(long id, ShareMember shareMember);

        bool DeleteShareMember(long id);
    }
}
