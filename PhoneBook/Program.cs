using PhoneBook.Database;
using PhoneBook.Commands;
namespace PhoneBook
{
    internal class PhoneBook
    {
        private static void Main(string[] args)
        {
            Person person1 = new();
            person1.FirstName = "Kaya"; person1.LastName = "Birinci"; person1.PhoneNumber = "0123 111 001";
            Person person2 = new();
            person2.FirstName = "Su"; person2.LastName = "İkinci"; person2.PhoneNumber = "0123 111 002";
            Person person3 = new();
            person3.FirstName = "Toprak"; person3.LastName = "Üçüncü"; person3.PhoneNumber = "0123 111 003";
            Person person4 = new();
            person4.FirstName = "Ateş"; person4.LastName = "Dördüncü"; person4.PhoneNumber = "0123 111 004";
            Person person5 = new();
            person5.FirstName = "Rüzgar"; person5.LastName = "Beşinci"; person5.PhoneNumber = "0123 111 005";


            PhoneBookDatabase.PhoneList.Add(person1);
            PhoneBookDatabase.PhoneList.Add(person2);
            PhoneBookDatabase.PhoneList.Add(person3);
            PhoneBookDatabase.PhoneList.Add(person4);
            PhoneBookDatabase.PhoneList.Add(person5);

            mainmenu:
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :) ");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numarayı Silmek");
            Console.WriteLine("(3) Varolan Numarayı Güncelleme");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak");

            string select = Console.ReadLine();
            if (int.TryParse(select, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        SavePerson.SaveOperation();
                        goto mainmenu;
                    case 2:
                        DeletePerson.DeleteOperation();
                        goto mainmenu;
                    case 3:
                        UpdatePerson.UpdateOperation();
                        goto mainmenu;
                    case 4:
                        ListPerson.ListOperation();
                        goto mainmenu;
                    case 5:
                        SearchPerson.SearchingOperation();
                        goto mainmenu;
                    default:
                    Console.WriteLine("Hatalı giriş yaptınız! Tekrar denemek için bir tuşa basınız.");
                    Console.ReadKey();
                    goto mainmenu;                   
                }

            }
            else
            {
                Console.WriteLine("Sadece rakam girebilirsiniz! Tekrar denemek için bir tuşa basınız. ");
                Console.ReadKey();
                goto mainmenu;
            }




        }
    }
}