using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using  System.IO;

namespace FetchNet
{
    public class FileUpdater
    {

        public string FileName { get; set; }

        public   bool  UpdateFile(string txtContent)
        {
           // FileStream stream = File.Create();
            System.IO.StreamWriter sw = new System.IO.StreamWriter(@"C:\Windows\System32\drivers\etc\hosts", false);

            sw.Write(txtContent);
            sw.Close();
            return true;
        }
    }
}
