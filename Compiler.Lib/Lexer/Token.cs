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

namespace Compiler.Lib.Lexer
{
  public class Token
  {
    public Token(TokenKind kind, string literal)
    {
      this.TokenKind = kind;
      this.Literal = literal;
    }

    public TokenKind TokenKind { get; set; }
    public string Literal { get; set; }

    public static TokenKind LookupIdentifier(string identifier)
    {
      if (Token.Keywords.ContainsKey(identifier))
      {
        return Keywords[identifier];
      }
      return TokenKind.IDENTIFIER;
    }

    public static Dictionary<string, TokenKind> Keywords
      = new Dictionary<string, TokenKind>()
      {
          {"const",TokenKind.CONST},
          {"let",TokenKind.LET},
          {"await",TokenKind.AWAIT},
          {"async",TokenKind.ASYNC},
          {"switch",TokenKind.SWITCH},
          {"when",TokenKind.WHEN},
          {"public",TokenKind.PUBLIC},
          {"private",TokenKind.PRIVATE},
          {"int8",TokenKind.INT8},
          {"int16",TokenKind.INT16},
          {"int32",TokenKind.INT32},
          {"int64",TokenKind.INT64},
          {"float32",TokenKind.FLOAT32},
          {"float64",TokenKind.FLOAT64},
          {"number",TokenKind.NUMBER},
          {"true",TokenKind.TRUE},
          {"false",TokenKind.FALSE},
          {"boolean",TokenKind.BOOLEAN},
      };
  }
}