﻿using Superubezpieczenia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Services
{
    public interface ITypeOwnerService
    {
        Task<IEnumerable<TypeOwner>> AllTypeOwner();
        TypeOwner FindById(int id);
        void AddTypeOwner(TypeOwner typeOwner);
        void DeleteTypeOwner(TypeOwner typeOwner);
        void UpdateTypeOwner(TypeOwner typeOwner);
        bool SaveChanges();
    }
}
