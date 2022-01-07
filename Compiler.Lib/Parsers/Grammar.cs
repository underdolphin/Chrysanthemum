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
using System.Linq;
using static Compiler.Lib.Parsers.OpAndPunctions;
using static Compiler.Lib.Parsers.Keywords;
using static Compiler.Lib.Parsers.LexerFragments;

namespace Compiler.Lib.Parsers
{
  public class Grammar
  {
    /// <summary>
    /// embedded_type:
    ///   INT8
    ///   | INT16
    ///   | INT32
    ///   | INT64
    ///   | FLOAT32
    ///   | FLOAT64
    ///   | NUMBER
    ///   | STRING;
    /// </summary>
    /// <returns></returns>
    public static readonly Parser<string> EmbeddedType =
      int8Keyword
      .Or(int16Keyword)
      .Or(int32Keyword)
      .Or(int64Keyword)
      .Or(float32Keyword)
      .Or(float64Keyword)
      .Or(numberKeyword)
      .Or(stringKeyword);

    /// <summary>
    /// object_name: identifier (DOT identifier)*?;
    /// </summary>
    /// <returns></returns>
    public static readonly Parser<List<string>> ObjectName =
      from first in Identifier.Once()
      from subs in Dot.Then(_ => Identifier).Many()
      select first.Concat(subs).ToList();

    /// <summary>
    /// assignment_operator:
    ///   ASSIGNMENT
    ///   | OP_ADD_ASSIGNMENT
    ///   | OP_SUB_ASSIGNMENT
    ///   | OP_MULT_ASSIGNMENT
    ///   | OP_DIV_ASSIGNMENT
    ///   | OP_MOD_ASSIGNMENT
    ///   | OP_AND_ASSIGNMENT
    ///   | OP_OR_ASSIGNMENT
    ///   | OP_XOR_ASSIGNMENT
    ///   | OP_LEFT_SHIFT_ASSIGNMENT
    ///   | OP_RIGHT_SHIFT_ASSIGNMENT;
    /// </summary>
    /// <returns></returns>
    public static readonly Parser<string> AssignmentOperator =
      OpAssignment
      .Or(OpAddAssignment)
      .Or(OpSubAssignment)
      .Or(OpMultiAssignment)
      .Or(OpDivideAssignment)
      .Or(OpModAssignment)
      .Or(OpAndAssignment)
      .Or(OpOrAssignment)
      .Or(OpXorAssignment)
      .Or(OpLeftShiftAssignment)
      .Or(OpRightShiftAssignment);

    /// <summary>
    /// boolean_literal: TRUE | FALSE;
    /// </summary>
    /// <returns></returns>
    public static readonly Parser<string> BooleanLiteral =
      trueKeyword
      .Or(falseKeyword);
  }
}