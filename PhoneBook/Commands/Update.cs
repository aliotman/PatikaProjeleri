using PhoneBook.Database;
namespace PhoneBook.Commands
{
    static class UpdatePerson
    {
        public static void UpdateOperation()
        {
            tryFind:
            Console.WriteLine("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:");
            string findPerson=Console.ReadLine();

            if (PhoneBookDatabase.PhoneList.Any(x=>x.FirstName == findPerson||x.LastName==findPerson))
            {
                Person updatePerson = new();
                updatePerson=PhoneBookDatabase.PhoneList.FirstOrDefault(x=>x.FirstName==findPerson||x.LastName==findPerson);

                Console.WriteLine(updatePerson.FirstName+" "+updatePerson.LastName+" isimli kişinin yeni numarasını giriniz.");
                updatePerson.PhoneNumber=Console.ReadLine();
                Console.WriteLine("Güncelleme işlemi başarıyla gerçekleşti. Ana menüye dönmek için bir tuşa basınız.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                tryInput:
                Console.WriteLine("* Güncellemeyi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için           : (2)");
               
                char tryOrExit=Convert.ToChar(Console.ReadLine());

                if (tryOrExit=='1')
                {
                    Console.WriteLine("Güncelleme işlemi sonlandırıldı. Ana menüye dönmek için bir tuşa basınız.");
                    Console.ReadKey();    
                }
                else if (tryOrExit=='2')
                {
                    goto tryFind;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yaptınız. Tekrar deneyiniz.");
                    goto tryInput;
                }
            }
        }
    }
}