using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ExamUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page2 : Page
    {
        public Page2()
        {
            this.InitializeComponent();
            GetListFileAsync();
        }

        public async void GetListFileAsync()
        {
            var Files = await ApplicationData.Current.LocalFolder.GetFilesAsync();            
            foreach (var file in Files)
            {
                ListFile.Items.Add(file.Name);                
            }
        }

        private async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine(ListFile.SelectedItem);
            var Files = await ApplicationData.Current.LocalFolder.GetFilesAsync();
            foreach (var file in Files)
            {
                if(file.Name == ListFile.SelectedItem.ToString())
                {
                    FileContent.Text = await Windows.Storage.FileIO.ReadTextAsync(file);
                }
            }
        }
    }
}
