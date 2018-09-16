using Autofac;
using ITBuNan.DAL;
using ITBuNan.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace ITBuNan.DALContainer
{
    public class Container
    {
        /// <summary>
        /// IOC 容器
        /// </summary>
        public static IContainer container = null;

       

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialise()
        {
            var builder = new ContainerBuilder();
            //格式：builder.RegisterType<xxxx>().As<Ixxxx>().InstancePerLifetimeScope();

            //var ass = Assembly.Load("EMS11.Site");
            //builder.RegisterControllers(ass);

            builder
                .RegisterGeneric(typeof(BaseDAL<>))  //注册泛型类BaseDal<> 的类型
                .As(typeof(IBaseDAL<>))                     //强制转换成 IBaseDal<> 的类型
                .InstancePerDependency();                 //每一次HTTP的请求都创建一个新的BaseDal<> 类的实体



            //builder.RegisterType<typeof(BaseDAL<>)>().As<IBaseDAL<>>().InstancePerLifetimeScope();
            //container = builder.Build();
        }
    }
}