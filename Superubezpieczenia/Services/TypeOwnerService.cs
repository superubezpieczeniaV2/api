using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Repositories;
using Superubezpieczenia.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Services
{
    public class TypeOwnerService : ITypeOwnerService
    {
        public readonly ITypeOwnerRepository _ownerRepository;
        public TypeOwnerService(ITypeOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public void AddTypeOwner(TypeOwner typeOwner)
        {
            _ownerRepository.AddTypeOwner(typeOwner);
        }

        public Task<IEnumerable<TypeOwner>> AllTypeOwner()
        {
            return _ownerRepository.AllTypeOwner();
        }

        public void DeleteTypeOwner(TypeOwner typeOwner)
        {
            _ownerRepository.DeleteTypeOwner(typeOwner);
        }

        public TypeOwner FindById(int id)
        {
            return _ownerRepository.FindById(id);
        }

        public bool SaveChanges()
        {
            return _ownerRepository.SaveChanges();
        }

        public void UpdateTypeOwner(TypeOwner typeOwner)
        {
            _ownerRepository.UpdateTypeOwner(typeOwner);
        }
    }
}
