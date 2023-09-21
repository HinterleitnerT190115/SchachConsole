namespace SchachConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte Konsole vergrößern und groß lassen - defekt von Windows");
            Console.ReadLine();
            Console.Clear();


            Chessboard cb = new Chessboard();

            while(true)
            {
                cb.NextInput();
            }
        }
    }
}