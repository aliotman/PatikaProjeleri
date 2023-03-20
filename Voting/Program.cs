

internal class Program
{
    private static void Main(string[] args)
    {
        tryTransaction:
        Console.WriteLine("Lütfen yapılacak işlemi seçiniz. 1 - Oy Ver, 2 - Sonuçları Gör: ");
        int transaction = int.Parse(Console.ReadLine());

        switch (transaction)
        {
            case 1:
            Voting();
            break;

            case 2:
            Results();
            break;

            default: 
            Console.WriteLine("Hatalı işlem yaptınız.Ana Menüye dönmek için bir tuşa basınız.");
            Console.ReadKey();
            Console.Clear();
            break;  
        }
        goto tryTransaction;
    }
    public static void Voting(){
        tryAgain:
        Console.Write("Lütfen Kullanıcı Adınızı Giriniz: ");
        string userName = Console.ReadLine();
        tryVote:
        Users user = new Users();
        

        if (Database.users.Any(u=>u.userName==userName))  
        {
            user=Database.users.First(u=>u.userName==userName);
            
            
            if(user.isVoted==false)
            {
                foreach (var item in Database.categories)
                {
                    Console.WriteLine($"No: {item.categoryID} - Tür: {item.categoryName}");
                }
                tryCategory:
                Console.WriteLine("Oy Vermek İstediğiniz Kategori Numarasını Giriniz: ");
                int choice = int.Parse(Console.ReadLine());

                if (Database.categories.Any(c=>c.categoryID==choice)) 
                {
                    var chosenCategory = Database.categories.FirstOrDefault(c => c.categoryID == choice);
                    chosenCategory.categoryVote++;
                    Console.WriteLine("Oylama başarılı.Ana Menü'ye dönmek için bir tuşa basınız.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Kategori bulunamadı!");
                    goto tryCategory;
                }
            }
            
            else
            {
                Console.WriteLine($"{user.userName} adlı kullanıcı zaten oy kullanmıştır. Lütfen başka bir kullanıcı adı giriniz.");
                goto tryAgain;
            }
            user.isVoted=true;
        }
        else 
        {
            Console.WriteLine("Böyle bir kullanıcı bulunamadı. Kayıt ekranına yönlendiriliyorsunuz.");
            tryUserName:
            Console.WriteLine("Lütfen oluşturmak istediğiniz kullanıcı adını giriniz: ");
            string newUserName=Console.ReadLine();

            if (Database.users.Any(user=>user.userName==newUserName)) 
            {
                Console.WriteLine("Bu kullanıcı adı zaten alınmış.");
                goto tryUserName;
            }
            else 
            {
                user.userName=newUserName;
                user.isVoted=false;
                Database.users.Add(user);
                Console.WriteLine("Kaydınız başarıyla yapılmıştır.Oylama ekranına yönlendiriliyorsunuz. Lütfen bir tuşa basınız.");
                Console.ReadKey();
                Console.Clear();
                goto tryVote;
            }
        }   
    }

    public static void Results(){
        Console.WriteLine("Oylama Sonuçları");
        int totalVotes = Database.categories.Sum(c => c.categoryVote);
        Console.WriteLine($"Toplam Oy Sayısı: {totalVotes} Oy");
        foreach (var item in Database.categories)
        {
            
            Console.WriteLine($"Kategori Adı: {item.categoryName}, Oy Sayısı: {item.categoryVote}, Yüzdelik Değeri: %{Convert.ToDouble(100*item.categoryVote/totalVotes)}");
        }
        Console.WriteLine("Ana Menü'ye dönmek için bir tuşa basınız.");
        Console.ReadKey();
    }
}

