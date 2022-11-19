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
            Type commandType = assembly.GetTypes().FirstOrDefault(x => x.Name == $"{commandName}Command"); //проверяваме дали имаме такава команда, запазва се типа на желаната комада HelloCommand/ExitCommand, командата, която отговаря на патърна $"{commandName}Command"
            MethodInfo commandTypeInfo = commandType.GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault(x => x.Name == "Execute"); //тук търсим метода, който е инстанционен (BindingFlags.Instance) и е публичен (BindingFlags.Public) и трябва да се казва "Execute" ---> (x => x.Name == "Execute")

            object commandInstance = Activator.CreateInstance(commandType); //създаваме инстанция на командата с активатора, която е обект

            string result = (string)commandTypeInfo.Invoke(commandInstance, new object[] {commandArgs}); // тъй като MethodInfo, не е свързано с инстанция, за да го извикаме, викаме .Invoke, като Invoke приема 2 неща: инстанцията,от която искаме да викаме метода (commandInstance) и аргументите, като аргументите винаги се подават в objext[] {} (new object[] {commandArgs}).
            

            return result;
        }
    }
}
