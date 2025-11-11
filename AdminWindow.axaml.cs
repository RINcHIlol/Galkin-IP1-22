using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaApplication1;

public partial class AdminWindow : Window
{
    public AdminWindow()
    {
        InitializeComponent();
    }

    private void AddButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        AddUser addUser = new AddUser();
        addUser.ShowDialog(this);
    }

    private void EditButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        AllUsesr allUsesr = new AllUsesr();
        allUsesr.ShowDialog(this);
    }

    private void LogoutButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }
}