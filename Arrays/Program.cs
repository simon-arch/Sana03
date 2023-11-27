using System.Text;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            int n = inputProcedure("> Введіть кількість дійсних елементів масиву n: ");
            double[] arr = new double[n];
            double min = arr[0], max = arr[0], maxabs = arr[0], negsum = 0;
            int prec = 2, maxind = 0, indsum = 0, intnum = 0;
            Console.Write("[i] Згенерований масив: ");
            genArray(n, arr, -5.0, 5.0, prec);
            printArray(n, arr);
            for (int i = 0; i < n; i++)
            {
                if (arr[i] < 0) negsum += arr[i];
                if (arr[i] < min) min = arr[i];
                if (arr[i] > max) max = arr[maxind = i];
                if (Math.Abs(arr[i]) > Math.Abs(maxabs)) maxabs = arr[i];
                if (arr[i] > 0) indsum += i;
                if ((arr[i] % 1) == 0) intnum++;
            }
            Console.Write("\n               >> ... <<              ");
            Console.Write($"\n[i] Сума від'ємних елементів масиву: {Math.Round(negsum, prec)}\n[i] Мінімальний елемент масиву: {min}");
            Console.Write($"\n[i] Індекс максимального елемента масиву: {maxind}\n[i] Максимальний за модулем елемент масиву: {maxabs}");
            Console.Write($"\n[i] Сума індексів додатніх елементів: {indsum}\n[i] Кількість цілих чисел у масиві: {intnum}");
        }

        private static void printArray(int n, double[] arr)
        {
            Console.Write("[");
            for (int i = 0; i < n-1; i++) Console.Write($"{arr[i]}, ");
            Console.Write($"{arr[n-1]}] ");
        }

        private static void genArray(int n, double[] arr, double min, double max, int precision)
        {
            Random rnd = new Random();
            for (int i = 0; i < n; i++) arr[i] = Math.Round((rnd.NextDouble() * (max - min) + min), precision);
        }

        private static int inputProcedure(string ctext)
        {
            while (true)
            {
                Console.Write(ctext);
                if (int.TryParse(Console.ReadLine(), out int outval) && outval > 0) return outval;
                else Console.WriteLine("[!] Введіть натуральне число N.");
            }
        }
    }
}