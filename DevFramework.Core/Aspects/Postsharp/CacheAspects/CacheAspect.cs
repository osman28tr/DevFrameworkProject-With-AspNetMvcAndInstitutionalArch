using DevFramework.Core.CrossCuttingCorners.Caching;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.Postsharp.CacheAspects
{
    [Serializable]
    public class CacheAspect : MethodInterceptionAspect
    {
        private Type _cacheType;
        private int _cacheByMinute;
        private ICacheManager _cacheManager;
        public CacheAspect(Type cacheType, int cacheByMinute = 60)
        {
            _cacheType = cacheType;
            _cacheByMinute = cacheByMinute;
        }
        public override void RuntimeInitialize(MethodBase method) //ilgili cachemanager'dan instance ürettik.
        {
            if (typeof(ICacheManager).IsAssignableFrom(_cacheType) == false)//gönderilen type bir ICacheManager degilse demek.
            {
                throw new Exception("Wrong Cache Manager");
            }
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);//reflection ile bir instance oluşturduk.

            base.RuntimeInitialize(method);
        }
        public override void OnInvoke(MethodInterceptionArgs args)/*
        metodun içerisine girmeden çalışılacak metot*/
        {
            var methodName = string.Format("{0}.{1}.{2}", args.Method.
                ReflectedType.Namespace,
                args.Method.
                ReflectedType.Name,
                args.Method.Name); /* metodla ilgili bilgileri getiriyor.
            1.parametre:metodun bulunduğu namespace ismi
            2.parametre:metodun bulunduğu class ismi
            3.parametre:metodun ismi*/
            var arguments = args.Arguments.ToList(); //metodun parametrelerini list olarak alıyor.

            var key = string.Format("{0}({1})", methodName,
                string.Join(",", arguments.Select(x => x != null ? x.ToString() : "<Null>")));
            //metot için key oluşturduk.
            if (_cacheManager.IsAdd(key)) //bu metot cache'de varmı
            {
                args.ReturnValue = _cacheManager.Get<object>(key); //cache'de bu key'e ait bir veri varsa bana onu döndür.
            }
            base.OnInvoke(args);
            _cacheManager.Add(key, args.ReturnValue, _cacheByMinute); //cache'de varsa cache'den getir yoksa cache'e ekle.
        }
    }
}
