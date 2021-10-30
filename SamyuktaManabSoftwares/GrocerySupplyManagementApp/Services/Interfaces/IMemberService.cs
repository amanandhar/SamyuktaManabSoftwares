using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IMemberService
    {
        IEnumerable<Member> GetMembers();
        Member GetMember(string memberId);
        bool IsMemberExist(string memberId);

        Member AddMember(Member member);
        UserTransaction AddMemberReceipt(UserTransaction userTransaction, BankTransaction bankTransaction, string username);

        Member UpdateMember(string memberId, Member member);

        bool DeleteMember(string memberId);
        bool DeleteMemberReceipt(long id);
    }
}
