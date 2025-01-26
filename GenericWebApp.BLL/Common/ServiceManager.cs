using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericWebApp.BLL.Common
{
    public abstract class SearchDTO
    {
        public virtual int PageNumber { get; set; } = 0;
        public virtual int PageSize { get; set; } = 10;
        public virtual string SortField { get; set; }
        public virtual bool SortDescending { get; set; } = false;
    }

    public abstract class ServiceManager<T, TSearchDTO> where TSearchDTO : SearchDTO
    {
        public virtual DTO.Common.Response<T> Response { get; set; }

        public ServiceManager()
        {
            Response = new DTO.Common.Response<T>() { List = new List<T>(), ErrorList = new List<DTO.Common.Error>() };
        }

        public abstract Task GetListAsync(TSearchDTO searchParams);
        public abstract Task GetItemAsync(TSearchDTO searchParams);
        public abstract Task SaveItemAsync(T dto);
        public abstract Task DeleteItemAsync(T dto);
    }
}
