﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.BLL.Common
{
    public abstract class ServiceManager<T, Tdto>
    {
        public virtual DTO.Common.Response<T> Response { get; set; }
        public virtual Boolean FirstRun { get; set; }

        public ServiceManager()
        {
            Response = new DTO.Common.Response<T>() { List = new List<T>() };
            FirstRun = true;
        }

        public abstract Task<List<T>> GetList(Tdto searchParams);
        public abstract Task<T> GetItem(Tdto searchParams);
        public abstract void SaveItem(T dto, Boolean isNew = false);
        public abstract void DeleteItem(T dto);
    }
}
