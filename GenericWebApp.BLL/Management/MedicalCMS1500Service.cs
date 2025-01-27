using GenericWebApp.BLL.Common;
using GenericWebApp.DTO.Common;
using GenericWebApp.DTO.Management;
using GenericWebApp.Model.Common;
using GenericWebApp.Model.Management;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericWebApp.BLL.Management
{
    public class MedicalCMS1500Service : ServiceManager<DTO.Management.CMS1500Form, MedicalCMS1500SeachDTO>
    {
        private readonly ManagementContext? _context;

        public MedicalCMS1500Service()
        {
        }

        public MedicalCMS1500Service(ManagementContext context)
        {
            _context = context;
        }

        public override async Task DeleteItemAsync(DTO.Management.CMS1500Form dto)
        {
            Response.ErrorList.Clear();

            try
            {
                if(_context == null)
                {
                    Response.ErrorList.Add(new Error { Code = "ContextIsNull", Message = "Context is null" });
                    return;
                }

                var entity = await _context.CMS1500Forms.FirstOrDefaultAsync(c => c.ID == dto.ID);
                if (entity != null)
                {
                    _context.CMS1500Forms.Remove(entity);
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

        public void GetItem(MedicalCMS1500SeachDTO searchParams)
        {
            Response.ErrorList.Clear();

            try
            {
                if (_context == null)
                {
                    Response.ErrorList.Add(new Error { Code = "ContextIsNull", Message = "Context is null" });
                    return;
                }

                var entity = _context.CMS1500Forms
                    .Include(c => c.Claimant)
                        .ThenInclude(claimant => claimant.PrimaryAddress)
                    .Include(c => c.Claimant)
                        .ThenInclude(claimant => claimant.SecondaryAddress)
                    .First(c =>
                        searchParams.ID.HasValue && c.ID == searchParams.ID.Value);

                Response.Item = ManagementDTOParser.ParseDTO(entity);
            }
            catch (Exception ex)
            {
                Response.ErrorList.Add(new Error { Code = ex.Source, Message = ex.Message });
                Response.Item = null;
            }
        }

        public override async Task GetItemAsync(MedicalCMS1500SeachDTO searchParams)
        {
            Response.ErrorList.Clear();

            try
            {
                if(_context == null)
                {
                    Response.ErrorList.Add(new Error { Code = "ContextIsNull", Message = "Context is null" });
                    return;
                }

                var entity = await _context.CMS1500Forms
                    .Include(c => c.Claimant)
                        .ThenInclude(claimant => claimant.PrimaryAddress)
                    .Include(c => c.Claimant)
                        .ThenInclude(claimant => claimant.SecondaryAddress)
                    .FirstAsync(c =>
                        (searchParams.ID.HasValue && c.ID == searchParams.ID) ||
                        (!string.IsNullOrWhiteSpace(searchParams.ClaimantName) && c.Claimant.Name.Contains(searchParams.ClaimantName, StringComparison.CurrentCultureIgnoreCase)) ||
                        (searchParams.CreatedDate.HasValue && c.CreatedDate >= searchParams.CreatedDate) ||
                        (searchParams.UpdatedDate.HasValue && c.UpdatedDate >= searchParams.UpdatedDate));

                Response.Item = ManagementDTOParser.ParseDTO(entity);
            }
            catch (Exception ex)
            {
                Response.ErrorList.Add(new Error { Code = ex.Source, Message = ex.Message });
                Response.Item = null;
            }
        }

        public override async Task GetListAsync(MedicalCMS1500SeachDTO searchParams)
        {
            try
            {
                if (_context == null)
                {
                    Response.ErrorList.Add(new Error { Code = "ContextIsNull", Message = "Context is null" });
                    return;
                }

                var query = _context.CMS1500Forms
                    .Include(c => c.Claimant)
                        .ThenInclude(claimant => claimant.PrimaryAddress)
                    .Include(c => c.Claimant)
                        .ThenInclude(claimant => claimant.SecondaryAddress)
                    .AsQueryable();

                if (searchParams.ID.HasValue)
                {
                    query = query.Where(c => c.ID == searchParams.ID);
                }

                if (!string.IsNullOrWhiteSpace(searchParams.ClaimantName))
                {
                    query = query.Where(c => c.Claimant.Name.Contains(searchParams.ClaimantName, StringComparison.OrdinalIgnoreCase));
                }

                if (searchParams.CreatedDate.HasValue)
                {
                    query = query.Where(c => c.CreatedDate >= searchParams.CreatedDate);
                }

                if (searchParams.UpdatedDate.HasValue)
                {
                    query = query.Where(c => c.UpdatedDate >= searchParams.UpdatedDate);
                }

                // Apply sorting
                if (!string.IsNullOrWhiteSpace(searchParams.SortField))
                {
                    query = searchParams.SortField switch
                    {
                        "ClaimantName" => searchParams.SortDescending ? query.OrderByDescending(c => c.Claimant.Name) : query.OrderBy(c => c.Claimant.Name),
                        "CreatedDate" => searchParams.SortDescending ? query.OrderByDescending(c => c.CreatedDate) : query.OrderBy(c => c.CreatedDate),
                        "UpdatedDate" => searchParams.SortDescending ? query.OrderByDescending(c => c.UpdatedDate) : query.OrderBy(c => c.UpdatedDate),
                        _ => query
                    };
                }

                // Get total count before applying pagination
                var totalItems = await query.CountAsync();

                // Apply pagination
                query = query.Skip((searchParams.PageNumber) * searchParams.PageSize).Take(searchParams.PageSize);

                var entities = await query.ToListAsync();
                Response.List = [.. entities.ConvertAll(ManagementDTOParser.ParseDTO)];
                Response.TotalItems = totalItems;
            }
            catch (Exception ex)
            {
                Response.ErrorList.Add(new Error { Code = ex.Source, Message = ex.Message });
                Response.List = [];
            }
        }

        public override async Task SaveItemAsync(DTO.Management.CMS1500Form dto)
        {
            Response.ErrorList.Clear();

            if (dto.IsValid(Response.ErrorList))
            {
                try
                {
                    if (_context == null)
                    {
                        Response.ErrorList.Add(new Error { Code = "ContextIsNull", Message = "Context is null" });
                        return;
                    }

                    var entity = await _context.CMS1500Forms.FirstOrDefaultAsync(c => c.ID == dto.ID);
                    if (entity != null)
                    {
                        ManagementModelParser.ParseModel(entity, dto);
                        entity.UpdatedDate = DateTime.UtcNow;

                        _context.CMS1500Forms.Update(entity);
                    }
                    else
                    {
                        entity ??= new Model.Management.CMS1500Form() { 
                            Claimant = new Model.Management.Claimant() { 
                                Name = String.Empty,
                                PrimaryAddress = new Model.Management.Address(),
                                SecondaryAddress = new Model.Management.Address()
                            } };

                        ManagementModelParser.ParseModel(entity, dto);
                        entity.CreatedDate = DateTime.UtcNow;
                        entity.UpdatedDate = DateTime.UtcNow;
                        await _context.CMS1500Forms.AddAsync(entity);
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

    public class MedicalCMS1500SeachDTO : SearchDTO
    {
        public int? ID { get; set; }
        public string? ClaimantName { get; set; }
        public string? PrimaryAddress { get; set; }
        public string? SecondaryAddress { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
