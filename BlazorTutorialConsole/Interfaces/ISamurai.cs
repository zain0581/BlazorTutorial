using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorTutorialConsole.Model;

namespace BlazorTutorialConsole.Interfaces
{
    public interface ISamurai
    {
        int Add(Samurai obj);
        int Update(Samurai obj);
        int Delete(int id);
        Samurai Get(int id);
        List<Samurai> GetAll();


    }
}
