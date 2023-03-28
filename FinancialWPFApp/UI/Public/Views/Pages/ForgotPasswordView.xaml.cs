using FinancialWPFApp.Helpers;
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

namespace FinancialWPFApp.UI.Public.Views.Pages
{
    /// <summary>
    /// Interaction logic for ForgotPasswordView.xaml
    /// </summary>
    public partial class ForgotPasswordView : Page
    {
        public ForgotPasswordView()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            if (ValidationHelper.IsValidEmail(email) == false)
            {
                MessageBox.Show("Please enter correct email, example a@gmail.com");
            } else
            {
                SendMailToClient(email);
                MessageBox.Show("Your password have been sent to your email");
            }
        }
        public void SendMailToClient(string email)
        {
            MailMessage mail = new MailMessage();

            // set the sender address
            mail.From = new MailAddress("nguyenthanhlam1070@gmail.com");

            // set the recipient address
            mail.To.Add(email);

            // set the subject and body of the email
            mail.Subject = "Password Reset Request";
            mail.Body = "Here is your new password: abc123";

            // create an SMTP client and send the email
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");

            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("nguyenthanhlam1070@gmail.com", "@#$Lam808106Lam$#@");
            smtp.EnableSsl = true;


            //smtp.Send(mail);
        }
        private void btnSignin_Click(object sender, RoutedEventArgs e)
        {
            Frame frame = (Frame)Application.Current.MainWindow.FindName("frameContent");
            frame.Navigate(new LoginView());
        }
    }
}
