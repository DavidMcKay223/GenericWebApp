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
        private readonly GenericWebApp.Model.Management.ManagementContext? _context;

        public TaskService()
        {
        }

        public TaskService(GenericWebApp.Model.Management.ManagementContext context)
        {
            _context = context;
        }

        public override async Task DeleteItemAsync(GenericWebApp.DTO.Management.TaskItem dto)
        {
            Response.ErrorList.Clear();

            try
            {
                if (_context == null)
                {
                    Response.ErrorList.Add(new Error { Code = "ContextIsNull", Message = "Context is null" });
                    return;
                }

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
                if (_context == null)
                {
                    Response.ErrorList.Add(new Error { Code = "ContextIsNull", Message = "Context is null" });
                    return;
                }

                var taskItem = await _context.TaskItems.FirstOrDefaultAsync(t =>
                        (searchParams.ID.HasValue && t.ID == searchParams.ID) ||
                        (!string.IsNullOrWhiteSpace(searchParams.TaskTitle) && t.Title.Contains(searchParams.TaskTitle, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrWhiteSpace(searchParams.TaskDescription) && t.Description.Contains(searchParams.TaskDescription, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrWhiteSpace(searchParams.TaskObjectType_Code) && t.TaskObjectType_Code != null && t.TaskObjectType_Code.Contains(searchParams.TaskObjectType_Code, StringComparison.CurrentCultureIgnoreCase)) ||
                        (searchParams.Task_Object_ID.HasValue && t.Task_Object_ID == searchParams.Task_Object_ID) ||
                        (searchParams.TaskActivity_ID.HasValue && t.TaskActivity_ID == searchParams.TaskActivity_ID) ||
                        (searchParams.CreatedDate.HasValue && t.CreatedDate >= searchParams.CreatedDate) ||
                        (searchParams.UpdatedDate.HasValue && t.UpdatedDate >= searchParams.UpdatedDate));

                Response.Item = GenericWebApp.Model.Common.ManagementDTOParser.ParseDTO(taskItem ?? new Model.Management.TaskItem() { Title = String.Empty, Description = String.Empty });
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
                if (_context == null)
                {
                    Response.ErrorList.Add(new Error { Code = "ContextIsNull", Message = "Context is null" });
                    return;
                }

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
                    query = query.Where(t => t.TaskObjectType_Code != null && EF.Functions.Like(t.TaskObjectType_Code, $"%{searchParams.TaskObjectType_Code}%"));
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
                Response.List = [.. taskItems.ConvertAll(GenericWebApp.Model.Common.ManagementDTOParser.ParseDTO)];
                Response.TotalItems = totalItems;
            }
            catch (Exception ex)
            {
                Response.ErrorList.Add(new Error { Code = ex.Source, Message = ex.Message });
                Response.List = [];
            }
        }

        public override async Task SaveItemAsync(GenericWebApp.DTO.Management.TaskItem dto)
        {
            Response.ErrorList.Clear();

            if (dto.IsValid(Response.ErrorList))
            {
                try
                {
                    if (_context == null)
                    {
                        Response.ErrorList.Add(new DTO.Common.Error { Code = "ContextIsNull", Message = "Context is null" });
                        return;
                    }

                    var existingTaskItem = await _context.TaskItems.FirstOrDefaultAsync(t => t.ID == dto.ID);
                    if (existingTaskItem != null)
                    {
                        GenericWebApp.Model.Common.ManagementModelParser.ParseModel(existingTaskItem, dto);
                        existingTaskItem.UpdatedDate = DateTime.UtcNow;

                        _context.TaskItems.Update(existingTaskItem);
                    }
                    else
                    {
                        existingTaskItem ??= new Model.Management.TaskItem() { Title = String.Empty , Description = String.Empty };
                        GenericWebApp.Model.Common.ManagementModelParser.ParseModel(existingTaskItem, dto);
                        existingTaskItem.CreatedDate = DateTime.UtcNow;
                        existingTaskItem.UpdatedDate = DateTime.UtcNow;
                        await _context.TaskItems.AddAsync(existingTaskItem);
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
        public string? TaskTitle { get; set; }
        public string? TaskDescription { get; set; }
        public string? TaskObjectType_Code { get; set; }
        public int? Task_Object_ID { get; set; }
        public int? TaskActivity_ID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
