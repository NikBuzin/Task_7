using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManager
{
   public class Reader
   {
        public string ReadFile(string fileName)
        {
            string r = File.ReadAllText(fileName);
            return r;
        }
   }
}
