using McqueenDoctor.Core.Entities;
using McqueenDoctor.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace McqueenDoctor.Core.Services
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUnitOfWork UnitOfWork;

        public UserInfoService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserInfo>> GetUsersInfo()
        {
            return await UnitOfWork.UserInfoRepository.GetAll();
        }

        public async Task InsertUserInfo(UserInfo userInfo)
        {
            await UnitOfWork.UserInfoRepository.Add(userInfo);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
