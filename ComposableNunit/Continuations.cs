namespace Composable.Nunit
{
    public static class Continuations
    {
        public static IConstraintExpression<T> Have<T>(this IConstraintExpression<T> me)
        {
            return me;
        }

        public static IConstraintExpression<T> Be<T>(this IConstraintExpression<T> me)
        {
            return me;
        }
    }
}