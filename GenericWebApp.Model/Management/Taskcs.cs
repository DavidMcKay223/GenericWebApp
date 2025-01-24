using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GenericWebApp.Model.Management
{
    public class ManagementContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<TaskSubType> TaskSubTypes { get; set; }
        public DbSet<TaskObjectType> TaskObjectTypes { get; set; }
        public DbSet<TaskActivity> TaskActivities { get; set; }

        public ManagementContext(DbContextOptions<ManagementContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection", options =>
                    options.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

    [Table("Management_TaskItem")]
    public class TaskItem
    {
        [Key]
        public int? ID { get; set; }

        [MaxLength(500)]
        public string Title { get; set; }

        public string Description { get; set; }

        [MaxLength(10)]
        public string? TaskObjectType_Code { get; set; }

        public int? Task_Object_ID { get; set; }

        public int? TaskActivity_ID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public static GenericWebApp.DTO.Management.TaskItem ParseDTO(GenericWebApp.Model.Management.TaskItem taskItem)
        {
            if (taskItem == null) return null;

            GenericWebApp.DTO.Management.TaskItem dto = new GenericWebApp.DTO.Management.TaskItem
            {
                ID = taskItem.ID,
                Title = taskItem.Title,
                Description = taskItem.Description,
                TaskObjectType_Code = taskItem.TaskObjectType_Code,
                Task_Object_ID = taskItem.Task_Object_ID,
                TaskActivity_ID = taskItem.TaskActivity_ID,
                CreatedDate = taskItem.CreatedDate,
                UpdatedDate = taskItem.UpdatedDate
            };

            return dto;
        }

        public static GenericWebApp.Model.Management.TaskItem ParseModel(GenericWebApp.DTO.Management.TaskItem dto)
        {
            if (dto == null) return null;

            GenericWebApp.Model.Management.TaskItem taskItem = new GenericWebApp.Model.Management.TaskItem
            {
                ID = dto.ID,
                Title = dto.Title,
                Description = dto.Description,
                TaskObjectType_Code = dto.TaskObjectType_Code,
                Task_Object_ID = dto.Task_Object_ID,
                TaskActivity_ID = dto.TaskActivity_ID,
                CreatedDate = dto.CreatedDate,
                UpdatedDate = dto.UpdatedDate
            };

            return taskItem;
        }
    }

    [Table("Management_TaskType")]
    public class TaskType
    {
        [Key]
        [MaxLength(10)]
        public string Code { get; set; }

        public string Description { get; set; }

        public static GenericWebApp.DTO.Management.TaskType ParseDTO(GenericWebApp.Model.Management.TaskType taskType)
        {
            if (taskType == null) return null;

            GenericWebApp.DTO.Management.TaskType dto = new GenericWebApp.DTO.Management.TaskType
            {
                Code = taskType.Code,
                Description = taskType.Description
            };

            return dto;
        }

        public static GenericWebApp.Model.Management.TaskType ParseModel(GenericWebApp.DTO.Management.TaskType dto)
        {
            if (dto == null) return null;

            GenericWebApp.Model.Management.TaskType taskType = new GenericWebApp.Model.Management.TaskType
            {
                Code = dto.Code,
                Description = dto.Description
            };

            return taskType;
        }
    }

    [Table("Management_TaskSubType")]
    public class TaskSubType
    {
        [Key]
        [MaxLength(10)]
        public string Code { get; set; }

        public string Description { get; set; }

        public static GenericWebApp.DTO.Management.TaskSubType ParseDTO(GenericWebApp.Model.Management.TaskSubType taskSubType)
        {
            if (taskSubType == null) return null;

            GenericWebApp.DTO.Management.TaskSubType dto = new GenericWebApp.DTO.Management.TaskSubType
            {
                Code = taskSubType.Code,
                Description = taskSubType.Description
            };

            return dto;
        }

        public static GenericWebApp.Model.Management.TaskSubType ParseModel(GenericWebApp.DTO.Management.TaskSubType dto)
        {
            if (dto == null) return null;

            GenericWebApp.Model.Management.TaskSubType taskSubType = new GenericWebApp.Model.Management.TaskSubType
            {
                Code = dto.Code,
                Description = dto.Description
            };

            return taskSubType;
        }
    }

    [Table("Management_TaskObjectType")]
    public class TaskObjectType
    {
        [Key]
        [MaxLength(10)]
        public string Code { get; set; }

        public string Description { get; set; }

        public static GenericWebApp.DTO.Management.TaskObjectType ParseDTO(GenericWebApp.Model.Management.TaskObjectType taskObjectType)
        {
            if (taskObjectType == null) return null;

            GenericWebApp.DTO.Management.TaskObjectType dto = new GenericWebApp.DTO.Management.TaskObjectType
            {
                Code = taskObjectType.Code,
                Description = taskObjectType.Description
            };

            return dto;
        }

        public static GenericWebApp.Model.Management.TaskObjectType ParseModel(GenericWebApp.DTO.Management.TaskObjectType dto)
        {
            if (dto == null) return null;

            GenericWebApp.Model.Management.TaskObjectType taskObjectType = new GenericWebApp.Model.Management.TaskObjectType
            {
                Code = dto.Code,
                Description = dto.Description
            };

            return taskObjectType;
        }
    }

    [Table("Management_TaskActivity")]
    public class TaskActivity
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(10)]
        public string TaskType_Code { get; set; }

        [MaxLength(10)]
        public string TaskSubType_Code { get; set; }

        public static GenericWebApp.DTO.Management.TaskItem ParseDTO(GenericWebApp.Model.Management.TaskItem taskItem)
        {
            if (taskItem == null) return null;

            GenericWebApp.DTO.Management.TaskItem dto = new GenericWebApp.DTO.Management.TaskItem
            {
                ID = taskItem.ID,
                Title = taskItem.Title,
                Description = taskItem.Description,
                TaskObjectType_Code = taskItem.TaskObjectType_Code,
                Task_Object_ID = taskItem.Task_Object_ID,
                TaskActivity_ID = taskItem.TaskActivity_ID,
                CreatedDate = taskItem.CreatedDate,
                UpdatedDate = taskItem.UpdatedDate
            };

            return dto;
        }

        public static GenericWebApp.Model.Management.TaskItem ParseModel(GenericWebApp.DTO.Management.TaskItem dto)
        {
            if (dto == null) return null;

            GenericWebApp.Model.Management.TaskItem taskItem = new GenericWebApp.Model.Management.TaskItem
            {
                ID = dto.ID,
                Title = dto.Title,
                Description = dto.Description,
                TaskObjectType_Code = dto.TaskObjectType_Code,
                Task_Object_ID = dto.Task_Object_ID,
                TaskActivity_ID = dto.TaskActivity_ID,
                CreatedDate = dto.CreatedDate,
                UpdatedDate = dto.UpdatedDate
            };

            return taskItem;
        }
    }
}
