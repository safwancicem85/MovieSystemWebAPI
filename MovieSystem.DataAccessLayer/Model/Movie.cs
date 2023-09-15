using System.ComponentModel.DataAnnotations;

namespace MovieSystem.DataAccessLayer.Model
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }
        [Required]
        [Range(0,10)]
        public decimal Rating { get; set; }
        public string Image { get; set; }
        public int Duration { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
