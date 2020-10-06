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

namespace WPFBrowserClient.View.UserControls
{
    public delegate void AnswereIsReady(bool answer);
    /// <summary>
    /// Interaction logic for QuestionDialog.xaml
    /// </summary>
    public partial class QuestionDialog : UserControl
    {
        public event AnswereIsReady AnswereIsReadyEvent;
        public QuestionDialog(string question, AnswereIsReady answereIsReadyHandler)
        {
            Question = question;
            InitializeComponent();
            AnswereIsReadyEvent += answereIsReadyHandler;
            this.DataContext = this;
        }

        public string Question { get; set; }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnswereIsReadyEvent != null)
            {
                AnswereIsReadyEvent(true);
            }
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnswereIsReadyEvent != null)
            {
                AnswereIsReadyEvent(false);
            }
        }
    }
}
