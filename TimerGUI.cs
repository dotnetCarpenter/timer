using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Globalization;
using System.Resources;

namespace WinFormTimer
{
    public partial class frmTimer : Form
    {
//        private static readonly frmTimer m_instance = new frmTimer();

        private ResourceManager resources;
        private Timer timer = new Timer();
        private int minutes;
        private string minutsOrTime;
        /// <summary>
        /// Singleton
        /// </summary>
        /// <returns></returns>
 /*       public static frmTimer GetInstance()
        {
            return m_instance;
        }
        */
        public frmTimer()
        {
            this.resources = new ResourceManager(typeof(frmTimer));
            InitializeComponent();
            // setup notify icon
            timerNotify.Text = this.resources.GetString("notStarted");
            // setup text boks validation
            minutsOrTime = @"(^[1-9]\d*$)|([0-2]\d:[0-5]\d)";
            txtMinuts.Regular_Expression = minutsOrTime;
            errInput.SetIconAlignment(txtMinuts, ErrorIconAlignment.MiddleLeft);
            errInput.SetIconPadding(txtMinuts, 5);
            // setup button
            btnAction.Enabled = false;
            btnAction.Tag = TimerActions.Start;
            // setup progressbar
            prbRemainingTime.Step = 1;
            // setup timer
            timer.Interval = 1000 * 60;
            timer.Tick += new EventHandler(delegate(object sender, EventArgs e) {
                if (minutes == 0)
                {
                    if (rdoHibernate.Checked)
                    {
#if DEBUG
                        Debug.WriteLine("Hibernate");
#else
                        Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\shutdown.exe", "-h");
                        Application.Exit();
#endif
                    }
                    if (rdoShutDown.Checked)
                    {
#if DEBUG
                        Debug.WriteLine("ShutDown");
#else
                        Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\shutdown.exe", "-s -f");
#endif
                    }
                    btnAction.Text = this.resources.GetString("btnAction.Cancel");
                    btnAction.Tag = TimerActions.Cancel;
                }
                else
                {
                    prbRemainingTime.PerformStep();
                    updateText();
                    minutes--;
                    if (minutes == 0)
                    {
                        // warn the user that windows is closing...
                        updateText();
                    }
                }
            });
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            switch ((TimerActions)btnAction.Tag){
                case TimerActions.Start :
                    if(Regex.Matches(txtMinuts.Text, minutsOrTime)[0].Groups[1].Success){
                        minutes = Convert.ToInt32(txtMinuts.Text);
                    } else {
                        if((DateTime.ParseExact(txtMinuts.Text, "t", null) - DateTime.Now).Minutes <= 0){
                            minutes = (int)(DateTime.ParseExact(txtMinuts.Text, "t", null).AddDays(1) - DateTime.Now).TotalMinutes;
                        } else {
                            minutes = (int)(DateTime.ParseExact(txtMinuts.Text, "t", null) - DateTime.Now).TotalMinutes;
                        }
                    }
                    timer.Start();

                    btnAction.Text = this.resources.GetString("btnAction.Stop");
                    btnAction.Tag = TimerActions.Stop;
                    btnAction.Focus();
                    updateText();
                    txtMinuts.ReadOnly = true;

                    /* setup progressbar */
                    prbRemainingTime.Maximum = minutes;
                    prbRemainingTime.Value = 0;
                    break;
                case TimerActions.Stop :
                    timer.Stop();
                    btnAction.Text = this.resources.GetString("btnAction.Text");
                    btnAction.Tag = TimerActions.Start;
                    updateText();
                    txtMinuts.ReadOnly = false;
                    break;
                case TimerActions.Cancel :
                    Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\shutdown.exe", "-a");
                    btnAction.Tag = TimerActions.Stop;
                    btnAction_Click(sender, e);
                    break;
            }
        }        

        private void updateText()
        {
            string text = timer.Enabled
                ? (minutes == 1 ? this.resources.GetString("minute") : minutes + this.resources.GetString("minutes"))
                : this.resources.GetString("lblText.Text");
            lblText.Text = text;
            timerNotify.Text = text;
            if (this.WindowState == FormWindowState.Minimized && (timerNotify.Text.Length + this.resources.GetString("hiddenHint").Length + 1) < 64 /* the text in the notification area can not exceed 64 chars */)
            {
                timerNotify.Text += Environment.NewLine + this.resources.GetString("hiddenHint");
            }
        }

        private void txtMinuts_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMinuts.ValidateControl())
            {
                btnAction.Enabled = true;
                errInput.SetError(txtMinuts, string.Empty);
            }
            else
            {
                btnAction.Enabled = false;
                errInput.SetError(txtMinuts, this.resources.GetString("inputFormat"));
                return;
            }
            if (e.KeyCode == Keys.Enter) { btnAction_Click(sender, e); }
        }

        private void timerNotify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void frmTimer_Resize(object sender, EventArgs e)
        {
            updateText();
        }
    }
}