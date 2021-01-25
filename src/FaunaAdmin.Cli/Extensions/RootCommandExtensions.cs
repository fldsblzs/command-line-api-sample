using System;
using System.CommandLine;
using System.Linq;

namespace FaunaAdmin.Cli.Extensions
{
    public static class RootCommandExtensions
    {
        public static RootCommand AddCommands(this RootCommand rootCommand)
        {
            var commandIdentity = typeof(Command);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(t => t.BaseType == commandIdentity && t != typeof(RootCommand));

            foreach (var type in types)
            {
                var name = type.GetField("CommandName").GetValue(null);
                var description = type.GetField("CommandDescription").GetValue(null);
                var instance = (Command)Activator.CreateInstance(type, name, description);
                
                rootCommand.AddCommand(instance);
            }

            return rootCommand;
        }
    }
}