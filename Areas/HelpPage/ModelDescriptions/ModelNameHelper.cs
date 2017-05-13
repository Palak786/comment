using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Comment.Areas.HelpPage.ModelDescriptions
{
    internal static class ModelNameHelper
    {
        
        public static string GetModelName(Type type)
        {
            ModelNameAttribute modelNameAttribute = type.GetCustomAttribute<ModelNameAttribute>();
            if (modelNameAttribute != null && !String.IsNullOrEmpty(modelNameAttribute.Name))
            {
                return modelNameAttribute.Name;
            }

            string modelName = type.Name;
          
            return modelName;
        }
    }
}