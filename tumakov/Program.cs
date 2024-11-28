using System;
class Laba
{
    static void Main()
    {
        Console.WriteLine("Введите имя файла:");
        string filename = Console.ReadLine();
        Task1(filename);
        Task2();
        Task3();
        Task4(filename);
        Task6();
    }
    static void Task1(string filename)
    {
        try {
            Console.WriteLine("6.1");
            char[] file = File.ReadAllText(filename).ToCharArray();
            Console.WriteLine($"Колво гласных: {Glas(file)}");
            Console.WriteLine($"Колво гласных: {Soglas(file)}");
        }
        catch
        {
            Console.WriteLine("Ошибка обработки файла");
        }
    }
    static void Task2()
    {
        Console.WriteLine("6.2");
        int[,] matrix1 = MatrixRead();
        int[,] matrix2 = MatrixRead();
        MatrixPrint(matrix1);
        MatrixPrint(matrix2);
        MatrixPrint(MatrixProizv(matrix1, matrix2));
    }
    static void Task3()
    {
        Console.WriteLine("6.3");
        Random random = new Random();
        int[,] temperature = new int[12, 30];
        for (int i = 0; i < temperature.GetLength(0); i++)
        {
            for (int j = 0; j < temperature.GetLength(1); j++)
            {
                temperature[i, j] = random.Next(-100, 100);
            }
        }
        string[] months = ["Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"];
        for (int i = 0; i < months.Length; i++)
        {
            Console.WriteLine($"{months[i]}: {AverageTemperature(temperature)[i]}");
        }
    }
    static void Task4(string filename)
    {
        Console.WriteLine("dz6.1");
        List<char> fileList = File.ReadAllText(filename).ToList();
        Console.WriteLine($"Колво гласных: {Glas(fileList)}");
        Console.WriteLine($"Колво гласных: {Soglas(fileList)}");
    }
    static void Task5()
    {
        
    }
    static void Task6()
    {
        Console.WriteLine("dz6.3");
        Random random = new Random();
        Dictionary<string, double[]> tempByMonth = new Dictionary<string, double[]>
        {
            {"Январь", TempGenerate(random)},
            {"Февраль", TempGenerate(random)},
            {"Март", TempGenerate(random)},
            {"Апрель", TempGenerate(random)},
            {"Май", TempGenerate(random)},
            {"Июнь", TempGenerate(random)},
            {"Июль", TempGenerate(random)},
            {"Август", TempGenerate(random)},
            {"Сентябрь", TempGenerate(random)},
            {"Октябрь", TempGenerate(random)},
            {"Ноябрь", TempGenerate(random)},
            {"Декабрь", TempGenerate(random)}
        };
        double[] averTemp = new double[tempByMonth.Count];
        int index = 0;
        foreach (var month in tempByMonth.Keys)
        {
            double[] dailyTemps = tempByMonth[month];
            double totalTemp = 0;

            foreach (double temp in dailyTemps)
            {
                totalTemp += temp;
            }

            averTemp[index++] = totalTemp / dailyTemps.Length;
            Console.WriteLine($"Средняя температура за {month}: {averTemp[index - 1]:F1}");
        }
        Array.Sort(averTemp);

        Console.WriteLine("Отсортированные средние температуры по месяцам:");
        foreach (double avgTemp in averTemp)
        {
            Console.WriteLine(avgTemp.ToString("F1"));
        }
    }
    static double[] TempGenerate(Random random)
    {
        const int daysInMonth = 30;
        double[] temp = new double[daysInMonth];

        for (int i = 0; i < daysInMonth; i++)
        {
            temp[i] = -10 + (random.NextDouble() * 50);
        }
        return temp;
    }
    static int Glas(char[] file)
    {
        int countGlas = 0;
        string glas = "аяуюеёиыоэАЯУЮЕЁИЫОЭaeiouyAEIOUY";
        foreach (char c in file)
        {
            if (glas.Contains(c))
            {
                countGlas++;
            }
        }
        return countGlas;
    }
    static int Soglas(char[] file)
    {
        int countSoglas = 0;
        string soglas = "бвгджзйклмнпрстфхцчшщъьБВГДЖЗЙКЛМНПРСТФХЦЧШЩЪЬbcdfghjklmnpqrstvwxzBCDFGHJKLMNPQRSTVWXZ";
        foreach (char c in file)
        {
            if (soglas.Contains(c)) 
            {
                countSoglas++;
            }
        }
        return countSoglas;
    }
    static int Glas(List<char> list)
    {
        int countGlas = 0;
        string glas = "аяуюеёиыоэАЯУЮЕЁИЫОЭaeiouyAEIOUY";
        foreach (char c in list)
        {
            if (glas.Contains(c))
            {
                countGlas++;
            }
        }
        return countGlas;
    }
    static int Soglas(List<char> list)
    {
        int countSoglas = 0;
        string soglas = "бвгджзйклмнпрстфхцчшщъьБВГДЖЗЙКЛМНПРСТФХЦЧШЩЪЬbcdfghjklmnpqrstvwxzBCDFGHJKLMNPQRSTVWXZ";
        foreach (char c in list)
        {
            if (soglas.Contains(c))
            {
                countSoglas++;
            }
        }
        return countSoglas;
    }
    static int[,] MatrixRead()
    {
            Console.WriteLine("Введите количество строк матрицы:");
            int row = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов матрицы:");
            int column = int.Parse(Console.ReadLine());
            int[,] matrix = new int[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write($"Введите элемент [{i + 1}, {j + 1}]: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            return matrix;
    }
    static void MatrixPrint(int[,] matrix)
    {
        int row = matrix.GetLength(0);
        int column = matrix.GetLength(1);
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
        }
        Console.WriteLine();
    }
    static int[,] MatrixProizv(int[,] matrix1, int[,] matrix2)
    {
        int row1 = matrix1.GetLength(0);
        int column1 = matrix1.GetLength(1);
        int row2 = matrix2.GetLength(0);
        int column2 = matrix2.GetLength(1);
        if (column1 != column2)
        {
            throw new ArgumentException();
        }
        int[,] result = new int[row1, column2];
        for (int i = 0; i < row1; i++)
        {
            for (int j = 0; j < column2; j++)
            {
                for (int k = 0; k < column1; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }
        return result;
    }
    static int[] AverageTemperature(int[,] temperature)
    {   
        int[] averTemp = new int[12];
        for (int i = 0; i < temperature.GetLength(0);i++)
        {
            int dayTemp = 0;
            for (int j = 0; j < temperature.GetLength(1);j++)
            {
                dayTemp += temperature[i, j];
            }
            dayTemp /= temperature.GetLength(1);
            averTemp[i] = dayTemp;
        }
        return averTemp;
    } 
}