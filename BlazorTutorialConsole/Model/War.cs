using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTutorialConsole.Model
{
   public class War
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public List<Samurai> Samurais { get; set; }
    }
}
