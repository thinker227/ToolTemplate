using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;

RootCommand rootCommand = new()
{
	Name = "ToolTemplate",
	Description = "The root command"
};

Argument<string> nameArgument = new()
{
	Name = "name",
	Description = "The name of the person to greet"
};
rootCommand.AddArgument(nameArgument);

#if (async)
rootCommand.SetHandler(async (name) =>
#else
rootCommand.SetHandler((name) =>
#endif
{
	Console.WriteLine($"Hello, {name}!");
},
	nameArgument);

CommandLineBuilder builder = new(rootCommand);

builder.UseDefaults();

var parser = builder.Build();

#if (async)
return await parser.InvokeAsync(args);
#else
return parser.Invoke(args);
#endif
