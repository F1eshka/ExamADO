﻿using System.Windows;
using EkzamenADO.Models;
using EkzamenADO.Services;
using EkzamenADO.Windows;

namespace EkzamenADO
{
    public partial class LoginWindow : Window
    {
        private readonly ILoginService _loginService;

        public LoginWindow(ILoginService loginService)
        {
            InitializeComponent();
            _loginService = loginService;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailBox.Text;
            string password = PasswordBox.Password;

            var user = _loginService.Login(email, password);

            if (user != null)
            {
                MessageBox.Show("Успішний вхід!!))", "Вітаю");
                AdsWindow adsWindow = new AdsWindow(user);
                adsWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Невірний логін або пароль((");
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailBox.Text;
            string password = PasswordBox.Password;

            bool success = _loginService.Register(email, password);

            if (success)
                MessageBox.Show("Реєстрація успішна!!))");
            else
                MessageBox.Show("Цей email вже зареєстрований ((");
        }

    

    }
}
