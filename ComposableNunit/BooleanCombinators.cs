namespace Composable.Nunit
{
    public static class BooleanCombinators
    {
        public static IConstraintExpression<TActual> And<TActual>(this IConstraint<TActual> me)
        {
            return new ConstraintExpression<TActual>(me.Actual, me.InnerConstraint.And);
        }

        public static IConstraintExpression<TActual> Or<TActual>(this IConstraint<TActual> me)
        {
            return new ConstraintExpression<TActual>(me.Actual, me.InnerConstraint.Or);
        }

        public static IConstraintExpression<TActual> Not<TActual>(this IConstraintExpression<TActual> me)
        {
            return me.Append(expression => expression.Not);
        }
    }
}