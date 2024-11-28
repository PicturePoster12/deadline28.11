using System;
using System.Drawing;
public enum Exams
{
    English,
    IT,
    Physics,
}
class Student
{
    public string Surname;
    public string Name;
    public DateTime BirthDay;
    public Exams Exam;
    public int Points;


    public Student(string surname, string name, string d, Exams exam, int points)
    {
        Surname = surname;
        Name = name;
        BirthDay = DateTime.Parse(d);
        Exam = exam;
        Points = points;
    }
}
class Program
{
    static Dictionary<int, Student> Students()
    {
        Dictionary<int, Student> students = new Dictionary<int, Student>()
            {
                { 1, new Student( "Гуро", "Руслан", "17.09.2006", Exams.IT, 242) },
                { 2, new Student( "Балобанова", "Арина", "13.03.2006", Exams.English, 247) },
                { 3, new Student( "Валеев", "Сергей", "25.08.2006", Exams.Physics, 278) },
                { 4, new Student( "Габов", "Алексей", "05.07.2006", Exams.IT, 252) },
                { 5, new Student( "Дорожан", "Андрей", "14.05.2006", Exams.IT, 255) },
                { 6, new Student( "Лисюткина", "Руслана", "28.06.2006", Exams.IT, 241) },
                { 7, new Student( "Назарова", "Дарья", "11.05.2006", Exams.English, 239) },
                { 8, new Student( "Сабирова", "Далия", "14.05.2006", Exams.English, 287) },
                { 9, new Student( "Спиридонова", "Весна", "15.04.2006", Exams.Physics, 253) },
                { 10, new Student( "Халикова", "Данна", "03.11.2006", Exams.English, 262) },
            };
        return students;
    }

    static void Main()
    {
        Console.WriteLine("1.");
        RandomList();
    }
    static void RandomList()
    {
        List<string> images = new List<string>
    {
        "1.jfif","1.jfif",
        "2.jfif","2.jfif",
        "3.jfif","3.jfif",
        "4.jfif","4.jfif",
        "5.jfif","5.jfif",
        "6.jfif","6.jfif",
        "7.jfif","8.jfif",
        "8.jfif","8.jfif",
        "9.jfif","9.jfif",
        "10.jfif","10.jfif",
        "11.jfif","11.jfif",
        "12.jfif","12.jfif",
        "13.jfif","13.jfif",
        "14.jfif","14.jfif",
        "15.jfif","15.jfif",
        "16.jfif","16.jfif",
        "17.jfif","17.jfif",
        "18.jfif","18.jfif",
        "19.jfif","19.jfif",
        "20.jfif","20.jfif",
        "21.jfif","21.jfif",
        "22.jfif","22.jfif",
        "23.jfif","23.jfif",
        "24.jfif","24.jfif",
        "25.jfif","25.jfif",
        "26.jfif","26.jfif",
        "27.jfif","27.jfif",
        "28.jfif","28.jfif",
        "29.jfif","29.jfif",
        "30.jfif","30.jfif",
        "31.jfif","31.jfif",
        "32.jfif","32.jfif",
    };
        Console.WriteLine("Порядок до перемешивания:");
        images.ForEach(p => Console.WriteLine(p));
        Random random = new Random();
        string temp = images[0];
        for (int i = 0; i < images.Count; i++)
        {
            images.RemoveAt(0);
            images.Insert(random.Next(images.Count), temp);
        }
        Console.WriteLine("Порядок после перемешивания:");
        images.ForEach(p => Console.WriteLine(p));
        return;
    }
    static void Task2()
    {
        Console.WriteLine("2.");
        Dictionary<int, Student> students = Students();
        Console.WriteLine("Список:");
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Key}: {student.Value.Name} {student.Value.Surname} {student.Value.BirthDay} {student.Value.Exam} {student.Value.Points}");
        }
        Console.WriteLine("Напишите 'Новый студент', если хотите добавить студента, напишите 'Удалить', если хотите удалить студента, напишите 'Отсортировать', если хотите отсортировать список по баллам");
        string input = Console.ReadLine();
        switch (input)
        {
            case "Новый студент":
                students.Add(students.Count + 1, new Student("Пигуляк", "Роман", "27.07.2006", Exams.IT, 243));
                break;
            case "Удалить":
                Console.WriteLine("Введите имя и фамилию студента:");
                string RemoveName = Console.ReadLine().ToLower();
                string RemoveSurname = Console.ReadLine().ToLower();
                students.Remove(students.FirstOrDefault(x => x.Value.Name.ToLower() == RemoveName && x.Value.Surname.ToLower() == RemoveSurname).Key);
                break;
            case "Отсортировать":
                students = students.OrderBy(d  => d.Value.Points).ToDictionary(d =>d.Key, d => d.Value);
                break;
        }
    }
}