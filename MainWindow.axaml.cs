using Avalonia.Controls;
using AvaloniaApplication1.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AvaloniaApplication1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AuthButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            using var ctx = new DatabaseContext();
            var users = ctx.Users.ToList();
            if (!(string.IsNullOrEmpty(TextBoxLogin.Text)) && !(string.IsNullOrEmpty(TextBoxPassword.Text)))
            {
                foreach (var user in users)
                {
                    if (user.Login == TextBoxLogin.Text && user.Password == TextBoxPassword.Text)
                    {
                        ErrorTextBlock.IsVisible = false;
                        switch (user.RoleId)
                        {
                            case 1:
                                AdminWindow adminWindow = new AdminWindow();
                                adminWindow.ShowDialog(this);
                                return;
                            case 2:
                                UserWindow userWindow = new UserWindow();
                                userWindow.ShowDialog(this);
                                return;
                        }
                    }
                    else
                    {
                        ErrorTextBlock.IsVisible = true;
                        ErrorTextBlock.Text = "Вы ввели неверный логин или пароль. Пожалуйста проверьте ещё раз введенные данные";
                    }
                }
            }
            else
            {
                ErrorTextBlock.IsVisible = true;
                ErrorTextBlock.Text = "Заполните все поля";
            }
        }
    }
}