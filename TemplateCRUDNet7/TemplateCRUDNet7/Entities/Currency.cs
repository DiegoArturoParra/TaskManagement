using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemplateCRUDNet7.Entities
{
    [Table("CURRENCY", Schema = "QUALA")]
    public partial class Currency
    {
        [Key]
        public Guid Id { get; set; }
        public string Acronym { get; set; }
        public string Description { get; set; }
    }
}
