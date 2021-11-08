using System;
using System.Collections.Generic;
using System.Text;

namespace CityLight.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string FullName { get; set; }
        public string ContactPerson { get; set; }
        public string Phone { get; set; }
        public string Comment { get; set; }
    }
}
