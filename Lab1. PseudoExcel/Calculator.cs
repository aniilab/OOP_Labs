using Antlr4.Runtime;
using System;
using System.Collections.Generic;

namespace PseudoExcel
{
    public static class Calculator
    {
        private static List<string> checkedCellNames = new List<string>();
        public static List<string> GetCheckedNames()
        {
            return checkedCellNames;
        }
        public static string Evaluate(string expression)
        {
            if (expression == string.Empty)
                return string.Empty;

            checkedCellNames.Clear();
            var lexer = new PseudoExcelLexer(new AntlrInputStream(expression));
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new ThrowExceptionErrorListener());

            var tokens = new CommonTokenStream(lexer);
            var parser = new PseudoExcelParser(tokens);

            var tree = parser.compileUnit();

            var visitor = new PseudoExcelVisitor();
            double res = visitor.Visit(tree);
            checkedCellNames = visitor.GetCheckedNames();

            return Convert.ToString(res);
        }
    }
}
