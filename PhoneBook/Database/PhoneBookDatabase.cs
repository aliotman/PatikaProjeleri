namespace PhoneBook.Database
{
    public class PhoneBookDatabase
    {
      
        static List <Person> _phoneList; 

        public static List <Person> PhoneList
        {
            get {return _phoneList;}
        }

        static PhoneBookDatabase()
        {
            _phoneList=new List <Person>(){};
        }
       
    }
}