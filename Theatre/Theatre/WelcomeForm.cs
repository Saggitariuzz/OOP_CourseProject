namespace Theatre
{
    public partial class WelcomeForm : Form
    {

        private System.Windows.Forms.Timer timer;

        public WelcomeForm()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 10000;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            timer.Stop();
            Close();
        }

        private void WelcomeForm_MouseDown(object sender, EventArgs e)
        {
            Close();
        }

        private void WelcomeForm_KeyDown(object sender, EventArgs e)
        {
            Close();
        }
    }
}
