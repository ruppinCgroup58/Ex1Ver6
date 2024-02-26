namespace Ex1Ver6.BL
{
    public class User
    {
        string firstName;
        string familyName;
        string email;
        string password;
        static List<User> usersList= new List<User>();
        DBServices dbs = new DBServices();

        public User() { }

        public User(string firstName, string familyName, string email, string password)
        {
            FirstName = firstName;
            FamilyName = familyName;
            Email = email;
            Password = password;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string FamilyName { get => familyName; set => familyName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }

        public bool Insert()
        {
            dbs.InsertUser(this);
            return true;
        }

        public bool Update(string id, string password)
        {
            foreach (var user in usersList)
            {
                if (user.email == id)
                {
                    user.password = password;
                }
            }
            return true;
        }
    }
}
