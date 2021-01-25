# command-line-api-sample

## About

An experimental console application testing the capabilities of the [System.CommandLine](https://github.com/dotnet/command-line-api) library. The example application interacts with FaunaDB via two commands to create collections and indexes in a given database.

## Usage

Root command (`fauna-cli`):

```
> dotnet .\FaunaAdmin.Cli.dll
Required command was not provided.

fauna-cli:
  An admin toolset to interact with FaunaDB.

Usage:
  fauna-cli [options] [command]

Options:
  --version         Show version information
  -?, -h, --help    Show help and usage information

Commands:
  create-collection <collectionName> <serverKey>                       Create a collection in a database.
  create-index <indexName> <collectionName> <fieldName> <serverKey>    Create an index for a database.
```

Create collection command (`create-collection`):

```
> dotnet .\FaunaAdmin.Cli.dll create-collection
Required argument missing for command: create-collection
Required argument missing for command: create-collection

create-collection:
  Create a collection in a database.

Usage:
  fauna-cli create-collection [options] <collectionName> <serverKey>

Arguments:
  <collectionName>    Name of the collection.
  <serverKey>         Database server key.

Options:
  -?, -h, --help    Show help and usage information
```

Create index command (`create-index`):

```
> dotnet .\FaunaAdmin.Cli.dll create-index
Required argument missing for command: create-index
Required argument missing for command: create-index
Required argument missing for command: create-index
Required argument missing for command: create-index

create-index:
  Create an index for a database.

Usage:
  fauna-cli create-index [options] <indexName> <collectionName> <fieldName> <serverKey>

Arguments:
  <indexName>         Name of the index to create.
  <collectionName>    Name of the collection.
  <fieldName>         Name of the field to use for the index.
  <serverKey>         Database server key.

Options:
  -?, -h, --help    Show help and usage information
```