namespace shared
{
    public class ConsoleExtensions
    {
        public static int GetInt(string message)
        {
            Console.Write(message);
            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                return result;
            }

            throw new ArgumentException("el valor ingresado no es un numero entero valido");
        }


        // este metodo nos devuelve un entero
        public static String? Getstring(string message)
        {
            Console.Write(message);
            var text = Console.ReadLine();
            return text;
        }

        // metodo para devolver flotantes 

        public static float GetFloat(string message)
        {
            Console.Write(message);
            var numberString = Console.ReadLine();
            if (float.TryParse(numberString, out float numberFloat))
            {
                return numberFloat;
            }

            return 0.0f;
        }

        public static decimal GetDecimal(string message)
        {
            Console.Write(message);
            var numberString = Console.ReadLine();
            if (decimal.TryParse(numberString, out decimal numberdecimal))
            {
                return numberdecimal;
            }

            return 0;
        }
        public static string Getviga(string message)
        {
            Console.Write(message);
            var input = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Debe ingresar al menos un símbolo de viga.");
            }

            var validSymbols = new HashSet<char> { '%', '&', '#', '=', '*' };

            foreach (char c in input)
            {
                if (!validSymbols.Contains(c))
                {
                    throw new ArgumentException($"El símbolo '{c}' no es válido. Solo se permiten: %, &, #, =, *");
                }
            }

            return input;
        }

    }
}