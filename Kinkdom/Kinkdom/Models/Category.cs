﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinkdom.Models
{
    public class Category
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
