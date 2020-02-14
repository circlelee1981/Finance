using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finance.Models;
using Finance.Models.Users;

using System.Data.Entity;
using System.Linq.Expressions;

namespace Finance.DAL
{
    public abstract class BaseService<T> where T : BaseModel, new ()
    {
        protected readonly FinanceContext financeContext;

        public BaseService(FinanceContext financeContext) //未来可通过依赖注入搞进context, 这样让service自动管理context的周期
        {
            this.financeContext = financeContext;
        }
        
        public async Task AddAsync(T t)
        {
            //throw new NotImplementedException();
            financeContext.Set<T>().Add(t);
            await financeContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(params T[] t)
        {
            financeContext.Set<T>().AddRange(t);
            await financeContext.SaveChangesAsync();
        }

        public async Task EditAsync(T t)
        {
            financeContext.Entry<T>(t).State = EntityState.Modified;
            await financeContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var t = new T (){ ID = id};

            //t.IsRemoved = true;
            //financeContext.Entry<T>(t).State = EntityState.Modified;
            //上面这个写法有问题, 要用下面写法
            //为啥上面不行? 因为下面写法中先挂上追踪, 再更改, ef会自动追踪到是哪个属性修改了, 到时只改那个属性
            //而如果像上面注释掉的部分的话, ef只能认为全部属性都要更改, 这就出问题了, 全部改, 效率出事了, 值也不对

            financeContext.Entry<T>(t).State = EntityState.Unchanged;
            t.IsRemoved = true;

            await financeContext.SaveChangesAsync();

            //这样的t本来根本不是数据库查出来的, 为什么它能有效? 因为ef会根据主键, 对应进行映射操作
        }

        public IQueryable<T> GetAll() //这里不用async了, 因为最终不生成sql语句不与数据库打交道, 
        {
            return financeContext.Set<T>().Where(x => x.IsRemoved == false).AsNoTracking();
            //AsNoTracking, 意味着查出来的多个对象, state都是detached状态, 否则的话是unchanged状态
            //对于detached的对象, 无论你怎么改, 只要不改动state, 就不会更新到数据库, 
            //但是unchanged对象只要一动, 马上变成modify等状态, savechange就会更新到数据库
        }

        public  IQueryable<T> GetWhere(Expression<Func<T,bool>> predicate)
        {
            return this.GetAll().Where(predicate).AsNoTracking();
            //注意AsNoTracking的运用
        }

        public virtual async Task<T> GetOneAsync(int id) //为啥加virtual? 因为多对多中间模型要干掉它
        {
            return await this.GetWhere(x => x.ID == id).FirstOrDefaultAsync();
            //这里要用到AsNoTracking吗? 感觉不用了, 因为前面getwhere里已经asnotracking了
        }



    }

}
