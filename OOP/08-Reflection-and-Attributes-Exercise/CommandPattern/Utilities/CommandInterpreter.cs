using CommandPattern.Utilities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

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
            Type commandType = assembly.GetTypes().FirstOrDefault(x=>x.Name==commandName);
        }
    }
}
