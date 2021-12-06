using System;
using System.Collections.Generic;
using System.Linq;
using FMSWebPortal.Shared.Constants.DefaultValues;


namespace FMSWebPortal.Shared
{
    class RandomHelper
    {
        public static string GenerateEmail(int localPartLenght = 64, int domainPartLenght = 94, bool validLocalPart = true, bool validDomainPart = true)
        {
            var email = "";

            if (localPartLenght != 0)
            {
                email = validLocalPart
                ? RandomString(localPartLenght, localPart: true)
                : RandomString(localPartLenght, invalidCharacters: true);
            }

            email += "@";

            if (domainPartLenght != 0)
            {
                email += validDomainPart
                ? RandomString(domainPartLenght, domain: true) + "." + RandomString(94, domain: true)
                : RandomString(domainPartLenght, invalidCharacters: true) + "." + RandomString(94, domain: true);
            }
            return email;
        }

        public static int RandomNumber(int min, int max) => new Random().Next(min, max);

        public static int RandomNumberIsEven(int min, int max, bool isEven = true) => Enumerable.Range(min, max).Where(a => a % 2 == (isEven ? 0 : 1)).FirstOrDefault();

        public static IEnumerable<int> RandomNumbers(int min, int max)
        {
            var rnd = new Random();

            return Enumerable.Range(min, max)
                     .SelectMany(i => Enumerable.Repeat(i, 1))
                     .OrderBy(i => rnd.Next());
        }

        public static List<int> GetUniqueRandomNumbers(int min, int max)
        {
            var rnd = new Random();

            return Enumerable.Range(min, max).OrderBy(_ => rnd.Next()).ToList();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0045:Convert to conditional expression", Justification = "<Pending>")]
        public static string RandomString(
            int length = 45,
            bool digit = false,
            bool lowercase = false,
            bool nonAlphanumeric = false,
            bool uppercase = false,
            bool uppercaseAccentedCharacters = false,
            bool lowercaseAccentedCharacters = false,
            bool alphabeticalWithSymbols = false,
            bool localPart = false,
            bool domain = false,
            bool name = false,
            bool password = false,
            bool punctuation = false,
            bool phone = false,
            bool timeNowTicks = false,
            bool username = false,
            bool displayName = false,
            bool invalidCharacters = false,
            string firstNamePassword = null,
            string lastNamePassword = null,
            string usernamePassword = null)
        {
            Random rnd = new Random(Environment.TickCount);
            string chars = "";
            string randomString = "";

            if (uppercase)
            {
                chars += DefaultValues.Uppercase;
            }

            if (lowercase)
            {
                chars += DefaultValues.Lowercase;
            }

            if (digit)
            {
                chars += DefaultValues.NumericDigit;
            }

            if (nonAlphanumeric)
            {
                chars += DefaultValues.DisplayName;
            }

            if (uppercaseAccentedCharacters)
            {
                chars += DefaultValues.UppercaseAccentedCharacters;
            }

            if (lowercaseAccentedCharacters)
            {
                chars += DefaultValues.LowercaseAccentedCharacters;
            }

            if (punctuation)
            {
                chars += DefaultValues.ValidCharacters;
            }

            if (alphabeticalWithSymbols)
            {
                chars += DefaultValues.Uppercase;
                chars += DefaultValues.Lowercase;
                chars += DefaultValues.NumericDigit;
                chars += DefaultValues.ValidCharacters;
            }

            if (localPart)
            {
                chars += DefaultValues.Uppercase;
                chars += DefaultValues.Lowercase;
                chars += DefaultValues.NumericDigit;
                chars += DefaultValues.Email;
            }

            if (domain)
            {
                chars += DefaultValues.Uppercase;
                chars += DefaultValues.Lowercase;
                chars += DefaultValues.NumericDigit;
            }

            if (name)
            {
                chars += DefaultValues.Uppercase;
                chars += DefaultValues.Lowercase;
                chars += DefaultValues.UppercaseAccentedCharacters;
                chars += DefaultValues.LowercaseAccentedCharacters;
                chars += DefaultValues.Name;
            }

            if (password)
            {
                chars += DefaultValues.Uppercase;
                chars += DefaultValues.Lowercase;
                chars += DefaultValues.NumericDigit;
                chars += DefaultValues.ValidCharacters;
            }

            if (phone)
            {
                chars += DefaultValues.NumericDigit;
                chars += DefaultValues.Phone;
            }

            if (username)
            {
                chars += DefaultValues.Lowercase;
                chars += DefaultValues.NumericDigit;
                chars += DefaultValues.Username;
            }

            if (displayName)
            {
                chars += DefaultValues.Uppercase;
                chars += DefaultValues.Lowercase;
                chars += DefaultValues.NumericDigit;
                chars += DefaultValues.DisplayName;
            }

            if (invalidCharacters)
            {
                chars += DefaultValues.InvalidCharacters;
            }

            if (timeNowTicks)
            {
                return DateTime.Now.Ticks.ToString();
            }

            if (chars == "")
            {
                chars += DefaultValues.Uppercase;
                chars += DefaultValues.Lowercase;
            }

            randomString = new string(Enumerable.Repeat(chars, length).Select(s => s[rnd.Next(s.Length)]).ToArray());

            if (password)
            {
                do
                {
                    if (usernamePassword != null)
                    {
                        randomString = usernamePassword + new string(Enumerable.Repeat(chars, length - usernamePassword.Length).Select(s => s[rnd.Next(s.Length)]).ToArray());
                    }
                    else if (firstNamePassword != null)
                    {
                        randomString = firstNamePassword + new string(Enumerable.Repeat(chars, length - firstNamePassword.Length).Select(s => s[rnd.Next(s.Length)]).ToArray());
                    }
                    else if (lastNamePassword != null)
                    {
                        randomString = lastNamePassword + new string(Enumerable.Repeat(chars, length - lastNamePassword.Length).Select(s => s[rnd.Next(s.Length)]).ToArray());
                    }
                    else
                    {
                        randomString = new string(Enumerable.Repeat(chars, length).Select(s => s[rnd.Next(s.Length)]).ToArray());
                    }
                } while (!PasswordIsValid(randomString));
            }
            else if (localPart)
            {
                while (!EmailIsValid(randomString))
                {
                    randomString = new string(Enumerable.Repeat(chars, length).Select(s => s[rnd.Next(s.Length)]).ToArray());
                }
            }
            else if ((name || displayName) && length != 0)
            {
                while (!NameIsValid(randomString))
                {
                    randomString = new string(Enumerable.Repeat(chars, length).Select(s => s[rnd.Next(s.Length)]).ToArray());
                }
            }
            else
            {
                randomString = new string(Enumerable.Repeat(chars, length).Select(s => s[rnd.Next(s.Length)]).ToArray());
            }

            return randomString;
        }

        private static bool PasswordIsValid(string password)
        {
            var valid = password.Any(p => DefaultValues.Uppercase.Contains(p));
            valid &= password.Any(p => DefaultValues.Lowercase.Contains(p));
            valid &= password.Any(p => DefaultValues.NumericDigit.Contains(p));
            valid &= password.Any(p => DefaultValues.ValidCharacters.Contains(p));

            return valid;
        }

        private static bool EmailIsValid(string email) => email.Last() != '.' && email.First() != '.';

        private static bool NameIsValid(string name) => name.Last() != ' ' && name.First() != ' ' && !name.Contains("  ");

        
    }
}
