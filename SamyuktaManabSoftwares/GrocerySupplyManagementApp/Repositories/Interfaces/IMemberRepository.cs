using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetMembers();
        Member GetMember(string memberId);
        int GetLastMemberId();

        Member AddMember(Member member);

        Member UpdateMember(string memberId, Member member);

        bool DeleteMember(string memberId);
    }
}
