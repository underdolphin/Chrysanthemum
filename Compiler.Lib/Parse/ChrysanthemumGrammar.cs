using System.Data;
using Irony.Parsing;

namespace Compiler.Lib.Parse
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
      var OPEN_BRACE = ToTerm("{", "OPEN_BRACE");
      var CLOSE_BRACE = ToTerm("}", "CLOSE_BRACE");
      var OPEN_BRACKET = ToTerm("[", "OPEN_BRACKET");
      var CLOSE_BRACKET = ToTerm("]", "CLOSE_BRACKET");
      var OPEN_PAREN = ToTerm("(", "OPEN_PAREN");
      var CLOSE_PAREN = ToTerm(")", "CLOSE_PAREN");
      var DOT = ToTerm(".", "DOT");
      var COMMA = ToTerm(",", "COMMA");
      var COLON = ToTerm(";", "COLON");
      var LT = ToTerm("<", "LT");
      var GT = ToTerm(">", "GT");
      var RIGHT_ALLOW = ToTerm("=>", "RIGHT_ALLOW");
      var AMP = ToTerm("&", "AMP");
      var BITWISE_OR = ToTerm("|", "BITWISE_OR");
      var CARET = ToTerm("^", "CARET");

      // Operators 
      var ASSIGNMENT = ToTerm("=", "ASSIGNMENT");
      var PLUS = ToTerm("+", "PLUS");
      var MINUS = ToTerm("-", "MINUS");
      var STAR = ToTerm("*", "STAR");
      var DIV = ToTerm("/", "DIV");
      var PERCENT = ToTerm("%", "PERCENT");
      var OP_INC = ToTerm("++", "OP_INC");
      var OP_DEC = ToTerm("--", "OP_DEC");
      var OP_AND = ToTerm("&&", "OP_AND");
      var OP_OR = ToTerm("||", "OP_OR");
      var OP_EQ = ToTerm("==", "OP_EQ");
      var OP_NE = ToTerm("!=", "OP_NE");
      var OP_LE = ToTerm("<=", "OP_LE");
      var OP_GE = ToTerm(">=", "OP_GE");
      var OP_ADD_ASSIGNMENT = ToTerm("+=", "OP_ADD_ASSIGNMENT");
      var OP_SUB_ASSIGNMENT = ToTerm("-=", "OP_SUB_ASSIGNMENT");
      var OP_MULT_ASSIGNMENT = ToTerm("*=", "OP_MULT_ASSIGNMENT");
      var OP_DIV_ASSIGNMENT = ToTerm("/=", "OP_DIV_ASSIGNMENT");
      var OP_MOD_ASSIGNMENT = ToTerm("%=", "OP_MOD_ASSIGNMENT");
      var OP_AND_ASSIGNMENT = ToTerm("&=", "OP_AND_ASSIGNMENT");
      var OP_OR_ASSIGNMENT = ToTerm("|=", "OP_OR_ASSIGNMENT");
      var OP_XOR_ASSIGNMENT = ToTerm("^=", "OP_XOR_ASSIGNMENT");
      var OP_LEFT_SHIFT = ToTerm("<<", "OP_LEFT_SHIFT");
      var OP_LEFT_SHIFT_ASSIGNMENT = ToTerm("<<=", "OP_LEFT_SHIFT_ASSIGNMENT");
      var OP_RIGHT_SHIFT = ToTerm(">>", "OP_RIGHT_SHIFT");
      var OP_RIGHT_SHIFT_ASSIGNMENT = ToTerm(">>=", "OP_RIGHT_SHIFT_ASSIGNMENT");
      var OP_RANGE = ToTerm("..", "OP_RANGE");

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
      var array_access = new NonTerminal("array_access");
      var array_accessor_list = new NonTerminal("array_accessor_list");
      var array_accessor = new NonTerminal("array_accessor");

      // Expressions
      var expression = new NonTerminal("expression");
      var assignment = new NonTerminal("assignment");
      var assignment_operator = new NonTerminal("assignment_operator");
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
      var member_eval = new NonTerminal("member_eval");
      var member_eval_args = new NonTerminal("member_eval_args");
      var conditional_expression = new NonTerminal("conditional_expression");
      var conditional_or_expression = new NonTerminal("conditional_or_expression");
      var conditional_and_expression = new NonTerminal("conditional_and_expression");
      var inclusive_or_expression = new NonTerminal("inclusive_or_expression");
      var exclusive_or_expression = new NonTerminal("exclusive_or_expression");
      var and_expression = new NonTerminal("and_expression");
      var equility_expression = new NonTerminal("equility_expression");
      var relational_expression = new NonTerminal("relational_expression");
      var shift_expression = new NonTerminal("shift_expression");
      var additive_expression = new NonTerminal("additive_expression");
      var multiplicative_expression = new NonTerminal("multiplicative_expression");
      var switch_expression = new NonTerminal("switch_expression");
      var switch_expression_arms = new NonTerminal("switch_expression_arms");
      var switch_expression_arm = new NonTerminal("switch_expression_arm");
      var case_guard = new NonTerminal("case_guard");
      var range_expression = new NonTerminal("range_expression");

      // literals
      var literal = new NonTerminal("literal");
      var boolean_literal = new NonTerminal("boolean_literal");

      // Rules impl
      // Compilation units
      Root = one_source;
      one_source.Rule = block;
      object_definition.Rule = "var" + type_annotation_opt + ASSIGNMENT + expression;

      // Types
      type_annotation.Rule = COLON + types;
      type_annotation_opt.Rule = Empty | type_annotation;
      types.Rule = embedded_type | object_name | "void";
      embedded_type.Rule = ToTerm("int8") | "int16" | "int32" | "int64" | "float32" | "float64" | "number" | "string";
      var dot_identifier = new NonTerminal("dot_identifier");
      dot_identifier.Rule = DOT + identifier;
      var dot_identifier_list = new NonTerminal("dot_identifier_list");
      dot_identifier_list.Rule = MakeStarRule(dot_identifier_list, null, dot_identifier);
      object_name.Rule = identifier + dot_identifier_list;

      // array
      array_access.Rule = object_name + array_accessor_list;
      array_accessor_list.Rule = MakeStarRule(array_accessor_list, null, array_accessor);
      array_accessor.Rule = OPEN_BRACKET + object_name + CLOSE_BRACKET;

      // Expressions
      expression.Rule = assignment | function_expression | conditional_expression;
      assignment.Rule = unary_expression + assignment_operator + expression;
      assignment_operator.Rule =
      ASSIGNMENT
      | OP_ADD_ASSIGNMENT
      | OP_SUB_ASSIGNMENT
      | OP_MULT_ASSIGNMENT
      | OP_DIV_ASSIGNMENT
      | OP_MOD_ASSIGNMENT
      | OP_AND_ASSIGNMENT
      | OP_OR_ASSIGNMENT
      | OP_XOR_ASSIGNMENT
      | OP_LEFT_SHIFT_ASSIGNMENT
      | OP_RIGHT_SHIFT_ASSIGNMENT;
      unary_expression.Rule =
      primary_expression
      | PLUS + unary_expression
      | MINUS + unary_expression
      | OP_INC + unary_expression
      | OP_DEC + unary_expression
      | AMP + unary_expression
      | STAR + unary_expression
      | "await" + unary_expression
      | cast_expression;
      cast_expression.Rule = OPEN_PAREN + types + CLOSE_PAREN + unary_expression;
      primary_expression.Rule =
      literal
      | object_name
      | member_eval
      | array_access;
      function_expression.Rule = function_signature + RIGHT_ALLOW + function_body;
      function_signature.Rule =
      OPEN_PAREN + CLOSE_PAREN
      | OPEN_PAREN + function_parameter_list + CLOSE_PAREN
      | identifier;
      function_parameter_list.Rule = MakeStarRule(function_parameter_list, COMMA, function_parameter);
      var types_opt = new NonTerminal("types?");
      types_opt.Rule = Empty | types;
      function_parameter.Rule = identifier + types_opt;
      function_body.Rule = block;
      block.Rule =
      OPEN_BRACE + CLOSE_BRACE
      | OPEN_BRACE + block_content + CLOSE_BRACE;
      block_content.Rule = object_definition | member_eval;
      var member_eval_args_opt = new NonTerminal("member_eval_args?");
      member_eval_args_opt.Rule = Empty | member_eval_args;
      member_eval.Rule = types + member_eval_args_opt;
      var types_comma_list = new NonTerminal("types_comma_list");
      types_comma_list.Rule = MakeStarRule(types_comma_list, COMMA, types);
      member_eval_args.Rule = OPEN_PAREN + types_comma_list + CLOSE_PAREN;
      conditional_expression.Rule = conditional_or_expression;
      conditional_or_expression.Rule = conditional_and_expression + MakeStarRule(conditional_or_expression, OP_OR, conditional_and_expression);
      conditional_and_expression.Rule = inclusive_or_expression + MakeStarRule(conditional_and_expression, OP_AND, inclusive_or_expression);
      inclusive_or_expression.Rule = exclusive_or_expression + MakeStarRule(inclusive_or_expression, BITWISE_OR, exclusive_or_expression);
      exclusive_or_expression.Rule = and_expression + MakeStarRule(exclusive_or_expression, CARET, and_expression);
      and_expression.Rule = equility_expression + MakeStarRule(and_expression, AMP, equility_expression);
      var op_equilitys = new NonTerminal("op_equilitys");
      op_equilitys.Rule = OP_EQ | OP_NE;
      equility_expression.Rule = relational_expression + MakeStarRule(equility_expression, op_equilitys, relational_expression);
      var op_relationals = new NonTerminal("op_relationals");
      op_relationals.Rule = LT | GT | OP_LE | OP_GE;
      relational_expression.Rule = shift_expression + MakeStarRule(relational_expression, op_relationals, shift_expression);
      var op_shifts = new NonTerminal("op_shifts");
      op_shifts.Rule = OP_LEFT_SHIFT | OP_RIGHT_SHIFT;
      shift_expression.Rule = additive_expression + MakeStarRule(shift_expression, op_shifts, additive_expression);
      var op_additive = new NonTerminal("op_additive");
      op_additive.Rule = PLUS | MINUS;
      additive_expression.Rule = multiplicative_expression + MakeStarRule(additive_expression, op_additive, multiplicative_expression);
      var op_multiplicative = new NonTerminal("op_multiplicative");
      op_multiplicative.Rule = STAR | DIV | PERCENT;
      multiplicative_expression.Rule = switch_expression + MakeStarRule(multiplicative_expression, op_multiplicative, switch_expression);
      var switch_expression_opt = new NonTerminal("switch_expression?");
      var switch_expression_body = new NonTerminal("switch_expression_body");
      var swith_expression_comma = new NonTerminal("swith_expression_comma");
      var swith_expression_comma_opt = new NonTerminal("swith_expression_comma?");
      var comma_opt = new NonTerminal("comma?");
      switch_expression_body.Rule = "switch" + OPEN_BRACE + swith_expression_comma_opt + CLOSE_BRACE;
      comma_opt.Rule = Empty | COMMA;
      swith_expression_comma.Rule = switch_expression_arms + comma_opt;
      swith_expression_comma_opt.Rule = Empty | swith_expression_comma;
      switch_expression_opt.Rule = Empty | switch_expression_body;
      switch_expression.Rule = range_expression + switch_expression_opt;
      switch_expression_arms.Rule = switch_expression_arm + MakeStarRule(switch_expression_arms, COMMA, switch_expression_arm);
      var case_guard_opt = new NonTerminal("case_guard?");
      case_guard_opt.Rule = Empty | case_guard;
      switch_expression_arm.Rule = expression + case_guard_opt + RIGHT_ALLOW + expression;
      case_guard.Rule = "when" + expression;
      var unary_expression_opt = new NonTerminal("unary_expression?");
      unary_expression_opt.Rule = Empty | unary_expression;
      range_expression.Rule = unary_expression | unary_expression_opt + OP_RANGE + unary_expression_opt;
      
      // literals
      literal.Rule = boolean_literal | Number | StringLiteral;
      boolean_literal.Rule = ToTerm("true") | "false";
    }
  }
}
