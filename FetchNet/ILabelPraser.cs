using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchNet
{
    // 解析器
    public interface ILabelPraser
    {
        // 等待解析的标签
         string  Label { get; set; }

         AddressCollection Prase<T>(string htmlContent);
    }
}
