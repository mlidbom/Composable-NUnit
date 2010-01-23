namespace Composable.Nunit
{
    public static class ConstraintsOnString
    {
        public static IConstraint<string> Contain(this IConstraintResolver<string> me, string reference)
        {
            return me.ResolveWith(expression => expression.ContainsSubstring(reference));
        }

        public static IConstraint<string> MatchRegularExpression(this IConstraintResolver<string> me, string reference)
        {
            return me.ResolveWith(expression => expression.Matches(reference));
        }

        public static IConstraint<string> EndWith(this IConstraintResolver<string> me, string reference)
        {
            return me.ResolveWith(expression => expression.EndsWith(reference));
        }

        public static IConstraint<string> StartWith(this IConstraintResolver<string> me, string reference)
        {
            return me.ResolveWith(expression => expression.StartsWith(reference));
        }
    }
}