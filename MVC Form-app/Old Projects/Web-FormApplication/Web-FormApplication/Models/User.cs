namespace Web_FormApplication.Models
{
    public class User
    {
        //fn , ln , email , adress, phone , dob
        //details, update, add, delete

        public List<UserModel> UserList = new List<UserModel>();

        public UserModel UserDetails(int id)
        {
            UserModel ummm = null;

            foreach(UserModel um in UserList)
            {
                if (um.id==id)
                {
                    ummm = um;
                }
            }
            return ummm;
        }

        public void UserAdd(UserModel um)
        {
            UserList.Add(um);
        }

        public void UserUpdate(UserModel um)
        {
            foreach(UserModel ummm in UserList)
            {
                if (ummm.id==um.id)
                {
                    ummm.FirstName = ummm.FirstName;
                    ummm.LastName = ummm.LastName;
                    ummm.PhoneNumber = ummm.PhoneNumber;
                    ummm.Email = ummm.Email;
                    ummm.Address = ummm.Address;
                    ummm.DateOfBirth = ummm.DateOfBirth;
                }
            }
        }

        public void UserDelete(UserModel umm)
        {
            foreach (UserModel um in UserList)
            {
                if(um.id==umm.id) 
                {
                UserList.Remove(um);
                }
            }
        }
    }
}
