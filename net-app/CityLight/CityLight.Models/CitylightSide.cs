using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CityLight.Models
{
    public class CitylightSide
    {
        public int Id { get; set; }
        public SideType IsMain { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
    }
}
