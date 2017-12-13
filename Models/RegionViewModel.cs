using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Birdwatcher.Models{
    public class RegionViewModel{
        public List<Bird> birds;
        public SelectList regions;
        public string birdRegion{get; set;}
        public string birdColor{get; set;}
    }
}