using System.ComponentModel.DataAnnotations;

namespace myBookAPI.Models
{
    public class BookForCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string Title {get; set;}
        
        [Required]
        [MaxLength(100)]        
        public string Author {get; set;}
        
        [Required]
        [MaxLength(13)] 
        public string Isbn {get; set;}
        
        [Range(0.01, 999999999, ErrorMessage = "Price must be greater than 0.00")]
        public double Price {get; set;}
        
        [Range(1,5)]
        public double Rating {get; set;}
        public string CoverUrl {get; set;}
    }
}
