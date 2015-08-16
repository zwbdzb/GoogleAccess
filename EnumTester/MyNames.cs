using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EnumTester
{
    //  必须具有延迟执行的特性
    public class MyNames<T> : IQueryable<T>  where T : new()
    {
        // 延迟查询的结果
        public List<T> names = new List<T>();
        public Expression _Expression = null;

        public MyNames()
        { 
         
        }

        public Type ElementType
        {
            get
            {
                return     DataSource.GetDataSourceType();
            }
        }

        public Expression Expression
        {
            get
            {
                throw null;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return new QueryPrivder();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            List<T>  names  = this.Provider.Execute(this.Expression)  as  List<T>;

            return   names.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
