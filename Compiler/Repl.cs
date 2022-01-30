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
using System;
using Compiler.Lib.Lexer;

namespace Compiler
{
  public class Repl
  {
    const string PROMPT = ">>";

    public void Excute()
    {
      while (true)
      {
        Console.Write(PROMPT);

        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input)) return;

        var lexer = new TokenLexer(input);
        var token = lexer.NextToken();
        while (token.TokenKind != TokenKind.EOF)
        {
          Console.WriteLine($"{{Type: {token.TokenKind.ToString()}, Literal: {token.Literal}}}");
          token = lexer.NextToken();
        }
      }
    }
  }
}