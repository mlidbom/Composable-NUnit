using System;
using System.Collections.Generic;
using NUnit.Framework.Constraints;

namespace Composable.Nunit
{
    public abstract class NestedConstraintExpressionBase<TParentActual, TConstraintExpression> :
        INestedConstraintExpression<TParentActual, TConstraintExpression>
    {
        private IConstraintExpression<TParentActual> ParentConstraint { get; set; }

        protected NestedConstraintExpressionBase(IConstraintExpression<TParentActual> parent)
        {
            ParentConstraint = parent;
        }

        public IConstraint<TParentActual> ResolveWith(Func<ConstraintExpression, Constraint> func)
        {
            return ParentConstraint.ResolveWith(func);
        }

        public TConstraintExpression Append(Func<ConstraintExpression, ConstraintExpression> appender)
        {
            return CreateInstance(ParentConstraint.Append(appender));
        }

        protected abstract TConstraintExpression CreateInstance(IConstraintExpression<TParentActual> parent);
    }

    public class NestedConstraintExpression<TParentActual, TNestedActual> :
        NestedConstraintExpressionBase<TParentActual, NestedConstraintExpression<TParentActual, TNestedActual>>
    {
        public NestedConstraintExpression(IConstraintExpression<TParentActual> parent) : base(parent)
        {
        }

        protected override NestedConstraintExpression<TParentActual, TNestedActual> CreateInstance(
            IConstraintExpression<TParentActual> parent)
        {
            return new NestedConstraintExpression<TParentActual, TNestedActual>(parent);
        }
    }

    public class EnumerableItemConstraintExpression<TActual> :
        NestedConstraintExpressionBase<IEnumerable<TActual>, IEnumerableItemConstraintExpression<TActual>>,
        IEnumerableItemConstraintExpression<TActual>
    {
        public EnumerableItemConstraintExpression(IConstraintExpression<IEnumerable<TActual>> collectionConstraint)
            : base(collectionConstraint)
        {
        }

        protected override IEnumerableItemConstraintExpression<TActual> CreateInstance(IConstraintExpression<IEnumerable<TActual>> parent)
        {
            return new EnumerableItemConstraintExpression<TActual>(parent);
        }
    }
}