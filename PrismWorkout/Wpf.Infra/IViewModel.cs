using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Infra
{
    public interface IViewModel
    {
        IView View { get; set; }

        //In View First Approach this IViewModel will be empty...
    }
}
