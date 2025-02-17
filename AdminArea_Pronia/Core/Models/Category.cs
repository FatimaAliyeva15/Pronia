﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminArea_ProniaCore.Models
{
    public class Category: BaseEntity
    {
        [Required(ErrorMessage = "Duzgun doldur")]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
