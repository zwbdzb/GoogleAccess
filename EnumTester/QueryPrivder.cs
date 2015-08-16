using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EnumTester
{
    // 接口定义  创建和执行IQueryable对象描述的查询
    public class QueryPrivder : IQueryProvider
    {
        //【 创建查询】 正因为返回 IQueryable ，才可以形成查询链
        public IQueryable CreateQuery(Expression expression)
        {
            // 分析参数 expression，集成进 IQueryable对象的 Expression 属性

            throw new NotImplementedException();
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            throw new NotImplementedException();
        }

        // 【执行查询】
        public object Execute(Expression expression)
        {
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}
