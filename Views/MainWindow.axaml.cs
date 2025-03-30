using System.Linq;
using Avalonia.Controls;

namespace RssReader.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        // too
        var initialButton = (from ctrl 
                            in this.GetControl<StackPanel>("ButtonPanel").Children
                            where (ctrl is Button && (ctrl as Button).Content.Equals("Channels"))
                            select ctrl).First();
        
        initialButton.Classes.Add("Active");
    }

    // Maybe not the most efficient way to do it, but it obeys MVVM
    private void Button_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var activeButtons = from ctrl 
            in this.GetControl<StackPanel>("ButtonPanel").Children
            where (ctrl is Button && ctrl.Classes.Contains("Active"))
            select ctrl;

        foreach (var button in activeButtons)
            button.Classes.Remove("Active");
        
        (sender as Button)!.Classes.Add("Active");
    }
}