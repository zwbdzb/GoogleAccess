using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchNet
{
    // 标签类
    public  class Label
    {
        public string LabelName { get; set; }
        public string LabelDesc { get; set; }

        public List<string> LabelAttr { get; set; }
    }

}
