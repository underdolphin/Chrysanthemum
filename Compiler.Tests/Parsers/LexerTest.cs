using System.Collections.Generic;

using Compiler.Lib.Lexer;

using Xunit;
namespace Compiler.Tests.Parsers;

public class LexerTest
{

  [Fact]
  public void TokensTest()
  {
    var input = "={}[]().,;:<>&|^+-*/%!";

    var testTokens = new List<Token>();
    testTokens.Add(new Token(TokenKind.ASSIGNMENT, "="));
    testTokens.Add(new Token(TokenKind.OPEN_BRACE, "{"));
    testTokens.Add(new Token(TokenKind.CLOSE_BRACE, "}"));
    testTokens.Add(new Token(TokenKind.OPEN_BRACKET, "["));
    testTokens.Add(new Token(TokenKind.CLOSE_BRACKET, "]"));
    testTokens.Add(new Token(TokenKind.OPEN_PAREN, "("));
    testTokens.Add(new Token(TokenKind.CLOSE_PAREN, ")"));
    testTokens.Add(new Token(TokenKind.DOT, "."));
    testTokens.Add(new Token(TokenKind.COMMA, ","));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    testTokens.Add(new Token(TokenKind.COLON, ":"));
    testTokens.Add(new Token(TokenKind.LT, "<"));
    testTokens.Add(new Token(TokenKind.GT, ">"));
    testTokens.Add(new Token(TokenKind.AMP, "&"));
    testTokens.Add(new Token(TokenKind.BITWISE_OR, "|"));
    testTokens.Add(new Token(TokenKind.CARET, "^"));
    testTokens.Add(new Token(TokenKind.PLUS, "+"));
    testTokens.Add(new Token(TokenKind.MINUS, "-"));
    testTokens.Add(new Token(TokenKind.STAR, "*"));
    testTokens.Add(new Token(TokenKind.DIV, "/"));
    testTokens.Add(new Token(TokenKind.PERCENT, "%"));
    testTokens.Add(new Token(TokenKind.BANG, "!"));
    testTokens.Add(new Token(TokenKind.EOF, ""));

    var lexer = new TokenLexer(input);

    foreach (var testToken in testTokens)
    {
      var token = lexer.NextToken();
      Assert.Equal(testToken.TokenKind, token.TokenKind);
      Assert.Equal(testToken.Literal, token.Literal);
    }
  }

  [Fact]
  public void TokensTest2()
  {
    var input = @"const a = 5;
    const ten = 10;
    
    let add = (x, y) => 
    { 
      x + y;
    };
    
    let result = add(a, ten);";

    var testTokens = new List<Token>();
    // const a = 5;
    testTokens.Add(new Token(TokenKind.CONST, "const"));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "a"));
    testTokens.Add(new Token(TokenKind.ASSIGNMENT, "="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "5"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // const a = 5;
    testTokens.Add(new Token(TokenKind.CONST, "const"));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "ten"));
    testTokens.Add(new Token(TokenKind.ASSIGNMENT, "="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "10"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // let add = (x, y) => 
    // { 
    //   x + y;
    // };
    testTokens.Add(new Token(TokenKind.LET, "let"));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "add"));
    testTokens.Add(new Token(TokenKind.ASSIGNMENT, "="));
    testTokens.Add(new Token(TokenKind.OPEN_PAREN, "("));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "x"));
    testTokens.Add(new Token(TokenKind.COMMA, ","));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "y"));
    testTokens.Add(new Token(TokenKind.CLOSE_PAREN, ")"));
    testTokens.Add(new Token(TokenKind.RIGHT_ALLOW, "=>"));
    testTokens.Add(new Token(TokenKind.OPEN_BRACE, "{"));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "x"));
    testTokens.Add(new Token(TokenKind.PLUS, "+"));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "y"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    testTokens.Add(new Token(TokenKind.CLOSE_BRACE, "}"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // let result = add(a, ten);
    testTokens.Add(new Token(TokenKind.LET, "let"));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "result"));
    testTokens.Add(new Token(TokenKind.ASSIGNMENT, "="));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "add"));
    testTokens.Add(new Token(TokenKind.OPEN_PAREN, "("));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "a"));
    testTokens.Add(new Token(TokenKind.COMMA, ","));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "ten"));
    testTokens.Add(new Token(TokenKind.CLOSE_PAREN, ")"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    testTokens.Add(new Token(TokenKind.EOF, ""));

    var lexer = new TokenLexer(input);

    foreach (var testToken in testTokens)
    {
      var token = lexer.NextToken();
      Assert.Equal(testToken.TokenKind, token.TokenKind);
      Assert.Equal(testToken.Literal, token.Literal);
    }
  }

  [Fact]
  public void TokensTest3()
  {
    var input = "++1;--1;1 && 1;1 || 1;1 == 1; 1 != 0; 1 <= 0; 1 >= 0;";

    var testTokens = new List<Token>();

    // ++1;
    testTokens.Add(new Token(TokenKind.OP_INC, "++"));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // --1;
    testTokens.Add(new Token(TokenKind.OP_DEC, "--"));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // 1 && 1;
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.OP_AND, "&&"));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // 1 || 1;
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.OP_OR, "||"));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // 1 == 1;
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.OP_EQ, "=="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // 1 != 0;
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.OP_NE, "!="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // 1 <= 0;
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.OP_LE, "<="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // 1 >= 0;
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.OP_GE, ">="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    testTokens.Add(new Token(TokenKind.EOF, ""));

    var lexer = new TokenLexer(input);

    foreach (var testToken in testTokens)
    {
      var token = lexer.NextToken();
      Assert.Equal(testToken.TokenKind, token.TokenKind);
      Assert.Equal(testToken.Literal, token.Literal);
    }
  }

  [Fact]
  public void TokensTest4()
  {
    var input = "1 += 0;1 -= 0;1 *= 0;1 /= 0;1 %= 0;1 &= 0;1 |= 0;1 ^= 0;1 << 0;1 <<= 0;1 >> 0;1 >>= 0;1 .. 0;";

    var testTokens = new List<Token>();

    // 1 += 0;
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.OP_ADD_ASSIGNMENT, "+="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // 1 -= 0;
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.OP_SUB_ASSIGNMENT, "-="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // 1 *= 0;
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.OP_MULT_ASSIGNMENT, "*="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // 1 /= 0;
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.OP_DIV_ASSIGNMENT, "/="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // 1 %= 0;
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.OP_MOD_ASSIGNMENT, "%="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // 1 &= 0;
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.OP_AND_ASSIGNMENT, "&="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // 1 |= 0;
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.OP_OR_ASSIGNMENT, "|="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // 1 ^= 0;
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.OP_XOR_ASSIGNMENT, "^="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // 1 << 0;
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.OP_LEFT_SHIFT, "<<"));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // 1 <<= 0;
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.OP_LEFT_SHIFT_ASSIGNMENT, "<<="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // 1 >> 0;
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.OP_RIGHT_SHIFT, ">>"));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // 1 >>= 0;
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.OP_RIGHT_SHIFT_ASSIGNMENT, ">>="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // 1 .. 0;
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Token(TokenKind.OP_RANGE, ".."));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    testTokens.Add(new Token(TokenKind.EOF, ""));

    var lexer = new TokenLexer(input);

    foreach (var testToken in testTokens)
    {
      var token = lexer.NextToken();
      Assert.Equal(testToken.TokenKind, token.TokenKind);
      Assert.Equal(testToken.Literal, token.Literal);
    }
  }

  [Fact]
  public void TokensTestModifier()
  {
    var input = @"private async const add = (x, y) => 
                 {
                   await HeavyProcess();
                 };
                 
                 public async let add = (x, y) => 
                 {
                   await HeavyProcess();
                 };";

    var testTokens = new List<Token>();

    // private async const add = (x, y) => 
    // {
    //    await HeavyProcess();
    // };
    testTokens.Add(new Token(TokenKind.PRIVATE, "private"));
    testTokens.Add(new Token(TokenKind.ASYNC, "async"));
    testTokens.Add(new Token(TokenKind.CONST, "const"));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "add"));
    testTokens.Add(new Token(TokenKind.ASSIGNMENT, "="));
    testTokens.Add(new Token(TokenKind.OPEN_PAREN, "("));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "x"));
    testTokens.Add(new Token(TokenKind.COMMA, ","));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "y"));
    testTokens.Add(new Token(TokenKind.CLOSE_PAREN, ")"));
    testTokens.Add(new Token(TokenKind.RIGHT_ALLOW, "=>"));
    testTokens.Add(new Token(TokenKind.OPEN_BRACE, "{"));
    testTokens.Add(new Token(TokenKind.AWAIT, "await"));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "HeavyProcess"));
    testTokens.Add(new Token(TokenKind.OPEN_PAREN, "("));
    testTokens.Add(new Token(TokenKind.CLOSE_PAREN, ")"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    testTokens.Add(new Token(TokenKind.CLOSE_BRACE, "}"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // public async let add = (x, y) => 
    // {
    //    await HeavyProcess();
    // };
    testTokens.Add(new Token(TokenKind.PUBLIC, "public"));
    testTokens.Add(new Token(TokenKind.ASYNC, "async"));
    testTokens.Add(new Token(TokenKind.LET, "let"));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "add"));
    testTokens.Add(new Token(TokenKind.ASSIGNMENT, "="));
    testTokens.Add(new Token(TokenKind.OPEN_PAREN, "("));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "x"));
    testTokens.Add(new Token(TokenKind.COMMA, ","));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "y"));
    testTokens.Add(new Token(TokenKind.CLOSE_PAREN, ")"));
    testTokens.Add(new Token(TokenKind.RIGHT_ALLOW, "=>"));
    testTokens.Add(new Token(TokenKind.OPEN_BRACE, "{"));
    testTokens.Add(new Token(TokenKind.AWAIT, "await"));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "HeavyProcess"));
    testTokens.Add(new Token(TokenKind.OPEN_PAREN, "("));
    testTokens.Add(new Token(TokenKind.CLOSE_PAREN, ")"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    testTokens.Add(new Token(TokenKind.CLOSE_BRACE, "}"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    testTokens.Add(new Token(TokenKind.EOF, ""));
   
    var lexer = new TokenLexer(input);

    foreach (var testToken in testTokens)
    {
      var token = lexer.NextToken();
      Assert.Equal(testToken.TokenKind, token.TokenKind);
      Assert.Equal(testToken.Literal, token.Literal);
    }
  }

  [Fact]
  public void TokensTestType()
  {
    var input = @"const:boolean value = true;
                 const:boolean value = false;
                 const:int8 value = 0;
                 const:int16 value = 0;
                 const:int32 value = 0;
                 const:int64 value = 0;
                 const:float32 value = 0;
                 const:float64 value = 0;
                 const:number value = 0;";

    var testTokens = new List<Token>();

    // const:boolean value = true;
    testTokens.Add(new Token(TokenKind.CONST, "const"));
    testTokens.Add(new Token(TokenKind.COLON, ":"));
    testTokens.Add(new Token(TokenKind.BOOLEAN, "boolean"));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "value"));
    testTokens.Add(new Token(TokenKind.ASSIGNMENT, "="));
    testTokens.Add(new Token(TokenKind.TRUE, "true"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // const:boolean value = false;
    testTokens.Add(new Token(TokenKind.CONST, "const"));
    testTokens.Add(new Token(TokenKind.COLON, ":"));
    testTokens.Add(new Token(TokenKind.BOOLEAN, "boolean"));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "value"));
    testTokens.Add(new Token(TokenKind.ASSIGNMENT, "="));
    testTokens.Add(new Token(TokenKind.FALSE, "false"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // const:int8 value = 0;
    testTokens.Add(new Token(TokenKind.CONST, "const"));
    testTokens.Add(new Token(TokenKind.COLON, ":"));
    testTokens.Add(new Token(TokenKind.INT8, "int8"));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "value"));
    testTokens.Add(new Token(TokenKind.ASSIGNMENT, "="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // const:int16 value = 0;
    testTokens.Add(new Token(TokenKind.CONST, "const"));
    testTokens.Add(new Token(TokenKind.COLON, ":"));
    testTokens.Add(new Token(TokenKind.INT16, "int16"));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "value"));
    testTokens.Add(new Token(TokenKind.ASSIGNMENT, "="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // const:int32 value = 0;
    testTokens.Add(new Token(TokenKind.CONST, "const"));
    testTokens.Add(new Token(TokenKind.COLON, ":"));
    testTokens.Add(new Token(TokenKind.INT32, "int32"));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "value"));
    testTokens.Add(new Token(TokenKind.ASSIGNMENT, "="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // const:int64 value = 0;
    testTokens.Add(new Token(TokenKind.CONST, "const"));
    testTokens.Add(new Token(TokenKind.COLON, ":"));
    testTokens.Add(new Token(TokenKind.INT64, "int64"));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "value"));
    testTokens.Add(new Token(TokenKind.ASSIGNMENT, "="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // const:float32 value = 0;
    testTokens.Add(new Token(TokenKind.CONST, "const"));
    testTokens.Add(new Token(TokenKind.COLON, ":"));
    testTokens.Add(new Token(TokenKind.FLOAT32, "float32"));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "value"));
    testTokens.Add(new Token(TokenKind.ASSIGNMENT, "="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // const:float64 value = 0;
    testTokens.Add(new Token(TokenKind.CONST, "const"));
    testTokens.Add(new Token(TokenKind.COLON, ":"));
    testTokens.Add(new Token(TokenKind.FLOAT64, "float64"));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "value"));
    testTokens.Add(new Token(TokenKind.ASSIGNMENT, "="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    // const:number value = 0;
    testTokens.Add(new Token(TokenKind.CONST, "const"));
    testTokens.Add(new Token(TokenKind.COLON, ":"));
    testTokens.Add(new Token(TokenKind.NUMBER, "number"));
    testTokens.Add(new Token(TokenKind.IDENTIFIER, "value"));
    testTokens.Add(new Token(TokenKind.ASSIGNMENT, "="));
    testTokens.Add(new Token(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Token(TokenKind.SEMICOLON, ";"));
    testTokens.Add(new Token(TokenKind.EOF, ""));
   
    var lexer = new TokenLexer(input);

    foreach (var testToken in testTokens)
    {
      var token = lexer.NextToken();
      Assert.Equal(testToken.TokenKind, token.TokenKind);
      Assert.Equal(testToken.Literal, token.Literal);
    }
  }
}