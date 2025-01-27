using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericWebApp.BLL.Common
{
    public abstract class SearchDTO
    {
        public virtual int PageNumber { get; set; } = 0;
        public virtual int PageSize { get; set; } = 10;
        public virtual string? SortField { get; set; }
        public virtual bool SortDescending { get; set; } = false;
    }

    public abstract class ServiceManager<T, TSearchDTO> 
        where T : DTO.Common.EntityDTO
        where TSearchDTO : SearchDTO
    {
        public virtual required DTO.Common.Response<T> Response { get; set; }

        public ServiceManager()
        {
            Response = new DTO.Common.Response<T>() { List = [], ErrorList = [] };
        }

        public abstract Task GetListAsync(TSearchDTO searchParams);
        public abstract Task GetItemAsync(TSearchDTO searchParams);
        public abstract Task SaveItemAsync(T dto);
        public abstract Task DeleteItemAsync(T dto);
    }
}
