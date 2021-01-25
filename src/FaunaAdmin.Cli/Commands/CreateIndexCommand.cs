using FaunaDB.Client;
using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using static FaunaDB.Query.Language;

namespace FaunaAdmin.Cli.Commands
{
    public class CreateIndexCommand : Command
    {
        public const string CommandName = "create-index";
        public const string CommandDescription = "Create an index .";
        
        public CreateIndexCommand(string name, string? description = null) 
            : base(name, description)
        {
            AddArgument(new Argument<string>("indexName"));
            AddArgument(new Argument<string>("collectionName"));
            AddArgument(new Argument<string>("fieldName"));
            AddArgument(new Argument<string>("serverKey"));
            Handler = CommandHandler.Create<string, string, string, string>(Execute);
        }
        
        private void Execute(
            string indexName, 
            string collectionName,
            string fieldName,
            string serverKey)
        {
            var client = new FaunaClient(serverKey);

            try
            {
                var result = client
                    .Query(CreateIndex(Obj(
                        "name", indexName,
                        "source", Collection(collectionName),
                        "terms", Arr(Obj("field", Arr("data", fieldName)))
                    )))
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