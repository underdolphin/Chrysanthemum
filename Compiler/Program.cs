using System;
using Compiler.Lib.Parse;
using Irony.Parsing;

namespace Compiler
{
  public class Program
  {
    public static void Main(string[] args)
    {
      string src = "[a]";
      var grammar = new ChrysanthemumGrammar();
      var parser = new Parser(grammar);

      var parsedTree = parser.Parse(src);
      Console.WriteLine(parsedTree.ParserMessages);
    }
  }
}
