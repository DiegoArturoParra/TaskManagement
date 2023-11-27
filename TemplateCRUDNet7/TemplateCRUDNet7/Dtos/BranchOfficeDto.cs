using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TemplateCRUDNet7.Dtos
{
    public class BranchOfficeDto
    {
        public Guid BranchOfficeId { get; set; }
        public string Description { get; set; }
        public int Code { get; set; }
    }
    public class BranchDetailOfficeDto
    {
        public Guid BranchOfficeId { get; set; }
        public string Identification { get; set; }
        public int Code { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string CurrencyDescription { get; set; }
        public Guid CurrencyId { get; set; }
        [JsonIgnore]
        public DateTime DateCreated { get; set; }
        [JsonIgnore]
        public DateTime? DateUpdated { get; set; }
        public string DateCreatedString => DateCreated.ToString("dd/MM/yyyy");
        public string DateUpdatedString => DateUpdated.HasValue ? DateUpdated.Value.ToString("dd/MM/yyyy") : "N/A";
    }
    public record BranchOfficeCreateDto([Required][MaxLength(250)] string Description, [Required][MaxLength(250)] string Address,
        [Required][MaxLength(50)] string Identification, [Required] int Code, [Required] Guid CurrencyId);
    public record BranchOfficeUpdateDto(Guid BranchOfficeId, [Required][MaxLength(250)] string Description, [Required][MaxLength(250)] string Address,
        [Required][MaxLength(50)] string Identification, [Required] int Code, [Required] Guid CurrencyId);
}
