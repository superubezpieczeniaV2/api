﻿using Superubezpieczenia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Services
{
    public interface IPolicyDetailsService
    {
        Task<IEnumerable<PolicyDetails>> AllPolicys();
        Task<IEnumerable<PolicyDetails>> FindByUser(string id);
        void AddPolicyDetails(PolicyDetails policy);
        bool SaveChanges();
        void DeletePolicyDetails(PolicyDetails policy);
    }
}
