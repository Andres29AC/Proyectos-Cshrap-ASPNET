using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Revenue
{
    public interface IRevenue
    {
        public decimal Revenue(decimal amount);
    }
}
//TODO: Factory pattern
//TODO: Este patron ayuda a crear objetos
//TODO: sin especificar la clase concreta de objeto que se creará.