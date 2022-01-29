// Copyright 2022 underdolphin
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Compiler.Lib.Lexer;

namespace Compiler
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var input = @"const:int16 a = 5;";

      var testTokens = new List<Tokens>();
      // const a = 5;
      testTokens.Add(new Tokens(TokenKind.CONST, "const"));
      testTokens.Add(new Tokens(TokenKind.COLON, ":"));
      testTokens.Add(new Tokens(TokenKind.INT16, "int16"));
      testTokens.Add(new Tokens(TokenKind.IDENTIFIER, "a"));
      testTokens.Add(new Tokens(TokenKind.ASSIGNMENT, "="));
      testTokens.Add(new Tokens(TokenKind.INTEGER_LITERAL, "5"));
      testTokens.Add(new Tokens(TokenKind.SEMICOLON, ";"));

      var lexer = new TokenLexer(input);

      foreach (var testToken in testTokens)
      {
        var token = lexer.NextToken();
        Console.WriteLine(token.TokenKind);
        Console.WriteLine(token.Literal);
      }
      return;
    }
  }
}
