using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FetchNet
{
    // 数据结构；地址列表
    public class AddressCollection
    {

        public AddressCollection()
        {
            Collection = new List<Address>();
        }
        public List<Address> Collection { get; set; }

        public FileDownLoader FileDownLoader
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        // 按照更新时间排序
        public void SortedByUpdateTime()
        {

        }

        // 根据特定算法  返回最有可能的1个地址
        public Address GetMostPossibleAddress()
        {
            //LINQ  Where 这个竟然不是破坏性的 ？
            this.Collection = this.Collection.Where(m => m.Href.StartsWith(@"http://laod.cn/wp-content/uploads") == true).ToList();

            Console.WriteLine(this.Collection.Last().Text + "\t" + this.Collection.Last().Href);

            return this.Collection.Last();

            // 对的，LINQ Where 本来就不是破坏性的，因为里面应用了装饰模式，具有延迟执行的特性，在查询语句执行之前，本体是不会改变的。这个我们可以仔细看一下装饰模式的设计原理。
        }

        public void GetAllAddress()
        {
            if (Collection != null && Collection.Count > 0)
            {
                Collection.ForEach(m => Console.WriteLine(m.Text + "\t" + m.Href));
            }
        }
    }

    // 地址
    public class Address
    {
        public string Text
        {
            get;
            set;
        }

        public string Href
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Text.ToString() + "\t" + Href.ToString();
        }
    }

}
