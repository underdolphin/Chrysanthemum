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
  public enum TokenKind
  {
    // Comments
    SINGLE_LINE_COMMENT,
    DELIMITED_COMMENT,

    // identifier 
    IDENTIFIER,

    // literal
    INTEGER_LITERAL,
    HEX_INTEGER_LITERAL,
    BIN_INTEGER_LITERAL,

    // keyword
    CONST,
    LET,
    AWAIT,
    SWITCH,
    WHEN,

    // types
    INT8,
    INT16,
    INT32,
    INT64,
    FLOAT32,
    FLOAT64,
    STRING,
    NUMBER,
    VOID,
    TRUE,
    FALSE,

    // Punctuators
    OPEN_BRACE,
    CLOSE_BRACE,
    OPEN_BRACKET,
    CLOSE_BRACKET,
    OPEN_PAREN,
    CLOSE_PAREN,
    DOT,
    COMMA,
    COLON,
    SEMICOLON,
    LT,
    GT,
    RIGHT_ALLOW,
    AMP,
    BITWISE_OR,
    CARET,

    // Operators 
    ASSIGNMENT,
    PLUS,
    MINUS,
    STAR,
    DIV,
    PERCENT,
    OP_INC,
    OP_DEC,
    OP_AND,
    OP_OR,
    OP_EQ,
    OP_NE,
    OP_LE,
    OP_GE,
    OP_ADD_ASSIGNMENT,
    OP_SUB_ASSIGNMENT,
    OP_MULT_ASSIGNMENT,
    OP_DIV_ASSIGNMENT,
    OP_MOD_ASSIGNMENT,
    OP_AND_ASSIGNMENT,
    OP_OR_ASSIGNMENT,
    OP_XOR_ASSIGNMENT,
    OP_LEFT_SHIFT,
    OP_LEFT_SHIFT_ASSIGNMENT,
    OP_RIGHT_SHIFT,
    OP_RIGHT_SHIFT_ASSIGNMENT,
    OP_RANGE,
    EOF,
    ILLEGAL
  }
}