using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericWebApp.BLL.Common
{
    public abstract class ServiceManager<T, Tdto>
    {
        public virtual DTO.Common.Response<T> Response { get; set; }

        public ServiceManager()
        {
            Response = new DTO.Common.Response<T>() { List = new List<T>() };
        }

        public abstract Task<List<T>> GetListAsync(Tdto searchParams);
        public abstract Task<T> GetItemAsync(Tdto searchParams);
        public abstract Task SaveItemAsync(T dto, Boolean isNew = false);
        public abstract Task DeleteItemAsync(T dto);
    }
}
