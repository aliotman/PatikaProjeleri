public class Operations
{   
    Log log = new Log();
    public void Login()
    {
    tryLogin:
        Console.Write("Lütfen 11 Haneli TC Kimlik Numaranızı Giriniz: ");
        string idNo = Console.ReadLine();
        Console.Write("Lütfen Kart Şifrenizi Giriniz: ");
        string password = Console.ReadLine();

        var user = Database.customer.FirstOrDefault(k => k.IdNo == idNo);

        log.CheckAndCreate();
       

        if (user != null && user.Password == password)
        {
            log.LoginSuccessLog(user.IdNo,user.Name,user.Surname);
        mainMenu:
            Console.Clear();
            Console.Write($"Sayın {user.Surname} Lütfen Yapmak İstediğiniz İşlemi Seçiniz: ");
            Console.WriteLine("\n1-Para Çek\n2-Para Yatır\n3-Para Gönder\n4-Bakiye Görüntüle\n5-Kullanıcı Değiştir\n6-Çıkış Yap");
            int choice = int.Parse(Console.ReadLine());
            Operations operations = new Operations();
            Console.Clear();
            switch (choice)
            {

                case 1:
                    operations.WithdrawMoney(user.IdNo, user.AccountBalance);//Para Çek
                    break;

                case 2:
                    operations.DepositMoney(user.IdNo, user.AccountBalance);
                    break;

                case 3:
                    operations.SendMoney(user.IdNo, user.AccountBalance);
                    break;

                case 4:
                    operations.ViewBalance(user.IdNo, user.AccountBalance);
                    break;

                case 5:
                    operations.Login();
                    break;

                case 6:
                    operations.LogOut(user.IdNo,user.Name,user.Surname);
                    break;

                default:
                    Console.WriteLine("Hatalı Giriş Yaptınız.Lütfen bir tuşa basınız.");
                    Console.ReadKey();
                    break;
            }
            goto mainMenu;
        }
        else
        {
            Console.Clear();
            if (user==null) 
            {
                
            }
            else if (user.IdNo!=null && user.Password!=password)
            {
                log.CheckAndCreate();
                log.LoginFailedLog(user.IdNo,user.Name,user.Surname);    
            }
            Console.WriteLine("Kullanıcı Adı veya Şifre Hatalı.");
            
            
            goto tryLogin;
        }
    }
    public void WithdrawMoney(string idNo, int AccountBalance)
    {

        Console.Write("Lütfen çekmek istediğiniz para miktarını giriniz: ");
        int amount = Math.Abs(int.Parse(Console.ReadLine()));

        var customer = Database.customer.FirstOrDefault(x => x.IdNo == idNo);

        if (customer.AccountBalance - amount < 0)
        {
            Console.Clear();
            Console.WriteLine("Yetersiz bakiye. Devam etmek için bir tuşa basınız.");
            Console.ReadKey();
        }
        else
        {
            customer.AccountBalance -= amount;
            Console.WriteLine($"{amount} TL para çekme işlemi başarılı.");
            log.WithdrawMoneyLog(customer.IdNo,customer.Name,customer.Surname,amount,customer.AccountBalance);
            ViewBalance(customer.IdNo, customer.AccountBalance);
        }

    }
    public void DepositMoney(string idNo, int AccountBalance)
    {

        Console.Write("Lütfen yatırmak istediğiniz para miktarını giriniz: ");
        int amount = Math.Abs(int.Parse(Console.ReadLine()));

        var customer = Database.customer.FirstOrDefault(x => x.IdNo == idNo);

        customer.AccountBalance += amount;
        Console.WriteLine($"{amount} TL para yatırma işlemi başarılı.");
        log.DepositMoneyLog(customer.IdNo,customer.Name,customer.Surname,amount,customer.AccountBalance);
        ViewBalance(customer.IdNo, customer.AccountBalance);

    }
    public void SendMoney(string idNo, int AccountBalance)
    {

        Console.Write("Göndermek istediğiniz kişinin 11 haneli TC kimlik numarasını giriniz: ");
        string sendMoneyIdNo = Console.ReadLine();

        var moneyReceiver = Database.customer.FirstOrDefault(r => r.IdNo == sendMoneyIdNo); //Alıcı
        var moneySender = Database.customer.FirstOrDefault(s => s.IdNo == idNo);
        if (moneyReceiver != null)
        {
            Console.Write("Göndermek istediğiniz tutarı giriniz: ");
            int amount = Math.Abs(int.Parse(Console.ReadLine()));

            if (AccountBalance - amount < 0)
            {
                Console.Clear();
                Console.WriteLine("Yetersiz bakiye.");
            }
            else
            {
                moneySender.AccountBalance -= amount;
                moneyReceiver.AccountBalance += amount;
                Console.WriteLine($"{moneyReceiver.Name} kişisine {amount} TL gönderilmiştir.");
                ViewBalance(moneySender.IdNo, moneySender.AccountBalance);
                log.SendMoneyLog(moneySender.IdNo,moneyReceiver.IdNo,moneySender.Name,moneyReceiver.Name,moneySender.Surname,moneyReceiver.Surname,amount,moneySender.AccountBalance);
                log.TakeMoneyLog(moneySender.IdNo,moneyReceiver.IdNo,moneySender.Name,moneyReceiver.Name,moneySender.Surname,moneyReceiver.Surname,amount,moneyReceiver.AccountBalance);
            }

        }
        else
        {
            Console.WriteLine("Kullanıcı bulunamadı.");
        }
        
    }
    public void ViewBalance(string idNo, int AccountBalance)
    {
        var customer = Database.customer.FirstOrDefault(x => x.IdNo == idNo);
        Console.WriteLine($"Ad : {customer.Name}\nSoyad: {customer.Surname}\nBakiye : {customer.AccountBalance} TL");
        log.ViewBalanceLog(customer.IdNo,customer.Name,customer.Surname);
        EndOperation(customer.IdNo,customer.Name,customer.Surname);
    }
    public void LogOut(string idNo,string name,string surname)
    {
        log.LogOut(idNo,name,surname);
        Environment.Exit(0);
    }
    public void EndOperation(string idNo,string name,string surname)
    {
    tryEnd:
        Console.WriteLine("1 - Çıkış Yap\n2 - Ana Menü'ye Dön");
        int operation = int.Parse(Console.ReadLine());
        switch (operation)
        {
            case 1:
                LogOut(idNo,name,surname);
                break;

            case 2:
                break;

            default:
                Console.Clear();
                Console.WriteLine("Hatalı seçim yaptınız.");
                goto tryEnd;
        }
    }
}