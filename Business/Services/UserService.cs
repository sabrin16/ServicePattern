using System;
using System.Collections.Generic;
using System.Linq;
using Business.Models;
using Business.Exceptions;
using Business.Inetfaces;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly List<UserBase> _users = new List<UserBase>();
        private int _nextId = 1; 

        public void AddUser(UserBase user)
        {
            user.Id = _nextId++;
            _users.Add(user);
        }

        public UserBase GetUserById(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                throw new UserNotFoundException($"User with ID {id} not found.");
            return user;
        }

        public List<UserBase> GetAllUsers()
        {
            return new List<UserBase>(_users);
        }
    }
}