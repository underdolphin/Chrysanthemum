parser grammar chrysanthemumParser;

options {
	tokenVocab = chrysanthemumLexer;
}

one_source: block;

object_definition:
	access_modifier_and_async_modifier const_or_let type_annotation? object_name ASSIGNMENT
		expression SEMICOLON;

access_modifier_and_async_modifier: access_modifier? ASYNC?;

access_modifier: PUBLIC | PRIVATE;

const_or_let: CONST | LET;

type_annotation: COLON type;

type: embedded_type | object_name | VOID;

embedded_type:
	INT8
	| INT16
	| INT32
	| INT64
	| FLOAT32
	| FLOAT64
	| NUMBER
	| STRING;

object_name: identifier (DOT identifier)*?;

array_access: object_name array_accessor_list;

array_accessor_list: array_accessor*;

array_accessor: OPEN_BRACKET object_name CLOSE_BRACKET;

identifier: IDENTIFIER;

expression:
	assignment
	| function_expression
	| conditional_expression;

assignment: unary_expression assignment_operator expression;

assignment_operator:
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

unary_expression:
	primary_expression
	| PLUS unary_expression
	| MINUS unary_expression
	| OP_INC unary_expression
	| OP_DEC unary_expression
	| AMP unary_expression
	| STAR unary_expression
	| AWAIT unary_expression
	| cast_expression;

cast_expression: OPEN_PAREN type CLOSE_PAREN unary_expression;

primary_expression:
	literal
	| object_name
	| member_eval
	| array_access;

function_expression:
	function_signature RIGHT_ALLOW function_body;

function_signature:
	OPEN_PAREN CLOSE_PAREN
	| OPEN_PAREN function_parameter_list CLOSE_PAREN
	| identifier;

function_parameter_list:
	function_parameter (COMMA function_parameter)*;

function_parameter: identifier type?;

function_body: block;

block:
	access_modifier_and_async_modifier OPEN_BRACE CLOSE_BRACE
	| access_modifier_and_async_modifier OPEN_BRACE block_content+ CLOSE_BRACE;

block_content: object_definition | member_eval;

member_eval: object_name member_eval_args?;

member_eval_args: OPEN_PAREN (type (COMMA type)*)? CLOSE_PAREN;

conditional_expression: conditional_or_expression;

conditional_or_expression:
	conditional_and_expression (OP_OR conditional_and_expression)*;

conditional_and_expression:
	inclusive_or_expression (OP_AND inclusive_or_expression)*;

inclusive_or_expression:
	exclusive_or_expression (BITWISE_OR exclusive_or_expression)*;

exclusive_or_expression: and_expression (CARET and_expression)*;

and_expression: equility_expression (AMP equility_expression)*;

equility_expression:
	relational_expression ((OP_EQ | OP_NE) relational_expression)*;

relational_expression:
	shift_expression ((LT | GT | OP_LE | OP_GE) shift_expression)*;

shift_expression:
	additive_expression (
		(OP_LEFT_SHIFT | OP_RIGHT_SHIFT) additive_expression
	)*;

additive_expression:
	multiplicative_expression (
		(PLUS | MINUS) multiplicative_expression
	)*;

multiplicative_expression:
	switch_expression ((STAR | DIV | PERCENT) switch_expression)*;

switch_expression:
	range_expression (
		SWITCH OPEN_BRACE (switch_expression_arms COMMA?)? CLOSE_BRACE
	)?;

switch_expression_arms:
	switch_expression_arm (COMMA switch_expression_arm)*;

switch_expression_arm:
	expression case_guard? RIGHT_ALLOW expression;

case_guard: WHEN expression;

range_expression:
	unary_expression
	| unary_expression? OP_RANGE unary_expression?;

literal:
	boolean_literal
	| INTEGER_LITERAL
	| HEX_INTEGER_LITERAL
	| BIN_INTEGER_LITERAL;

boolean_literal: TRUE | FALSE;