﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Comment
    {
        
        public int CommentId { get; set; }

        
        public string UserId { get; set; }
        public User User { get; set; }


        public string CommentText { get; set; }
        public string CommentTitle { get; set; }

    }
}
