using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WindowsFormsMyServiceClient
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
       MyServiceClientNamespace.MyServiceDllClient myproxy;
       SolidColorBrush RedBrush = new SolidColorBrush();
       SolidColorBrush BlackBrush = new SolidColorBrush();
        
        public Window1()
        {
            InitializeComponent();
            RedBrush.Color = Colors.Red;
            BlackBrush.Color = Colors.Black;
            
            //how do you get the info about the client?
            //ServiceEndpoint endpointInfo=
            //txtBoxInfo.Text=endpointInfo.Address.ToString();
        }

        private void btnInvoke_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxSend.Text==string.Empty)
            {
                MessageBox.Show("Enter something on the 'Text to send' box", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                try
                {
                    txtBoxTest.Text += myproxy.MessageBack(txtBoxSend.Text);
                }
                catch (Exception ex)
                {

                    string s = string.Format("\nTransmission failed!\n{0}", ex.Message);
                    txtBoxInfo.Text += s;
                    //MessageBox.Show(s, "Error", MessageBoxButton.OK);
                    btnConnect.IsEnabled = true;
                }
                
                //txtBlockTest.Text = myproxy.MessageBack(txtBoxSend.Text);
                //lblResponse.Content=myproxy.MessageBack(txtBoxSend.Text);
            }

        }
        
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (myproxy!=null)
            {
                if (myproxy.State == CommunicationState.Faulted)
                {
                    myproxy.Abort();
                }
                else
                {
                    myproxy.Close();
                }
            } 

        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnInvoke.IsEnabled = false;
                txtBoxInfo.Text = "Proxy creation...";
                myproxy = new WindowsFormsMyServiceClient.MyServiceClientNamespace.MyServiceDllClient();
                txtBoxInfo.Text += ".success!";
                btnInvoke.IsEnabled = true;
                btnConnect.IsEnabled = false;
            }
            catch (Exception ex)
            {
                string s = string.Format(".failed.\n{0}", ex.Message);
                txtBoxInfo.Foreground = RedBrush;
                txtBoxInfo.Text += s;
                txtBoxInfo.Foreground = BlackBrush;
                //string s = string.Format("Error inizialiting the proxy: {0}", ex.Message);
                //MessageBox.Show(s,"Error",MessageBoxButton.OK);
                btnConnect.IsEnabled = true;
            } 

        }

    }
}
