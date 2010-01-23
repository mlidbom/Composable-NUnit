using System;
using NUnit.Framework.Constraints;

namespace Composable.Nunit
{
    public class RelationShipConstraint<TActual, TExpected> : Constraint
    {
        public TActual Actual;
        public TExpected Expected { get; set; }

        public RelationShipConstraint(TExpected expected)
        {
            Expected = expected;
        }

        public override bool Matches(object actual)
        {
            this.actual = actual;
            return Condition(((TActual) actual));
        }

        public override void WriteDescriptionTo(MessageWriter writer)
        {
            if (!string.IsNullOrEmpty(Description))
            {
                writer.WritePredicate(Description);
            }
            writer.WriteExpectedValue(Expected);
        }

        public string Description { private get; set; }
        public Func<TActual, bool> Condition { private get; set; }
    }
}