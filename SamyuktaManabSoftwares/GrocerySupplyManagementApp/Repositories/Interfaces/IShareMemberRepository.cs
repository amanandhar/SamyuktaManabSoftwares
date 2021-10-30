using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IShareMemberRepository
    {
        IEnumerable<ShareMemberView> GetShareMembers();
        ShareMember GetShareMember(long id);
        IEnumerable<ShareMemberTransactionView> GetShareMemberTransactions(ShareMemberTransactionFilter shareMemberTransactionFilter);

        ShareMember AddShareMember(ShareMember shareMember);

        ShareMember UpdateShareMember(long id, ShareMember shareMember);

        bool DeleteShareMember(long id);
    }
}
