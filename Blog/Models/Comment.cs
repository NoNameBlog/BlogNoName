﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Comment
    {
        public Comment()
        {

        }

        public Comment(int postId, string content)
        {
            this.Content = content;
            this.ArticleId = postId;
        }

        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        [ForeignKey("Article")]
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}