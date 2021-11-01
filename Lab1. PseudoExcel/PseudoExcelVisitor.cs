using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PseudoExcel
{
    class PseudoExcelVisitor : PseudoExcelBaseVisitor<double>
    {
        Dictionary<string, double> tableIdentifier = new Dictionary<string, double>();
        public List<string> GetCheckedNames()
        {
            List<string> res = new List<string>();
            foreach(var pair in tableIdentifier)
            {
                res.Add(pair.Key);
            }
            return res;
        }
        public override double VisitCompileUnit(PseudoExcelParser.CompileUnitContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitNumberExpr(PseudoExcelParser.NumberExprContext context)
        {
            var result = double.Parse(context.GetText());
            Debug.WriteLine(result);
            return result;
        }


        public override double VisitIdentifierExpr(PseudoExcelParser.IdentifierExprContext context)
        {
            var result = context.GetText();
            double value;
            if (tableIdentifier.TryGetValue(result.ToString(), out value))
            {
                return value;
            }
            else
            {
                return 0.0;
            }
        }

        public override double VisitParenthesizedExpr([NotNull] PseudoExcelParser.ParenthesizedExprContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitExponentialExpr([NotNull] PseudoExcelParser.ExponentialExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            Debug.WriteLine("{0} ^ {1}", left, right);
            return System.Math.Pow(left, right);
        }

        public override double VisitAdditiveExpr([NotNull] PseudoExcelParser.AdditiveExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (context.operatorToken.Type == PseudoExcelLexer.ADD)
            {
                Debug.WriteLine("{0}+{1}", left, right);
                return left + right;
            }
            else
            {
                Debug.WriteLine("{0}-{1}", left, right);
                return left - right;
            }
        }
        public override double VisitMultiplicativeExpr([NotNull] PseudoExcelParser.MultiplicativeExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (context.operatorToken.Type == PseudoExcelLexer.MULTIPLY)
            {
                Debug.WriteLine("{0}*{1}", left, right);
                return left * right;
            }
            else
            {
                Debug.WriteLine("{0} / {1}", left, right);
                return left / right;
            }
        }

        public override double VisitMaxMinExpr([NotNull] PseudoExcelParser.MaxMinExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (context.operatorToken.Type == PseudoExcelLexer.MAX)
            {
                Debug.WriteLine("max({0},{1})", left, right);
                return Math.Max(left, right);
            }
            else
            {
                Debug.WriteLine("min({0},{1})", left, right);
                return Math.Min(left, right);
            }
        }

        public override double VisitIncDecExpr([NotNull] PseudoExcelParser.IncDecExprContext context)
        {
            var number = WalkLeft(context);
            if (context.operatorToken.Type == PseudoExcelLexer.INC)
            {
                Debug.WriteLine("inc ({0})", number);
                return number + 1;
            }
            else
            {
                Debug.WriteLine("dec ({0})", number);
                return number - 1;
            }
        }

        private double WalkLeft(PseudoExcelParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<PseudoExcelParser.ExpressionContext>(0));
        }

        private double WalkRight(PseudoExcelParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<PseudoExcelParser.ExpressionContext>(1));
        }
    }
}
