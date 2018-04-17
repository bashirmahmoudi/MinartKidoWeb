using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MinartKidoWeb.Extenders
{
    public class JsonModelBinder :IModelBinder
    {
        private IJsonAttribute _attribute;
        private Type _targeType;

        public JsonModelBinder(Type type, IJsonAttribute attribute)
        {
            _attribute = attribute as IJsonAttribute;
            _targeType = type ?? throw new ArgumentNullException(nameof(type));
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if(bindingContext == null) throw new ArgumentNullException(nameof(bindingContext));
            // Check the value sent in
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueProviderResult == ValueProviderResult.None) return Task.CompletedTask;
            bindingContext.ModelState.SetModelValue(bindingContext.ModelName,valueProviderResult);
            // Attempt to convert the input value
            var valueAsString = valueProviderResult.FirstValue;
            var result = _attribute.TryConvert(valueAsString, _targeType, out var sucess);
            if (!sucess) return Task.CompletedTask;
            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;

        }
    }
}
