using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CstomerQueue
{
    class NameGenerator
    {
        static char[] consonants = { 'б', 'в', 'г', 'д', 'ж', 'з', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ' };
        static char[] vowels = { 'а', 'у', 'о', 'ы', 'и', 'э', 'я', 'ю', 'ё', 'е' };
        static string[] surnameEndings = { "иев", "ева", "ов", "ова", "ских" };
        static Random rnd = new Random();

        static public (string lastName, string firstName) Generate()
        {
            string lastName = "";
            string firstName = "";
            int lastNameLen = rnd.Next(3, 7);
            int nowAlph = rnd.Next(0, 1);

            for (int i = 0; i < lastNameLen; i++)
            {
                if (nowAlph == 0)
                {
                    nowAlph = 1;
                    lastName += consonants[rnd.Next(0, consonants.Length - 1)];
                }
                else
                {
                    nowAlph = 0;
                    lastName += vowels[rnd.Next(0, vowels.Length - 1)];
                }
                if (i == 0) lastName = lastName.ToUpper();
            }
            lastName += surnameEndings[rnd.Next(0, surnameEndings.Length - 1)];
            nowAlph = rnd.Next(0, 1);
            if (nowAlph == 0) firstName += consonants[rnd.Next(0, consonants.Length - 1)] + ".";
            else firstName += vowels[rnd.Next(0, vowels.Length - 1)] + ".";
            nowAlph = rnd.Next(0, 1);
            if (nowAlph == 0) firstName += consonants[rnd.Next(0, consonants.Length - 1)] + ".";
            else firstName += vowels[rnd.Next(0, vowels.Length - 1)] + ".";
            firstName = firstName.ToUpper();
            return (lastName, firstName);
        }
    }
}
