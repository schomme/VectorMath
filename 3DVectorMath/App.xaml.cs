using System.Windows;
using System.Windows.Input;

namespace _3DVectorMath
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Constants.NumberValidationRegex.IsMatch(e.Text);
        }
    }
}
