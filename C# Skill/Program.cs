using System;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;

namespace C__Skill
{
    class Program


    {

        public static void Main()
        {
           
            Exam();
           
            Console.ReadKey(); 
        }

        public static (string firstname, string lastname, int age, bool HavePet, int CountPet, string[] PetNames, int CountFavColors, string[] FavColors ) Anketa()
        {
             (string firstname, string lastname, int age, bool HavePet, int CountPet , string[] PetNames, int CountFacColors, string[] FavColors) User;
                Console.WriteLine("Приветствую! Давайте вместе заполним Вашу анкету!");            
                Console.WriteLine("Введите ваше имя");
                User.firstname = Console.ReadLine();
                Console.WriteLine("Введите вашу фамилию");
                User.lastname = Console.ReadLine();


            string quest1 = "Сколько вам полных лет ? (цифрами)";

            User.age =Valid(quest1);

            Console.WriteLine("У вас есть питомец? (Да или Нет)");
                if (Console.ReadLine() == "Да" )
                {
                    User.HavePet = true;
                }
                else
                {
                    User.HavePet = false;
                }
                if (User.HavePet)

                {
                    string quest2 = "Сколько у вас питомцев?";

                    User.CountPet = Valid(quest2);
                    User.PetNames = PetNames(User.CountPet);

                }
                else
                {
                    User.CountPet = 0;
                    User.PetNames = new string[0]; //пустое значение
                }

            string quest3 = "Сколько у вас любимых цветов радуги? (цифрами)";


            User.CountFacColors = Valid(quest3);

            User.FavColors = FavColors(User.CountFacColors);

                return User;


        }
        public static string[] PetNames(int PetNum)// МЕтод для ввода массива имён питомцев
        {
                var result = new string[PetNum];
            


                for (int i = 0; i < PetNum; i++)
                    {
                        Console.WriteLine("Введите имя питомца " + (i + 1));
                        result[i] = Console.ReadLine();
                    }
            
                return result;
        }

        public static string[] FavColors(int FavNum) // создаём метод ввода любимых цветов, который позволяет выбрать только из списка цветов радуги
        {
                var result = new string[FavNum];

                for (int i = 0; i < FavNum; i++)

                {
                    string input;
                    bool valid;
                do
                {
                    Console.WriteLine("Введите свой любимый цвет радуги № {0}", i + 1);
                    input = Console.ReadLine();
                    valid = ValidColor(input);
                    if (!valid)
                    {
                        Console.WriteLine(" Такого цвета нет в радуге. Повторите ввод.");
                    }

                }
                while (!valid);
                    result[i] = input;
                }


                return result;
        }

        public enum RainbowColor // создаем перечисление из цветов радуги
        {
                Красный,
                Оранжевый,
                Жёлтый,
                Зелёный,
                Голубой,
                Синий,
                Фиолетовый
        }
        
        public static bool ValidColor(string color) // создаём метод проверки введённого цвета на соответсвие с элементами перечисления из цветов радуги
        {
                return Enum.TryParse<RainbowColor> (color, ignoreCase: true, out _); // сравниваем без учёта регистра
        }


        
        public static int Valid(string quest) // создаём метод для проверки введённого числа, метод принимает запрос для пользователя на ввод числовых данных
        {
            string input;
            
          
            while(true)// запускаем цикл, который будет работать, пока пользователь не введёт число больше 0
            {
                Console.WriteLine(quest);


                input = Console.ReadLine();
               

                if (int.TryParse(input, out int number)) // ветка на число или буквы
                {
                    if (number > 0)// ветка на больше или меньше 0
                    {
                        number = Convert.ToInt32(input);
                        return number;
                        
                    }
                    
                    else
                    {
                        Console.WriteLine("Число должно быть больше 0 !");
                        
                        
                    }

                }


                else
                {
                    Console.WriteLine("Введите цифры !");
                }
                

            }
 
        }

        public static void Exam()// создаём метод для вывода введённых данных на экран
        {
            
            var data = Anketa();
            Console.WriteLine();

            Console.WriteLine("Давайте сверим введённые данные ");
            Console.WriteLine("Ваше имя : " + data.firstname);
            Console.WriteLine("Ваша фамилия : " + data.lastname);
            Console.WriteLine("Ваш возраст : " + data.age);
            if (data.HavePet)
            {
                Console.WriteLine("У вас {0} питомца(ев)", data.CountPet);
                Console.WriteLine("Ваши питомцы(ец)");
                foreach(var pet in data.PetNames)
                { 
                    Console.WriteLine(pet); 
                }


            }
            else
            {
                Console.WriteLine("У вас нет питомца(ев)");
            }
             
            

            Console.WriteLine("У вас {0} любимых цвета", data.CountFavColors );
            Console.WriteLine("Ваши любимые цвета : ");
            foreach(var color in data.FavColors)
            {
                Console.WriteLine(color);
            }

        }
    }
}
           
