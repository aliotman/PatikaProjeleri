using TODO.Operations;
using TODO.Datas;
namespace TODO
{
    internal class Program
    {
        private static void Main(string[] args)
        {       
            Database datas = new();
            mainMenu:
            Console.WriteLine("\nLütfen yapmak istediğiniz işlemi seçiniz.");
            Console.WriteLine("*******************************************");     
            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");
            int mainMenuChoice = int.Parse(Console.ReadLine());

            switch (mainMenuChoice)
            {
                case 1:
                ListOperation list = new();
                list.ListCard();
                goto mainMenu;

                case 2:
                AddOperation add = new();
                add.AddCard();
                goto mainMenu;

                case 3:
                DeleteOperation delete = new();
                delete.DeleteCard();
                goto mainMenu;

                case 4:
                MoveOperation move = new();
                move.MoveCard();
                goto mainMenu;

                default:
                Console.WriteLine("Hatalı seçim yaptınız.");
                goto mainMenu;
            }     
        }
    }
}
