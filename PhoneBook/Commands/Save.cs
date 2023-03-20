using PhoneBook.Database;
namespace PhoneBook.Commands
{
    static class SavePerson
    {
        public static void SaveOperation()
        {
            Person person = new Person();
            Console.WriteLine("Lütfen isim giriniz:");
            person.FirstName=Console.ReadLine();
            Console.WriteLine("Lütfen soyisim giriniz:");
            person.LastName=Console.ReadLine();
            Console.WriteLine("Lütfen telefon numarası giriniz:");
            person.PhoneNumber=Console.ReadLine();

         
            PhoneBookDatabase.PhoneList.Add(person);
            Console.WriteLine("Kişi başarıyla eklendi!");


        }
    }



}