using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Util;


namespace FetchNet
{
    //    轻量级别的文件下载，添加进启动菜单[ 或者做成浏览器插件，网页更新提醒插件]
    //    自动更新系统hosts文件，下载地址  http://laod.cn/hosts/2015-google-hosts.html
    class Index
    {
            private　static　void　ExtractResourceToFile(string　resourceName,　string　filename)
　　　　    {
　　　　　　　    if　(!System.IO.File.Exists(filename))
　　　　　　　　　    using　(System.IO.Stream　s　=　System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
　　　　　　　　　    using　(System.IO.FileStream　fs　=　new　System.IO.FileStream(filename,　System.IO.FileMode.Create))
　　　　　　　　　    {
　　　　　　　　　　　　    byte[]　b　=　new　byte[s.Length];
　　　　　　　　　　　　    s.Read(b,　0,　b.Length);
　　　　　　　　　　　　    fs.Write(b,　0,　b.Length);
　　　　　　　　    }
　　　　    }

        static void Main(string[] args)
        {

            ExtractResourceToFile("Winista.HtmlParser", Environment.CurrentDirectory + "\\Winista.HtmlParser.dll");

            //*****************************

            var downLoader = new FileDownLoader
            {
                HostAddress = "http://laod.cn/hosts/2015-google-hosts.html"
            };

            downLoader.FileDownLoad();

            var parser = new CommonLabelPraser();
            var col = downLoader.LabelPrase<ATag>(parser);

            Address addr = col.GetMostPossibleAddress();

            downLoader.HostAddress = addr.Href;
            downLoader.FileDownLoad();

            Console.WriteLine(downLoader.HtmlContent);

            var updater = new FileUpdater();
            updater.UpdateFile(downLoader.HtmlContent);

            Console.ReadKey();

        }
    }
}
