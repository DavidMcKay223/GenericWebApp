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
            Response.ErrorList.Clear();

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
                    Response.ErrorList.Add(new Error { Message = "Item did not delete" });
                }
            }
            catch (Exception ex)
            {
                Response.ErrorList.Add(new Error { Code = ex.Source, Message = ex.Message });
            }
        }

        public override async Task GetItemAsync(GenericWebApp.BLL.Management.TaskSeachDTO searchParams)
        {
            Response.ErrorList.Clear();

            try
            {
                var taskItem = await _context.TaskItems
                    .FirstOrDefaultAsync(t =>
                        (searchParams.ID.HasValue && t.ID == searchParams.ID) ||
                        (!string.IsNullOrWhiteSpace(searchParams.TaskTitle) && t.Title.ToLower().Contains(searchParams.TaskTitle.ToLower())) ||
                        (!string.IsNullOrWhiteSpace(searchParams.TaskDescription) && t.Description.ToLower().Contains(searchParams.TaskDescription.ToLower())) ||
                        (!string.IsNullOrWhiteSpace(searchParams.TaskObjectType_Code) && t.TaskObjectType_Code.ToLower().Contains(searchParams.TaskObjectType_Code.ToLower())) ||
                        (searchParams.Task_Object_ID.HasValue && t.Task_Object_ID == searchParams.Task_Object_ID) ||
                        (searchParams.TaskActivity_ID.HasValue && t.TaskActivity_ID == searchParams.TaskActivity_ID) ||
                        (searchParams.CreatedDate.HasValue && t.CreatedDate >= searchParams.CreatedDate) ||
                        (searchParams.UpdatedDate.HasValue && t.UpdatedDate >= searchParams.UpdatedDate));

                Response.Item = GenericWebApp.Model.Common.ManagementParser.ParseDTO(taskItem);
            }
            catch (Exception ex)
            {
                Response.ErrorList.Add(new Error { Code = ex.Source, Message = ex.Message });
                Response.Item = null;
            }
        }

        public override async Task GetListAsync(TaskSeachDTO searchParams)
        {
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

                if (searchParams.CreatedDate.HasValue)
                {
                    query = query.Where(t => t.CreatedDate >= searchParams.CreatedDate);
                }

                if (searchParams.UpdatedDate.HasValue)
                {
                    query = query.Where(t => t.UpdatedDate >= searchParams.UpdatedDate);
                }

                // Apply sorting
                if (!string.IsNullOrWhiteSpace(searchParams.SortField))
                {
                    query = searchParams.SortField switch
                    {
                        "TaskTitle" => searchParams.SortDescending ? query.OrderByDescending(t => t.Title) : query.OrderBy(t => t.Title),
                        "CreatedDate" => searchParams.SortDescending ? query.OrderByDescending(t => t.CreatedDate) : query.OrderBy(t => t.CreatedDate),
                        "UpdatedDate" => searchParams.SortDescending ? query.OrderByDescending(t => t.UpdatedDate) : query.OrderBy(t => t.UpdatedDate),
                        _ => query
                    };
                }

                // Get total count before applying pagination
                var totalItems = await query.CountAsync();

                // Apply pagination
                query = query.Skip((searchParams.PageNumber) * searchParams.PageSize).Take(searchParams.PageSize);

                var taskItems = await query.ToListAsync();
                Response.List = taskItems.Select(GenericWebApp.Model.Common.ManagementParser.ParseDTO).ToList();
                Response.TotalItems = totalItems;
            }
            catch (Exception ex)
            {
                Response.ErrorList.Add(new Error { Code = ex.Source, Message = ex.Message });
                Response.List = new List<GenericWebApp.DTO.Management.TaskItem>();
            }
        }

        public override async Task SaveItemAsync(GenericWebApp.DTO.Management.TaskItem dto)
        {
            Response.ErrorList.Clear();

            if (dto.IsValid(Response.ErrorList))
            {
                try
                {
                    var taskItem = GenericWebApp.Model.Common.ManagementParser.ParseModel(dto);

                    var existingTaskItem = await _context.TaskItems.FirstOrDefaultAsync(t => t.ID == dto.ID);
                    if (existingTaskItem != null)
                    {
                        existingTaskItem.Title = taskItem.Title;
                        existingTaskItem.Description = taskItem.Description;
                        existingTaskItem.TaskObjectType_Code = taskItem.TaskObjectType_Code;
                        existingTaskItem.Task_Object_ID = taskItem.Task_Object_ID;
                        existingTaskItem.TaskActivity_ID = taskItem.TaskActivity_ID;
                        existingTaskItem.UpdatedDate = DateTime.UtcNow;

                        _context.TaskItems.Update(existingTaskItem);
                    }
                    else
                    {
                        taskItem.CreatedDate = DateTime.UtcNow;
                        taskItem.UpdatedDate = DateTime.UtcNow;
                        await _context.TaskItems.AddAsync(taskItem);
                    }

                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Response.ErrorList.Add(new Error { Code = ex.Source, Message = ex.Message });
                }
            }
        }
    }

    public class TaskSeachDTO : SearchDTO
    {
        public int? ID { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public string TaskObjectType_Code { get; set; }
        public int? Task_Object_ID { get; set; }
        public int? TaskActivity_ID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
