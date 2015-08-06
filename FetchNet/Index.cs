using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Util;


namespace FetchNet
{
    //    轻量级别的文件下载，添加进启动菜单。
    //    自动更新系统hosts文件，下载地址  http://laod.cn/hosts/2015-google-hosts.html
    class Index
    {
        static void Main(string[] args)
        {
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
