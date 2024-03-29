﻿using System;

namespace CityLight.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
