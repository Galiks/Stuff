using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Logging
{
    public class Logging
    {
        public void WriteLoggingInFile(string text)
        {
            using (StreamWriter file = new StreamWriter("Logging.txt", true, Encoding.Default))
            {
                file.WriteLine($"{text} : {DateTime.Now}");

                file.Close();
            }
        }
    }
}
