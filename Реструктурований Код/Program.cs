var builder = new StructuredTextBuilder("My Title")
    .UseRenderer(new PlainTextRenderer())
    .AddParagraph("Hello, world!", " More text.")
    .AddList(false, new[]{ new[]{ "Item 1" } }, new[]{ new[]{ "Item 2" } });

var output = builder.Build();
Console.WriteLine(output);
