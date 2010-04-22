namespace Composable.Nunit
{
    public static class ConstraintExpressionBootStrapper
    {
        public static IConstraintExpression<T> Will<T>(this T actual)
        {
            return new ConstraintExpression<T>(actual);
        }
    }
}