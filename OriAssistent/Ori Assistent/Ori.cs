using System;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;
using System.Drawing;

namespace Ori_Assistent
{
    public partial class OriAssistentStartForm : Form
    {
        #region Перменные
        private readonly SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine(new CultureInfo("en-US"));
        private readonly SpeechSynthesizer ori = new SpeechSynthesizer();
        private readonly SpeechRecognitionEngine startlistening = new SpeechRecognitionEngine(new CultureInfo("en-US"));
        private CancellationTokenSource _tokenSource = null;

        public Random rnd = new Random();
        public Commands Commands = new Commands();
        private int RecTimeOut = 0;
        public static bool isCanBeCanseled = false;

        public bool isSwitchOnOriVoice = true;

        // Инкапсуляция
        public Random Rnd { get => rnd; set => rnd = value; }
        public Commands Commands1 { get => Commands; set => Commands = value; }
        #endregion

        /// <summary>
        /// Инициализация формы
        /// </summary>
        public OriAssistentStartForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие при закрытии программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OriAssistentStartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// События при запуске программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OriAssistentStartForm_Load(object sender, EventArgs e)
        {
            // Проверка на язык системы
            CultureInfo cultureInfo = new CultureInfo("en-US");
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName != cultureInfo.TwoLetterISOLanguageName)
            {
                SystemMessageListBox.Items.Add($"For the assistant to work correctly, define the system language as English (en). Current language - {CultureInfo.CurrentCulture}");
            }

            #region Реализация аудиозахвата и аудиовывода
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultCommands.txt")))));
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            _recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(Recognizer_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);

            startlistening.SetInputToDefaultAudioDevice();
            startlistening.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultCommands.txt")))));
            startlistening.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Startlistening_SpeechRecognized);
            #endregion

            // Текущее время суток
            ChangeGreeting();

            // Автозагрузка сохранений
            isAutoRunCheckBox.DataBindings.Add("Checked", Properties.Settings.Default, "IsAutoRun", true, DataSourceUpdateMode.OnPropertyChanged);
            TimerForShotDown.DataBindings.Add("Text", Properties.Settings.Default, "ShotDownTimer", true, DataSourceUpdateMode.OnPropertyChanged);
            HibernateTimer.DataBindings.Add("Text", Properties.Settings.Default, "HibernateStateTimer", true, DataSourceUpdateMode.OnPropertyChanged);

            // Стартовое системное сообщение
            SystemMessageListBox.Items.Add("System: To view all commands, say Ori \"Show commands\"");
        }

        /// <summary>
        /// События по команде
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string socialCommands = e.Result.Text;
            string functionalCommands = e.Result.Text;

            switch (socialCommands)
            {
                case "Hello":
                    ChooseAnswer(e, Commands.command1);
                    break;
                case "How are you":
                    ChooseAnswer(e, Commands.command2);
                    break;
                case "Thank you":
                    ChooseAnswer(e, Commands.command6);
                    break;
            }

            switch (functionalCommands)
            {
                case "What time is it":
                    ChooseAnswer(e, Commands.command3);
                    break;
                case "Stop talking":
                    ori.SpeakAsyncCancelAll();
                    ChooseAnswer(e, Commands.command4);
                    break;
                case "Stop listening":
                    _recognizer.RecognizeAsyncCancel();
                    startlistening.RecognizeAsync(RecognizeMode.Multiple);
                    ChooseAnswer(e, Commands.command5);
                    break;
                case "Show commands":
                    SystemMessageListBox.Items.Add($"You: {socialCommands}");
                    ShowCommands();
                    break;
                case "Hide commands":
                    CommandsList.Visible = false;
                    SystemMessageListBox.Items.Add($"You: {socialCommands}");
                    break;
                case "Shut down the computer":
                    SystemMessageListBox.Items.Add($"You: {socialCommands}");
                    ShutDownTheComputer(e);
                    isCanBeCanseled = true;
                    break;
                case "Cancel":
                    if (isCanBeCanseled)
                    {
                        _tokenSource.Cancel();
                        ChooseAnswer(e, Commands.command7);
                        isCanBeCanseled = false;
                    }
                    else
                    {
                        ChooseAnswer(e, Commands.command8);
                    }
                    break;
                case "Open settings":
                    Label1_Click(sender, e);
                    ChooseAnswer(e, Commands.command10);
                    break;
                case "Close settings":
                    Label1_Click(sender, e);
                    ChooseAnswer(e, Commands.command10);
                    break;
                case "Check start with windows":
                    AutoRunCheckBoxState();
                    ChooseAnswer(e, Commands.command10);
                    break;
                case "Uncheck start with windows":
                    AutoRunUncheckBoxState();
                    ChooseAnswer(e, Commands.command10);
                    break;
                case "Switch off voice":
                    ori.SpeakAsync("Voice off");
                    isSwitchOnOriVoice = false;
                    SystemMessageListBox.Items.Add($"You: {functionalCommands}");
                    break;
                case "Switch on voice":
                    if (isSwitchOnOriVoice == false)
                    {
                        ori.SpeakAsync("Voice on");
                        isSwitchOnOriVoice = true;
                        SystemMessageListBox.Items.Add($"You: {functionalCommands}");
                    }
                    else
                    {
                        ChooseAnswer(e, Commands.command8);
                    }
                    break;
                case "Put the computer to sleep":
                    SystemMessageListBox.Items.Add($"You: {socialCommands}");
                    HibernateState(e);
                    isCanBeCanseled = true;
                    break;
            }
        }

        /// <summary>
        /// Слово - активация ассистента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Startlistening_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            if (speech == "Ori" || speech == "Oi")
            {
                startlistening.RecognizeAsyncCancel();
                ChooseAnswer(e, Commands.command9);
                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
        }

        /// <summary>
        /// Изменение приветствия в зависимости от времени суток
        /// </summary>
        private void ChangeGreeting()
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;

            if (currentTime >= TimeSpan.Parse("12:01") &&
                currentTime <= TimeSpan.Parse("16:00"))
            {
                GreetingsLabel.Text = "Good afternoon";
            }
            else if (currentTime >= TimeSpan.Parse("16:01") &&
                     currentTime <= TimeSpan.Parse("23:00"))
            {
                GreetingsLabel.Text = "Good evening";
            }
            else if (currentTime >= TimeSpan.Parse("23:01") &&
                     currentTime <= TimeSpan.Parse("4:00"))
            {
                GreetingsLabel.Text = "Good night";
            }
            else if (currentTime >= TimeSpan.Parse("4:01") &&
                     currentTime <= TimeSpan.Parse("12:00"))
            {
                GreetingsLabel.Text = "Good mornin";
            }
        }

        /// <summary>
        /// Голосовой ответ ИИ
        /// </summary>
        /// <param name="e"></param>
        /// <param name="index"></param>
        private async void ChooseAnswer(SpeechRecognizedEventArgs e, List<string> index)
        {
            int ranNum;
            string speech = e.Result.Text;

            ranNum = Rnd.Next(index.Count);

            if (isSwitchOnOriVoice)
            {
                ori.SpeakAsync(index[ranNum]);
            }
            SystemMessageListBox.Items.Add($"You: {speech}");

            await Task.Delay(1000);

            if (index[ranNum] != null)
            {
                SystemMessageListBox.Items.Add($"Ori: {index[ranNum]}");
            }
        }

        /// <summary>
        /// Таймер разговора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerSpeaking_Tick(object sender, EventArgs e)
        {
            if (RecTimeOut == 10)
            {
                _recognizer.RecognizeAsyncCancel();
            }
            else if (RecTimeOut == 11)
            {
                TimerSpeaking.Stop();
                startlistening.RecognizeAsync(RecognizeMode.Multiple);
                RecTimeOut = 0;
            }
        }

        /// <summary>
        /// Обновление таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Recognizer_SpeechRecognized(object sender, SpeechDetectedEventArgs e)
        {
            RecTimeOut = 0;
        }

        /// <summary>
        /// Отмена фокуса при клике на форму для любого TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OriAssistentStartForm_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        /// <summary>
        /// Таймер до выключения компьютера
        /// </summary>
        /// <param name="token"></param>
        private void ShutDownTimer(CancellationToken token)
        {
            for (int i = Properties.Settings.Default.ShotDownTimer; i > 0; i--)
            {
                ori.SpeakAsync(i.ToString());

                Thread.Sleep(1000);

                if (token.IsCancellationRequested)
                {
                    break;
                }

                if (i == 1)
                {
                    Process.Start("cmd", "/c shutdown -s -f -t 00");
                }
            }
        }

        /// <summary>
        /// Изменение значения для таймера выключения компьютера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerForShotDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
                Properties.Settings.Default.ShotDownTimer = Convert.ToInt32(TimerForShotDown.Text);
            }
        }

        /// <summary>
        /// Выбор состояния для автозапуска программы с Windows
        /// </summary>
        /// <param name="autorun"></param>
        /// <returns></returns>
        public bool SetAutorunValue(bool autorun)
        {
            const string name = "Ori assistent";
            string ExePath = Application.ExecutablePath;
            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                if (autorun)
                    reg.SetValue(name, ExePath);
                else
                    reg.DeleteValue(name);

                reg.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }


        #region Реализация комманд для ассистента
        /// <summary>
        /// Метод раскрытия списка команд
        /// </summary>
        private void ShowCommands()
        {
            string[] commands = File.ReadAllLines(@"DefaultCommands.txt");
            CommandsList.Items.Clear();
            CommandsList.SelectionMode = SelectionMode.None;
            CommandsList.Visible = true;

            foreach (string command in commands)
            {
                CommandsList.Items.Add(command);
            }

            if (Settings.Visible == true)
            {
                Settings.Visible = false;
            }
        }

        /// <summary>
        /// Голосовое выключение компьютера
        /// </summary>
        /// <param name="e"></param>
        private async void ShutDownTheComputer(SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            _tokenSource = new CancellationTokenSource();
            var token = _tokenSource.Token;

            try
            {
                await Task.Run(() => ShutDownTimer(token));
            }
            catch (OperationCanceledException)
            {
                ChooseAnswer(e, Commands.command8);
            }
            finally
            {
                _tokenSource.Dispose();
            }
        }

        /// <summary>
        /// Включение и выключение Settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label1_Click(object sender, EventArgs e)
        {
            if (Settings.Visible == false)
            {
                Settings.Visible = true;


                if (CommandsList.Visible == true)
                {
                    CommandsList.Visible = false;
                }
            }
            else if (Settings.Visible == true)
            {
                Settings.Visible = false;
            }
        }

        /// <summary>
        /// Голосовая ативация автозапуска програмы с Windows
        /// </summary>
        private void AutoRunCheckBoxState()
        {
            isAutoRunCheckBox.Checked = true;
            SetAutorunValue(true);
            Properties.Settings.Default.IsAutoRun = isAutoRunCheckBox.Checked;
        }

        /// <summary>
        /// Голосовая отмена автозапуска програмы с Windows
        /// </summary>
        private void AutoRunUncheckBoxState()
        {
            isAutoRunCheckBox.Checked = false;
            SetAutorunValue(false);
            Properties.Settings.Default.IsAutoRun = isAutoRunCheckBox.Checked;
        }

        /// <summary>
        /// Ручная активация / деактивация автозапуска программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsAutoRunCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isAutoRunCheckBox.Checked == true)
            {
                SetAutorunValue(true);
                Properties.Settings.Default.IsAutoRun = isAutoRunCheckBox.Checked;
            }
            else
            {
                SetAutorunValue(false);
                Properties.Settings.Default.IsAutoRun = isAutoRunCheckBox.Checked;
            }
        }

        /// <summary>
        /// Голосовая команда перевода компьютера в сон
        /// </summary>
        /// <param name="e"></param>
        private async void HibernateState(SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            _tokenSource = new CancellationTokenSource();
            var token = _tokenSource.Token;

            try
            {
                await Task.Run(() => HibernateStateTimer(token));
            }
            catch (OperationCanceledException)
            {
                ChooseAnswer(e, Commands.command8);
            }
            finally
            {
                _tokenSource.Dispose();
            }
        }

        /// <summary>
        /// Таймер до перевода в сон
        /// </summary>
        /// <param name="token"></param>
        private void HibernateStateTimer(CancellationToken token)
        {
            for (int i = Properties.Settings.Default.HibernateStateTimer; i > 0; i--)
            {
                ori.SpeakAsync(i.ToString());

                Thread.Sleep(1000);

                if (token.IsCancellationRequested)
                {
                    break;
                }

                if (i == 1)
                {
                    bool isHibernate = Application.SetSuspendState(PowerState.Hibernate , false, true);

                    if (isHibernate == false)
                    {
                        SystemMessageListBox.Items.Add("Could not hybernate the system.");
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// Обновляет текущее время
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentDate_Tick(object sender, EventArgs e)
        {
            CurrentDateTime.Text = DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss");
        }

        /// <summary>
        /// Устанавливает цвет Gold при наведении на Settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label1_MouseHover(object sender, EventArgs e)
        {
            SettingsLabelText.ForeColor = Color.Gold;
        }

        /// <summary>
        /// Устанавливает цвет White в качестве Default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsLabelText_MouseLeave(object sender, EventArgs e)
        {
            SettingsLabelText.ForeColor = Color.White;
        }

        #region Перенос слов в ListBox
        private void SystemMessageListBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(SystemMessageListBox.Items[e.Index].ToString(), SystemMessageListBox.Font, SystemMessageListBox.Width).Height;
        }

        private void Lst_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (SystemMessageListBox.Items.Count > 0)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                e.Graphics.DrawString(SystemMessageListBox.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }

        private void SystemMessageListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (SystemMessageListBox.Items.Count > 0)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                e.Graphics.DrawString(SystemMessageListBox.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }
        #endregion
    }
}
