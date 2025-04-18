﻿using TaskMaster.ViewModels;
using Microsoft.Maui.Controls;
using TaskMaster.Services;
using TaskMaster.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskMaster.Views
{
    public partial class Inscription : ContentPage
    {
        public Inscription()
        {
            InitializeComponent();
            var connectionString = "server=localhost;port=3306;database=taskmanager;user=root;password=";
            var options = new DbContextOptionsBuilder<TaskMasterContext>()
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .Options;
            BindingContext = new InscriptionViewModel(new AuthService(new TaskMasterContext(options)));
        }
    }
}