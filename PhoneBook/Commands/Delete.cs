using PhoneBook.Database;
namespace PhoneBook.Commands
{
    static class DeletePerson
    {
        public static void DeleteOperation()
        {   
            tryFind:      
            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
            string findPerson = Console.ReadLine();
            
            if (PhoneBookDatabase.PhoneList.Any(x=> x.FirstName==findPerson|| x.LastName==findPerson))
            {
                Person deletePerson = new();
                deletePerson = PhoneBookDatabase.PhoneList.FirstOrDefault(y=> y.FirstName==findPerson || y.LastName==findPerson);
                Console.WriteLine(deletePerson.FirstName+" "+deletePerson.LastName+" isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)");
                string choice = Console.ReadLine().ToUpper();
                if (choice=="Y")
                {
                    PhoneBookDatabase.PhoneList.Remove(deletePerson);
                    Console.WriteLine(deletePerson.FirstName+" "+deletePerson.LastName+" isimli kişi başarıyla silindi. Ana menüye dönmek için bir tuşa basınız.");
                }
                else if (choice=="N")
                {
                    Console.WriteLine("Silme işlemi iptal edildi. Ana menüye dönmek için bir tuşa basınız.");                
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yaptınız. Ana menüye dönmek için bir tuşa basınız.");                 
                }
                Console.ReadKey();    
  
            }
            else
            {
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                tryInput:
                Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için      : (2)");
               
                char tryOrExit=Convert.ToChar(Console.ReadLine());

                if (tryOrExit=='1')
                {
                    Console.WriteLine("Silme işlemi sonlandırıldı. Ana menüye dönmek için bir tuşa basınız.");
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