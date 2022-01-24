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
  public class TokenLexer
  {
    public string Input { get; set; }
    public int Position { get; set; }
    public char NextChar { get; set; }
    public char CurrentChar { get; set; }

    public TokenLexer(string input)
    {
      this.Input = input;
      this.ReadChar();
    }

    private void ReadChar()
    {
      if (this.Position >= this.Input.Length)
      {
        this.CurrentChar = (char)0;
      }
      else
      {
        this.CurrentChar = this.Input[this.Position];
      }

      if (this.Position + 1 >= this.Input.Length)
      {
        this.NextChar = (char)0;
      }
      else
      {
        this.NextChar = this.Input[this.Position + 1];
      }

      Position += 1;
    }

    public Tokens NextToken()
    {
      this.SkipWhitespace();
      Tokens token = new Tokens(TokenKind.ILLEGAL, this.CurrentChar.ToString());
      switch (this.CurrentChar)
      {
        case '{':
          token = new Tokens(TokenKind.OPEN_BRACE, this.CurrentChar.ToString());
          break;
        case '}':
          token = new Tokens(TokenKind.CLOSE_BRACE, this.CurrentChar.ToString());
          break;
        case '[':
          token = new Tokens(TokenKind.OPEN_BRACKET, this.CurrentChar.ToString());
          break;
        case ']':
          token = new Tokens(TokenKind.CLOSE_BRACKET, this.CurrentChar.ToString());
          break;
        case '(':
          token = new Tokens(TokenKind.OPEN_PAREN, this.CurrentChar.ToString());
          break;
        case ')':
          token = new Tokens(TokenKind.CLOSE_PAREN, this.CurrentChar.ToString());
          break;
        case '.':
          if (this.NextChar == '.')
          {
            token = new Tokens(TokenKind.OP_RANGE, "..");
            this.ReadChar();
          }
          else
          {
            token = new Tokens(TokenKind.DOT, this.CurrentChar.ToString());
          }
          break;
        case ',':
          token = new Tokens(TokenKind.COMMA, this.CurrentChar.ToString());
          break;
        case ';':
          token = new Tokens(TokenKind.SEMICOLON, this.CurrentChar.ToString());
          break;
        case ':':
          token = new Tokens(TokenKind.COLON, this.CurrentChar.ToString());
          break;
        case '<':
          if (this.NextChar == '=')
          {
            token = new Tokens(TokenKind.OP_LE, "<=");
            this.ReadChar();
          }
          else if (this.NextChar == '<')
          {
            this.ReadChar();
            if (this.NextChar == '=')
            {
              token = new Tokens(TokenKind.OP_LEFT_SHIFT_ASSIGNMENT, "<<=");
              this.ReadChar();
            }
            else
            {
              token = new Tokens(TokenKind.OP_LEFT_SHIFT, "<<");
            }
          }
          else
          {
            token = new Tokens(TokenKind.LT, this.CurrentChar.ToString());
          }
          break;
        case '>':
          if (this.NextChar == '=')
          {
            token = new Tokens(TokenKind.OP_GE, ">=");
            this.ReadChar();
          }
          else if (this.NextChar == '>')
          {
            this.ReadChar();
            if (this.NextChar == '=')
            {
              token = new Tokens(TokenKind.OP_RIGHT_SHIFT_ASSIGNMENT, ">>=");
              this.ReadChar();
            }
            else
            {
              token = new Tokens(TokenKind.OP_RIGHT_SHIFT, ">>");
            }
          }
          else
          {
            token = new Tokens(TokenKind.GT, this.CurrentChar.ToString());
          }
          break;
        case '&':
          if (this.NextChar == '&')
          {
            token = new Tokens(TokenKind.OP_AND, "&&");
            this.ReadChar();
          }
          else if (this.NextChar == '=')
          {
            token = new Tokens(TokenKind.OP_AND_ASSIGNMENT, "&=");
            this.ReadChar();
          }
          else
          {
            token = new Tokens(TokenKind.AMP, this.CurrentChar.ToString());
          }
          break;
        case '|':
          if (this.NextChar == '|')
          {
            token = new Tokens(TokenKind.OP_OR, "||");
            this.ReadChar();
          }
          else if (this.NextChar == '=')
          {
            token = new Tokens(TokenKind.OP_OR_ASSIGNMENT, "|=");
            this.ReadChar();
          }
          else
          {
            token = new Tokens(TokenKind.BITWISE_OR, this.CurrentChar.ToString());
          }
          break;
        case '^':
          if (this.NextChar == '=')
          {
            token = new Tokens(TokenKind.OP_XOR_ASSIGNMENT, "^=");
            this.ReadChar();
          }
          else
          {
            token = new Tokens(TokenKind.CARET, this.CurrentChar.ToString());
          }
          break;
        case '=':
          if (this.NextChar == '>')
          {
            token = new Tokens(TokenKind.RIGHT_ALLOW, "=>");
            this.ReadChar();
          }
          else if (this.NextChar == '=')
          {
            token = new Tokens(TokenKind.OP_EQ, "==");
            this.ReadChar();
          }
          else
          {
            token = new Tokens(TokenKind.ASSIGNMENT, this.CurrentChar.ToString());
          }
          break;
        case '+':
          if (this.NextChar == '+')
          {
            token = new Tokens(TokenKind.OP_INC, "++");
            this.ReadChar();
          }
          else if (this.NextChar == '=')
          {
            token = new Tokens(TokenKind.OP_ADD_ASSIGNMENT, "+=");
            this.ReadChar();
          }
          else
          {
            token = new Tokens(TokenKind.PLUS, this.CurrentChar.ToString());
          }
          break;
        case '-':
          if (this.NextChar == '-')
          {
            token = new Tokens(TokenKind.OP_DEC, "--");
            this.ReadChar();
          }
          else if (this.NextChar == '=')
          {
            token = new Tokens(TokenKind.OP_SUB_ASSIGNMENT, "-=");
            this.ReadChar();
          }
          else
          {
            token = new Tokens(TokenKind.MINUS, this.CurrentChar.ToString());
          }
          break;
        case '*':
          if (this.NextChar == '=')
          {
            token = new Tokens(TokenKind.OP_MULT_ASSIGNMENT, "*=");
            this.ReadChar();
          }
          else
          {
            token = new Tokens(TokenKind.STAR, this.CurrentChar.ToString());
          }
          break;
        case '/':
          if (this.NextChar == '=')
          {
            token = new Tokens(TokenKind.OP_DIV_ASSIGNMENT, "/=");
            this.ReadChar();
          }
          else
          {
            token = new Tokens(TokenKind.DIV, this.CurrentChar.ToString());
          }
          break;
        case '%':
          if (this.NextChar == '=')
          {
            token = new Tokens(TokenKind.OP_MOD_ASSIGNMENT, "%=");
            this.ReadChar();
          }
          else
          {
            token = new Tokens(TokenKind.PERCENT, this.CurrentChar.ToString());
          }
          break;
        case '!':
          if (this.NextChar == '=')
          {
            token = new Tokens(TokenKind.OP_NE, "!=");
            this.ReadChar();
          }
          else
          {
            token = new Tokens(TokenKind.BANG, this.CurrentChar.ToString());
          }
          break;
        case (char)0:
          token = new Tokens(TokenKind.EOF, "");
          break;
        default:
          if (this.IsLetter(this.CurrentChar))
          {
            var identifier = this.ReadIdentifier();
            var type = Tokens.LookupIdentifier(identifier);
            token = new Tokens(type, identifier);
          }
          else if (this.IsDigit(this.CurrentChar))
          {
            var number = this.ReadNumber();
            token = new Tokens(TokenKind.INTEGER_LITERAL, number);
          }
          else
          {
            token = new Tokens(TokenKind.ILLEGAL, this.CurrentChar.ToString());
          }
          break;
      };

      this.ReadChar();
      return token;
    }
    private string ReadIdentifier()
    {
      var identifier = this.CurrentChar.ToString();

      // 次の文字が文字ならそれを読んで文字列に加える
      while (this.IsLetter(this.NextChar))
      {
        identifier += this.NextChar;
        this.ReadChar();
      }
      return identifier;
    }

    private bool IsLetter(char c)
    {
      return ('a' <= c && c <= 'z')
        || ('A' <= c && c <= 'Z')
        || c == '_';
    }

    private string ReadNumber()
    {
      var number = this.CurrentChar.ToString();

      // 次の文字が文字ならそれを読んで文字列に加える
      while (this.IsDigit(this.NextChar))
      {
        number += this.NextChar;
        this.ReadChar();
      }
      return number;
    }

    private bool IsDigit(char c)
    {
      return '0' <= c && c <= '9';
    }

    private void SkipWhitespace()
    {
      while (this.CurrentChar == ' '
            || this.CurrentChar == '\r'
            || this.CurrentChar == '\n'
            || this.CurrentChar == '\t')
      {
        this.ReadChar();
      }
    }
  }
}