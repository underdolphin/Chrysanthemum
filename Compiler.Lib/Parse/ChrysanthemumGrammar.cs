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

using Irony.Parsing;

namespace Compiler.Lib.ParseOld
{
  [Language("Chrysanthemum")]
  public class ChrysanthemumGrammar : Grammar
  {
    public ChrysanthemumGrammar()
    {
      // Lexical rules
      var StringLiteral = TerminalFactory.CreateCSharpString("string_literal");
      var CharLiteral = TerminalFactory.CreateCSharpChar("char_literal");
      var Number = TerminalFactory.CreateCSharpNumber("number");
      var identifier = TerminalFactory.CreateCSharpIdentifier("identifier");

      var SingleLineComment = new CommentTerminal("SingleLineComment", "//", "\r", "\n", "\u0085", "\u2028", "\u2029");
      var DelimitedComment = new CommentTerminal("DelimitedComment", "/*", "*/");
      NonGrammarTerminals.Add(SingleLineComment);
      NonGrammarTerminals.Add(DelimitedComment);

      // Punctuators
      var open_brace = ToTerm("{", "open_brace");
      var close_brace = ToTerm("}", "close_brace");
      var open_bracket = ToTerm("[", "open_bracket");
      var close_bracket = ToTerm("]", "close_bracket");
      var open_paren = ToTerm("(", "open_paren");
      var close_paren = ToTerm(")", "close_paren");
      var dot = ToTerm(".", "dot");
      var comma = ToTerm(",", "comma");
      var colon = ToTerm(";", "colon");
      var lt = ToTerm("<", "lt");
      var gt = ToTerm(">", "gt");
      var right_allow = ToTerm("=>", "right_allow");
      var amp = ToTerm("&", "amp");
      var bitwise_or = ToTerm("|", "bitwise_or");
      var caret = ToTerm("^", "caret");

      // Operators 
      var op_assignment = ToTerm("=", "op_assignment");
      var op_plus = ToTerm("+", "op_plus");
      var op_minus = ToTerm("-", "op_minus");
      var op_star = ToTerm("*", "op_star");
      var op_div = ToTerm("/", "op_div");
      var op_percent = ToTerm("%", "op_percent");
      var op_increment = ToTerm("++", "op_increment");
      var op_decrement = ToTerm("--", "op_decrement");
      var op_and = ToTerm("&&", "op_and");
      var op_or = ToTerm("||", "op_or");
      var op_eq = ToTerm("==", "op_eq");
      var op_ne = ToTerm("!=", "op_ne");
      var op_le = ToTerm("<=", "op_le");
      var op_ge = ToTerm(">=", "op_ge");
      var op_add_assignment = ToTerm("+=", "op_add_assignment");
      var op_sub_assignment = ToTerm("-=", "op_sub_assignment");
      var op_multi_assignment = ToTerm("*=", "op_multi_assignment");
      var op_div_assignment = ToTerm("/=", "op_div_assignment");
      var op_mod_assignment = ToTerm("%=", "op_mod_assignment");
      var op_and_assignment = ToTerm("&=", "op_and_assignment");
      var op_or_assignment = ToTerm("|=", "op_or_assignment");
      var op_xor_assignment = ToTerm("^=", "op_xor_assignment");
      var op_left_shift = ToTerm("<<", "op_left_shift");
      var op_left_shift_assignment = ToTerm("<<=", "op_left_shift_assignment");
      var op_right_shift = ToTerm(">>", "op_right_shift");
      var op_right_shift_assignment = ToTerm(">>=", "op_right_shift_assignment");
      var op_range = ToTerm("..", "op_range");

      // Compilation units
      var one_source = new NonTerminal("one_source");
      var object_definition = new NonTerminal("object_definition");

      // Types
      var type_annotation = new NonTerminal("type_annotation");
      var type_annotation_opt = new NonTerminal("type_annotation?");
      var types = new NonTerminal("types");
      var embedded_type = new NonTerminal("embedded_type");
      var object_name = new NonTerminal("object_name");

      // array
      var array_accessor_list = new NonTerminal("array_accessor_list");
      var array_accessor = new NonTerminal("array_accessor");

      // Expressions
      var expression = new NonTerminal("expression");
      var assignment = new NonTerminal("assignment");
      var assignment_operator = new NonTerminal("assignment_operator");
      var assignment_op_expression_opt = new NonTerminal("assignment_op_exppression?");
      var assignment_op_expression = new NonTerminal("assignment_op_expression");
      var unary_expression = new NonTerminal("unary_expression");
      var cast_expression = new NonTerminal("cast_expression");
      var primary_expression = new NonTerminal("primary_expression");
      var function_expression = new NonTerminal("function_expression");
      var function_signature = new NonTerminal("function_signature");
      var function_parameter_list = new NonTerminal("function_parameter_list");
      var function_parameter = new NonTerminal("function_parameter");
      var function_body = new NonTerminal("function_body");
      var block = new NonTerminal("block");
      var block_content = new NonTerminal("block_content");
      var block_content_list = new NonTerminal("block_content+");
      var member_eval = new NonTerminal("member_eval");
      var member_eval_args = new NonTerminal("member_eval_args");
      // conditional
      var binary_expression = new NonTerminal("binary_expression");
      var binary_operators = new NonTerminal("binary_operators");
      var switch_expression = new NonTerminal("switch_expression");
      var switch_expression_arms = new NonTerminal("switch_expression_arms");
      var switch_expression_arm = new NonTerminal("switch_expression_arm");
      var case_guard = new NonTerminal("case_guard");

      // literals
      var literal = new NonTerminal("literal");
      var boolean_literal = new NonTerminal("boolean_literal");

      // Operators
      RegisterOperators(1, "=", "+=", "-=", "*=", "/=", "%=", "&=", "|=", "^=", "<<=", ">>=", "=>");
      RegisterOperators(2, "||");
      RegisterOperators(3, "&&");
      RegisterOperators(4, "|");
      RegisterOperators(5, "^");
      RegisterOperators(6, "&");
      RegisterOperators(7, "==", "!=");
      RegisterOperators(8, "<", ">", "<=", ">=");
      RegisterOperators(9, "<<", ">>");
      RegisterOperators(10, "+", "-");
      RegisterOperators(11, "*", "/", "%");
      RegisterOperators(12, "..");

      MarkTransient(literal, expression, primary_expression, binary_expression);
      MarkPunctuation(".", ",", ";", "{", "}", "[", "]", "(", ")");
      AddTermsReportGroup("typename", "int8", "int16", "int32", "float32", "float64", "number", "string");

      // Rules impl
      // Compilation units
      Root = one_source;
      one_source.Rule = block;
      object_definition.Rule = "var" + type_annotation_opt + expression;

      // // Types
      var types_or_object_name = new NonTerminal("types_or_object_name");
      object_name.Rule = MakeStarRule(object_name, dot, identifier);
      type_annotation.Rule = colon + types_or_object_name;
      type_annotation_opt.Rule = Empty | type_annotation;
      types_or_object_name.Rule = types | object_name;
      types.Rule = embedded_type | "void";
      embedded_type.Rule = ToTerm("int8") | "int16" | "int32" | "int64" | "float32" | "float64" | "number" | "string";

      // // Expressions
      expression.Rule = assignment | binary_expression | switch_expression | function_expression;
      assignment.Rule = unary_expression + assignment_op_expression_opt;
      assignment_op_expression_opt.Rule = Empty | assignment_op_expression;
      assignment_op_expression.Rule = assignment_operator + expression;
      assignment_operator.Rule =
        op_assignment
        | op_add_assignment
        | op_sub_assignment
        | op_multi_assignment
        | op_div_assignment
        | op_mod_assignment
        | op_and_assignment
        | op_or_assignment
        | op_xor_assignment
        | op_left_shift_assignment
        | op_right_shift_assignment;
      unary_expression.Rule =
        primary_expression
        | op_plus + unary_expression
        | op_minus + unary_expression
        | op_increment + unary_expression
        | op_decrement + unary_expression
        | amp + unary_expression
        | op_star + unary_expression
        | "await" + unary_expression
        | "static" + unary_expression;
      primary_expression.Rule =
        literal |
        member_eval;

      // // function
      function_expression.Rule = function_signature + right_allow + function_body;
      function_signature.Rule = open_paren + function_parameter_list + close_paren;
      function_parameter_list.Rule = MakeStarRule(function_parameter_list, comma, function_parameter);
      function_parameter.Rule = unary_expression + type_annotation_opt;
      function_body.Rule = block;

      // block
      block.Rule = open_brace + block_content_list + close_brace;
      block_content.Rule = object_definition | unary_expression;
      block_content_list.Rule = MakeStarRule(block_content_list, block_content);

      // // member_eval
      var member_eval_select = new NonTerminal("member_eval_select");
      var member_eval_select_opt = new NonTerminal("member_eval_select?");
      member_eval_args.Rule = open_paren + expression + close_paren;
      member_eval_select.Rule = member_eval_args | array_accessor_list;
      member_eval_select_opt.Rule = Empty | member_eval_select;
      member_eval.Rule = object_name + member_eval_select_opt;

      // // array
      array_accessor_list.Rule = MakePlusRule(array_accessor_list, null, array_accessor);
      array_accessor.Rule = open_bracket + expression + close_bracket;

      // conditional
      binary_operators.Rule =
        op_or |
        op_and |
        bitwise_or |
        caret |
        amp |
        op_eq |
        op_ne |
        lt |
        gt |
        op_le |
        op_ge |
        op_left_shift |
        op_right_shift |
        op_plus |
        op_minus |
        op_star |
        op_div |
        op_percent;
      binary_expression.Rule = MakeStarRule(binary_expression, binary_operators, expression);

      // switch_expression
      var switch_expression_opt = new NonTerminal("switch_expression?");
      var switch_expression_body = new NonTerminal("switch_expression_body");
      var swith_expression_comma = new NonTerminal("swith_expression_comma");
      var swith_expression_comma_opt = new NonTerminal("swith_expression_comma?");
      var comma_opt = new NonTerminal("comma?");
      var case_guard_opt = new NonTerminal("case_guard?");
      switch_expression.Rule = unary_expression + switch_expression_body;
      switch_expression_body.Rule = "switch" + open_brace + swith_expression_comma_opt + close_brace;
      swith_expression_comma_opt.Rule = Empty | swith_expression_comma;
      swith_expression_comma.Rule = switch_expression_arms + comma_opt;
      comma_opt.Rule = Empty | comma;
      switch_expression_arms.Rule = MakeStarRule(switch_expression_arms, comma, switch_expression_arm);
      case_guard_opt.Rule = Empty | case_guard;
      switch_expression_arm.Rule = expression + case_guard_opt + right_allow + expression;
      case_guard.Rule = "when" + expression;

      // literals
      literal.Rule = boolean_literal | Number | StringLiteral;
      boolean_literal.Rule = ToTerm("true") | "false";
    }
  }
}
