using System.Collections.Generic;
using System.Linq;

namespace Composable.Nunit
{
    public static class ConstraintBootStrapperOnIEnumerable
    {
        public static IConstraintExpression<IEnumerable<TActual>> Is<TActual>(this IEnumerable<TActual> actual)
        {
            return ConstraintBootstrapperOnObject.Is(actual.ToList().AsEnumerable());
        }

        public static IConstraintExpression<IEnumerable<TActual>> Are<TActual>(this IEnumerable<TActual> actual)
        {
            return actual.Is();
        }

        public static IConstraintExpression<IEnumerable<TActual>> Has<TActual>(this IEnumerable<TActual> actual)
        {
            return actual.Is();
        }

        public static IConstraintExpression<IEnumerable<TActual>> Will<TActual>(this IEnumerable<TActual> actual)
        {
            return actual.Is();
        }
    }
}