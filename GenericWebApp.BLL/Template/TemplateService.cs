using GenericWebApp.BLL.Common;
using GenericWebApp.BLL.Template;
using GenericWebApp.DTO.Common;
using GenericWebApp.DTO.Template;
using GenericWebApp.Model.Template;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.BLL.Template
{
    public class TemplateService : ServiceManager<DTO.Template.TemplateItem, TemplateSearchDTO>
    {
        private readonly TemplateContext? _context;

        public TemplateService()
        {
        }

        public TemplateService(TemplateContext context)
        {
            _context = context;
        }

        public override async Task DeleteItemAsync(DTO.Template.TemplateItem dto)
        {
            Response.ErrorList.Clear();

            try
            {
                if (_context == null)
                {
                    Response.ErrorList.Add(new Error { Code = "ContextIsNull", Message = "Context is null" });
                    return;
                }

                var templateItem = await _context.TemplateItems.FirstOrDefaultAsync(t => t.ID == dto.ID);
                if (templateItem != null)
                {
                    _context.TemplateItems.Remove(templateItem);
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

        public override async Task GetItemAsync(TemplateSearchDTO searchParams)
        {
            Response.ErrorList.Clear();

            try
            {
                if (_context == null)
                {
                    Response.ErrorList.Add(new Error { Code = "ContextIsNull", Message = "Context is null" });
                    return;
                }

                var templateItem = await _context.TemplateItems.FirstOrDefaultAsync(t =>
                        (searchParams.ID.HasValue && t.ID == searchParams.ID) ||
                        (!string.IsNullOrWhiteSpace(searchParams.Title) && t.Title.ToLower().Contains(searchParams.Title.ToLower())) ||
                        (!string.IsNullOrWhiteSpace(searchParams.Description) && t.Description.ToLower().Contains(searchParams.Description.ToLower())) ||
                        (searchParams.IsCompleted.HasValue && t.IsCompleted == searchParams.IsCompleted.Value)
                    );


                Response.Item = GenericWebApp.Model.Common.TemplateDTOParser.ParseDTO(templateItem!);
            }
            catch (Exception ex)
            {
                Response.ErrorList.Add(new Error { Code = ex.Source, Message = ex.Message });
                Response.Item = null;
            }
        }

        public override async Task GetListAsync(TemplateSearchDTO searchParams)
        {
            try
            {
                if (_context == null)
                {
                    Response.ErrorList.Add(new Error { Code = "ContextIsNull", Message = "Context is null" });
                    return;
                }

                var query = _context.TemplateItems.AsQueryable();

                if (searchParams.ID.HasValue)
                {
                    query = query.Where(t => t.ID == searchParams.ID);
                }

                if (!string.IsNullOrWhiteSpace(searchParams.Title))
                {
                    query = query.Where(t => t.Title.ToLower().Contains(searchParams.Title.ToLower()));
                }

                if (!string.IsNullOrWhiteSpace(searchParams.Description))
                {
                    query = query.Where(t => t.Description.ToLower().Contains(searchParams.Description.ToLower()));
                }

                if (searchParams.TemplateStatusID.HasValue)
                {
                    query = query.Where(t => t.TemplateStatus_ID == searchParams.TemplateStatusID);
                }

                if (searchParams.CreatedDate.HasValue)
                {
                    query = query.Where(t => t.CreatedDate >= searchParams.CreatedDate);
                }

                if (searchParams.UpdatedDate.HasValue)
                {
                    query = query.Where(t => t.UpdatedDate >= searchParams.UpdatedDate);
                }

                if (searchParams.IsCompleted.HasValue)
                {
                    query = query.Where(t => t.IsCompleted == searchParams.IsCompleted.Value);
                }

                // Apply sorting
                if (!string.IsNullOrWhiteSpace(searchParams.SortField))
                {
                    query = searchParams.SortField switch
                    {
                        "TemplateTitle" => searchParams.SortDescending ? query.OrderByDescending(t => t.Title) : query.OrderBy(t => t.Title),
                        "TemplateDescription" => searchParams.SortDescending ? query.OrderByDescending(t => t.Description) : query.OrderBy(t => t.Description),
                        "CreatedDate" => searchParams.SortDescending ? query.OrderByDescending(t => t.CreatedDate) : query.OrderBy(t => t.CreatedDate),
                        "UpdatedDate" => searchParams.SortDescending ? query.OrderByDescending(t => t.UpdatedDate) : query.OrderBy(t => t.UpdatedDate),
                        _ => query
                    };
                }

                // Get total count before applying pagination
                var totalItems = await query.CountAsync();

                // Apply pagination
                query = query.Skip((searchParams.PageNumber) * searchParams.PageSize).Take(searchParams.PageSize);

                var templateItems = await query.ToListAsync();
                Response.List = [.. templateItems.ConvertAll(GenericWebApp.Model.Common.TemplateDTOParser.ParseDTO)];
                Response.TotalItems = totalItems;
            }
            catch (Exception ex)
            {
                Response.ErrorList.Add(new Error { Code = ex.Source, Message = ex.Message });
                Response.List = [];
            }
        }

        public override async Task SaveItemAsync(DTO.Template.TemplateItem dto)
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

                    var existingTemplateItem = await _context.TemplateItems.FirstOrDefaultAsync(t => t.ID == dto.ID);
                    if (existingTemplateItem != null)
                    {
                        GenericWebApp.Model.Common.TemplateModelParser.ParseModel(existingTemplateItem, dto);
                        existingTemplateItem.UpdatedDate = DateTime.UtcNow;
                        existingTemplateItem.IsCompleted = dto.IsCompleted; // Add this line

                        _context.TemplateItems.Update(existingTemplateItem);
                    }
                    else
                    {
                        existingTemplateItem ??= new Model.Template.TemplateItem()
                        {
                            Title = String.Empty,
                            Description = String.Empty,
                            TemplateStatus_ID = 1,
                            IsCompleted = false,
                            PrimaryAddress = new Model.Template.TemplateAddress(),
                            SecondaryAddress = new Model.Template.TemplateAddress()
                        };
                        GenericWebApp.Model.Common.TemplateModelParser.ParseModel(existingTemplateItem, dto);
                        existingTemplateItem.CreatedDate = DateTime.UtcNow;
                        existingTemplateItem.UpdatedDate = DateTime.UtcNow;
                        existingTemplateItem.IsCompleted = dto.IsCompleted; // Add this line
                        await _context.TemplateItems.AddAsync(existingTemplateItem);
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

    public class TemplateSearchDTO : SearchDTO
    {
        public int? ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? TemplateStatusID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Boolean? IsCompleted { get; set; }
    }
}
