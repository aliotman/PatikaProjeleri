using TODO.Datas;

namespace TODO.Operations
{
    public class DeleteOperation
    {

        public void DeleteCard()
        {
            remove:
            Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.\nLütfen kart başlığını yazınız:  ");
            string title = Console.ReadLine();
            Card remove = Database.defaultCard.FirstOrDefault(x => x.Title == title);
            if (remove !=null)
            {
                Database.defaultCard.Remove(remove);
                Console.WriteLine("Kart başarıyla silindi!");
            }
            else
            {
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                choice:
                Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için : (2)");
                int choice = int.Parse(Console.ReadLine());
                if (choice==1)
                {
                    
                }
                else if (choice==2)
                {
                    Console.Clear();
                    goto remove;
                }
                else
                {
                    Console.WriteLine("Hatalı seçim yaptınız.");
                    goto choice;
                }
            }


        }

    }
}