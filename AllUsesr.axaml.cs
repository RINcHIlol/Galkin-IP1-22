using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AvaloniaApplication1;

public partial class AllUsesr : Window
{
    public List<User> dataSourceUsers = new List<User>();
    public ObservableCollection<User> users = new ObservableCollection<User>();
    public AllUsesr()
    {
        InitializeComponent();
        using var ctx = new DatabaseContext();
        dataSourceUsers = ctx.Users.Where(x => x.RoleId == 2).ToList();
        ListBoxUsers.ItemsSource = users;
        Display();
    }

    public void Display()
    {
        var temp = dataSourceUsers;
        users.Clear();
        foreach(User t in temp)
        {
            users.Add(t);
        }
    }

    private void BackButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }

    private void EditButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }
}