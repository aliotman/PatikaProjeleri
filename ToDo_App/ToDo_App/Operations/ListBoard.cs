using TODO.Datas;

namespace TODO.Operations
{


    public class ListOperation
    {
        public void ListCard()
        {

            string todo = Database.defaultCard.FirstOrDefault(x => x.Line == "TODO")?.Line;
            if (todo!=null)
            {
                ListingProgressNotNull(todo);
            }
            else
            {
                todo = "TODO";
                ListingProgressNull(todo);
            }

            string inProgress = Database.defaultCard.FirstOrDefault(x => x.Line == "INPROGRESS")?.Line;
            if (inProgress!=null)
            {
                ListingProgressNotNull(inProgress);
            }
            else
            {
                inProgress = "INPROGRESS";
                ListingProgressNull(inProgress);
            }

            string done = Database.defaultCard.FirstOrDefault(x => x.Line == "DONE")?.Line;
            if (done!=null)
            {
                ListingProgressNotNull(done);
            }
            else
            {
                done = "DONE";
                ListingProgressNull(done);
            }
        }

        public void ListingProgressNotNull(string line)
        {
            if (line != null)
            {
                Console.WriteLine(line + " Line");
                Console.WriteLine("************************");
                foreach (var item in Database.defaultCard)
                {

                    if (item.Line == line)
                    {
                        Console.WriteLine("Başlık           :" + item.Title);
                        Console.WriteLine("İçerik           :" + item.Content);
                        Console.WriteLine("Atanan Kişi      :" + item.Member);
                        Console.WriteLine("Büyüklük         :" + item.Size);
                        Console.WriteLine("-");
                    }
                }
            }
           

        }

        public void ListingProgressNull(string nullLine)
        {
            Console.WriteLine(nullLine + " Line");
            Console.WriteLine("************************");
            Console.WriteLine("~ BOŞ ~\n");
        }
    }

}