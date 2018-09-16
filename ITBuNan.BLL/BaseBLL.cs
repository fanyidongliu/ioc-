using ITBuNan.IBLL;
using System;
using System.Collections.Generic;

namespace ITBuNan.BLL
{
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using ITBuNan.IDAL;
    public class BaseBLL<T>: IBaseBLL<T>
        where T:class
    {
        IBaseDAL<T> dal = null;

        public BaseBLL(IBaseDAL<T> _dal)
        {
            dal = _dal;
        }

        public DbSet<T> DbSet => dal.DbSet;

        public void Add(T model)
        {
            dal.Add(model);
        }

        public List<T> GetAllDatas()
        {
            return dal.GetAllDatas();
        }

        public void Remove(T model, bool isAddedEFContext)
        {
             Remove(model, isAddedEFContext);
        }

        public int SaveChanges()
        {
            return dal.SaveChanges();
        }

        public void Update(T model, string[] propertys)
        {
            dal.Update(model, propertys);
        }

        public List<T> WhereByCondition(Expression<Func<T, bool>> predicate)
        {
            return dal.WhereByCondition(predicate);
        }
    }
}
