using AutoMapper;
using FoodOrderBL.Interface;
using FoodOrderBL.MailHelper;
using FoodOrderBL.PasswordEncypt;
using FoodOrderDL.Models;
using FoodOrderDL.Models.ViewModel;
using FoodOrderDL.Repositories.IRepo;
using FoodOrderDL.Repositories.IServiceRepo;
using System.Data;

namespace FoodOrderBL.ServiceClass
{
    public class ApprovedUserService : IApprovedUser
    {
        private readonly IApprovedUserRepo _userRepo;
        private readonly IMapper _mapper;
        private readonly IMailRepo _mailrepo;

        public ApprovedUserService(IApprovedUserRepo userRepo, IMapper mapper, IMailRepo mailrepo)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _mailrepo = mailrepo;
        }

        public async Task<ApprovedUser> AddApprovedUsers(ApprovedUser approvedUsers)
        {
            string tempPass = _mailrepo.SendMail(approvedUsers.Email);
            approvedUsers.TempPassword = tempPass;
            approvedUsers.UserPassword = PasswordCheck.HashPassword(tempPass);
            var result = await _userRepo.AddApprovedUsers(approvedUsers);
            return result;
        }

        public async Task<string> DeleteUserDetails(int id)
        {
            var userId = await _userRepo.DeleteUserDetails(id);
            if (userId == null)
            {
                return null;
            }
            return "Deleted Successfully";
        }

        public async Task<List<ApprovedUser>> GetAllUserDetails()
        {
            return await _userRepo.GetAllUserDetails();
        }

        public async Task<List<NewArrivalsDTO>> GetNewArrivals()
        {
            var newUser = await _userRepo.GetNewArrivals();
            return _mapper.Map<List<NewArrivalsDTO>>(newUser);
        }

        public async Task<List<ApprovedUser>> GetOnlyUserDetails()
        {
            return await _userRepo.GetOnlyUserDetails();
        }

        public async Task<List<ApprovedUser>> GetOnlyVendorDetails()
        {
            return await _userRepo.GetOnlyVendorDetails();
        }

        public async Task<int> TotalapprovedUser()
        {
            return await _userRepo.TotalapprovedUser();
        }

        public async Task<int> TotalapprovedVendor()
        {
            return await _userRepo.TotalapprovedVendor();
        }

        public async Task<int> TotalpendingUser()
        {
            return await _userRepo.TotalpendingUser();
        }

        public async Task<int> Totalpendingvendor()
        {
            return await _userRepo.Totalpendingvendor();
        }

        public async Task<ApprovedUser> UpdateUserDetails(int id, ApprovedUser user)
        {
            return await _userRepo.UpdateUserDetails(id, user);
        }

        public async Task<LoginDTO> GetUserInfoByEmail(ApprovedUser email)
        {
            var result = await _userRepo.GetUserInfoByEmail(email);

            if (!PasswordCheck.VerifyPassword(email.UserPassword, result.UserPassword))
            {
                throw new Exception("password is incorrect");
            }
            return _mapper.Map<LoginDTO>(result);
        }

        public async Task<ApprovedUser> UpdatePassword(ApprovedUser user)
        {
            user.UserPassword = PasswordCheck.HashPassword(user.UserPassword);
            return await _userRepo.UpdatePassword(user);
        }

        public async Task<string> GetMailById(int id)
        {
            var result =  await _userRepo.GetMailById(id);
            if(result == null)
            {
                return null;
            }
            string email = result.Email.ToString();

            _mailrepo.SendOrderApproveMail(email);

            return "Approved";
        }
    }
}
