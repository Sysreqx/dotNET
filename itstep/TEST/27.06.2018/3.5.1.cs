using System; namespace Test { class Program { static void Result(int a, int b, int input) { string dif = a > b ? "" : "-" + (a > b ? Convert.ToString(a - b, input) : Convert.ToString(b - a, input)); Console.WriteLine($"{Convert.ToString(a, input)} + {Convert.ToString(b, input)} = {Convert.ToString(a + b, input)}"); Console.WriteLine($"{Convert.ToString(a, input)} - {Convert.ToString(b, input)} = {dif}"); Console.WriteLine($"{Convert.ToString(a, input)} * {Convert.ToString(b, input)} = {Convert.ToString(a * b, input)}"); Console.WriteLine($"{Convert.ToString(a, input)} / {Convert.ToString(b, input)} = {Convert.ToString(a / b, input)}"); Console.WriteLine($"{Convert.ToString(a, input)} % {Convert.ToString(b, input)} = {Convert.ToString(a % b, input)}"); Console.WriteLine($"{Convert.ToString(a, input)} ^ {Convert.ToString(b, input)} = {Convert.ToString(Convert.ToInt32(Math.Pow(Convert.ToDouble(a), Convert.ToDouble(b))), input)}\n"); } static void Main(string[] args) { string line = Console.ReadLine(); int a = int.Parse(line); line = Console.ReadLine(); int b = int.Parse(line); Result(a, b, 2); Result(a, b, 8); Result(a, b, 10); Result(a, b, 16); Console.ReadKey(); } } }