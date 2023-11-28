using Microsoft.EntityFrameworkCore;
using TemplateCRUDNet7.Context;
using TemplateCRUDNet7.Dtos;
using TemplateCRUDNet7.Entities;
using TemplateCRUDNet7.Helpers;
using TemplateCRUDNet7.Repositories.Interfaces;

namespace TemplateCRUDNet7.Repositories
{
    public class TaskUserRepository : ITaskUserRepository
    {
        private readonly TemplateContext _context;
        private readonly IClaimsHelper _claimsHelper;

        public TaskUserRepository(TemplateContext templateContext, IClaimsHelper claimsHelper)
        {
            _context = templateContext;
            _claimsHelper = claimsHelper;
        }


        public async Task<ResponseDto<IEnumerable<TaskDto>>> GetTasksByUser()
        {
            var userId = _claimsHelper.GetUserId();
            var data = await _context.TableTasks.Where(y => y.IsDeleted == false & y.UserId == userId)
                .Select(y => new TaskDto
                {
                    TaskId = y.Id,
                    TaskName = y.NameTask,
                    IsCompleted = y.IsCompleted
                }).ToListAsync();
            return Responses.ResponseSuccess<IEnumerable<TaskDto>>(data);
        }

        public async Task<ResponseDto<TaskDetailDto>> GetDetailTaskByUser(Guid taskId)
        {
            var userId = _claimsHelper.GetUserId();
            var isExist = await _context.TableTasks.AnyAsync(y => y.UserId == userId && y.Id == taskId);
            if (!isExist)
                return Responses.ResponseNotFound<TaskDetailDto>("No se encontro la tarea del usuario.");

            var data = await _context.TableTasks.Where(y => y.IsDeleted == false & y.UserId == userId && y.Id == taskId)
               .Select(y => new TaskDetailDto
               {
                   TaskId = y.Id,
                   DateCreated = y.DateCreated,
                   DateUpdated = y.DateUpdated,
                   Description = y.Description,
                   IsCompleted = y.IsCompleted
               }).FirstOrDefaultAsync();
            return Responses.ResponseSuccess(data);

        }

        public async Task<ResponseDto<Unit>> CreateTask(TaskCreateDto dto)
        {
            try
            {
                var userId = _claimsHelper.GetUserId();
                var entityTask = new Tasks
                {
                    UserId = userId,
                    Description = dto.Description.Trim(),
                    DateCreated = DateTime.Now,
                    IsCompleted = false,
                    NameTask = dto.TaskName,
                };
                var validate = await ValidateDataToCreatedAsync(entityTask);
                if (validate != null)
                    return validate;

                await _context.AddAsync(entityTask);
                await _context.SaveChangesAsync();
                return Responses.ResponseCreated();
            }
            catch (Exception ex)
            {
                return Responses.ResponseInternalErrorServer("Error al crear la tarea del usuario.", ex);
            }
        }



        public async Task<ResponseDto<Unit>> SoftDeleteTask(Guid id)
        {
            try
            {
                var entity = _context.TableTasks.Find(id);
                if (entity is null)
                    return Responses.ResponseNotFound<Unit>("No se encontro la tarea del usuario.");

                entity.IsDeleted = true;
                _context.TableTasks.Update(entity);
                await _context.SaveChangesAsync();
                return Responses.ResponseUpdated("Se ha eliminado satisfactoriamente.");
            }
            catch (Exception ex)
            {
                return Responses.ResponseInternalErrorServer("Error al eliminar la tarea.", ex);
            }
        }



        public async Task<ResponseDto<Unit>> CompletedTask(Guid id)
        {
            try
            {
                var entity = _context.TableTasks.Find(id);
                if (entity is null)
                    return Responses.ResponseNotFound<Unit>("No se encontro la tarea del usuario.");

                entity.IsCompleted = true;
                _context.TableTasks.Update(entity);
                await _context.SaveChangesAsync();
                return Responses.ResponseUpdated("Se ha actualizado satisfactoriamente.");
            }
            catch (Exception ex)
            {
                return Responses.ResponseInternalErrorServer("Error al actualizar.", ex);
            }
        }

        private async Task<ResponseDto<Unit>> ValidateDataToCreatedAsync(Tasks entity)
        {
            List<ErrorDto> errores = new();
            var existNameTask = await _context.TableTasks.AnyAsync(x => x.NameTask.ToUpper() == entity.NameTask.ToUpper() && x.UserId == entity.UserId);

            if (existNameTask)
                errores.Add(new ErrorDto("Ya existe una tarea con el mismo nombre."));

            return errores.Any() ? Responses.ResponseConflict(errores) : null;
        }


    }
}
