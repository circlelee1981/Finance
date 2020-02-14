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
    public class UserService
    {
        protected readonly FinanceContext financeContext;

        public UserService(FinanceContext financeContext)
        {
            this.financeContext = financeContext;
        }

        public async Task AddAsync(User user)
        {
            //throw new NotImplementedException();
            financeContext.Set<User>().Add(user);
            await financeContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(params User[] users)
        {
            financeContext.Set<User>().AddRange(users);
            await financeContext.SaveChangesAsync();
        }

        public async Task EditAsync(User user)
        {
            financeContext.Entry<User>(user).State = EntityState.Modified;
            await financeContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var t = new User() { ID = id };

            //t.IsRemoved = true;
            //financeContext.Entry<T>(t).State = EntityState.Modified;
            //上面这个写法有问题, 要用下面写法
            //为啥上面不行? 因为下面写法中先挂上追踪, 再更改, ef会自动追踪到是哪个属性修改了, 到时只改那个属性
            //而如果像上面注释掉的部分的话, ef只能认为全部属性都要更改, 这就出问题了, 全部改, 效率出事了, 值也不对

            financeContext.Entry<User>(t).State = EntityState.Unchanged;
            t.IsRemoved = true;

            await financeContext.SaveChangesAsync();

            //这样的t本来根本不是数据库查出来的, 为什么它能有效? 因为ef会根据主键, 对应进行映射操作
        }

        public IQueryable<User> GetAll() //这里不用async了, 因为最终不生成sql语句不与数据库打交道, 
        {
            return financeContext.Set<User>().Where(x => x.IsRemoved == false).AsNoTracking();
            //AsNoTracking, 意味着查出来的多个对象, state都是detached状态, 否则的话是unchanged状态
            //对于detached的对象, 无论你怎么改, 只要不改动state, 就不会更新到数据库, 
            //但是unchanged对象只要一动, 马上变成modify等状态, savechange就会更新到数据库
        }

        public IQueryable<User> GetWhere(Expression<Func<User, bool>> predicate)
        {
            return this.GetAll().Where(predicate).AsNoTracking();
            //注意AsNoTracking的运用
        }

        public async Task<User> GetOneAsync(int id) //为啥加virtual? 因为多对多中间模型要干掉它
        {
            return await this.GetWhere(x => x.ID == id).FirstOrDefaultAsync();
            //这里要用到AsNoTracking吗? 感觉不用了, 因为前面getwhere里已经asnotracking了
        }



    }
}
