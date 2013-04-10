﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TargetMvcApplication.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}