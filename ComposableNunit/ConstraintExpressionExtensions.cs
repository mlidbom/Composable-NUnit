using System;

namespace Composable.Nunit
{
    public static class ConstraintExpressionExtensions
    {
        public static IConstraint<TActual> Constraint<TActual, TExpected>(this IConstraintExpression<TActual> me,
                                                                        string description,
                                                                        TExpected expected,
                                                                        Func<TActual, bool> condition)
        {
            return me.ResolveWith(_ => new RelationShipConstraint<TActual, TExpected>(expected)
                                           {
                                               Description = description,
                                               Condition = condition
                                           });
        }
    }
}