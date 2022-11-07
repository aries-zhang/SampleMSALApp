using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Broker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            GetAccount("4b0db8c2-9f26-4417-8bde-3f0e3656f8e0");
        }

        async void GetAccount(string clientId)
        {
            IPublicClientApplication client = PublicClientApplicationBuilder
              .Create(clientId)
              .WithAuthority("https://login.microsoftonline.com/consumers")
              .WithBrokerPreview(true)   // this method exists in Microsoft.Identity.Client.Broker package
              .Build();

            IntPtr windowHandle = new System.Windows.Interop.WindowInteropHelper(this).Handle;

            try
            {
                var result = await client.AcquireTokenInteractive(new string[] { "openid",
                "email",
                "profile",
                "offline_access", })
                     .WithParentActivityOrWindow(windowHandle)
                     .WithPrompt(Prompt.NoPrompt)
                     .WithAccount(PublicClientApplication.OperatingSystemAccount)
                     .ExecuteAsync();

                MessageBox.Show(Convert.ToString(result), "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message+ex.StackTrace, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
