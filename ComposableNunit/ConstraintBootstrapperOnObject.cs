namespace Composable.Nunit
{
    /// <summary>The T typed methods gets you into the fluent interface
    /// The more specifically typed once make sure you do not lose your context once you're
    /// in and you find yourself wanting to type Is, Will, Has etc again
    /// </summary>
    public static class ConstraintBootstrapperOnObject
    {
        public static IConstraintExpression<T> Is<T>(this T actual)
        {
            return new ConstraintExpression<T>(actual);
        }

        public static IConstraintExpression<T> Is<T>(this IConstraintExpression<T> me)
        {
            return me;
        }

        public static IConstraintExpression<T> Has<T>(this T actual)
        {
            return actual.Is();
        }

        public static IConstraintExpression<T> Has<T>(this IConstraintExpression<T> me)
        {
            return me;
        }

        public static IConstraintExpression<T> Does<T>(this T actual)
        {
            return actual.Is();
        }

        public static IConstraintExpression<T> Does<T>(this IConstraintExpression<T> me)
        {
            return me;
        }
        
        public static IConstraintExpression<T> With<T>(this T actual)
        {
            return actual.Is();
        }


        public static IConstraintExpression<T> Will<T>(this IConstraintExpression<T> me)
        {
            return me;
        }

        public static IConstraintExpression<T> Will<T>(this T actual)
        {
            return actual.Is();
        }
    }
}