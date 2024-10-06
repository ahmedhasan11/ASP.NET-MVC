namespace Form_Application.Models
{
    public class Users
    {
        public List<UserModel> UserList = new List<UserModel>();
        //Details
        //create
        //update
        //delete

        public UserModel GetUser(int id) //details
        {
            UserModel usrmod = null;

            foreach (UserModel um in UserList)
            {
                if (um.id ==id)
                {
                    usrmod = um;
                }
            }
            return usrmod;            
        }

        public void CreateUser(UserModel usermodel)
        {
            UserList.Add(usermodel);
        }

        public void UpdateUser(UserModel usermodel)
        {
        foreach(UserModel um in UserList)
            {
                if (um.id == usermodel.id)
                {
                    um.FirstName = usermodel.FirstName;
                    um.LastName = usermodel.LastName;
                    um.address = usermodel.address;
                    um.Email = usermodel.Email;
                    um.DateOfBirth = usermodel.DateOfBirth;
                    um.salary = usermodel.salary;
                    break;
                }
            }

        }

        public void DeleteUser(UserModel usrmod) 
        {
            foreach (UserModel um in UserList)
            {
                if (um.id==usrmod.id)
                {
                    UserList.Remove(um);
                    break;
                }
            }
            
        }

       


    }
}
