using MedUnify.Inpatient.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedUnify.Inpatient.DAL.Repository.Interfaces
{
    public interface IBaseRepository<TDbModel> where TDbModel : TableAudit
    {
        Task<TDbModel> AddAsync(TDbModel entity);
        Task<TDbModel> AddOrUpdateAsync(TDbModel entity);
        Task<bool> AddOrUpdateRangeAsync(List<TDbModel> entities);
        Task<List<TDbModel>> AddRangeAsync(List<TDbModel> entities);
        Task<bool> DeleteAsync(long id, string loggedInUser);
        Task DetachAllAsync(List<TDbModel> entities);
        Task DetachAsync(TDbModel entity);
        Task DirectUpdateAsync(TDbModel entity);
        Task<List<TDbModel>> FetchByIDListAsync(List<long> idList, bool? includeChain = null);
        Task<List<TDbModel>> GetAllActiveAsync(bool? includeChain = null, int? skip = null, int? take = null);
        Task<long> GetAllActiveCountAsync();
        Task<List<TDbModel>> GetAllAsync(bool? includeChain = null, int? skip = null, int? take = null);
        Task<long> GetAllCountAsync();
        Task<List<TDbModel>> GetAllInActiveAsync(bool? includeChain = null, int? skip = null, int? take = null);
        Task<long> GetAllInActiveCountAsync();
        Task<TDbModel> GetAsync(long id, bool? basic = null);
        DbContext GetDbContext();
        Task<List<TDbModel>> GetWhereAsync(Expression<Func<TDbModel, bool>> predicate);
        IQueryable<TDbModel> IncludeChain(IQueryable<TDbModel> chain);
        Task<TDbModel> OnAfterAddAsync(TDbModel model);
        Task<TDbModel> OnAfterUpdateAsync(TDbModel model);
        Task<TDbModel> OnBeforeAddAsync(TDbModel model);
        Task<TDbModel> OnBeforeUpdateAsync(TDbModel model);
        IOrderedQueryable<TDbModel> OrderByDescending(IQueryable<TDbModel> queryable);
        Task<bool> RemoveAsync(long id);
        Task<int> RemoveListAsync(List<long> ids);
        void SaveChanges();
        Task SaveChangesAsync();
        void SetDbContext(DbContext dbContext);
        Task<TDbModel> UpdateAsync(TDbModel entity);
        Task<List<TDbModel>> UpdateRangeAsync(List<TDbModel> entities);
    }
}