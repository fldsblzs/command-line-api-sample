using FaunaAdmin.Cli.Extensions;
using System.CommandLine;
using System.Threading.Tasks;

namespace FaunaAdmin.Cli
{
    internal static class Program
    {
        private static async Task<int> Main(string[] args)
        {
            var rootCommand = new RootCommand
            {
                Name = "fauna-cli",
                Description = "An admin toolset to interact with FaunaDB."
            };

            rootCommand.AddCommands();
            
            return await rootCommand.InvokeAsync(args);
        }
    }
}