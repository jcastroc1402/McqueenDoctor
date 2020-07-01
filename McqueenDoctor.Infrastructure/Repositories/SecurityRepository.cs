using McqueenDoctor.Core.Entities;
using McqueenDoctor.Core.Interfaces;
using McqueenDoctor.Infrastructure.Data;
using McqueenDoctor.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace McqueenDoctor.Infrastructure.Repositories
{
    public class SecurityRepository : BaseRepository<Security>, ISecurityRepository
    {
        public SecurityRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await Entities.FirstOrDefaultAsync(x => x.User == login.Username);
        }
    }
}
