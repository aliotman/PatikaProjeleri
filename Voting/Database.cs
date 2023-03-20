


public class Database
{
    private static List<Categories> _categories;
    private static List<Users> _users;
    static Database()
    {
        _categories = new()
        {
            new Categories{categoryID=1,categoryName="Horror",categoryVote=0},
            new Categories{categoryID=2,categoryName="Comedy",categoryVote=0},
            new Categories{categoryID=3,categoryName="Action",categoryVote=0},
            new Categories{categoryID=4,categoryName="Adventure",categoryVote=0},
            new Categories{categoryID=5,categoryName="Western",categoryVote=0},
        };

        _users=new()
        {
            new Users{userName="Mert",isVoted=false},
            new Users{userName="Ali",isVoted=false},
            new Users{userName="Aksel",isVoted=false},
        };
    }
    public static List<Categories> categories => _categories;
    public static List<Users> users=>_users;
}

