using TemplateCRUDNet7.Dtos;
using TemplateCRUDNet7.Entities;
using TemplateCRUDNet7.Helpers;

namespace TemplateCRUDNet7.Repositories.Interfaces
{
    public interface ITaskUserRepository
    {
        Task<ResponseDto<IEnumerable<TaskDetailDto>>> GetTasksByUser();
        Task<ResponseDto<Unit>> CreateTask(TaskCreateDto entity);
        Task<ResponseDto<Unit>> SoftDeleteTask(Guid id);
        Task<ResponseDto<Unit>> CompletedTask(Guid id);
    }
}