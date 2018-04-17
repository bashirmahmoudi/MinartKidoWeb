using System;

namespace MinartKidoWeb.Extenders
{
    public interface IJsonAttribute
    {
        object TryConvert(string modelValue, Type targetType, out bool success);
    }

}