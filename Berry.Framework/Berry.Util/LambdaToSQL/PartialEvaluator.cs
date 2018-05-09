using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LambdaToSQL
{
    /// <summary>
    ///重写一个表达示树,并将其中引用变量转换成常量
    ///去除所附加的类信息
    /// </summary>
    internal static class PartialEvaluator
    {
        /// <summary>
        /// Performs evaluation & replacement of independent sub-trees
        /// </summary>
        /// <param name="expression">The root of the expression tree.</param>
        /// <returns>A new tree with sub-trees evaluated and replaced.</returns>
        public static Expression Eval(Expression expression)
        {
            return Eval(expression, null);
        }

        /// <summary>
        /// Performs evaluation & replacement of independent sub-trees
        /// </summary>
        /// <param name="expression">The root of the expression tree.</param>
        /// <param name="fnCanBeEvaluated">A function that decides whether a given expression node can be part of the local function.</param>
        /// <returns>A new tree with sub-trees evaluated and replaced.</returns>
        private static Expression Eval(Expression expression, Func<Expression, bool> fnCanBeEvaluated)
        {
            if (fnCanBeEvaluated == null)
                fnCanBeEvaluated = PartialEvaluator.CanBeEvaluatedLocally;
            return SubtreeEvaluator.Eval(Nominator.Nominate(fnCanBeEvaluated, expression), expression);
        }

        private static bool CanBeEvaluatedLocally(Expression expression)
        {
            return expression.NodeType != ExpressionType.Parameter;
        }

        /// <summary>
        /// Evaluates & replaces sub-trees when first candidate is reached (top-down)
        /// </summary>
        private class SubtreeEvaluator : ExpressionVisitor
        {
            private readonly HashSet<Expression> _candidates;

            private SubtreeEvaluator(HashSet<Expression> candidates)
            {
                this._candidates = candidates;
            }

            internal static Expression Eval(HashSet<Expression> candidates, Expression exp)
            {
                return new SubtreeEvaluator(candidates).Visit(exp);
            }

            protected override Expression Visit(Expression exp)
            {
                if (exp == null)
                {
                    return null;
                }

                if (this._candidates.Contains(exp))
                {
                    return this.Evaluate(exp);
                }

                return base.Visit(exp);
            }

            private Expression Evaluate(Expression e)
            {
                Type type = e.Type;

                // check for nullable converts & strip them
                if (e.NodeType == ExpressionType.Convert)
                {
                    var u = (UnaryExpression)e;
                    if (TypeHelper.GetNonNullableType(u.Operand.Type) == TypeHelper.GetNonNullableType(type))
                    {
                        e = ((UnaryExpression)e).Operand;
                    }
                }

                // if we now just have a constant, return it
                if (e.NodeType == ExpressionType.Constant)
                {
                    var ce = (ConstantExpression)e;

                    // if we've lost our nullable typeness add it back
                    if (e.Type != type && TypeHelper.GetNonNullableType(e.Type) == TypeHelper.GetNonNullableType(type))
                    {
                        e = ce = Expression.Constant(ce.Value, type);
                    }

                    return e;
                }

                var me = e as MemberExpression;
                if (me != null)
                {
                    // member accesses off of constant's are common, and yet since these partial evals
                    // are never re-used, using reflection to access the member is faster than compiling
                    // and invoking a lambda
                    var ce = me.Expression as ConstantExpression;
                    if (ce != null)
                    {
                        return Expression.Constant(me.Member.GetValue(ce.Value), type);
                    }
                }

                if (type.IsValueType)
                {
                    e = Expression.Convert(e, typeof(object));
                }

                Expression<Func<object>> lambda = Expression.Lambda<Func<object>>(e);
#if NOREFEMIT
                Func<object> fn = ExpressionEvaluator.CreateDelegate(lambda);
#else
                Func<object> fn = lambda.Compile();
#endif
                return Expression.Constant(fn(), type);
            }
        }

        /// <summary>
        /// Performs bottom-up analysis to determine which nodes can possibly
        /// be part of an evaluated sub-tree.
        /// </summary>
        private class Nominator : ExpressionVisitor
        {
            private readonly Func<Expression, bool> _fnCanBeEvaluated;
            private readonly HashSet<Expression> _candidates;
            private bool _cannotBeEvaluated;

            private Nominator(Func<Expression, bool> fnCanBeEvaluated)
            {
                this._candidates = new HashSet<Expression>();
                this._fnCanBeEvaluated = fnCanBeEvaluated;
            }

            internal static HashSet<Expression> Nominate(Func<Expression, bool> fnCanBeEvaluated, Expression expression)
            {
                Nominator nominator = new Nominator(fnCanBeEvaluated);
                nominator.Visit(expression);
                return nominator._candidates;
            }

            protected override Expression VisitConstant(ConstantExpression c)
            {
                return base.VisitConstant(c);
            }

            protected override Expression Visit(Expression expression)
            {
                if (expression != null)
                {
                    bool saveCannotBeEvaluated = this._cannotBeEvaluated;
                    this._cannotBeEvaluated = false;
                    base.Visit(expression);
                    if (!this._cannotBeEvaluated)
                    {
                        if (this._fnCanBeEvaluated(expression))
                        {
                            this._candidates.Add(expression);
                        }
                        else
                        {
                            this._cannotBeEvaluated = true;
                        }
                    }
                    this._cannotBeEvaluated |= saveCannotBeEvaluated;
                }
                return expression;
            }
        }
    }
}