using System.Collections.Generic;

using Compiler.Lib.Lexer;

using Xunit;
namespace Compiler.Tests.Parsers;

public class LexerTest
{

  [Fact]
  public void TokensTest()
  {
    var input = "{}[]().,;:<>&|^=+-*/!";

    var testTokens = new List<Tokens>();
    testTokens.Add(new Tokens(TokenKind.OPEN_BRACE, "{"));
    testTokens.Add(new Tokens(TokenKind.CLOSE_BRACE, "}"));
    testTokens.Add(new Tokens(TokenKind.OPEN_BRACKET, "["));
    testTokens.Add(new Tokens(TokenKind.CLOSE_BRACKET, "]"));
    testTokens.Add(new Tokens(TokenKind.OPEN_PAREN, "("));
    testTokens.Add(new Tokens(TokenKind.CLOSE_PAREN, ")"));
    testTokens.Add(new Tokens(TokenKind.DOT, "."));
    testTokens.Add(new Tokens(TokenKind.COMMA, ","));
    testTokens.Add(new Tokens(TokenKind.SEMICOLON, ";"));
    testTokens.Add(new Tokens(TokenKind.COLON, ":"));
    testTokens.Add(new Tokens(TokenKind.LT, "<"));
    testTokens.Add(new Tokens(TokenKind.GT, ">"));
    testTokens.Add(new Tokens(TokenKind.AMP, "&"));
    testTokens.Add(new Tokens(TokenKind.BITWISE_OR, "|"));
    testTokens.Add(new Tokens(TokenKind.CARET, "^"));

    testTokens.Add(new Tokens(TokenKind.ASSIGNMENT, "="));
    testTokens.Add(new Tokens(TokenKind.PLUS, "+"));
    testTokens.Add(new Tokens(TokenKind.MINUS, "-"));
    testTokens.Add(new Tokens(TokenKind.STAR, "*"));
    testTokens.Add(new Tokens(TokenKind.DIV, "/"));
    testTokens.Add(new Tokens(TokenKind.BANG, "!"));
    testTokens.Add(new Tokens(TokenKind.EOF, ""));

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

    var testTokens = new List<Tokens>();
    // const a = 5;
    testTokens.Add(new Tokens(TokenKind.CONST, "const"));
    testTokens.Add(new Tokens(TokenKind.IDENTIFIER, "a"));
    testTokens.Add(new Tokens(TokenKind.ASSIGNMENT, "="));
    testTokens.Add(new Tokens(TokenKind.INTEGER_LITERAL, "5"));
    testTokens.Add(new Tokens(TokenKind.SEMICOLON, ";"));
    // const a = 5;
    testTokens.Add(new Tokens(TokenKind.CONST, "const"));
    testTokens.Add(new Tokens(TokenKind.IDENTIFIER, "ten"));
    testTokens.Add(new Tokens(TokenKind.ASSIGNMENT, "="));
    testTokens.Add(new Tokens(TokenKind.INTEGER_LITERAL, "10"));
    testTokens.Add(new Tokens(TokenKind.SEMICOLON, ";"));
    // let add = (x, y) => 
    // { 
    //   x + y;
    // };
    testTokens.Add(new Tokens(TokenKind.LET, "let"));
    testTokens.Add(new Tokens(TokenKind.IDENTIFIER, "add"));
    testTokens.Add(new Tokens(TokenKind.ASSIGNMENT, "="));
    testTokens.Add(new Tokens(TokenKind.OPEN_PAREN, "("));
    testTokens.Add(new Tokens(TokenKind.IDENTIFIER, "x"));
    testTokens.Add(new Tokens(TokenKind.COMMA, ","));
    testTokens.Add(new Tokens(TokenKind.IDENTIFIER, "y"));
    testTokens.Add(new Tokens(TokenKind.CLOSE_PAREN, ")"));
    testTokens.Add(new Tokens(TokenKind.RIGHT_ALLOW, "=>"));
    testTokens.Add(new Tokens(TokenKind.OPEN_BRACE, "{"));
    testTokens.Add(new Tokens(TokenKind.IDENTIFIER, "x"));
    testTokens.Add(new Tokens(TokenKind.PLUS, "+"));
    testTokens.Add(new Tokens(TokenKind.IDENTIFIER, "y"));
    testTokens.Add(new Tokens(TokenKind.SEMICOLON, ";"));
    testTokens.Add(new Tokens(TokenKind.CLOSE_BRACE, "}"));
    testTokens.Add(new Tokens(TokenKind.SEMICOLON, ";"));
    // let result = add(a, ten);
    testTokens.Add(new Tokens(TokenKind.LET, "let"));
    testTokens.Add(new Tokens(TokenKind.IDENTIFIER, "result"));
    testTokens.Add(new Tokens(TokenKind.ASSIGNMENT, "="));
    testTokens.Add(new Tokens(TokenKind.IDENTIFIER, "add"));
    testTokens.Add(new Tokens(TokenKind.OPEN_PAREN, "("));
    testTokens.Add(new Tokens(TokenKind.IDENTIFIER, "a"));
    testTokens.Add(new Tokens(TokenKind.COMMA, ","));
    testTokens.Add(new Tokens(TokenKind.IDENTIFIER, "ten"));
    testTokens.Add(new Tokens(TokenKind.CLOSE_PAREN, ")"));
    testTokens.Add(new Tokens(TokenKind.SEMICOLON, ";"));
    testTokens.Add(new Tokens(TokenKind.EOF, ""));

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

    var testTokens = new List<Tokens>();

    // ++1;
    testTokens.Add(new Tokens(TokenKind.OP_INC, "++"));
    testTokens.Add(new Tokens(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Tokens(TokenKind.SEMICOLON, ";"));
    // --1;
    testTokens.Add(new Tokens(TokenKind.OP_DEC, "--"));
    testTokens.Add(new Tokens(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Tokens(TokenKind.SEMICOLON, ";"));
    // 1 && 1;
    testTokens.Add(new Tokens(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Tokens(TokenKind.OP_AND, "&&"));
    testTokens.Add(new Tokens(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Tokens(TokenKind.SEMICOLON, ";"));
    // 1 || 1;
    testTokens.Add(new Tokens(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Tokens(TokenKind.OP_OR, "||"));
    testTokens.Add(new Tokens(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Tokens(TokenKind.SEMICOLON, ";"));
    // 1 == 1;
    testTokens.Add(new Tokens(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Tokens(TokenKind.OP_EQ, "=="));
    testTokens.Add(new Tokens(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Tokens(TokenKind.SEMICOLON, ";"));
    // 1 != 0;
    testTokens.Add(new Tokens(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Tokens(TokenKind.OP_NE, "!="));
    testTokens.Add(new Tokens(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Tokens(TokenKind.SEMICOLON, ";"));
    // 1 <= 0;
    testTokens.Add(new Tokens(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Tokens(TokenKind.OP_LE, "<="));
    testTokens.Add(new Tokens(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Tokens(TokenKind.SEMICOLON, ";"));
    // 1 >= 0;
    testTokens.Add(new Tokens(TokenKind.INTEGER_LITERAL, "1"));
    testTokens.Add(new Tokens(TokenKind.OP_GE, ">="));
    testTokens.Add(new Tokens(TokenKind.INTEGER_LITERAL, "0"));
    testTokens.Add(new Tokens(TokenKind.SEMICOLON, ";"));
    testTokens.Add(new Tokens(TokenKind.EOF, ""));

    var lexer = new TokenLexer(input);

    foreach (var testToken in testTokens)
    {
      var token = lexer.NextToken();
      Assert.Equal(testToken.TokenKind, token.TokenKind);
      Assert.Equal(testToken.Literal, token.Literal);
    }
  }
}