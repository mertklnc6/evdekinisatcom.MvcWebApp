﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp.Entity.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
