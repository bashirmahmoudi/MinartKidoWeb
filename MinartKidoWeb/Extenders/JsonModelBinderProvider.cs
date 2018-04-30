using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MinartKidoWeb.Extenders
{
    //public class JsonModelBinderProvider : IModelBinderProvider
    //{
    //    public IModelBinder GetBinder(ModelBinderProviderContext context)
    //    {
    //        if(context == null) throw new ArgumentNullException(nameof(context));

    //        if (context.Metadata.IsComplexType)
    //        {
    //            var propName = context.Metadata.PropertyName;
    //            var propInfo = context.Metadata.ContainerType?.GetProperty(propName);
    //            if (propName == null || propInfo == null) return null;

    //            // Look for FromJson Attributes
    //            var attribute = propInfo.GetCustomAttributes(typeof(FromJsonAttribute), false).FirstOrDefault();
    //        }
    //    }
    //}
}
