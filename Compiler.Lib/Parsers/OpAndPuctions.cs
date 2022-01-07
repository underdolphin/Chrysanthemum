using System.Net.Mime;
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

using Sprache;

namespace Compiler.Lib.Parsers
{
  public class OpAndPunctions
  {
    // Punctuators
    // OPEN_BRACE: '{';
    public static readonly Parser<char> OpenBrace = Parse.Char('{');
    // CLOSE_BRACE: '}';
    public static readonly Parser<char> CloseBrace = Parse.Char('}');
    // OPEN_BRACKET: '[';
    public static readonly Parser<char> OpenBracket = Parse.Char('[');
    // CLOSE_BRACKET: ']';
    public static readonly Parser<char> CloseBracket = Parse.Char(']');
    // OPEN_PAREN: '(';
    public static readonly Parser<char> OpenParen = Parse.Char('(');
    // CLOSE_PAREN: ')';
    public static readonly Parser<char> CloseParen = Parse.Char(')');
    // DOT: '.';
    public static readonly Parser<char> Dot = Parse.Char('.');
    // COMMA: ',';
    public static readonly Parser<char> Comma = Parse.Char(',');
    // COLON: ';';
    public static readonly Parser<char> Colon = Parse.Char(';');
    // LT: '<';
    public static readonly Parser<char> LessThan = Parse.Char('<');
    // GT: '>';
    public static readonly Parser<char> GreaterThan = Parse.Char('>');
    // AMP: '&';
    public static readonly Parser<char> Ampersand = Parse.Char('&');
    // BITWISE_OR: '|';
    public static readonly Parser<char> BitwiseOr = Parse.Char('|');
    // CARET: '^';
    public static readonly Parser<char> Caret = Parse.Char('^');

    // Operators 
    // ASSIGNMENT: '=';
    public static readonly Parser<string> OpAssignment = Parse.String("=").Text();
    // PLUS: '+';
    public static readonly Parser<string> OpPlus = Parse.String("+").Text();
    // MINUS: '-';
    public static readonly Parser<string> OpMinus = Parse.String("-").Text();
    // STAR: '*';
    public static readonly Parser<string> OpStar = Parse.String("*").Text();
    // DIV: '/';
    public static readonly Parser<string> OpDivide = Parse.String("/").Text();
    // PERCENT: '%';
    public static readonly Parser<string> OpPercent = Parse.String("%").Text();
    // OP_INC: '++';
    public static readonly Parser<string> OpIncrement = Parse.String("++").Text();
    // OP_DEC: '--';
    public static readonly Parser<string> OpDecrement = Parse.String("--").Text();
    // OP_AND: '&&';
    public static readonly Parser<string> OpAnd = Parse.String("&&").Text();
    // OP_OR: '||';
    public static readonly Parser<string> OpOr = Parse.String("||").Text();
    // OP_EQ: '==';
    public static readonly Parser<string> OpEqual = Parse.String("==").Text();
    // OP_NE: '!=';
    public static readonly Parser<string> OpNotEqual = Parse.String("!=").Text();
    // OP_LE: '<=';
    public static readonly Parser<string> OpLessEqual = Parse.String("<=").Text();
    // OP_GE: '>=';
    public static readonly Parser<string> OpGreaterEqual = Parse.String(">=").Text();
    // OP_ADD_ASSIGNMENT: '+=';
    public static readonly Parser<string> OpAddAssignment = Parse.String("+=").Text();
    // OP_SUB_ASSIGNMENT: '-=';
    public static readonly Parser<string> OpSubAssignment = Parse.String("-=").Text();
    // OP_MULT_ASSIGNMENT: '*=';
    public static readonly Parser<string> OpMultiAssignment = Parse.String("*=").Text();
    // OP_DIV_ASSIGNMENT: '/=';
    public static readonly Parser<string> OpDivideAssignment = Parse.String("/=").Text();
    // OP_MOD_ASSIGNMENT: '%=';
    public static readonly Parser<string> OpModAssignment = Parse.String("%=").Text();
    // OP_AND_ASSIGNMENT: '&=';
    public static readonly Parser<string> OpAndAssignment = Parse.String("&=").Text();
    // OP_OR_ASSIGNMENT: '|=';
    public static readonly Parser<string> OpOrAssignment = Parse.String("|=").Text();
    // OP_XOR_ASSIGNMENT: '^=';
    public static readonly Parser<string> OpXorAssignment = Parse.String("^=").Text();
    // OP_LEFT_SHIFT: '<<';
    public static readonly Parser<string> OpLeftShift = Parse.String("<<").Text();
    // OP_LEFT_SHIFT_ASSIGNMENT: '<<=';
    public static readonly Parser<string> OpLeftShiftAssignment = Parse.String("<<=").Text();
    // OP_RIGHT_SHIFT: '>>';
    public static readonly Parser<string> OpRightShift = Parse.String(">>").Text();
    // OP_RIGHT_SHIFT_ASSIGNMENT: '>>=';
    public static readonly Parser<string> OpRightShiftAssignment = Parse.String(">>=").Text();
    // OP_RANGE: '..';
    public static readonly Parser<string> OpRange = Parse.String("..").Text();
    // OP_RIGHT_ALLOW: '=>';
    public static readonly Parser<string> OpRightAllow = Parse.String("=>").Text();
  }
}