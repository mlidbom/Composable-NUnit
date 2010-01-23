using System.Collections.Generic;

namespace Composable.Nunit
{
    public static class ConstraintsOnObject
    {
        public static IConstraint<T> Equal<T>(this IConstraintResolver<T> me, object reference)
        {
            return me.ResolveWith(expression => expression.EqualTo(reference));
        }
    }
}