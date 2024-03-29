﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVideoCourseWebsite.Models
{
    public class Video
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long Duration { get; set; }
        public string Thumbnail { get; set; }
        public string URL { get; set; }
        public List<TopicVideo> TopicVideos { get; set; } = new List<TopicVideo>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
