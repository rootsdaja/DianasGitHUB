using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirplaneTrafficManagement.Repo
{
    interface IUserTypeRepository
    {
        IEnumerable<UserType> GetUserTypes();
        UserType GetUserTypesById(int id);
        void InsertUserType(UserType user);
        void DeleteUserType(int Id);
        void UpdateUserType(UserType user);
        void Save();
    }
}
