using DevFramework.Core.CrossCuttingCorners.Validation.FluentValidation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Postsharp.Aspects
namespace DevFramework.Core.Aspects.Postsharp
{
    //[Serializable]
    public class FluentValidationAspect//:OnMethodBoundaryAspect
    {
        //Type _validatorType;
        //public FluentValidationAspect(Type validatorType)
        //{
        //    _validatorType = validatorType;
        //}
        //public override void OnEntry(MethodExecutionArgs args)
        //{
        //    //var validator = (IValidator)Activator.CreateInstance(_validatorType);
        //    //var entityType = _validatorType.BaseType.GetGenericArguments()[0];//productvalidator'un
        //    ////basetype'ının birinci generic argümanının tipinin ver.
        //    //var entities = args.Arguments.Where(t => t.GetType() == entityType);//birden fazla
        //    ////product gönderilebilir diye hepsini geziyoruz.
        //    ////args:çalıştırılan metot ile ilgili bilgi almamızı sağlar.
        //    //foreach (var entity in entities)
        //    //{
        //    //    ValidatorTool.FluentValidate(validator, entity);
        //    //}
        //}
    }
}
