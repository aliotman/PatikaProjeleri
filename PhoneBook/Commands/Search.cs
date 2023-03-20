using PhoneBook.Database;
namespace PhoneBook.Commands
{
     static class SearchPerson
    {
        
        public static void SearchingOperation()
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.\n**********************************************");
            Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
            Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");
            string select = Console.ReadLine();
            Person searchPerson=new();
            if (int.TryParse(select, out int choice))
            {

                if (choice == 1)
                {
                    Console.WriteLine("Lütfen arama yapmak istediğiniz kişinin adını ya da soyadını giriniz:");
                    string findPerson = Console.ReadLine();
                    if (PhoneBookDatabase.PhoneList.Any(x => x.FirstName == findPerson || x.LastName == findPerson)) ;
                    {

                        searchPerson = PhoneBookDatabase.PhoneList.FirstOrDefault(x => x.FirstName == findPerson || x.LastName == findPerson);
                        ShowPerson(searchPerson);
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Lütfen arama yapmak istediğiniz kişinin numarasını giriniz:");
                    string findPerson = Console.ReadLine();
                    if (PhoneBookDatabase.PhoneList.Any(x => x.PhoneNumber == findPerson)) ;
                    {

                        searchPerson = PhoneBookDatabase.PhoneList.FirstOrDefault(x => x.PhoneNumber == findPerson);
                        ShowPerson(searchPerson);
                    }
                }
                else
                {
                    Console.WriteLine("Hatalı giriş. Sadece 1 veya 2 yazmanız gerekir. Ana menüye dönmek için bir tuşa basınız.");
                }

            }
            else
            {
                Console.WriteLine("Sadece rakam girebilirsiniz. Ana menüye dönmek için bir tuşa basınız.");
            }
            Console.ReadKey();
        }
        public static void ShowPerson(Person searchPerson)
        {
            Console.WriteLine("İsim:             {0}", searchPerson.FirstName);
            Console.WriteLine("Soyisim:          {0}", searchPerson.LastName);
            Console.WriteLine("Telefon Numarası: {0}", searchPerson.PhoneNumber);
            Console.WriteLine("Ana menüye dönmek için bir tuşa basınız.");
        }
    }
}