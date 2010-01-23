using System;
using System.Collections.Generic;
using NUnit.Framework.Constraints;

namespace Composable.Nunit
{
    public interface IConstraintResolver<TActual>
    {
        IConstraint<TActual> ResolveWith(Func<ConstraintExpression, Constraint> func);
    }

    public interface IConstraintExpression<TActual> : IConstraintResolver<TActual>
    {
        IConstraintExpression<TActual> Append(Func<ConstraintExpression, ConstraintExpression> appender);
    }

    public interface INestedConstraintExpression<TActual, TConstraintExpression> : IConstraintResolver<TActual>
    {
        TConstraintExpression Append(Func<ConstraintExpression, ConstraintExpression> appender);
    }

    public interface IEnumerableItemConstraintExpression<TActual> :
        INestedConstraintExpression<IEnumerable<TActual>, IEnumerableItemConstraintExpression<TActual>>
    {
    }

    public sealed class ConstraintExpression<TActual> : IConstraintExpression<TActual>
    {
        public ConstraintExpression Expression { get; set; }

        public TActual Actual { get; private set; }

        public ConstraintExpression(TActual actual, ConstraintExpression expression)
        {
            Actual = actual;
            Expression = expression;
        }

        public ConstraintExpression(TActual actual) : this(actual, new ConstraintExpression())
        {
        }

        public IConstraint<TActual> ResolveWith(Func<ConstraintExpression, Constraint> func)
        {
            return new Constraint<TActual>(Actual, func(Expression));
        }

        public IConstraintExpression<TActual> Append(Func<ConstraintExpression, ConstraintExpression> appender)
        {
            return new ConstraintExpression<TActual>(Actual, appender(Expression));
        }
    }
}