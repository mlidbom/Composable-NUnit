using System;

namespace Composable.Nunit
{
    public static class ConstraintsOnIComparable
    {
        public static IConstraint<TActual> GreaterThan<TActual,TReference>(this IConstraintResolver<TActual> me, IComparable<TReference> reference)
        {
            return me.ResolveWith(expr => expr.GreaterThan(reference));
        }

        public static IConstraint<TActual> GreaterThanOrEqualTo<TActual, TReference>(this IConstraintResolver<TActual> me, IComparable<TReference> reference)
        {
            return me.ResolveWith(expr => expr.GreaterThanOrEqualTo(reference));
        }

        public static IConstraint<TActual> LessThan<TActual, TReference>(this IConstraintResolver<TActual> me, IComparable<TReference> reference)
        {
            return me.ResolveWith(expr => expr.LessThan(reference));
        }

        public static IConstraint<TActual> LessThanOrEqualTo<TActual, TReference>(this IConstraintResolver<TActual> me, IComparable<TReference> reference)
        {
            return me.ResolveWith(expr => expr.LessThanOrEqualTo(reference));
        }
    }
}