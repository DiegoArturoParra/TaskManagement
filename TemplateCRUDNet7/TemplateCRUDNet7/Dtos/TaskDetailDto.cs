using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TemplateCRUDNet7.Dtos
{
    public class TaskDto
    {
        public Guid TaskId { get; set; }
        public string TaskName { get; set; }
        public bool IsCompleted { get; set; }
        public string TextCompleted => IsCompleted ? "Tarea completada." : "Tarea faltante.";
    }
    public class TaskDetailDto
    {
        public Guid TaskId { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        [JsonIgnore]
        public DateTime DateCreated { get; set; }
        [JsonIgnore]
        public DateTime? DateUpdated { get; set; }
        public string DateCreatedString => DateCreated.ToString("dd/MM/yyyy");
        public string DateUpdatedString => DateUpdated.HasValue ? DateUpdated.Value.ToString("dd/MM/yyyy") : "N/A";
    }
    public record TaskCreateDto([Required][MaxLength(250)] string Description, [Required][MaxLength(150)] string TaskName);
    public record TaskIsCompletedDto(Guid TaskId);
    public record TaskUpdateDto(Guid TaskId, [Required][MaxLength(250)] string Description, [Required][MaxLength(150)] string TaskName);
}
