using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumTester
{
    public  class DataSource
    {
        public static List<Name> Names = new List<Name>
            {
                new Name {  Id=1,Sur="A",Age=21},
                new Name {  Id=2,Sur="B",Age=22},
                new Name {  Id=3,Sur="C",Age=22}
            };

        public  DataSource()
        {

        }

        public static  Type  GetDataSourceType()
        {
            return typeof(Name);
        }
    }
}
