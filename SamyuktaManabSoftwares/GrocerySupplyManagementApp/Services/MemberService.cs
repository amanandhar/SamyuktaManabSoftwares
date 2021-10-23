using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public IEnumerable<Member> GetMembers()
        {
            return _memberRepository.GetMembers();
        }

        public Member GetMember(string memberId)
        {
            return _memberRepository.GetMember(memberId);
        }

        public bool IsMemberExist(string memberId)
        {
            return _memberRepository.IsMemberExist(memberId);
        }

        public Member AddMember(Member member)
        {
            return _memberRepository.AddMember(member);
        }

        public Member UpdateMember(string memberId, Member member)
        {
            return _memberRepository.UpdateMember(memberId, member);
        }

        public bool DeleteMember(string memberId)
        {
            return _memberRepository.DeleteMember(memberId);
        }
    }
}
