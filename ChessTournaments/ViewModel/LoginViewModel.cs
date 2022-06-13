﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using ChessTournaments.Model;

namespace ChessTournaments.ViewModel
{
    using View;
    using BaseClasses;
    class LoginViewModel:ViewModelBase
    {
        private ICommand goToRegisterScreen;
        public ICommand GoToRegisterScreenEvent => goToRegisterScreen ?? (goToRegisterScreen =
            new RelayCommand(
                o =>
                {
                    RegisterScreen registerScreen = new RegisterScreen();                    
                    LoginScreen loginScreen = o as LoginScreen;
                    registerScreen.Show();
                    loginScreen.Close();

                },
                null));

    }
}