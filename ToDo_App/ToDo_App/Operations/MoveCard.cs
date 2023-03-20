using TODO.Datas;

namespace TODO.Operations
{
    public class MoveOperation
    {

        public void MoveCard()
        {
        move:
            Console.WriteLine("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.\nLütfen kart başlığını yazınız:  ");
            string title = Console.ReadLine();
            Card move = Database.defaultCard.FirstOrDefault(x => x.Title == title);
            if (move !=null)  
            {
                Console.WriteLine("Bulunan Kart Bilgileri:");
                Console.WriteLine("**************************************");
                Console.WriteLine("Başlık      :" + move.Title);
                Console.WriteLine("İçerik      :" + move.Content);
                Console.WriteLine("Atanan Kişi :" + move.Member);
                Console.WriteLine("Büyüklük    :" + move.Size);
                Console.WriteLine("Line        :" + move.Line + "\n");
            moveChoice:
                Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz: ");
                Console.WriteLine("(1) TODO");
                Console.WriteLine("(2) IN PROGRESS");
                Console.WriteLine("(3) DONE");

                int moveChoice = int.Parse(Console.ReadLine());

                switch (moveChoice)
                {
                    case 1:
                        move.Line = "TODO";
                        break;

                    case 2:
                        move.Line = "INPROGRESS";
                        break;

                    case 3:
                        move.Line = "DONE";
                        break;

                    default:
                        Console.WriteLine("Hatalı seçim yaptınız.");
                        goto moveChoice;
                }
                Console.WriteLine("Kart başarıyla taşındı!");
            }
            else
            {
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
            choice:
                Console.WriteLine("* Taşımayı sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için : (2)");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {

                }
                else if (choice == 2)
                {
                    Console.Clear();
                    goto move;
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