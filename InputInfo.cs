using System;
using System.ComponentModel.DataAnnotations;

namespace QuizWithSQL
{
    public class InputInfo
    {
        private string Choice { get; set; }
        public string Name { get; set; }
        public int MyAge { get; set; }
        public string ContactEmail { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string Answer5 { get; set; }

        public void InputPersonalInfo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Как вас зовут(ФИО)?");
            while (true)
            {
                
                string[] checkName;
                Name = Console.ReadLine();
                checkName = Name.Split(' ');
                if (checkName.Length == 3)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Введите своё полное имя!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }
            //Console.WriteLine($"Кол-во слов: {checkName.Length}");


            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                try
                {
                    Console.WriteLine("Ваш возраст.");
                    MyAge = int.Parse(Console.ReadLine());
                    if (MyAge <= 3 || MyAge > 100)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Я не верю, что вам {MyAge}.   -_-");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный ввод, повторите попытку.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }  
            }
            Console.WriteLine("Ваш адрес электронной почты.");
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                
                ContactEmail = Console.ReadLine();
                var addrChek = new EmailAddressAttribute();
                bool addr;
                addr = addrChek.IsValid(ContactEmail);
                if(addr == true)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный ввод, повторите попытку.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }
        }          
        protected void OutputConsolePersonalInfo()
        {
            Console.Clear();
            Console.WriteLine($"Я, {Name}, мне {MyAge}. Моя почта: {ContactEmail}.");
        }
        public void ChekerPersonalInfo()
        {
            char check = '0';
            while (true)
            {
                OutputConsolePersonalInfo();
                Console.WriteLine("Всё верно?(y/n)");
                try
                {
                    check = char.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                }
                if (check == 'y' || check == 'Y')
                {
                    Console.Clear();
                    Console.WriteLine("Отлично! Перейдем к опросу.");
                    Console.WriteLine();
                    break;
                }
                else if (check == 'n' || check == 'N')
                {
                    Console.Clear();
                    Console.WriteLine("Вводи заново :D");
                    InputPersonalInfo();
                    OutputConsolePersonalInfo();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Идиот, либо да(y), либо нет(n)!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }
        }
        protected void Choices(string a1, string a2, string a3, string a4, string a5)
        {
            while (true)
            {
                char checkA = '0';
                Console.ForegroundColor = ConsoleColor.Cyan;

                try
                {
                    checkA = char.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                }

                if (checkA == '1')
                {
                    Choice = a1;
                    break;
                }
                else if (checkA == '2')
                {
                    Choice = a2;
                    break;
                }
                else if (checkA == '3')
                {
                    Choice = a3;
                    break;
                }
                else if (checkA == '4')
                {
                    Choice = a4;
                    break;
                }
                else if (checkA == '5')
                {
                    Choice = a5;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Такого варианта нет. Повторите попытку.");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
        }
        public void AnswerOnQuestion()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            // 1
            Console.WriteLine("Вопрос №1");
            Console.WriteLine("Насколько качественно преподавание Ваших главных (профилирующих) предметов?");
            Console.WriteLine("|1| - Очень качественно\n|2| - Качественно\n|3| - Скорее качественно\n|4| - Скорее некачественно\n|5| - Некачественно");
            Choices("Очень качественно", "Качественно", "Скорее качественно", "Скорее некачественно", "Некачественно");
            Answer1 = Choice;
            //2
            Console.WriteLine("Вопрос №2");
            Console.WriteLine("Вы считаете, учебные помещения ТТИиП'а оборудованы надлежащим образом?");
            Console.WriteLine("|1| - Да, полностью\n|2| - Да, достаточно\n|3| - Скорее да\n|4| - Скорее нет\n|5| - Недостаточно");
            Choices("Да, полностью", "Да, достаточно", "Скорее да", "Скорее нет", "Недостаточно");
            Answer2 = Choice;
            //3
            Console.WriteLine("Вопрос №3");
            Console.WriteLine("Вы чувствуете себя в ТТИиП'е безопасно?");
            Console.WriteLine("|1| - Полностью безопасно\n|2| - Скорее безопасно\n|3| - Безопасно\n|4| - Скорее небезопасно\n|5| - Я не чувствую себя безопасно");
            Choices("Полностью безопасно", "Скорее безопасно", "Безопасно", "Скорее небезопасно", "Я не чувствую себя безопасно");
            Answer3 = Choice;
            //4
            Console.WriteLine("Вопрос №4");
            Console.WriteLine("Насколько трудно получить нужные учебные материалы?");
            Console.WriteLine("|1| - Очень просто\n|2| - Просто\n|3| - Нормально\n|4| - Трудно\n|5| - Очень трудно");
            Choices("Очень просто", "Просто", "Нормально", "Трудно", "Очень трудно");
            Answer4 = Choice;
            //5
            Console.WriteLine("Вопрос №5");
            Console.WriteLine("Насколько Вы в общем довольны обучением в ТТИиП?");
            Console.WriteLine("|1| - Очень доволен/льна\n|2| - Доволен/льна\n|3| - Нормально доволен/льна\n|4| - Недоволен/льна\n|5| - Очень недоволен/льна");
            Choices("Очень доволен/льна", "Доволен/льна", "Нормально доволен/льна", "Недоволен/льна", "Очень недоволен/льна");
            Answer5 = Choice;
        }
    }
}
