using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myBookAPI.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id  {get; set;}
        [Required]
        [MaxLength(50)]
        public string Title {get; set;}
        [Required]
        [MaxLength(100)]
        public string Author {get; set;}
        [Required]
        [MaxLength(13)]
        public string Isbn {get; set;}
        [Range(0.01, 999999999)]
        public double Price {get; set;}
        [Range(1,5)]
        public double Rating {get; set;}
        public string CoverUrl {get; set;}
    }
}
