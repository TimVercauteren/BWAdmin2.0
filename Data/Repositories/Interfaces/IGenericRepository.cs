using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories.Interfaces
{
    public interface IRepository
    {
        Task DeleteEntity<TEntity>(Guid id) where TEntity : EntityBase, IDeletable;
        Task<TToAdd> AddEntity<TToAdd>(TToAdd entity) where TToAdd : EntityBase;
        Task<TUpdateable> UpdateEntity<TUpdateable>(Guid id, TUpdateable entity) where TUpdateable : EntityBase;
        Task<TGettable> GetEntity<TGettable>(Guid id) where TGettable : EntityBase;
    }
}
