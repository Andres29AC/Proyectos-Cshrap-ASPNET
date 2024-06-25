using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesingP1.Singleton
{
    public class Log
    {
        private readonly static Log _instance = new Log();
        private string _path = "log.txt";

        //TODO: Creando acceso a la instancia
        public static Log Instance
        {
            get
            {
                return _instance;
            }
        }

        //TODO: Constructor privado
        private Log() { }
        public void Save(string message)
        {
            File.AppendAllText(_path, message + Environment.NewLine);
        }
    }
}
