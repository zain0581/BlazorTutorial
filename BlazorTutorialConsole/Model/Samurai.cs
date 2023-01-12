using BlazorTutorialConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTutorialConsole.Model
{
    public class Samurai
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
        public Horse Horse { get; set; }

        public Weapons weapon { get; set; }

        public War Wars { get; set; }

    }
}
