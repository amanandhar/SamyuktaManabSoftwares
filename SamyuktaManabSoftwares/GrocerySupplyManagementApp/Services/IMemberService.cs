using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public interface IMemberService
    {
        IEnumerable<Member> GetMembers();

        Member GetMember(string memberId);

        Member AddMember(Member member);

        Member UpdateMember(string memberId, Member member);

        bool DeleteMember(string memberId);

        string GetNewMemberId();
    }
}
