public class Log
{

    public void LoginSuccessLog(string id, string name, string surname)
    {
        string writeLog = $"{id} kimlik numaralı {name + " " + surname} kişisi {DateTime.Now} - tarihinde başarılı giriş yaptı.";
        TransactionLog(id, writeLog);
    }
    public void LoginFailedLog(string id, string name, string surname)
    {
        string writeLog = $"{id} kimlik numaralı {name + " " + surname} kişisi {DateTime.Now} - tarihinde hatalı giriş yaptı.";
        TransactionLog(id, writeLog);
    }
    public void WithdrawMoneyLog(string id, string name, string surname, int amount, int balance)
    {
        string writeLog = $"{id} kimlik numaralı {name + " " + surname} kişisi {DateTime.Now} - tarihinde {amount} TL para çekti.";
        string[] writeBalanceLog = { $"Adı: {name}", $"Soyadı: {surname}", $"Bakiye: {balance}" };
        BalanceLog(id, writeBalanceLog);
        TransactionLog(id, writeLog);
    }

    public void DepositMoneyLog(string id, string name, string surname, int amount, int balance)
    {
        string writeLog = $"{id} kimlik numaralı {name + " " + surname} kişisi {DateTime.Now} - tarihinde {amount} TL para yatırdı.";
        string[] writeBalanceLog = { $"Adı: {name}", $"Soyadı: {surname}", $"Bakiye: {balance}" };
        BalanceLog(id, writeBalanceLog);
        TransactionLog(id, writeLog);
    }

    public void SendMoneyLog(string senderID, string receiverID, string senderName, string receiverName, string senderSurname, string receiverSurname, int amount, int balance)
    {
        string writeLog = $"{senderID} kimlik numaralı {senderName + " " + senderSurname} kişisi, {receiverID} kimlik numaralı {receiverName + " " + receiverSurname} kişisine  {DateTime.Now} - tarihinde {amount} TL para gönderdi.";
        string[] writeBalanceLog = { $"Adı: {senderName}", $"Soyadı: {senderSurname}", $"Bakiye: {balance}" };
        BalanceLog(senderID, writeBalanceLog);
        TransactionLog(senderID, writeLog);
    }

    public void TakeMoneyLog(string senderID, string receiverID, string senderName, string receiverName, string senderSurname, string receiverSurname, int amount, int balance)
    {
        string writeLog = $"{senderID} kimlik numaralı {senderName + " " + senderSurname} kişisinden, hesabınıza {DateTime.Now} - tarihinde {amount} TL para gönderildi.";
        string[] writeBalanceLog = { $"Adı: {receiverName}", $"Soyadı: {receiverSurname}", $"Bakiye: {balance}" };
        BalanceLog(receiverID, writeBalanceLog);
        TransactionLog(receiverID, writeLog);
    }

    

    public void ViewBalanceLog(string id, string name, string surname)
    {
        string writeLog = $"{id} kimlik numaralı {name + " " + surname} kişisi {DateTime.Now} - tarihinde bakiyeyi görüntüledi.";
        TransactionLog(id, writeLog);
    }

    public void LogOut(string id, string name, string surname)
    {
        string writeLog = $"{id} kimlik numaralı {name + " " + surname} kişisi {DateTime.Now} - tarihinde çıkış yaptı.";
        TransactionLog(id, writeLog);
    }

    public void CheckAndCreate()
    {
        if (!Directory.Exists(@"C:\Atm App"))
        {
            Directory.CreateDirectory(@"C:\Atm App");

            foreach (var item in Database.customer)
            {
                string idLogLocation = $@"C:\Atm App\{item.IdNo} Log.txt";
                FileStream fs1 = new FileStream(idLogLocation, FileMode.OpenOrCreate, FileAccess.Write);

                string balanceLogLocation = $@"C:\Atm App\{item.IdNo} Account.txt";
                FileStream fs2 = new FileStream(balanceLogLocation, FileMode.OpenOrCreate, FileAccess.Write);

                fs1.Close();
                fs2.Close();

                string[] userDefaultAccountInfo = { $"Adı: {item.Name}", $"Soyadı: {item.Surname}", $"Bakiye: {0}" };
                BalanceLog(item.IdNo, userDefaultAccountInfo);
            }
        }
        else
        {
            string filesLocation = @"C:\Atm App\";
            string[] getAccountFileNames = Directory.GetFiles(filesLocation, "*Account.txt");
            string[] getIdFileName = Directory.GetFiles(filesLocation, "*Log.txt");
            for (int i = 0; i < Database.customer.Count; i++)
            {
                string fileLocation = getAccountFileNames[i];
                string[] getLines = File.ReadAllLines(fileLocation);
                int balance = int.Parse(getLines[2].Substring(8));

                string fileName = getIdFileName[i].Substring(11, 11);
                var userBalance = Database.customer.FirstOrDefault(x => x.IdNo == fileName);
                userBalance.AccountBalance = balance;

            }
        }
    }

    public void TransactionLog(string idNo, string log)
    {
        string idLogLocation = $@"C:\Atm App\{idNo} Log.txt";
        FileStream fs1 = new FileStream(idLogLocation, FileMode.OpenOrCreate, FileAccess.Write);
        fs1.Close();
        File.AppendAllText(idLogLocation, Environment.NewLine + log);
    }

    public void BalanceLog(string idNo, string[] balanceLog)
    {
        File.WriteAllLines($@"C:\Atm App\{idNo} Account.txt", balanceLog);
    }

}