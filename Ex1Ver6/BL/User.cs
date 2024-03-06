namespace Ex1Ver6.BL
{
    public class User
    {
        string firstName;
        string familyName;
        string email;
        string password;
        bool isAdmin;
        bool isActive;
        static List<User> usersList= new List<User>();
        DBServices dbs = new DBServices();

        public User() { }

        public User(string firstName, string familyName, string email, string password, bool isAdmin, bool isActive)
        {
            FirstName = firstName;
            FamilyName = familyName;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
            IsActive = isActive;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string FamilyName { get => familyName; set => familyName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
        public bool IsActive { get => isActive; set => isActive = value; }

        public List<User> Read()
        {
            return dbs.ReadUser();
        }

        public User GetUser(string email)
        {
            return dbs.GetUser(email);
        }

        public bool ChangeStatus(string email, bool newStatus)
        {
            return dbs.ChangeStatus(email, newStatus);
        }
        public int Insert()
        {
            return dbs.InsertUser(this);
        }

        public int UpdateUserDetails(string firstName, string familyName, string email, string password)
        {
            return dbs.UpdateUserDetails(firstName, familyName, email, password);
        }

        public User Login(string email, string password)
        {
            return dbs.Login(email, password);
        }
    }
}
