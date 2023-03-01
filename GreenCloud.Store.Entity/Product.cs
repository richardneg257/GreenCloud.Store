using System.ComponentModel.DataAnnotations;

namespace GreenCloud.Store.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string Code { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public int Stock { get; set; }
    }
}
