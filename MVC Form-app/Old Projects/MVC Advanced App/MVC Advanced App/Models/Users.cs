namespace MVC_Advanced_App.Models
{
    public class Users
    {
        public List<UserModels> UserList = new List<UserModels> { } ;

        public UserModels GetUser(int id)
        {
            UserModels usermod = null;
            foreach(UserModels um in UserList) 
            {
                if (um.id == id) 
                {
                    usermod= um;
                }
            }
            return usermod;
        }
        public void CreateUser(UserModels usermodel) 
        {
            UserList.Add(usermodel);         
        }

        public void UpdateUser(UserModels usermodel)
        {
            foreach (UserModels um in UserList)
            {
                if(um.id == usermodel.id)
                {
                    um.Firstname = usermodel.Firstname;
                    um.Lastname = usermodel.Lastname;
                    um.Salary = usermodel.Salary;
                    um.DOB = usermodel.DOB;                    
                }
            }
        }

        public void DeleteUser(UserModels usermodel)
        {
            foreach(UserModels um in UserList)
            {
                if (um.id == usermodel.id)
                {
                    UserList.Remove(um);
                }
            }
        }
    }
}
