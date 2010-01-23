using System.Collections.Generic;

namespace Composable.Nunit
{
    public static class ConstraintsOnIEnumerable
    {
        public static IEnumerableItemConstraintExpression<TActual> All<TActual>(this IConstraintExpression<IEnumerable<TActual>> me)
        {
            return new EnumerableItemConstraintExpression<TActual>(me.Append(expression => expression.All));
        }

        public static IEnumerableItemConstraintExpression<TActual> None<TActual>(this IConstraintExpression<IEnumerable<TActual>> me)
        {
            return new EnumerableItemConstraintExpression<TActual>(me.Append(expression => expression.None));
        }

        public static IEnumerableItemConstraintExpression<TActual> Some<TActual>(this IConstraintExpression<IEnumerable<TActual>> me)
        {
            return new EnumerableItemConstraintExpression<TActual>(me.Append(expression => expression.Some));
        }


        public static IConstraint<IEnumerable<TActual>> Contain<TActual>(this IConstraintExpression<IEnumerable<TActual>> me, TActual reference)
        {
            return me.ResolveWith(expression => expression.Contains(reference));
        }
    }
}