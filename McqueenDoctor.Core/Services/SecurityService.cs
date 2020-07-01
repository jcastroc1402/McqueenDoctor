using McqueenDoctor.Core.Entities;
using McqueenDoctor.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace McqueenDoctor.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork UnitOfWork;

        public SecurityService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<Security> GetLoginByCredentials(UserLogin userLogin)
        {
            return await UnitOfWork.SecurityRepository.GetLoginByCredentials(userLogin);
        }

        public async Task RegisterUser(Security security)
        {
            await UnitOfWork.SecurityRepository.Add(security);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
