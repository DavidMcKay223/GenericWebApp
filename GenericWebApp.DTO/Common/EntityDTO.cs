﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.DTO.Common
{
    public abstract class EntityDTO
    {
        public Boolean IsValid(List<Error> errorList)
        {
            return true;
        }
    }
}
