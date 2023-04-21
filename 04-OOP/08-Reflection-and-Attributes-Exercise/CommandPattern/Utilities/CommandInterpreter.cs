using CommandPattern.Utilities.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Utilities
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdArgs = args.Split(' ');
            string commandName = cmdArgs[0];
            string[] commandArgs = cmdArgs.Skip(1).ToArray();

            Assembly assembly = Assembly.GetEntryAssembly();
            Type commandType = assembly.GetTypes().FirstOrDefault(x=>x.Name==$"{commandName}Command");
            MethodInfo commandArgsInfo = commandType.GetMethods(BindingFlags.Public | BindingFlags.Instance).FirstOrDefault(x=>x.Name=="Execute");

            object commandInstance = Activator.CreateInstance(commandType);
            string result = (string)commandArgsInfo.Invoke(commandInstance, new object[] { commandArgs });

            return result;
        }
    }
}
