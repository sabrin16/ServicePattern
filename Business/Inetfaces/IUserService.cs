using Business.Models;
using System.Collections.Generic;


namespace Business.Inetfaces
{
    public interface IUserService
    {
    void AddUser(UserBase user);
    UserBase GetUserById(int id);
    List<UserBase> GetAllUsers();
    }
}