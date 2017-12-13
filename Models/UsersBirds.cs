using System;

namespace Birdwatcher.Models{
    public class UsersBirds{
        public int ID {get; set; }
        public string Name { get; set; }
        public string Bird { get; set; }
        public string Description {get; set; }
        public string ImageLocation {get; set; }
        public DateTime DateSeen {get; set; }


    }
}