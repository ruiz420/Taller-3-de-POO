using shared;

class HarvestHorse
{
    static void Main()
    {
        string response = string.Empty;

        do
        {
            try
            {
                var fruitsInput = ConsoleExtensions.Getstring("Enter fruit locations (example: C4+,C7*,E3-,E1=,H4*):");
                var fruitsData = fruitsInput.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                char[,] board = new char[8, 8];

                foreach (var item in fruitsData)
                {
                    string pos = item.Substring(0, 2);
                    char fruit = item[2];

                    var p = new Position(pos);
                    board[p.Row, p.Column] = fruit;
                }

                var start = ConsoleExtensions.Getstring("Enter horse starting position:");
                var horse = new Position(start);

                var movesInput = ConsoleExtensions.Getstring("Enter horse moves:");
                var moves = movesInput.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                List<char> collected = new List<char>();

                foreach (var move in moves)
                {
                    MoveHorse(horse, move);

                    char fruit = board[horse.Row, horse.Column];

                    if (fruit != '\0')
                    {
                        collected.Add(fruit);
                    }
                }

                Console.WriteLine($"Collected fruits: {string.Join("", collected)}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Continue? [Y/N]: ");
            response = Console.ReadLine()!.ToUpper();

            while (response != "Y" && response != "N")
            {
                Console.WriteLine("Please enter 'Y' to continue or 'N' to exit.");
                response = Console.ReadLine()!.ToUpper();
            }

        } while (response == "Y");

        Console.WriteLine("Game Over");
    }

    public static void MoveHorse(Position horse, string move)
    {
        switch (move)
        {
            case "UL":
                horse.Row -= 2;
                horse.Column -= 1;
                break;

            case "UR":
                horse.Row -= 2;
                horse.Column += 1;
                break;

            case "LU":
                horse.Row -= 1;
                horse.Column -= 2;
                break;

            case "LD":
                horse.Row += 1;
                horse.Column -= 2;
                break;

            case "RU":
                horse.Row -= 1;
                horse.Column += 2;
                break;

            case "RD":
                horse.Row += 1;
                horse.Column += 2;
                break;

            case "DL":
                horse.Row += 2;
                horse.Column -= 1;
                break;

            case "DR":
                horse.Row += 2;
                horse.Column += 1;
                break;
        }
    }

    public class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position(string pos)
        {
            Column = pos[0] - 'A';
            Row = 8 - int.Parse(pos[1].ToString());
        }

        public override string ToString()
        {
            string[] columns = { "A", "B", "C", "D", "E", "F", "G", "H" };
            return columns[Column] + (8 - Row);
        }
    }
}