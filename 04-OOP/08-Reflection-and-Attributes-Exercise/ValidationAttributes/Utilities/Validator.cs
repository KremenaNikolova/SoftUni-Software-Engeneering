using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationAttributes.Utilities.Attributes;

namespace ValidationAttributes.Utilities
{
    public class Validator
    {
        public static bool IsValid(object obj) //this obj is our properties which we should check
        {
            Type objType = obj.GetType(); //take the type of the object
            PropertyInfo[] properties = objType
                .GetProperties()
                .Where(p => p.CustomAttributes.Any(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.AttributeType)))
                .ToArray(); //we take all properties and says: give to us only these properties, which custrom attributies to be assignable from base attribute "MyValidationAttribute to be AssignableFrom AttributeType) and we want to take only these attributes where in CustomAttributes collection have at least one custom attribute, which type to be assignable from MyValidationAttribute

            foreach (PropertyInfo property in properties)
            {
                object[] customAttributes = property
                    .GetCustomAttributes()
                    .Where(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.GetType()))
                    .ToArray(); //take these custom attributies which type of this instance is assinabgle from MyValidationAttribute, otherwise we take only these atrributies which are validate! 

                object propertyValue = property.GetValue(obj); //take da value of validate propertie

                foreach (object customAttribute in customAttributes)
                {
                    //custromAttribute is Instance and we can use it with .Invoke
                    MethodInfo isValidMethod = customAttribute.GetType()
                        .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                        .FirstOrDefault(mi => mi.Name == "IsValid"); //find the methos which is Intance and Public and its name is "IsValid"

                    bool result = (bool)isValidMethod.Invoke(customAttribute, new object[] { propertyValue });
                    if (!result)
                    {
                        return false;
                    }
                }

            }
            return true;

        }
    }
}
