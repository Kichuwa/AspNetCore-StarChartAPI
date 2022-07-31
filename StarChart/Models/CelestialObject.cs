using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace StarChart.Models
{
    public class CelestialObject
    {
        public int Id;
        [Required(ErrorMessage = "Name is Required")]
        public string Name;
        public int? OrbitedObjectId;
        [NotMapped]
        public List<CelestialObject> Sattelites;
        public TimeSpan OrbitalPeriod;



    }
}
