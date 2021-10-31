grammar PseudoExcel;

/*
 * Parser Rules
 */


compileUnit:expression EOF;

 expression:
 LPAREN expression RPAREN #ParenthesizedExpr
 | expression EXPONENT expression #ExponentialExpr
 | expression operatorToken=(MULTIPLY | DIVIDE) expression #MultiplicativeExpr
 | operatorToken=(MAX| MIN) LPAREN expression DESP expression RPAREN #MaxMinExpr
 | expression operatorToken=(ADD | SUBSTRACT) expression #AdditiveExpr
 | operatorToken=(INC| DEC) LPAREN expression RPAREN #IncDecExpr
 | NUMBER #NumberExpr
 | IDENTIFIER #IdentifierExpr
 ;

 /*
 * Lexer Rules
 */

 NUMBER:INT('.'INT)?;
 IDENTIFIER:[a-zA-Z]+[1-9][0-9]+;
 INT : ('0'..'9')+;
 MULTIPLY:'*';
 DIVIDE:'/';
 ADD:'+';
 SUBSTRACT:'-';
 EXPONENT: '^';
 INC: 'inc';
 DEC: 'dec';
 MAX:'max';
 MIN:'min';
 LPAREN:'(';
 RPAREN:')';
 COMMA:',';
 WS:[\t\r\n]->channel(HIDDEN);
