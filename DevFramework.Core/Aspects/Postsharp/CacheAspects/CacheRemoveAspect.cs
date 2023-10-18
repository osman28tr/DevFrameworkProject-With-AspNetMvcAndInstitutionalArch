using DevFramework.Core.CrossCuttingCorners.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.Postsharp.CacheAspects
{
    //[Serializable]
    public class CacheRemoveAspect//:OnMethodBoundaryAspect
    {
        private string _pattern;
        private Type _cacheType;
        private ICacheManager _cacheManager;
        public CacheRemoveAspect(Type cacheType)
        {
            _cacheType = cacheType;
        }
        public CacheRemoveAspect(string pattern,Type cacheType)
        {
            _cacheType = cacheType;
            _pattern = pattern;
        }
    //    public override void RuntimeInitialize(MethodBase method) ilgili cachemanager'dan instance ürettik.
    ////    {
    ////        if (typeof(ICacheManager).IsAssignableFrom(_cacheType)==false)//gönderilen type bir ICacheManager degilse demek.
    ////        {
    ////            throw new Exception("Wrong Cache Manager");
    ////        }
    ////        _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);//reflection ile bir instance oluşturduk.

    //    //        base.RuntimeInitialize(method);
    //    //    }
        //public override void OnSuccess(MethodExecutionArgs args)//ekleme silme işlemleri başarılı olduğunda cache'den datayı sil.
        //{
        //    _cacheManager.RemoveByPattern(string.IsNullOrEmpty(_pattern)
        //        ? string.Format("{0}.{1}.*", args.Method.ReflectedType.Namespace, args.Method.ReflectedType.Name)
        //        :_pattern);//gönderilen pattern null ise o namespacedeki ve classı ilgilendiren bütün cache'i sil.

        //}
    }
}
