using System;
using Xunit;
using Compiler.Lib.Parse;
using Irony.Parsing;

namespace Compiler.Tests;

public class ParseTest
{
    [Fact]
    public void Test1()
    {
        string src = "[a]";
        var grammar = new ChrysanthemumGrammar();
        var parser = new Parser(grammar);

        var parsedTree = parser.Parse(src);
        Console.WriteLine(parsedTree.ParserMessages);
    }
}