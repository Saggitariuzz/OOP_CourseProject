namespace Theatre
{
    internal static class Program
    {
        /// <summary>
        /// Точка входа в приложение.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            using(WelcomeForm form = new WelcomeForm())
            {
                form.ShowDialog();
            }
            Application.Run(new MainForm());
        }
    }
}