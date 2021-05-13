using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework.Constraints;

namespace NunitAssignment9
{
    public class CustomCapitalizeConstraint : Constraint
    {
        readonly string _expected;
        public CustomCapitalizeConstraint(string expected)
        {
            _expected = String.Join(" ", expected.Split(' ').Select(i => i.Substring(0, 1).ToUpper() + i.Substring(1).ToLower()).ToArray());
            Description = $"Expected is {expected}";
        }
        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            if (typeof(TActual) != typeof(string))
                return new ConstraintResult((IConstraint)this, actual, ConstraintStatus.Error);
            if (_expected == actual.ToString())
                return new ConstraintResult((IConstraint)this, actual, ConstraintStatus.Success);
            else
                return new ConstraintResult((IConstraint)this, actual, ConstraintStatus.Failure);
        }
    }
    public class Is : NUnit.Framework.Is
    {
        public static CustomCapitalizeConstraint IsCapitalize(string expected)
        {
            return new CustomCapitalizeConstraint(expected);
        }
    }
}

