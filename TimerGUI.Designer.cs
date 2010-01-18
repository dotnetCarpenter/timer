namespace WinFormTimer
{
    partial class frmTimer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimer));
            this.prbRemainingTime = new System.Windows.Forms.ProgressBar();
            this.btnAction = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            this.rdoHibernate = new System.Windows.Forms.RadioButton();
            this.rdoShutDown = new System.Windows.Forms.RadioButton();
            this.txtMinuts = new RegExControls.RegExTextBox();
            this.errInput = new System.Windows.Forms.ErrorProvider(this.components);
            this.timerNotify = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errInput)).BeginInit();
            this.SuspendLayout();
            // 
            // prbRemainingTime
            // 
            resources.ApplyResources(this.prbRemainingTime, "prbRemainingTime");
            this.prbRemainingTime.Name = "prbRemainingTime";
            // 
            // btnAction
            // 
            resources.ApplyResources(this.btnAction, "btnAction");
            this.btnAction.Name = "btnAction";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // lblText
            // 
            resources.ApplyResources(this.lblText, "lblText");
            this.lblText.Name = "lblText";
            // 
            // rdoHibernate
            // 
            resources.ApplyResources(this.rdoHibernate, "rdoHibernate");
            this.rdoHibernate.Checked = true;
            this.rdoHibernate.Name = "rdoHibernate";
            this.rdoHibernate.TabStop = true;
            this.rdoHibernate.UseVisualStyleBackColor = true;
            // 
            // rdoShutDown
            // 
            resources.ApplyResources(this.rdoShutDown, "rdoShutDown");
            this.rdoShutDown.Name = "rdoShutDown";
            this.rdoShutDown.TabStop = true;
            this.rdoShutDown.UseVisualStyleBackColor = true;
            // 
            // txtMinuts
            // 
            resources.ApplyResources(this.txtMinuts, "txtMinuts");
            this.txtMinuts.Name = "txtMinuts";
            this.txtMinuts.Regular_Expression = null;
            this.txtMinuts.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMinuts_KeyUp);
            // 
            // errInput
            // 
            this.errInput.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errInput.ContainerControl = this;
            // 
            // timerNotify
            // 
            resources.ApplyResources(this.timerNotify, "timerNotify");
            this.timerNotify.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.timerNotify_MouseDoubleClick);
            // 
            // frmTimer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtMinuts);
            this.Controls.Add(this.rdoShutDown);
            this.Controls.Add(this.rdoHibernate);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.prbRemainingTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmTimer";
            this.Resize += new System.EventHandler(this.frmTimer_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.errInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prbRemainingTime;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.RadioButton rdoHibernate;
        private System.Windows.Forms.RadioButton rdoShutDown;
        private RegExControls.RegExTextBox txtMinuts;
        private System.Windows.Forms.ErrorProvider errInput;
        private System.Windows.Forms.NotifyIcon timerNotify;
    }
}

