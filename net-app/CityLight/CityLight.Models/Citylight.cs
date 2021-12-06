using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CityLight.Models
{
    public class Citylight
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public CitylightLocation Location { get; set; }
        public string Street { get; set; }
        public decimal Latitude { get; set; } 
        public decimal Longitude { get; set; }
        
        [ForeignKey("Side1Id")]
        public CitylightSide Side1 { get; set; }

        [ForeignKey("Side2Id")]
        public CitylightSide Side2 { get; set; }
        
        [ForeignKey("AreaId")]
        public Area Area { get; set; }

    }
}
