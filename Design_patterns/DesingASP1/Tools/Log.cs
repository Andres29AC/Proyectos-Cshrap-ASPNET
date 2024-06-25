namespace Tools
{
    public sealed class Log
    {
        //TODO: sealed sirve para que no se pueda heredar de esta clase

        //TODO: Creando singleton
        private static Log _instance = null;
        private string _path;

        public static Log GetInstance (string path)
        {
            if (_instance == null)
            {
                _instance = new Log(path);
            
            }
            return _instance;
        }
        //TODO: Constructor privado
        private Log(string path)
        {
            _path = path;
        }

        public void save(string message)
        {
            File.AppendAllText(_path, message + Environment.NewLine);
        }

    }
}