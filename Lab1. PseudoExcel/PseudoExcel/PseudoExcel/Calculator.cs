using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoExcel
{
    public static class Calculator
    {
        public static double Evaluate(string expression)
        {
            var lexer = new PseudoExcelLexer(new AntlrInputStream(expression));
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new ThrowExceptionErrorListener());

            var tokens = new CommonTokenStream(lexer);
            var parser = new PseudoExcelParser(tokens);

            var tree = parser.compileUnit();

            var visitor = new PseudoExcelVisitor();

            return visitor.Visit(tree);
        }
    }
}
