using BlazorTutorialConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTutorialConsole.Interfaces
{
    public interface IWeapons
    {
        int Add(Weapons obj);
        int Update(Weapons obj);
        int Delete(int id);
        Weapons Get(int id);
        List<Weapons> GetAll();
    }
}
