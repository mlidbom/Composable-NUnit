using System;
using NUnit.Framework;

namespace Composable.Nunit
{
    public static class Expect
    {
        public static void That<TActual>(IConstraint<TActual> constraint)
        {
            That(constraint, null);
        }

        public static void That<TActual>(IConstraint<TActual> constraint, string message)
        {
            That(constraint, message, new object[0]);    
        }

        public static void That<TActual>(IConstraint<TActual> constraint, string message, params object[] values)
        {
            Assert.That(constraint.Actual, constraint.InnerConstraint, message, values);
        }

        public static TException Throws<TException>(Action action) where TException : Exception
        {
            return Assert.Throws<TException>(() => action());
        }
    }
}