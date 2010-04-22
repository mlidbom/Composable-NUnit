namespace Composable.Nunit.Test
{
    public static class TimeConstraints
    {
        public static IConstraint<TActual> Contain<TActual>(this IConstraintExpression<TActual> me,
                                                         IPointInTime point) where TActual : ITimeInterval
        {
            return me.Constraint("Contain", point, actual => actual.Contains(point));
        }
    }
}