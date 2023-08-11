using MedUnify.Inpatient.DAL.Model;
using MedUnify.Inpatient.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace MedUnify.Inpatient.DAL.Repository
{
    public abstract class BaseRepository<TDbModel> : IBaseRepository<TDbModel> where TDbModel : TableAudit
    {
        private DbContext dbContext;

        protected BaseRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual async Task<TDbModel> AddAsync(TDbModel entity)
        {
            entity = await OnBeforeAddAsync(entity);
            await dbContext.Set<TDbModel>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            entity = await GetAsync(entity.ID);
            entity = await OnAfterAddAsync(entity);
            return entity;
        }

        public virtual async Task<TDbModel> OnBeforeAddAsync(TDbModel model)
        {
            return await Task.FromResult(model);
        }

        public virtual async Task<TDbModel> OnAfterAddAsync(TDbModel model)
        {
            return await Task.FromResult(model);
        }

        public async virtual Task<bool> DeleteAsync(long id, string loggedInUser)
        {
            var entity = dbContext.Set<TDbModel>().Find(id);
            entity.IsDeleted = true;
            entity.UpdatedBy = loggedInUser;
            entity.UpdatedAt = DateTime.UtcNow;
            dbContext.Update(entity);
            var status = await dbContext.SaveChangesAsync();
            return status > 0;
        }

        public async virtual Task<bool> RemoveAsync(long id)
        {
            var entity = dbContext.Set<TDbModel>().Find(id);
            dbContext.Set<TDbModel>().Remove(entity);
            var status = await dbContext.SaveChangesAsync();
            return status > 0;
        }

        public async virtual Task<int> RemoveListAsync(List<long> ids)
        {
            var entities = dbContext.Set<TDbModel>().Where(x => ids.Contains(x.ID));
            dbContext.Set<TDbModel>().RemoveRange(entities);
            var status = await dbContext.SaveChangesAsync();
            return status;
        }

        public virtual async Task<TDbModel> GetAsync(long id, bool? basic = null)
        {
            var results = dbContext.Set<TDbModel>().AsQueryable();

            if (basic == null || !basic.Value)
                results = IncludeChain(results);

            var result = await results.AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }

        private IQueryable<TDbModel> ApplySkipAndTake(IQueryable<TDbModel> results, int? skip, int? take)
        {
            if (skip != null)
                results = results.Skip(skip.Value);

            if (take != null)
                results = results.Take(take.Value);

            return results;
        }

        public virtual async Task<List<TDbModel>> GetAllAsync(bool? includeChain = null, int? skip = null, int? take = null)
        {
            var results = dbContext.Set<TDbModel>().AsQueryable();
            results = ApplySkipAndTake(results, skip, take);

            if (includeChain != null && includeChain.Value)
                results = IncludeChain(results);

            var finalResults = await results.AsNoTracking().ToListAsync();
            return finalResults;
        }


        public virtual async Task<List<TDbModel>> GetAllActiveAsync(bool? includeChain = null, int? skip = null, int? take = null)
        {
            var results = dbContext.Set<TDbModel>().Where(x => x.IsActive);

            results = ApplySkipAndTake(results, skip, take);

            if (includeChain != null && includeChain.Value)
                results = IncludeChain(results);

            return await results.AsNoTracking().ToListAsync();
        }


        public virtual async Task<List<TDbModel>> GetAllInActiveAsync(bool? includeChain = null, int? skip = null, int? take = null)
        {
            var results = dbContext.Set<TDbModel>().Where(x => !x.IsActive);

            results = ApplySkipAndTake(results, skip, take);

            if (includeChain != null && includeChain.Value)
                results = IncludeChain(results);

            return await results.AsNoTracking().ToListAsync();
        }


        public virtual async Task<long> GetAllCountAsync()
        {
            var results = dbContext.Set<TDbModel>().AsNoTracking();
            return await results.LongCountAsync();
        }


        public virtual async Task<long> GetAllActiveCountAsync()
        {
            var results = dbContext.Set<TDbModel>().Where(x => x.IsActive);
            return await results.LongCountAsync();
        }


        public virtual async Task<long> GetAllInActiveCountAsync()
        {
            var results = dbContext.Set<TDbModel>().Where(x => !x.IsActive);
            return await results.LongCountAsync();
        }


        public virtual async Task<List<TDbModel>> FetchByIDListAsync(List<long> idList, bool? includeChain = null)
        {
            var results = dbContext.Set<TDbModel>()
                .Where(x => idList.Contains<long>(x.ID));

            if (includeChain != null && includeChain.Value)
                results = IncludeChain(results);

            return await results.ToListAsync();
        }

        public virtual void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public virtual async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public virtual async Task<TDbModel> UpdateAsync(TDbModel entity)
        {
            entity = await OnBeforeUpdateAsync(entity);
            var updateEntity = await GetAsync(entity.ID, true);
            entity.CreatedBy = updateEntity.CreatedBy;
            entity.UpdatedBy = updateEntity.UpdatedBy;
            entity.CreatedAt = updateEntity.CreatedAt;
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
            entity = await GetAsync(entity.ID);
            entity = await OnAfterUpdateAsync(entity);
            return entity;
        }

        public virtual async Task DirectUpdateAsync(TDbModel entity)
        {
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
        }

        public virtual async Task DetachAsync(TDbModel entity)
        {
            dbContext.Entry(entity).State = EntityState.Detached;
            await dbContext.SaveChangesAsync();
        }

        public virtual async Task DetachAllAsync(List<TDbModel> entities)
        {
            foreach (var entity in entities)
            {
                dbContext.Entry(entity).State = EntityState.Detached;
            }
            await dbContext.SaveChangesAsync();
        }


        public async virtual Task<TDbModel> OnBeforeUpdateAsync(TDbModel model)
        {
            return await Task.FromResult(model);
        }


        public async virtual Task<TDbModel> OnAfterUpdateAsync(TDbModel model)
        {
            return await Task.FromResult(model);
        }


        public virtual IQueryable<TDbModel> IncludeChain(IQueryable<TDbModel> chain)
        {
            return chain;
        }


        public virtual IOrderedQueryable<TDbModel> OrderByDescending(IQueryable<TDbModel> queryable)
        {
            return queryable.OrderByDescending(x => x.CreatedAt);
        }

        public async Task<List<TDbModel>> UpdateRangeAsync(List<TDbModel> entities)
        {
            dbContext.Set<TDbModel>().UpdateRange(entities);
            await dbContext.SaveChangesAsync();
            return entities;
        }

        public virtual async Task<List<TDbModel>> AddRangeAsync(List<TDbModel> entities)
        {
            await dbContext.Set<TDbModel>().AddRangeAsync(entities);
            await dbContext.SaveChangesAsync();
            return entities;
        }


        public virtual async Task<bool> AddOrUpdateRangeAsync(List<TDbModel> entities)
        {
            var updateEntities = entities.Where(x => x.ID > 0).ToList();
            var addEntities = entities.Where(x => x.ID == 0).ToList();

            if (updateEntities.Count > 0)
                await UpdateRangeAsync(updateEntities);

            if (addEntities.Count > 0)
                await AddRangeAsync(addEntities);

            await dbContext.SaveChangesAsync();
            return true;
        }


        public virtual async Task<TDbModel> AddOrUpdateAsync(TDbModel entity)
        {
            if (entity.ID > 0)
                return await UpdateAsync(entity);

            return await AddAsync(entity);
        }


        public DbContext GetDbContext()
        {
            return dbContext;
        }


        public void SetDbContext(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<List<TDbModel>> GetWhereAsync(Expression<Func<TDbModel, bool>> predicate)
        {
            var results = await dbContext.Set<TDbModel>().Where(predicate).ToListAsync();
            return results;
        }

    }
}
