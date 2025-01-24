using GenericWebApp.DTO.Management;
using GenericWebApp.BLL.Common;
using GenericWebApp.Model.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GenericWebApp.DTO.Common;

namespace GenericWebApp.BLL.Management
{
    public class TaskService : ServiceManager<GenericWebApp.DTO.Management.TaskItem, GenericWebApp.BLL.Management.TaskSeachDTO>
    {
        private readonly GenericWebApp.Model.Management.ManagementContext _context;

        public TaskService(GenericWebApp.Model.Management.ManagementContext context)
        {
            _context = context;
        }

        public override async Task DeleteItemAsync(GenericWebApp.DTO.Management.TaskItem dto)
        {
            Response.Error = null;

            try
            {
                var taskItem = await _context.TaskItems.FirstOrDefaultAsync(t => t.ID == dto.ID);
                if (taskItem != null)
                {
                    _context.TaskItems.Remove(taskItem);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Response.Error = new Error { Message = "Item did not delete" };
                }
            }
            catch (Exception ex)
            {
                Response.Error = new Error { Message = ex.Message };
            }
        }

        public override async Task<GenericWebApp.DTO.Management.TaskItem> GetItemAsync(GenericWebApp.BLL.Management.TaskSeachDTO searchParams)
        {
            Response.Error = null;

            try
            {
                var taskItem = await _context.TaskItems
                    .FirstOrDefaultAsync(t =>
                        (searchParams.ID.HasValue && t.ID == searchParams.ID) ||
                        (!string.IsNullOrWhiteSpace(searchParams.TaskTitle) && t.Title.ToLower().Contains(searchParams.TaskTitle.ToLower())) ||
                        (!string.IsNullOrWhiteSpace(searchParams.TaskDescription) && t.Description.ToLower().Contains(searchParams.TaskDescription.ToLower())) ||
                        (!string.IsNullOrWhiteSpace(searchParams.TaskObjectType_Code) && t.TaskObjectType_Code.ToLower().Contains(searchParams.TaskObjectType_Code.ToLower())) ||
                        (searchParams.Task_Object_ID.HasValue && t.Task_Object_ID == searchParams.Task_Object_ID) ||
                        (searchParams.TaskActivity_ID.HasValue && t.TaskActivity_ID == searchParams.TaskActivity_ID));

                return GenericWebApp.Model.Management.TaskItem.ParseDTO(taskItem);
            }
            catch (Exception ex)
            {
                Response.Error = new Error { Message = ex.Message };
                return null;
            }
        }

        public override async Task<List<GenericWebApp.DTO.Management.TaskItem>> GetListAsync(GenericWebApp.BLL.Management.TaskSeachDTO searchParams)
        {
            Response.Error = null;

            try
            {
                var query = _context.TaskItems.AsQueryable();

                if (searchParams.ID.HasValue)
                {
                    query = query.Where(t => t.ID == searchParams.ID);
                }

                if (!string.IsNullOrWhiteSpace(searchParams.TaskTitle))
                {
                    query = query.Where(t => t.Title.ToLower().Contains(searchParams.TaskTitle.ToLower()));
                }

                if (!string.IsNullOrWhiteSpace(searchParams.TaskDescription))
                {
                    query = query.Where(t => t.Description.ToLower().Contains(searchParams.TaskDescription.ToLower()));
                }

                if (!string.IsNullOrWhiteSpace(searchParams.TaskObjectType_Code))
                {
                    query = query.Where(t => t.TaskObjectType_Code.ToLower().Contains(searchParams.TaskObjectType_Code.ToLower()));
                }

                if (searchParams.Task_Object_ID.HasValue)
                {
                    query = query.Where(t => t.Task_Object_ID == searchParams.Task_Object_ID);
                }

                if (searchParams.TaskActivity_ID.HasValue)
                {
                    query = query.Where(t => t.TaskActivity_ID == searchParams.TaskActivity_ID);
                }

                var taskItems = await query.ToListAsync();
                return taskItems.Select(GenericWebApp.Model.Management.TaskItem.ParseDTO).ToList();
            }
            catch (Exception ex)
            {
                Response.Error = new Error { Message = ex.Message };
                return new List<GenericWebApp.DTO.Management.TaskItem>();
            }
        }

        public override async Task SaveItemAsync(GenericWebApp.DTO.Management.TaskItem dto, bool isNew = false)
        {
            Response.Error = null;

            try
            {
                var taskItem = GenericWebApp.Model.Management.TaskItem.ParseModel(dto);

                if (isNew)
                {
                    await _context.TaskItems.AddAsync(taskItem);
                }
                else
                {
                    var existingTaskItem = await _context.TaskItems.FirstOrDefaultAsync(t => t.ID == dto.ID);
                    if (existingTaskItem != null)
                    {
                        existingTaskItem.Title = taskItem.Title;
                        existingTaskItem.Description = taskItem.Description;
                        existingTaskItem.TaskObjectType_Code = taskItem.TaskObjectType_Code;
                        existingTaskItem.Task_Object_ID = taskItem.Task_Object_ID;
                        existingTaskItem.TaskActivity_ID = taskItem.TaskActivity_ID;

                        _context.TaskItems.Update(existingTaskItem);
                    }
                    else
                    {
                        await _context.TaskItems.AddAsync(taskItem);
                    }
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Response.Error = new Error { Message = ex.Message };
            }
        }
    }

    public class TaskSeachDTO
    {
        public int? ID { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public string TaskObjectType_Code { get; set; }
        public int? Task_Object_ID { get; set; }
        public int? TaskActivity_ID { get; set; }
    }
}
