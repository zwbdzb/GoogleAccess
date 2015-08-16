using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace TreeSearch
{

    public class Program
    {
        public static ArrayList al = new ArrayList();

        [Conditional("DEBUG")]
        static void Mainaa(string[] args)
        {

            // 获取所有文件
            GetAllFiles(@"F:\Workplace\FetchNet\FetchNet");

            foreach (var ii in al)
            {
                Console.WriteLine(ii);
            }

            Console.WriteLine("以上是所有文件,数量" + al.Count);

            // 获取文件中含有某个属性的最外层文件夹

            List<object> dirs = new List<object>();

            foreach (var ii in al)
            {
                var filename = ((dynamic)ii).FileName;                     //  使用动态表达式
                var fileclass = ((dynamic)ii).FileClass;
                FileInfo info = new FileInfo(filename);
                if (info.Name.Length > 15)
                {
                    dirs.Add(new { Name = filename, Class = fileclass });
                }
            }

            foreach (var ii in dirs)
            {
                string filename = ((dynamic)ii).Name.ToString();                     //  使用动态表达式
                string fileclass = ((dynamic)ii).Class.ToString();

                Debug.WriteLine(filename + "\t" + fileclass);
            }

            //   dirs.ForEach(m => Debug.WriteLine(((dynamic)m).Name + ((dynamic)m).Class ));
            Debug.WriteLine("数量是" + dirs.Count);


            List<dynamic>  ss  =  dirs.Select(m => (((dynamic) m).Class).ToString()).Distinct().ToList();

            
            foreach (var ii  in  ss)
            {
                string fileclass = ((dynamic)ii).ToString();

                Console.WriteLine(fileclass );
            }

            Console.ReadKey();
        }

        // 获取所有的文件
        public static void GetAllFiles(string strBaseDir)
        {

            DirectoryInfo di = new DirectoryInfo(strBaseDir);

            //  取得目录
            DirectoryInfo[] diA = di.GetDirectories();
            //  取得文件
            FileInfo[] files = di.GetFiles();

            for (int i = 0; i < files.Length; i++)
            {
                string ss = files[i].FullName.Replace(@"F:\Workplace\FetchNet\FetchNet", "").TrimStart('\\');

                int   j   = ss.IndexOf("\\");
                string fileClass = j > 0 ? ss.Substring(0, j) : "..";
                al.Add(new
                {
                    FileName = files[i].FullName,
                    FileClass = fileClass        // .Trim().
                });
            }

            // 如果是目录
            for (int i = 0; i < diA.Length; i++)
            {

                GetAllFiles(diA[i].FullName);
            }

        }

    }
}
