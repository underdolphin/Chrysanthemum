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
  public class Keywords
  {
    // keyword
    // VAR: 'var';
    public static readonly Parser<string> varKeyword = Parse.String("var").Text();
    // AWAIT: 'await';
    public static readonly Parser<string> awaitKeyword = Parse.String("await").Text();
    // SWITCH: 'switch';
    public static readonly Parser<string> switchKeyword = Parse.String("var").Text();
    // WHEN: 'when';
    public static readonly Parser<string> whenKeyword = Parse.String("when").Text();

    // // types
    // INT8: 'int8';
    public static readonly Parser<string> int8Keyword = Parse.String("int8").Text();
    // INT16: 'int16';
    public static readonly Parser<string> int16Keyword = Parse.String("int16").Text();
    // INT32: 'int32';
    public static readonly Parser<string> int32Keyword = Parse.String("int32").Text();
    // INT64: 'int64';
    public static readonly Parser<string> int64Keyword = Parse.String("int64").Text();
    // FLOAT32: 'float32';
    public static readonly Parser<string> float32Keyword = Parse.String("float32").Text();
    // FLOAT64: 'float64';
    public static readonly Parser<string> float64Keyword = Parse.String("float64").Text();
    // STRING: 'string';
    public static readonly Parser<string> stringKeyword = Parse.String("string").Text();
    // NUMBER: 'number'; // is float64 
    public static readonly Parser<string> numberKeyword = Parse.String("number").Text();
    // VOID: 'void';
    public static readonly Parser<string> voidKeyword = Parse.String("void").Text();
    // TRUE: 'true';
    public static readonly Parser<string> trueKeyword = Parse.String("true").Text();
    // FALSE: 'false';
    public static readonly Parser<string> falseKeyword = Parse.String("false").Text();
  }
}