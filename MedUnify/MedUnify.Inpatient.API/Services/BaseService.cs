using AutoMapper;
using MedUnify.Inpatient.DAL.Model;
using MedUnify.Inpatient.DAL.Repository.Interfaces;
using MedUnify.Inpatient.ViewModel;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace HNMC.Phoenix.Library.Services
{
    
    public abstract class BaseService
    {
        protected readonly IMapper mapper;
        protected readonly IServiceProvider serviceProvider;
        public string UserID { get; set; }

        public BaseService(IServiceProvider serviceProvider)
        {
            if (serviceProvider != null)
            {
                this.serviceProvider = serviceProvider;
                mapper = serviceProvider.GetService<IMapper>();
                var httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>();
                if (httpContextAccessor != null && httpContextAccessor.HttpContext != null)
                {
                    UserID = httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == "UserID")?.Value;
                }

            }
        }

    }

    
    public abstract class BaseService<TViewModel, TDbModel> : BaseService, IBaseService<TViewModel>
        where TViewModel : TableAuditViewModel
        where TDbModel : TableAudit
    {
        protected readonly IBaseRepository<TDbModel> baseRepository;

        
        public BaseService(IBaseRepository<TDbModel> baseRepository, IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            this.baseRepository = baseRepository;
        }

        
        public virtual TDbModel SetAuditDetail(TDbModel model)
        {
            return model;
        }

        
        public virtual List<TDbModel> SetAuditDetail(List<TDbModel> models)
        {
            models.ForEach(x =>
            {
                SetAuditDetail(x);
            });
            return models;
        }

        
        public virtual TViewModel OnBeforeAdd(TViewModel viewModel)
        {
            return viewModel;
        }

        
        public virtual TDbModel OnAfterAdd(TDbModel dbModel)
        {
            return dbModel;
        }

        
        public virtual TViewModel OnBeforeUpdate(TViewModel viewModel)
        {
            return viewModel;
        }

        
        public virtual TDbModel OnAfterUpdate(TDbModel dbModel)
        {
            return dbModel;
        }

        
        public async virtual Task<TDbModel> OnAfterAddAsync(TDbModel dbModel)
        {
            return await Task.FromResult(dbModel);
        }

        
        public async virtual Task<TDbModel> OnAfterUpdateAsync(TDbModel dbModel)
        {
            return await Task.FromResult(dbModel);
        }

        
        public async virtual Task OnAfterAddAsync(TViewModel viewModel)
        {
            await Task.CompletedTask;
        }

        
        public async virtual Task OnAfterUpdateAsync(TViewModel viewModel)
        {
            await Task.CompletedTask;
        }

        
        public virtual TViewModel MapViewModel(TDbModel model)
        {
            return mapper.Map<TViewModel>(model);
        }

        
        public virtual TDbModel MapDbModel(TViewModel model)
        {
            return mapper.Map<TDbModel>(model);
        }

        
        protected List<TViewModel> MapViewModels(List<TDbModel> dbModels)
        {
            var viewModels = new List<TViewModel>();
            foreach (var dbModel in dbModels)
                viewModels.Add(MapViewModel(dbModel));
            return viewModels;
        }

        
        protected List<TDbModel> MapDbModels(List<TViewModel> viewModels)
        {
            var dbModels = new List<TDbModel>();
            foreach (var viewModel in viewModels)
                dbModels.Add(MapDbModel(viewModel));
            return dbModels;
        }

        
        protected List<T2> MapList<T1, T2, T3>(List<T1> data, Func<T1, T3> func)
        {
            var returnData = new List<T2>();
            foreach (var item in data)
            {
                var obj = mapper.Map<T2>(func(item));
                obj = mapper.Map(obj, mapper.Map<T2>(item));
                returnData.Add(obj);
            }

            return returnData;
        }

        
        public async virtual Task<TViewModel> GetAsync(long id, bool? basic = null)
        {
            var objDbModel = await baseRepository.GetAsync(id, basic);

            if (objDbModel == null)
                return default(TViewModel);

            return MapViewModel(objDbModel);
        }

        
        public async virtual Task<List<TViewModel>> GetAllAsync(bool? includeChain = null, int? skip = null, int? take = null)
        {
            var objDbModels = await baseRepository.GetAllAsync(includeChain, skip, take);

            if (objDbModels == null)
                return null;

            return MapViewModels(objDbModels);
        }

        
        public async virtual Task<List<TViewModel>> GetAllActiveAsync(bool? includeChain = null, int? skip = null, int? take = null)
        {
            var objDbModels = await baseRepository.GetAllActiveAsync(includeChain, skip, take);

            if (objDbModels == null)
                return null;

            return MapViewModels(objDbModels);
        }

        
        public async virtual Task<List<TViewModel>> GetAllInActiveAsync(bool? includeChain = null, int? skip = null, int? take = null)
        {
            var objDbModels = await baseRepository.GetAllInActiveAsync(includeChain, skip, take);

            if (objDbModels == null)
                return null;

            return MapViewModels(objDbModels);
        }

        
        public async virtual Task<long> GetAllCountAsync()
        {
            var count = await baseRepository.GetAllCountAsync();
            return count;
        }

        
        public async virtual Task<long> GetAllActiveCountAsync()
        {
            var count = await baseRepository.GetAllActiveCountAsync();
            return count;
        }

        
        public async virtual Task<long> GetAllInActiveCountAsync()
        {
            var count = await baseRepository.GetAllInActiveCountAsync();
            return count;
        }

        
        public async virtual Task<bool> DeleteAsync(long id, string modifiedBy)
        {
            var result = await baseRepository.DeleteAsync(id, modifiedBy);
            return result;
        }

        
        public async virtual Task<int> RemoveListAsync(List<long> ids)
        {
            var result = await baseRepository.RemoveListAsync(ids);
            return result;
        }

        
        public async virtual Task<TViewModel> AddAsync(TViewModel addModel)
        {
            addModel = OnBeforeAdd(addModel);
            var model = MapDbModel(addModel);
            model = SetAuditDetail(model);
            var result = await baseRepository.AddAsync(model);
            result = OnAfterAdd(result);
            result = await OnAfterAddAsync(result);
            return MapViewModel(result);
        }

        
        public async virtual Task<TViewModel> UpdateAsync(TViewModel updateModel)
        {
            updateModel = OnBeforeUpdate(updateModel);
            var model = MapDbModel(updateModel);
            var entity = await baseRepository.GetAsync(model.ID);
            model.CreatedBy = entity.CreatedBy;
            model.CreatedAt = entity.CreatedAt;
            model = SetAuditDetail(model);
            var result = await baseRepository.UpdateAsync(model);
            result = OnAfterUpdate(result);
            result = await OnAfterUpdateAsync(result);
            return MapViewModel(result);
        }

        
        public virtual async Task<List<TViewModel>> AddRangeAsync(List<TViewModel> entities)
        {
            var dbModels = MapDbModels(entities);
            dbModels = SetAuditDetail(dbModels);
            dbModels = await baseRepository.AddRangeAsync(dbModels);
            return MapViewModels(dbModels);
        }

        
        public virtual async Task<List<TViewModel>> UpdateRangeAsync(List<TViewModel> entities)
        {
            var dbModels = MapDbModels(entities);
            dbModels = SetAuditDetail(dbModels);
            dbModels = await baseRepository.UpdateRangeAsync(dbModels);
            return MapViewModels(dbModels);
        }

        
        public virtual async Task<bool> AddOrUpdateRangeAsync(List<TViewModel> entities)
        {
            var dbModels = MapDbModels(entities);
            dbModels = SetAuditDetail(dbModels);
            var result = await baseRepository.AddOrUpdateRangeAsync(dbModels);
            return result;
        }

        
        public virtual async Task<TViewModel> AddOrUpdateAsync(TViewModel entity)
        {
            var dbModel = MapDbModel(entity);
            dbModel = SetAuditDetail(dbModel);
            var result = await baseRepository.AddOrUpdateAsync(dbModel);
            return MapViewModel(result);
        }

    }
}
