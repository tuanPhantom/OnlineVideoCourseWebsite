﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVideoCourseWebsite.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CourseId { get; set; }
        [MaxLength(80), Required]
        public string Title { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }
        [MaxLength(255)]
        public string ImageUrl { get; set; }
        [MaxLength(255)]
        public string MarqueeImageUrl { get; set; }
        public List<CourseOffering> CourseOfferings { get; set; } = new List<CourseOffering>();
    }
}
