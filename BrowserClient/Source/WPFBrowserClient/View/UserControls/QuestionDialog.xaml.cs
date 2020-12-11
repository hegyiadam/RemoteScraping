using System.Windows;
using System.Windows.Controls;

namespace WPFBrowserClient.View.UserControls
{
    public delegate void AnswereIsReady(bool answer);

    /// <summary>
    /// Interaction logic for QuestionDialog.xaml
    /// </summary>
    public partial class QuestionDialog : UserControl
    {
        public QuestionDialog(string question, AnswereIsReady answereIsReadyHandler)
        {
            Question = question;
            InitializeComponent();
            AnswereIsReadyEvent += answereIsReadyHandler;
            this.DataContext = this;
        }

        public event AnswereIsReady AnswereIsReadyEvent;

        public string Question { get; set; }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnswereIsReadyEvent != null)
            {
                AnswereIsReadyEvent(false);
            }
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnswereIsReadyEvent != null)
            {
                AnswereIsReadyEvent(true);
            }
        }
    }
}