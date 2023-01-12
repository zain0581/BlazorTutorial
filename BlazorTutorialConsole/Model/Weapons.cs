using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTutorialConsole.Model
{
    public class Weapons
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Samurai Samurai { get; set; }
    
}
}
