using Relua.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace DSM.API.Utilities {

	public static class LuaHelper {

		public static IExpression FindVariableValue(Block root, string name, Func<IExpression, bool> check, IStatement origin) {
			Variable var;
			Assignment ass;
			IExpression expr;
			foreach (IStatement statement in root.Statements) {
				if (statement == origin) {
					return null;
				}

				// TODO: this is a flat scan, maybe implement a hierarchical scan later?
				if ((ass = (statement as Assignment)) == null) {
					continue;
				}

				foreach (Variable target in ass.Targets) {
					if (target.Name != name) {
						continue;
					}

					foreach (IExpression value in ass.Values) {
						if ((var = (value as Variable)) == null) {
							if (check != null && !check(value)) {
								continue;
							}

							return value;
						}

						expr = FindVariableValue(root, var.Name, check, statement);
						if (expr != null) {
							return expr;
						}
					}
				}
			}

			return null;
		}


		public static TExpression FindVariableValue<TExpression>(Block root, string name, Func<TExpression, bool> check, IStatement origin) where TExpression : class, IExpression {
			IExpression expr = FindVariableValue(
				root,
				name,
				(x) => (x is TExpression),
				origin
			);

			TExpression texpr = (expr as TExpression);
			if (check != null && !check(texpr)) {
				return null;
			}

			return texpr;
		}




		public static string GetExpressionStringValue(IExpression expression) {
			if (expression is StringLiteral literal) {
				return literal.Value;
			} else if (expression is FunctionCall functionCall) {
				if (functionCall.Function is Variable function && function.Name != "_") {
					return null;
				}

				if (functionCall.Arguments?.Count < 1) {
					return null;
				}

				return GetExpressionStringValue(functionCall.Arguments[0]);
			}

			return null;
		}

	}

}
