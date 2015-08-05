using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchNet
{
    //    自动更新系统hosts文件，下载地址  http://laod.cn/hosts/2015-google-hosts.html
    class Index
    {
        static void Main(string[] args)
        {

            var Alabel = new Label { LabelName="A",LabelDesc="链接",LabelAttr =  new  List<string> { "href"}};

            var downLoader = new FileDownLoader<Label>
            {
                CareLabel = Alabel, 
                HostAddress = "http://laod.cn/hosts/2015-google-hosts.html"
            };

            downLoader.FileDownLoad();

            var  parser  = new  CommonLabelPraser();
            var  col  =  downLoader.LabelPrase(parser);

            Address  addr=  col.GetMostPossibleAddress();



            Console.ReadKey();

        }
    }
}
