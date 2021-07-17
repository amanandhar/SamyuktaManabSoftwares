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

        public Member AddMember(Member member)
        {
            member.Counter = _memberRepository.GetLastMemberId() + 1;
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

        public string GetNewMemberId()
        {
            string memberId;
            var id = (_memberRepository.GetLastMemberId() + 1).ToString();
            if (id.Length == 1)
            {
                memberId = "000" + id;
            }
            else if (id.Length == 2)
            {
                memberId = "00" + id;
            }
            else if (id.Length == 3)
            {
                memberId = "0" + id;
            }
            else
            {
                memberId = id;
            }

            return "M-" + memberId;
        }
    }
}
