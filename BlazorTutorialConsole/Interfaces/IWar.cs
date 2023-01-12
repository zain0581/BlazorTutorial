using BlazorTutorialConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTutorialConsole.Interfaces
{
    public interface IWar
    {
        int Add(War obj);
        int Update(War obj);
        int Delete(int id);
        War Get(int id);
        List<War> GetAll();
    }
}
