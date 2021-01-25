using FaunaDB.Client;
using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using static FaunaDB.Query.Language;

namespace FaunaAdmin.Cli.Commands
{
    public class CreateCollectionCommand : Command
    {
        public const string CommandName = "create-collection";
        public const string CommandDescription = "Create a collection resource.";
        
        public CreateCollectionCommand(string name, string? description = null)
            : base(name, description)
        {
            AddArgument(new Argument<string>("collectionName"));
            AddArgument(new Argument<string>("serverKey"));
            Handler = CommandHandler.Create<string, string>(Execute);
        }

        private void Execute(string collectionName, string serverKey)
        {
            var client = new FaunaClient(serverKey);

            try
            {
                var result = client
                    .Query(
                        CreateCollection(Obj("name", collectionName)), 
                        TimeSpan.FromSeconds(30))
                    .GetAwaiter()
                    .GetResult();
                
                Console.WriteLine(result);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}