﻿using MedPro.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedPro.CORE.IRepositories
{
    public interface IUserRepository
    {
        Task DeleteUserAsync(string userId);

    }
}
