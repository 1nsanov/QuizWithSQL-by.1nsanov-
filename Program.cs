using System;

namespace QuizWithSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("---------Опрос---------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Для начала давайте познакомимся.");

            InputInfo info = new InputInfo();
            info.InputPersonalInfo();
            info.ChekerPersonalInfo();
            info.AnswerOnQuestion();
            using (var context = new DatabaseContext())
            {
                var person = new People()
                {
                    Full_Name = info.Name,
                    Age = info.MyAge,
                    Email = info.ContactEmail,
                    Question_1 = info.Answer1,
                    Question_2 = info.Answer2,
                    Question_3 = info.Answer3,
                    Question_4 = info.Answer4,
                    Question_5 = info.Answer5
                };
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Loading...");
                context.Humans.Add(person);
                context.SaveChanges();
                Console.WriteLine("Load Success!");
            }


            //Для проверки ввода
            Console.WriteLine("Занесенно в БД:");
            Console.WriteLine(info.Name);
            Console.WriteLine(info.MyAge);
            Console.WriteLine(info.ContactEmail);
            Console.WriteLine(info.Answer1);
            Console.WriteLine(info.Answer2);
            Console.WriteLine(info.Answer3);
            Console.WriteLine(info.Answer4);
            Console.WriteLine(info.Answer5);         
            Console.ReadKey();
        }
    }
}
