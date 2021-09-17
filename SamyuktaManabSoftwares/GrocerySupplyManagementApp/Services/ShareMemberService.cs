using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class ShareMemberService : IShareMemberService
    {
        private readonly IShareMemberRepository _shareMemberRepository;

        public ShareMemberService(IShareMemberRepository shareMemberRepository)
        {
            _shareMemberRepository = shareMemberRepository;
        }

        public ShareMember GetShareMember(long id)
        {
            return _shareMemberRepository.GetShareMember(id);
        }

        public IEnumerable<ShareMember> GetShareMembers()
        {
            return _shareMemberRepository.GetShareMembers();
        }

        public ShareMember AddShareMember(ShareMember shareMember)
        {
            return _shareMemberRepository.AddShareMember(shareMember);
        }

        public ShareMember UpdateShareMember(long id, ShareMember shareMember)
        {
            return _shareMemberRepository.UpdateShareMember(id, shareMember);
        }

        public bool DeleteShareMember(long id)
        {
            return _shareMemberRepository.DeleteShareMember(id);
        }
    }
}
