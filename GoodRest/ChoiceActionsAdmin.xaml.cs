﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoodRest
{
    /// <summary>
    /// Логика взаимодействия для ChoiceActionsAdmin.xaml
    /// </summary>
    public partial class ChoiceActionsAdmin : Page
    {
        public ChoiceActionsAdmin()
        {
            InitializeComponent();
        }

        private void Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
        /// <summary>
        /// Кнопка "добавить данные"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new ChangeAdmin().Show();
            Helper.CloseWindow(Window.GetWindow(this));
        }
        /// <summary>
        /// Кнопка просмотра туров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Tours().Show();
            Helper.CloseWindow(Window.GetWindow(this)); 
        }
    }
}
