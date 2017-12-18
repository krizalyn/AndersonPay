using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonPayEntity
{
    [Table("TypeOfService")]
    public class ETypeOfService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeOfServiceId { get; set; }

        public string Description { get; set; }
        public string Name { get; set; }

        public Collection<EService> Services { get; set; }
    }
}
