using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Util;

namespace FetchNet
{
    public class FileDownLoader                 // 泛型类声明的写法<T>, 约束泛型参数T
    {      
        public string HostAddress { get; set; }
        internal string HtmlContent { get; set; }

        // 下载文件
        public void FileDownLoad()
        {
            var web = new WebClient();
            var byteData = web.DownloadData(HostAddress);
            var str = Encoding.UTF8.GetString(byteData);
            HtmlContent = str;
            Debug.WriteLine(HtmlContent);
        }

        // 解析文件中的T 标签 [ 算法设计模式]  还是用泛型函数算了
        public AddressCollection LabelPrase<T>(ILabelPraser praser) where T : Winista.Text.HtmlParser.ITag
        {
            return   praser.Prase<T>(HtmlContent);   
        }
    }
}


/*
 where 泛型类型约束，约束T必须是某个接口，基类，还可以做到构造函数约束。
 
 
 */