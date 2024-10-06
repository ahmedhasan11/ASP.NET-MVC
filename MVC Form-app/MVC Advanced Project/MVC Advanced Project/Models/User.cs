namespace MVC_Advanced_Project.Models
{
    public class User
    {
        public List<UserModel> UserList = new List<UserModel>();

        //add , delete , edit , details

        //AddUser

        public void AddUser(UserModel um)
        {
            UserList.Add(um);
        }
        //DeleteUser
        public void DeleteUser(UserModel um)
        {
            foreach (UserModel usermodel in UserList)
            {
                if (usermodel.Id == um.Id)
                {
                    UserList.Remove(usermodel);
                }
            }

        }

        //EditUser
        public void EditUser(UserModel um)
        {
            foreach(UserModel usermodel in UserList)
            {
                if (usermodel.Id == um.Id)
                {
                    um.FirstName = usermodel.FirstName;
                    um.LastName = usermodel.LastName;
                    um.Email = usermodel.Email;
                    um.Address = usermodel.Address;
                    um.DateOfBirth = usermodel.DateOfBirth;
                    um.PhoneNumber = usermodel.PhoneNumber;
                }
            }

        }

        public UserModel DetailsUser (int id )
        {
            UserModel usermodel = null;
            foreach(UserModel um in UserList) 
            {
                if (um.Id==id)
                {
                    usermodel = um;
                }
            }
            return usermodel;
        }
        


    }
}
