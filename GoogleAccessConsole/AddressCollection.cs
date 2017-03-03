using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleAccess
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
                throw new NotImplementedException();
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
            return this.Collection.LastOrDefault(x => x.Href.StartsWith(@"http://laod.cn/wp-content/uploads"));
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
        public string Text  { get;set; }

        public string Href  {get;set; }

        public override string ToString() => Text.ToString() + "\t" + Href.ToString();
    }

}
