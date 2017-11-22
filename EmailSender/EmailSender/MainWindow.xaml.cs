using System;
using System.Collections.Generic;
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
using System.Net.Mail;
using System.Net;

namespace EmailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSendMail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(txtBoxFrom.Text);
                mailMessage.To.Add(txtBoxRecipient.Text);
                mailMessage.Subject = txtBoxSubject.Text;
                mailMessage.Body = txtBoxMessage.Text;


                SmtpClient smtp = new SmtpClient("smtp.live.com");
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(txtBoxFrom.Text, passwordBox.Password);
                smtp.Port = 587;
                smtp.Send(mailMessage);

                MessageBox.Show("Mail sendt");
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }
    }
}