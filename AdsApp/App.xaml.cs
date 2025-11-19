using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AdsApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    // App.xaml.cs
    public partial class App : Application
    {
        public static Users CurrentUser { get; set; } // User — твоя сущность из БД
    }
}
