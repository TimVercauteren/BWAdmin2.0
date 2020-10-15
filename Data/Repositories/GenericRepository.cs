using System;
using System.Threading.Tasks;
using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories.Interfaces;
using Models.Exceptions;

namespace Data.Repositories
{
    public abstract class Repository<T> : IRepository where T : EntityBase 
    {
        protected readonly BwAdminContext Context;
        protected readonly IMapper Mapper;

        protected Repository(BwAdminContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public virtual async Task<TUpdateable> UpdateEntity<TUpdateable>(Guid id, TUpdateable entity) where TUpdateable : EntityBase
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = id;
            }
            Context.Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TGettable> GetEntity<TGettable>(Guid id) where TGettable : EntityBase
        {
            var entity = await Context.FindAsync<TGettable>(id);

            if (entity == null) throw new NotFoundException(id.ToString());

            return entity;
        }

        public virtual async Task<TToAdd> AddEntity<TToAdd>(TToAdd entity) where TToAdd : EntityBase
        {
            if (entity.Id == Guid.Empty)
            {
                var id = Guid.NewGuid();
                entity.Id = id;
            }

            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteEntity<TDeleteAbleEntity>(Guid id) where TDeleteAbleEntity : EntityBase, IDeletable
        {
            var entity = await Context.FindAsync<TDeleteAbleEntity>(id);

            if (entity == null) throw new NotFoundException(id.ToString());
            entity.IsDeleted = true;

            Context.Update(entity);
            await Context.SaveChangesAsync();
        }

    }
}
