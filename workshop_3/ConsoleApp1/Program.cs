using System;

class MadisonBridges
{
    static void Main()
    {
        while (true)
        {
            try
            {
                Console.Write("Enter the bridge: ");
                string bridge = Console.ReadLine() ?? "";

                if (string.IsNullOrEmpty(bridge))
                {
                    Console.WriteLine("INVALID");
                    continue;

                }

                if (bridge[0] != '*' || bridge[bridge.Length - 1] != '*') //* indexer the extremes
                {
                    Console.WriteLine("INVALID");
                    continue;
                }

                foreach (char c in bridge) // simbol valid , c = a simbol the tipe caracter
                {
                    if (c != '*' && c != '=' && c != '+')
                    {
                        Console.WriteLine("INVALID");
                        continue;
                    }
                }

                // remove ends
                string body = bridge.Substring(1, bridge.Length - 2);

                int count = 0; 
                foreach (char c in body) // máximo 3 = seguidos
                {
                    if (c == '=')
                    {
                        count++;
                        if (count > 3)
                        {
                            Console.WriteLine("INVALID");
                            continue;
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }


                for (int i = 0; i < bridge.Length / 2; i++) // symmetry
                {
                    if (bridge[i] != bridge[bridge.Length - 1 - i])
                    {
                        Console.WriteLine("INVALID");
                        continue;
                    }
                }

                Console.WriteLine("VALID");
            }
            catch
            {
                Console.WriteLine("La viga está mal construida!");
            }
        }
    }
}

0 *
1 =
9= 
10 * 