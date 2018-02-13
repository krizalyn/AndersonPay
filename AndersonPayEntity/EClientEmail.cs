using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AndersonPayEntity
{
    [Table("ClientEmail")]
    public class EClientEmail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmailId { get; set; }

        public string EmailAddress { get; set; }
    }
}
