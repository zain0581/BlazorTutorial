using BlazorTutorialConsole.Interfaces;
using BlazorTutorialConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTutorialConsole.Repositories
{
    internal class Step2 : IExample
    {
        /// <summary>
        /// Returns hardcoded data
        /// </summary>
        public List<Horse> getAllHorses()
        {
            List<Horse> result = new List<Horse>();
            result.Add(new Horse { Id = 1, Name = "acing"}); 
            result.Add(new Horse { Id = 2, Name = "B" });
            result.Add(new Horse { Id = 3, Name = "ha" });
            return result;
        }
    }
}
