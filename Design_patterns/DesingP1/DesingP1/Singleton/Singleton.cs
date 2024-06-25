using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingP1.Singleton
{
    public class Singleton
    {
        private readonly static Singleton _instance = new Singleton();
        //TODO: Creando acceso a la instancia
        public static Singleton Instance
        {
            get
            {
                return _instance;
            }
        }

        //TODO: Constructor privado
        private Singleton(){}
    }
}
