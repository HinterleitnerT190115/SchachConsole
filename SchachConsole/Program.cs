namespace SchachConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Preamble
            Console.WriteLine("Bitte Konsole vergrößern und groß lassen - defekt vom neuen Windows Terminal");
            Console.ReadLine();
            Console.Clear();

            //Game loop
            Chessboard cb = new Chessboard();

            while(true)
            {
                cb.NextInput();
            }
        }
    }
}