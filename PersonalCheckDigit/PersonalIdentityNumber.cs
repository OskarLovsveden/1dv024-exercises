using System;
using System.Text.RegularExpressions;

namespace PersonalCheckDigit
{
    public enum Gender
    {
        Unknown, Female, Male, Other
    }

    public class PersonalIdentityNumber : LuhnCheckDigit
    {
        private static readonly Regex PersonalIdentityNumberRegex = new Regex(@"^(\d{6}[-+]?|\d{8}-?)\d{4}$");

        public PersonalIdentityNumber(string number = "")
        : base()
        {
            Number = number;
        }

        public DateTime Birthdate { get; }
        public string BirthNumber { get; }
        public int Checkdigit { get; }
        public Gender Gender { get; }
        public override bool IsValid { get; }
    }
}