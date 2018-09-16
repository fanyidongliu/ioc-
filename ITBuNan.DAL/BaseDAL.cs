using System;
using System.Collections.Generic;

namespace ITBuNan.DAL
{

    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using ITBuNan.IDAL;

    public class BaseDAL<T>: IBaseDAL<T>
        where T:class
    {

        public BaseDbContext DB
        {
            get
            {
                //CallContext 负责缓存当前线程中的EF容器对象
                object efContext = System.Runtime.Remoting.Messaging.CallContext.GetData(typeof(BaseDbContext).FullName);
                //如果EF容器没有被缓存则要创建，将创建好的实体对象存入CallContext中管理
                if (efContext == null)
                {
                    BaseDbContext _db = new BaseDbContext();
                    System.Runtime.Remoting.Messaging.CallContext.SetData(typeof(BaseDbContext).FullName, _db);
                    efContext = _db;
                }
                //将EF上下文容器返回
                return efContext as BaseDbContext;
            }
        }

        public DbSet<T> DbSet { get => dbSet;  }

        DbSet<T> dbSet;

        public BaseDAL()
        {
            dbSet = DB.Set<T>();

        }
        /// <summary>
        /// 查询整张表数据
        /// </summary>
        /// <returns></returns>
        public List<T> GetAllDatas()
        {
            return dbSet.ToList();
        }

        /// <summary>
        /// 根据条件查询对应表的符合条件的数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<T> WhereByCondition(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public void Add(T model)
        {
            dbSet.Add(model);
        }

        /// <summary>
        /// 负责自定义实体和指定了具体要更新的字段
        /// </summary>
        public void Update(T model, string[] propertys)
        {
            if (propertys == null || propertys.Length == 0)
            {
                throw new Exception("当前更新的实体必须至少指定一个字段名称");
            }

            //1.0 关闭EF的 实体验证检查
            DB.Configuration.ValidateOnSaveEnabled = false;

            //2.0 将实体手工追加到EF容器中
            DbEntityEntry entry = DB.Entry(model);
            //3.0 将EF容器中当前实体的代理类状态修改成Unchanged
            entry.State = EntityState.Unchanged;
            //4.0 遍历用户传入的属性数值，将代理类中的属性对应的IsModified设置成true
            foreach (var item in propertys)
            {
                entry.Property(item).IsModified = true;
            }
        }

        #region 6.0 删除

        public void Remove(T model, bool isAddedEFContext)
        {
            //表示当前model未追加到EF上下文容器
            if (isAddedEFContext == false)
            {
                dbSet.Attach(model);
            }
            //将EF容器中当前实体对于的代理类状态修改成deleted
            dbSet.Remove(model);
        }

        #endregion

        #region 7.0 统一遍历当前EF容器执行保存操作

        public int SaveChanges()
        {
            return DB.SaveChanges();
        }

        #endregion

    }
}
