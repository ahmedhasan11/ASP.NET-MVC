
        using System; 
using System.Collections.Generic; 
 

namespace AdvancedMVCApplication.Models
    {

        public class Users
        {
            public List <UserModels> UserList = new List <UserModels>();

            //action to get user details 
            public UserModels GetUser(int id)
            {
                UserModels usrMdl = null;

                foreach (UserModels um in UserList)

                    if (um.Id == id)
                        usrMdl = um;
                return usrMdl;
            }

            //action to create new user 
            public void CreateUser(UserModels userModel)
            {
                UserList.Add(userModel);
            }

            //action to udpate existing user 
            public void UpdateUser(UserModels userModel)
            {

                foreach (UserModels usrlst in UserList)
                {

                    if (usrlst.Id == userModel.Id)
                    {
                        usrlst.Address = userModel.Address;
                        usrlst.DOB = userModel.DOB;
                        usrlst.Email = userModel.Email;
                        usrlst.FirstName = userModel.FirstName;
                        usrlst.LastName = userModel.LastName;
                        usrlst.Salary = userModel.Salary;
                        break;
                    }
                }
            }

            //action to delete exising user 
            public void DeleteUser(UserModels userModel)
            {

                foreach (UserModels usrlst in UserList)
                {

                    if (usrlst.Id == userModel.Id)
                    {
                        UserList.Remove(usrlst);
                        break;
                    }
                }
            }
        }
    }


