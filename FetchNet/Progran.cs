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
    class Progran
    {
          

        static void Main(string[] args)
        {

            var downLoader = new FileDownLoader
            {
                HostAddress = "http://laod.cn/hosts/2015-google-hosts.html"
            };

            Console.WriteLine("开始检索hosts文件，请稍等...");
            var watcher = new System.Diagnostics.Stopwatch();
            watcher.Start();
            downLoader.FileDownLoad();
            watcher.Stop();
            Console.WriteLine("下载用时：" + watcher.Elapsed);

            var parser = new CommonLabelPraser();
            
            watcher.Reset();
            watcher.Start();
            var col = downLoader.LabelPrase<ATag>(parser);
            watcher.Stop();
            Console.WriteLine("解析用时：" + watcher.Elapsed);


            Address addr = col.GetMostPossibleAddress();

            downLoader.HostAddress = addr.Href;
            Console.WriteLine(downLoader.HostAddress);
            Console.WriteLine("即将下载hosts文件");

            watcher.Reset();
            watcher.Start();
            downLoader.FileDownLoad();
            var updater = new FileUpdater();
            updater.UpdateFile(downLoader.HtmlContent);
            watcher.Stop();
            Console.WriteLine("下载并替换用时：" + watcher.Elapsed );

            Console.WriteLine("更新本地hosts文件完成");

            Console.ReadKey();

        }
    }
}
