public class Database
{
    private static List<Customer> _customer;
    static Database()
    {
        _customer=new()
        {
            new Customer{IdNo="12345678901",Name="Mert",Surname="Uçman",Password="1905",AccountBalance=0},
            new Customer{IdNo="12345678902",Name="Ali",Surname="Otman",Password="3131",AccountBalance=0},
            new Customer{IdNo="12345678903",Name="Aksel",Surname="Asma",Password="9198",AccountBalance=0},
        };
    }

    public static List<Customer>customer=>_customer;
}