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
        : base(number, 10)
        {
        }

        public DateTime Birthdate
        {
            get
            {
                ValidatePid();
                TryParseBirthdate(out DateTime birthDate);
                return birthDate;

            }
        }
        public string BirthNumber
        {
            get
            {
                ValidatePid();
                return Number.Substring((Number.Length - 4), 3);
            }
        }

        public int CheckDigit
        {
            get
            {
                ValidatePid();
                return Int32.Parse(Number.Substring((Number.Length - 1), 1));
            }
        }
        public Gender Gender
        {
            get
            {
                ValidatePid();
                return BirthNumber[BirthNumber.Length - 1] % 2 == 0 ? Gender.Female : Gender.Male;
            }
        }
        public override bool IsValid { get => TryParseBirthdate(out DateTime birthdate) && base.IsValid; }

        public override string ToString() => ToString("Y");

        public string ToString(string format)
        {
            switch (format)
            {
                case null:
                case "":
                case "Y":
                    if (IsValid)
                    {
                        return $"{Birthdate:yyyyMMdd}-{BirthNumber}{CheckDigit}";
                    }
                    goto case "g";
                case "y":
                    if (IsValid)
                    {
                        var separator = Birthdate <= DateTime.Today.AddYears(-100) ? '+' : '-';
                        return $"{Birthdate:yyMMdd}{separator}{BirthNumber}{CheckDigit}";
                    }
                    goto case "g";
                case "g":
                    return Number;
                default:
                    throw new FormatException();
            }
        }

        private bool TryParseBirthdate(out DateTime result)
        {
            if (PersonalIdentityNumberRegex.IsMatch(Number))
            {
                try
                {
                    string sanitizedNumber = SanitizedNumber;
                    bool isTenDigitNumber = sanitizedNumber.Length == 10;
                    if (isTenDigitNumber)
                    {
                        sanitizedNumber = sanitizedNumber.Insert(0, (DateTime.Today.Year / 100).ToString());
                    }

                    result = new DateTime(
                        int.Parse(sanitizedNumber.Substring(0, 4)),
                        int.Parse(sanitizedNumber.Substring(4, 2)),
                        int.Parse(sanitizedNumber.Substring(6, 2))
                    );

                    if (result > DateTime.Today)
                    {
                        result = result.AddYears(-100);
                    }

                    if (Number.Contains("+"))
                    {
                        result = result.AddYears(-100);
                    }

                    return true;
                }
                catch { }
            }

            result = default(DateTime);
            return false;
        }

        public void ValidatePid()
        {
            if (!IsValid)
            {
                throw new InvalidOperationException("Not a valid Personal Identification Number");
            }
        }
    }
}