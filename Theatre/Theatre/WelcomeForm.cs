namespace Theatre
{
    /// <summary>
    /// Класс, представляющий форму с информацией об авторе приложения.
    /// </summary>
    public partial class WelcomeForm : Form
    {
        /// <summary>
        /// Таймер, отсчитывающий время до закрытия формы.
        /// </summary>
        private System.Windows.Forms.Timer timer;

        /// <summary>
        /// Конструктор формы, инициализирующий компоненты и запускающий таймер.
        /// </summary>
        public WelcomeForm()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 10000;
            timer.Start();
        }

        /// <summary>
        /// Метод, обрабатывающий остановку таймера и закрытие приложения.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void Timer_Tick(object? sender, EventArgs e)
        {
            timer.Stop();
            Close();
        }

        /// <summary>
        /// Метод, обрабатывающий закрытие формы по клику мыши.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void WelcomeForm_MouseDown(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Метод, обрабатывающий закрытие формы по нажатию клавиши на клавиатуре.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void WelcomeForm_KeyDown(object sender, EventArgs e)
        {
            Close();
        }
    }
}
