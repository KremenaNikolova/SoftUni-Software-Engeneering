using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        //have a method StealFieldInfo which recieve 
        //string – the name of the class to investigate
        //an array of string - names of the fields to investigate


        public string StealFieldInfo(string classInvestigate, params string[] fieldsInvestigate)
        {
            Type classType = Type.GetType(classInvestigate);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();

            object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {classInvestigate}");
            foreach (FieldInfo field in classFields.Where(f=>fieldsInvestigate.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();

        }

    }

    
}
