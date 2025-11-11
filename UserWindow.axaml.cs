using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AvaloniaApplication1;

public partial class UserWindow : Window
{
    public UserWindow()
    {
        InitializeComponent();
        using var ctx = new DatabaseContext();
        var products = ctx.Products.Include(x => x.Manufacturer).ToList();
        ListBoxProducts.ItemsSource = products;
    }

    private void LogoutButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }

    private void AddProductButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }

    private void RemoveProductButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }

    private void BuyButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }
}