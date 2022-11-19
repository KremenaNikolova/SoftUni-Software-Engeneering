using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPatterForJudge
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdArgs = args.Split(' ');
            string commandName = cmdArgs[0];
            string[] commandArgs = cmdArgs.Skip(1).ToArray();

            Assembly assembly = Assembly.GetEntryAssembly(); //взимаме текущият проект/асембли
            Type commandType = assembly.GetTypes().FirstOrDefault(x => x.Name == $"{commandName}Command"); //взимаме типа на командата в текущото асембли
            MethodInfo commandTypeInfo = commandType.GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault(x => x.Name == "Execute"); //проверяваме дали имаме такава команда

            object commandInstance = Activator.CreateInstance(commandType);
            string result = (string)commandTypeInfo.Invoke(commandInstance, new object[] {commandArgs});

            return result;


            //string[] cmdArgs = args.Split(' ');
            //string commandName = cmdArgs[0];
            //string[] commandArgs = cmdArgs.Skip(1).ToArray();

            //Assembly assembly = Assembly.GetEntryAssembly();
            //Type commandType = assembly.GetTypes().FirstOrDefault(x => x.Name == $"{commandName}Command");
            //MethodInfo commandArgsInfo = commandType.GetMethods(BindingFlags.Public | BindingFlags.Instance).FirstOrDefault(x => x.Name == "Execute");

            //object commandInstance = Activator.CreateInstance(commandType);
            //string result = (string)commandArgsInfo.Invoke(commandInstance, new object[] { commandArgs });

            //return result;


        }
    }
}
