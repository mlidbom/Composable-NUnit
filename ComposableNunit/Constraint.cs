using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Composable.Nunit
{
    public interface IConstraint<TActual>
    {
        Constraint InnerConstraint { get; }
        TActual Actual { get; }
    }

    public class Constraint<TActual> : IConstraint<TActual>
    {
        public Constraint InnerConstraint { get; private set; }
        public TActual Actual { get; private set; }

        public Constraint(TActual actual, Constraint resolveConstraint)
        {
            InnerConstraint = resolveConstraint;
            Actual = actual;
        }

        private IResolveConstraint resolved;

        public override string ToString()
        {
            if (resolved == null)
            {
                resolved = ((IResolveConstraint) InnerConstraint).Resolve();
                InnerConstraint = (Constraint) resolved;
            }
            var writer = new TextMessageWriter();
            InnerConstraint.WriteDescriptionTo(writer);

            return writer.ToString();
        }
    }
}