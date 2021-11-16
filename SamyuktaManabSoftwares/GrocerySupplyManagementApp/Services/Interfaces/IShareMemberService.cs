using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IShareMemberService
    {
        IEnumerable<ShareMemberView> GetShareMembers();
        ShareMember GetShareMember(long id);
        IEnumerable<ShareMemberTransactionView> GetShareMemberTransactions(ShareMemberTransactionFilter shareMemberTransactionFilter);
        bool IsShareMemberExist(string shareMemberId);

        ShareMember AddShareMember(ShareMember shareMember);

        ShareMember UpdateShareMember(long id, ShareMember shareMember);

        bool DeleteShareMember(long id);
    }
}
