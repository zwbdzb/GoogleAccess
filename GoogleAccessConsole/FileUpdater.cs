using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using  System.IO;

namespace GoogleAccess
{
    public class FileUpdater
    {

        public string FileName { get; set; }

        public   bool  UpdateFile(string txtContent)
        {
            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(@"C:\Windows\System32\drivers\etc\hosts", false);

                sw.Write(txtContent);
                sw.Close();
                return true;
            }
            catch (UnauthorizedAccessException unex)
            {

                return false;
            }
            catch (Exception ex)            // 有可能没有权限去更改hosts文件
            {
                Console.WriteLine(ex.Message);
                return false;
            }
           
           
        }
    }
}
