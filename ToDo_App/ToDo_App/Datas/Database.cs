using System.Collections.Generic;
namespace TODO.Datas
{
    public class Database
    {
        private static List<Card> _defaultCard;
        private static List<Person> _person;
        static Database()
        {
            _person = new List<Person>()
            {
                new Person{Id=1,Name="Ferit Aslan"},
                new Person{Id=2,Name="Ela Koç"},
                new Person{Id=3,Name="Murat İkizler"},
                new Person{Id=4,Name="Buket Terazi"}
            };

            _defaultCard = new List<Card>()
            {
                new Card{Title="Kurs",Content="Udemy üzerinden yeni kurs izlenecek.",Member="Ferit Aslan",Size="L",Line="TODO"},
                new Card{Title="Ödev",Content="Yazılım ödevini yap.",Member="Ferit Aslan",Size="XS",Line="TODO"},
                new Card{Title="Ders",Content="Yarın için gerekli ders materyallerini hazırla.",Member="Ferit Aslan",Size="S",Line="INPROGRESS"},
                new Card{Title="Oku",Content="Ders kitabı oku.",Member="Ela Koç",Size="L",Line="DONE"},
            };

        }

        public static List<Card> defaultCard => _defaultCard;
        public static List<Person> defaultPersons => _person;

        
    }


}

