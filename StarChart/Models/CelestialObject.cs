using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace StarChart.Models
{
    public class CelestialObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        public int? OrbitedObjectId { get; set; }
        [NotMapped]
        public List<CelestialObject> Sattelites { get; set; }
        public TimeSpan OrbitalPeriod { get; set; }



    }
}
