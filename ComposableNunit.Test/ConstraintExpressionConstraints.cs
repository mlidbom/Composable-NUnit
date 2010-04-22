using System;

namespace Composable.Nunit.Test
{
    public static class ConstraintExpressionConstraints
    {
        public static IConstraint<IConstraint<TActual>> ConstraintDescription<TActual>(this IConstraintExpression<IConstraint<TActual>> me,
                                                                                       string description)
        {
            return me.Constraint("equal to", description, actual => actual.ToString().Equals(description));
        }
    }
}