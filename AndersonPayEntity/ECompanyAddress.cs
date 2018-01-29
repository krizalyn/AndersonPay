using BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AndersonPayEntity
{
    [Table("CompanyAddress")]
    public class ECompanyAddress : EBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyAddressId { get; set; }
        public string CompanyAddress { get; set; }


    }
}
