using System;
using System.Collections.Generic;
namespace ITBuNan.IDAL
{

    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    
    public interface IBaseDAL<T>
        where T:class
    {
        List<T> GetAllDatas();

        DbSet<T> DbSet { get; }
        List<T> WhereByCondition(Expression<Func<T, bool>> predicate);
        void Add(T model);

        void Update(T model, string[] propertys);

        void Remove(T model, bool isAddedEFContext);

        int SaveChanges();

    }
}
