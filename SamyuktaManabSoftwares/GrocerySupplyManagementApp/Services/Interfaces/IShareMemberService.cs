using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IShareMemberService
    {
        IEnumerable<ShareMember> GetShareMembers();
        ShareMember GetShareMember(long id);

        ShareMember AddShareMember(ShareMember shareMember);

        ShareMember UpdateShareMember(long id, ShareMember shareMember);

        bool DeleteShareMember(long id);
    }
}
