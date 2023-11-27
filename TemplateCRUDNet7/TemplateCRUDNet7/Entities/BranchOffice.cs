using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemplateCRUDNet7.Entities
{
    [Table("BRANCH_OFFICES", Schema = "QUALA")]
    public partial class BranchOffice : SoftDeleteEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int Code { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        [Required]
        [StringLength(250)]
        public string Address { get; set; }
        [Required]
        [StringLength(50)]
        public string Identification { get; set; }
        [Required]
        [StringLength(250)]
        public string Description { get; set; }
        public Guid CurrencyId { get; set; }
        public Currency TypeCurrency { get; set; }
    }
}