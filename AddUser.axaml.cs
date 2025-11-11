using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.Models;
using System.Linq;

namespace AvaloniaApplication1;

public partial class AddUser : Window
{
    public AddUser()
    {
        InitializeComponent();
    }

    private void AddButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (!(string.IsNullOrEmpty(TextBoxLogin.Text)) && !(string.IsNullOrEmpty(TextBoxPassword.Text)))
        {
            using var ctx = new DatabaseContext();
            var user = ctx.Users.Where(x => x.Login == TextBoxLogin.Text).FirstOrDefault();
            if (user != null)
            {
                ErrorTextBlock.IsVisible = true;
                ErrorTextBlock.Text = "Пользователь с таким логином уже существует";
                return;
            }
            User newUser = new User()
            {
                Login = TextBoxLogin.Text,
                Password = TextBoxPassword.Text,
                RoleId = 2
            };
            ctx.Users.Add(newUser);
            ctx.SaveChanges();
            ErrorTextBlock.IsVisible = false;
            Close();
        } else
        {
            ErrorTextBlock.IsVisible = true;
            ErrorTextBlock.Text = "Заполните все поля";
        }
    }
}