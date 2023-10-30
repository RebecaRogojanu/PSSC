using static LanguageExt.Prelude;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    public record CheckOrderValidation
    {
        private static readonly Regex ValidPattern = new("^LM[0-9]{5}$");

        public string Value { get; }

        private CheckOrderValidation(string value)
        {
            if (IsValid(value))
            {
                Value = value;
            }
            else
            {
                //throw new InvalidStudentRegistrationNumberException("");
            }
        }

        private static bool IsValid(string stringValue) => ValidPattern.IsMatch(stringValue);

        public override string ToString()
        {
            return Value;
        }

        public static Option<CheckOrderValidation> TryAsync(string stringValue)
        {
            if (IsValid(stringValue))
            {
                return Some<CheckOrderValidation>(new(stringValue));
            }
            else
            {
                return None;
            }
        }
    }
}