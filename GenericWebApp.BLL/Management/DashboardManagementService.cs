using GenericWebApp.Model.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.BLL.Management
{
    public class DashboardManagementService
    {
        private readonly ManagementContext _context;

        public DashboardManagementService(ManagementContext context)
        {
            _context = context;
        }
    }
}
