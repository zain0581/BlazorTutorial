using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorTutorialConsole.Model;

namespace BlazorTutorialConsole.Interfaces
{
    public interface IHorse
    {
        int Add(Horse obj);
        int Update(Horse obj);
        int Delete(int id);
        Horse Get(int id);
        List<Horse> GetAll();
    }
}
