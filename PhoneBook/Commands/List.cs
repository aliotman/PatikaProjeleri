using PhoneBook.Database;
namespace PhoneBook.Commands
{
    static class ListPerson
    {
        public static void ListOperation()
        {
            Console.WriteLine("Telefon Rehberi \n**********************************************");
            foreach (Person item in PhoneBookDatabase.PhoneList)
            {
                Console.WriteLine("İsim: " + item.FirstName);
                Console.WriteLine("Soyisim: " + item.LastName);
                Console.WriteLine("Telefon Numarası: " + item.PhoneNumber);
                Console.WriteLine("-");
            }

            


        }
    }
}