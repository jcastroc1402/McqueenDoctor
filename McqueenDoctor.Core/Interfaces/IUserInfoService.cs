﻿using McqueenDoctor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace McqueenDoctor.Core.Interfaces
{
    public interface IUserInfoService
    {
        Task<IEnumerable<UserInfo>> GetUsersInfo();

        Task InsertUserInfo(UserInfo userInfo);
    }
}
