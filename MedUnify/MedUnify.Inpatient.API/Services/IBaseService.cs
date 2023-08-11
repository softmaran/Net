using MedUnify.Inpatient.DAL.Model;
using MedUnify.Inpatient.ViewModel;

namespace HNMC.Phoenix.Library.Services
{
    public interface IBaseService<TViewModel>
        where TViewModel : TableAuditViewModel
    {
        Task<TViewModel> AddAsync(TViewModel addModel);
        Task<TViewModel> AddOrUpdateAsync(TViewModel entity);
        Task<bool> AddOrUpdateRangeAsync(List<TViewModel> entities);
        Task<List<TViewModel>> AddRangeAsync(List<TViewModel> entities);
        Task<bool> DeleteAsync(long id, string modifiedBy);
        Task<List<TViewModel>> GetAllActiveAsync(bool? includeChain = null, int? skip = null, int? take = null);
        Task<long> GetAllActiveCountAsync();
        Task<List<TViewModel>> GetAllAsync(bool? includeChain = null, int? skip = null, int? take = null);
        Task<long> GetAllCountAsync();
        Task<List<TViewModel>> GetAllInActiveAsync(bool? includeChain = null, int? skip = null, int? take = null);
        Task<long> GetAllInActiveCountAsync();
        Task<TViewModel> GetAsync(long id, bool? basic = null);
        Task OnAfterAddAsync(TViewModel viewModel);
        Task OnAfterUpdateAsync(TViewModel viewModel);
        TViewModel OnBeforeAdd(TViewModel viewModel);
        TViewModel OnBeforeUpdate(TViewModel viewModel);
        Task<int> RemoveListAsync(List<long> ids);
        Task<TViewModel> UpdateAsync(TViewModel updateModel);
        Task<List<TViewModel>> UpdateRangeAsync(List<TViewModel> entities);
    }
}