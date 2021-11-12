//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from D:\c#\PseudoExcel\PseudoExcelExpressionCalculator\PseudoExcel.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace PseudoExcelExpressionCalculator {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class PseudoExcelParser : Parser {
	public const int
		NUMBER=1, IDENTIFIER=2, INT=3, MULTIPLY=4, DIVIDE=5, ADD=6, SUBSTRACT=7, 
		EXPONENT=8, INC=9, DEC=10, MAX=11, MIN=12, LPAREN=13, RPAREN=14, COMMA=15, 
		WS=16;
	public const int
		RULE_compileUnit = 0, RULE_expression = 1;
	public static readonly string[] ruleNames = {
		"compileUnit", "expression"
	};

	private static readonly string[] _LiteralNames = {
		null, null, null, null, "'*'", "'/'", "'+'", "'-'", "'^'", "'inc'", "'dec'", 
		"'max'", "'min'", "'('", "')'", "','"
	};
	private static readonly string[] _SymbolicNames = {
		null, "NUMBER", "IDENTIFIER", "INT", "MULTIPLY", "DIVIDE", "ADD", "SUBSTRACT", 
		"EXPONENT", "INC", "DEC", "MAX", "MIN", "LPAREN", "RPAREN", "COMMA", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[System.Obsolete("Use Vocabulary instead.")]
	public static readonly string[] tokenNames = GenerateTokenNames(DefaultVocabulary, _SymbolicNames.Length);

	private static string[] GenerateTokenNames(IVocabulary vocabulary, int length) {
		string[] tokenNames = new string[length];
		for (int i = 0; i < tokenNames.Length; i++) {
			tokenNames[i] = vocabulary.GetLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = vocabulary.GetSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}

		return tokenNames;
	}

	[System.Obsolete("Use IRecognizer.Vocabulary instead.")]
	public override string[] TokenNames
	{
		get
		{
			return tokenNames;
		}
	}

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "PseudoExcel.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public PseudoExcelParser(ITokenStream input)
		: base(input)
	{
		_interp = new ParserATNSimulator(this,_ATN);
	}
	public partial class CompileUnitContext : ParserRuleContext {
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public ITerminalNode Eof() { return GetToken(PseudoExcelParser.Eof, 0); }
		public CompileUnitContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_compileUnit; } }
		public override void EnterRule(IParseTreeListener listener) {
			IPseudoExcelListener typedListener = listener as IPseudoExcelListener;
			if (typedListener != null) typedListener.EnterCompileUnit(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IPseudoExcelListener typedListener = listener as IPseudoExcelListener;
			if (typedListener != null) typedListener.ExitCompileUnit(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPseudoExcelVisitor<TResult> typedVisitor = visitor as IPseudoExcelVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitCompileUnit(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public CompileUnitContext compileUnit() {
		CompileUnitContext _localctx = new CompileUnitContext(_ctx, State);
		EnterRule(_localctx, 0, RULE_compileUnit);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 4; expression(0);
			State = 5; Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExpressionContext : ParserRuleContext {
		public ExpressionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expression; } }
	 
		public ExpressionContext() { }
		public virtual void CopyFrom(ExpressionContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class MultiplicativeExprContext : ExpressionContext {
		public IToken operatorToken;
		public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
		}
		public ITerminalNode MULTIPLY() { return GetToken(PseudoExcelParser.MULTIPLY, 0); }
		public ITerminalNode DIVIDE() { return GetToken(PseudoExcelParser.DIVIDE, 0); }
		public MultiplicativeExprContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IPseudoExcelListener typedListener = listener as IPseudoExcelListener;
			if (typedListener != null) typedListener.EnterMultiplicativeExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IPseudoExcelListener typedListener = listener as IPseudoExcelListener;
			if (typedListener != null) typedListener.ExitMultiplicativeExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPseudoExcelVisitor<TResult> typedVisitor = visitor as IPseudoExcelVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMultiplicativeExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class ExponentialExprContext : ExpressionContext {
		public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
		}
		public ITerminalNode EXPONENT() { return GetToken(PseudoExcelParser.EXPONENT, 0); }
		public ExponentialExprContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IPseudoExcelListener typedListener = listener as IPseudoExcelListener;
			if (typedListener != null) typedListener.EnterExponentialExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IPseudoExcelListener typedListener = listener as IPseudoExcelListener;
			if (typedListener != null) typedListener.ExitExponentialExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPseudoExcelVisitor<TResult> typedVisitor = visitor as IPseudoExcelVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitExponentialExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class AdditiveExprContext : ExpressionContext {
		public IToken operatorToken;
		public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
		}
		public ITerminalNode ADD() { return GetToken(PseudoExcelParser.ADD, 0); }
		public ITerminalNode SUBSTRACT() { return GetToken(PseudoExcelParser.SUBSTRACT, 0); }
		public AdditiveExprContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IPseudoExcelListener typedListener = listener as IPseudoExcelListener;
			if (typedListener != null) typedListener.EnterAdditiveExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IPseudoExcelListener typedListener = listener as IPseudoExcelListener;
			if (typedListener != null) typedListener.ExitAdditiveExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPseudoExcelVisitor<TResult> typedVisitor = visitor as IPseudoExcelVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAdditiveExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class NumberExprContext : ExpressionContext {
		public ITerminalNode NUMBER() { return GetToken(PseudoExcelParser.NUMBER, 0); }
		public NumberExprContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IPseudoExcelListener typedListener = listener as IPseudoExcelListener;
			if (typedListener != null) typedListener.EnterNumberExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IPseudoExcelListener typedListener = listener as IPseudoExcelListener;
			if (typedListener != null) typedListener.ExitNumberExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPseudoExcelVisitor<TResult> typedVisitor = visitor as IPseudoExcelVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitNumberExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class IdentifierExprContext : ExpressionContext {
		public ITerminalNode IDENTIFIER() { return GetToken(PseudoExcelParser.IDENTIFIER, 0); }
		public IdentifierExprContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IPseudoExcelListener typedListener = listener as IPseudoExcelListener;
			if (typedListener != null) typedListener.EnterIdentifierExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IPseudoExcelListener typedListener = listener as IPseudoExcelListener;
			if (typedListener != null) typedListener.ExitIdentifierExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPseudoExcelVisitor<TResult> typedVisitor = visitor as IPseudoExcelVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitIdentifierExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class ParenthesizedExprContext : ExpressionContext {
		public ITerminalNode LPAREN() { return GetToken(PseudoExcelParser.LPAREN, 0); }
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public ITerminalNode RPAREN() { return GetToken(PseudoExcelParser.RPAREN, 0); }
		public ParenthesizedExprContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IPseudoExcelListener typedListener = listener as IPseudoExcelListener;
			if (typedListener != null) typedListener.EnterParenthesizedExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IPseudoExcelListener typedListener = listener as IPseudoExcelListener;
			if (typedListener != null) typedListener.ExitParenthesizedExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPseudoExcelVisitor<TResult> typedVisitor = visitor as IPseudoExcelVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitParenthesizedExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class IncDecExprContext : ExpressionContext {
		public IToken operatorToken;
		public ITerminalNode LPAREN() { return GetToken(PseudoExcelParser.LPAREN, 0); }
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public ITerminalNode RPAREN() { return GetToken(PseudoExcelParser.RPAREN, 0); }
		public ITerminalNode INC() { return GetToken(PseudoExcelParser.INC, 0); }
		public ITerminalNode DEC() { return GetToken(PseudoExcelParser.DEC, 0); }
		public IncDecExprContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IPseudoExcelListener typedListener = listener as IPseudoExcelListener;
			if (typedListener != null) typedListener.EnterIncDecExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IPseudoExcelListener typedListener = listener as IPseudoExcelListener;
			if (typedListener != null) typedListener.ExitIncDecExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPseudoExcelVisitor<TResult> typedVisitor = visitor as IPseudoExcelVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitIncDecExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class MaxMinExprContext : ExpressionContext {
		public IToken operatorToken;
		public ITerminalNode LPAREN() { return GetToken(PseudoExcelParser.LPAREN, 0); }
		public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
		}
		public ITerminalNode COMMA() { return GetToken(PseudoExcelParser.COMMA, 0); }
		public ITerminalNode RPAREN() { return GetToken(PseudoExcelParser.RPAREN, 0); }
		public ITerminalNode MAX() { return GetToken(PseudoExcelParser.MAX, 0); }
		public ITerminalNode MIN() { return GetToken(PseudoExcelParser.MIN, 0); }
		public MaxMinExprContext(ExpressionContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IPseudoExcelListener typedListener = listener as IPseudoExcelListener;
			if (typedListener != null) typedListener.EnterMaxMinExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IPseudoExcelListener typedListener = listener as IPseudoExcelListener;
			if (typedListener != null) typedListener.ExitMaxMinExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPseudoExcelVisitor<TResult> typedVisitor = visitor as IPseudoExcelVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMaxMinExpr(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExpressionContext expression() {
		return expression(0);
	}

	private ExpressionContext expression(int _p) {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = State;
		ExpressionContext _localctx = new ExpressionContext(_ctx, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 2;
		EnterRecursionRule(_localctx, 2, RULE_expression, _p);
		int _la;
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 26;
			_errHandler.Sync(this);
			switch (_input.La(1)) {
			case LPAREN:
				{
				_localctx = new ParenthesizedExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				State = 8; Match(LPAREN);
				State = 9; expression(0);
				State = 10; Match(RPAREN);
				}
				break;
			case MAX:
			case MIN:
				{
				_localctx = new MaxMinExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				State = 12;
				((MaxMinExprContext)_localctx).operatorToken = _input.Lt(1);
				_la = _input.La(1);
				if ( !(_la==MAX || _la==MIN) ) {
					((MaxMinExprContext)_localctx).operatorToken = _errHandler.RecoverInline(this);
				} else {
					if (_input.La(1) == TokenConstants.Eof) {
						matchedEOF = true;
					}

					_errHandler.ReportMatch(this);
					Consume();
				}
				State = 13; Match(LPAREN);
				State = 14; expression(0);
				State = 15; Match(COMMA);
				State = 16; expression(0);
				State = 17; Match(RPAREN);
				}
				break;
			case INC:
			case DEC:
				{
				_localctx = new IncDecExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				State = 19;
				((IncDecExprContext)_localctx).operatorToken = _input.Lt(1);
				_la = _input.La(1);
				if ( !(_la==INC || _la==DEC) ) {
					((IncDecExprContext)_localctx).operatorToken = _errHandler.RecoverInline(this);
				} else {
					if (_input.La(1) == TokenConstants.Eof) {
						matchedEOF = true;
					}

					_errHandler.ReportMatch(this);
					Consume();
				}
				State = 20; Match(LPAREN);
				State = 21; expression(0);
				State = 22; Match(RPAREN);
				}
				break;
			case NUMBER:
				{
				_localctx = new NumberExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				State = 24; Match(NUMBER);
				}
				break;
			case IDENTIFIER:
				{
				_localctx = new IdentifierExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				State = 25; Match(IDENTIFIER);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			_ctx.stop = _input.Lt(-1);
			State = 39;
			_errHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(_input,2,_ctx);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.InvalidAltNumber ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					State = 37;
					_errHandler.Sync(this);
					switch ( Interpreter.AdaptivePredict(_input,1,_ctx) ) {
					case 1:
						{
						_localctx = new ExponentialExprContext(new ExpressionContext(_parentctx, _parentState));
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 28;
						if (!(Precpred(_ctx, 7))) throw new FailedPredicateException(this, "Precpred(_ctx, 7)");
						State = 29; Match(EXPONENT);
						State = 30; expression(8);
						}
						break;

					case 2:
						{
						_localctx = new MultiplicativeExprContext(new ExpressionContext(_parentctx, _parentState));
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 31;
						if (!(Precpred(_ctx, 6))) throw new FailedPredicateException(this, "Precpred(_ctx, 6)");
						State = 32;
						((MultiplicativeExprContext)_localctx).operatorToken = _input.Lt(1);
						_la = _input.La(1);
						if ( !(_la==MULTIPLY || _la==DIVIDE) ) {
							((MultiplicativeExprContext)_localctx).operatorToken = _errHandler.RecoverInline(this);
						} else {
							if (_input.La(1) == TokenConstants.Eof) {
								matchedEOF = true;
							}

							_errHandler.ReportMatch(this);
							Consume();
						}
						State = 33; expression(7);
						}
						break;

					case 3:
						{
						_localctx = new AdditiveExprContext(new ExpressionContext(_parentctx, _parentState));
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 34;
						if (!(Precpred(_ctx, 4))) throw new FailedPredicateException(this, "Precpred(_ctx, 4)");
						State = 35;
						((AdditiveExprContext)_localctx).operatorToken = _input.Lt(1);
						_la = _input.La(1);
						if ( !(_la==ADD || _la==SUBSTRACT) ) {
							((AdditiveExprContext)_localctx).operatorToken = _errHandler.RecoverInline(this);
						} else {
							if (_input.La(1) == TokenConstants.Eof) {
								matchedEOF = true;
							}

							_errHandler.ReportMatch(this);
							Consume();
						}
						State = 36; expression(5);
						}
						break;
					}
					} 
				}
				State = 41;
				_errHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(_input,2,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			UnrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 1: return expression_sempred((ExpressionContext)_localctx, predIndex);
		}
		return true;
	}
	private bool expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return Precpred(_ctx, 7);

		case 1: return Precpred(_ctx, 6);

		case 2: return Precpred(_ctx, 4);
		}
		return true;
	}

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x3\x12-\x4\x2\t\x2"+
		"\x4\x3\t\x3\x3\x2\x3\x2\x3\x2\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3"+
		"\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3"+
		"\x3\x5\x3\x1D\n\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3"+
		"\x3\a\x3(\n\x3\f\x3\xE\x3+\v\x3\x3\x3\x2\x2\x3\x4\x4\x2\x2\x4\x2\x2\x6"+
		"\x3\x2\r\xE\x3\x2\v\f\x3\x2\x6\a\x3\x2\b\t\x31\x2\x6\x3\x2\x2\x2\x4\x1C"+
		"\x3\x2\x2\x2\x6\a\x5\x4\x3\x2\a\b\a\x2\x2\x3\b\x3\x3\x2\x2\x2\t\n\b\x3"+
		"\x1\x2\n\v\a\xF\x2\x2\v\f\x5\x4\x3\x2\f\r\a\x10\x2\x2\r\x1D\x3\x2\x2\x2"+
		"\xE\xF\t\x2\x2\x2\xF\x10\a\xF\x2\x2\x10\x11\x5\x4\x3\x2\x11\x12\a\x11"+
		"\x2\x2\x12\x13\x5\x4\x3\x2\x13\x14\a\x10\x2\x2\x14\x1D\x3\x2\x2\x2\x15"+
		"\x16\t\x3\x2\x2\x16\x17\a\xF\x2\x2\x17\x18\x5\x4\x3\x2\x18\x19\a\x10\x2"+
		"\x2\x19\x1D\x3\x2\x2\x2\x1A\x1D\a\x3\x2\x2\x1B\x1D\a\x4\x2\x2\x1C\t\x3"+
		"\x2\x2\x2\x1C\xE\x3\x2\x2\x2\x1C\x15\x3\x2\x2\x2\x1C\x1A\x3\x2\x2\x2\x1C"+
		"\x1B\x3\x2\x2\x2\x1D)\x3\x2\x2\x2\x1E\x1F\f\t\x2\x2\x1F \a\n\x2\x2 (\x5"+
		"\x4\x3\n!\"\f\b\x2\x2\"#\t\x4\x2\x2#(\x5\x4\x3\t$%\f\x6\x2\x2%&\t\x5\x2"+
		"\x2&(\x5\x4\x3\a\'\x1E\x3\x2\x2\x2\'!\x3\x2\x2\x2\'$\x3\x2\x2\x2(+\x3"+
		"\x2\x2\x2)\'\x3\x2\x2\x2)*\x3\x2\x2\x2*\x5\x3\x2\x2\x2+)\x3\x2\x2\x2\x5"+
		"\x1C\')";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace PseudoExcelExpressionCalculator
