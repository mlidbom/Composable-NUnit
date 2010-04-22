using NUnit.Framework;
using Void.Linq;

namespace Composable.Nunit.Test
{
    [TestFixture]
    public class TestIt
    {
        [Test]
        public void Equality()
        {
            var expectation = 1.Will().Not().Equal(2).And().Not().Equal(0);
            Expect.That(expectation.Will().Have().ConstraintDescription("not 2 and not 0"));

            expectation = 1.Will()
                .Not().Equal(1)
                .Or()
                .Be().GreaterThan(1);

            Expect.That(expectation.Will().Have().ConstraintDescription("not 1 or greater than 1"));

            expectation = 1.Will().Not().Equal(1);
            Expect.That(expectation.Will().Have().ConstraintDescription("not 1"));
        }

        [Test]
        public void CollectionConstraints()
        {
            var constraint = 1.Through(3).Will().Have()
                .All().GreaterThan(0).And().Some().LessThanOrEqualTo(2).And().None().GreaterThanOrEqualTo(3);
            Expect.That(
                constraint.Will().Have().ConstraintDescription(
                    "all items greater than 0 and some item less than or equal to 2 and no item greater than or equal to 3"));
        }

        [Test]
        public void IComparable()
        {
            var constraint = 0.Will().Be()
                .GreaterThan(-1).And().GreaterThanOrEqualTo(0).And().LessThan(1).And().LessThanOrEqualTo(0);
            Expect.That(
                constraint.Will().Have().ConstraintDescription(
                    "greater than -1 and greater than or equal to 0 and less than 1 and less than or equal to 0"));
        }

        [Test]
        public void HandlesContains()
        {
            var expectation = 1.Through(3).Will()
                .Contain(1).And().Contain(2).And().Contain(3);
            Expect.That(
                expectation.Will().Have().ConstraintDescription(
                    "collection containing 1 and collection containing 2 and collection containing 3"));

            Expect.That(1.Through(3).Will().Contain(1).And().Contain(2).And().Contain(3));
        }

        [Test]
        public void STring()
        {
            var expectation = "hi".Will().Contain("hi").And().StartWith("h").And().EndWith("i").And().MatchRegularExpression(".*");

            Expect.That(
                expectation.ToString().Will().Equal(
                    @"String containing ""hi"" and String starting with ""h"" and String ending with ""i"" and String matching "".*"""));
        }

        [Test]
        public void ContainsTime()
        {
            var expectation = new FTimeInterval().Will().Contain(null);
            Expect.That(expectation.Will().Have().ConstraintDescription("Contain null"));
        }
    }
}