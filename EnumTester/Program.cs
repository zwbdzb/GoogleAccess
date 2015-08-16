using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumTester
{
    public  class  Name
    {
        public int Id { get; set; }
        public string Sur { get; set; }
        public int  Age { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {

            IEnumerable<Name> names = GetNames();
            foreach (var name in names)             // 常规方式实现IEnumerable接口的类： 查找IEnumerable的GetEnumerator方法，得到迭代器，然后编译器隐式使用迭代器迭代。
                name.Sur = "Jim";
           
            foreach (var name in names)
                Console.WriteLine(name.Sur);
            // won't output "Jim"
        }

        // 遵照博文的配置 模拟差异
        public  static  IEnumerable<Name> GetNames()
        {
            // .net以常规方式实现IEnumerable 接口的迭代集合类names
            List<Name> names = new List<Name>
            {
                new Name {  Id=1,Sur="A",Age=21},
                new Name {  Id=2,Sur="B",Age=22},
                new Name {  Id=3,Sur="C",Age=22}
            };

            //   先显示常规方式实现 IEnumerable 接口的迭代集合类
            MyNames<Name> mynames = new MyNames<Name>();

            
            return names.AsQueryable<Name>();
        }
    }
}
