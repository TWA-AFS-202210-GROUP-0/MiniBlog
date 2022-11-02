﻿using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Services
{
    public class UserService : IUserService
    {
        private IArticleStore _articleStore;
        private IUserStore _userStore;

        public UserService(IArticleStore articleStore, IUserStore userStore)
        {
            _articleStore = articleStore;
            _userStore = userStore;
        }

        public User Register(User user)
        {
            if (!_userStore.GetAll().Exists(_ => user.Name.ToLower() == _.Name.ToLower()))
            {
                _userStore.Save(user);
            }

            return user;
        }


    }
}