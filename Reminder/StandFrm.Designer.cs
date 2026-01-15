namespace Reminder
{
    partial class StandFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StandFrm));
            timerWrk = new System.Windows.Forms.Timer(components);
            lblSecond = new Label();
            lblMin = new Label();
            label2 = new Label();
            label3 = new Label();
            lblWarn = new Label();
            SuspendLayout();
            // 
            // timerWrk
            // 
            timerWrk.Enabled = true;
            timerWrk.Interval = 1000;
            timerWrk.Tick += Timer1_Tick;
            // 
            // lblSecond
            // 
            lblSecond.AutoSize = true;
            lblSecond.BackColor = Color.Transparent;
            lblSecond.Cursor = Cursors.SizeAll;
            lblSecond.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSecond.ForeColor = Color.White;
            lblSecond.Location = new Point(94, 33);
            lblSecond.Name = "lblSecond";
            lblSecond.Size = new Size(27, 19);
            lblSecond.TabIndex = 4;
            lblSecond.Text = "  ";
            lblSecond.Click += LblSecond_Click;
            lblSecond.MouseDown += WorkFrm_MouseDown;
            lblSecond.MouseMove += WorkFrm_MouseMove;
            lblSecond.MouseUp += WorkFrm_MouseUp;
            // 
            // lblMin
            // 
            lblMin.AutoSize = true;
            lblMin.BackColor = Color.Transparent;
            lblMin.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMin.ForeColor = Color.White;
            lblMin.Location = new Point(55, 33);
            lblMin.Name = "lblMin";
            lblMin.Size = new Size(27, 19);
            lblMin.TabIndex = 5;
            lblMin.Text = "  ";
            lblMin.MouseDown += WorkFrm_MouseDown;
            lblMin.MouseMove += WorkFrm_MouseMove;
            lblMin.MouseUp += WorkFrm_MouseUp;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Cursor = Cursors.SizeAll;
            label2.Font = new Font("宋体", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label2.ForeColor = Color.White;
            label2.Location = new Point(80, 35);
            label2.Name = "label2";
            label2.Size = new Size(15, 14);
            label2.TabIndex = 6;
            label2.Text = ":";
            label2.MouseDown += WorkFrm_MouseDown;
            label2.MouseMove += WorkFrm_MouseMove;
            label2.MouseUp += WorkFrm_MouseUp;
            // 
            // label3
            // 
            label3.Cursor = Cursors.SizeAll;
            label3.Image = (Image)resources.GetObject("label3.Image");
            label3.Location = new Point(4, 9);
            label3.Name = "label3";
            label3.Size = new Size(33, 37);
            label3.TabIndex = 8;
            label3.MouseDown += WorkFrm_MouseDown;
            label3.MouseMove += WorkFrm_MouseMove;
            label3.MouseUp += WorkFrm_MouseUp;
            // 
            // lblWarn
            // 
            lblWarn.AutoSize = true;
            lblWarn.Cursor = Cursors.SizeAll;
            lblWarn.Font = new Font("楷体", 15F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblWarn.ForeColor = Color.White;
            lblWarn.Location = new Point(33, 8);
            lblWarn.Name = "lblWarn";
            lblWarn.Size = new Size(93, 20);
            lblWarn.TabIndex = 7;
            lblWarn.Text = "站立办公";
            lblWarn.Click += Label1_Click;
            lblWarn.MouseDown += WorkFrm_MouseDown;
            lblWarn.MouseMove += WorkFrm_MouseMove;
            lblWarn.MouseUp += WorkFrm_MouseUp;
            // 
            // StandFrm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.DodgerBlue;
            ClientSize = new Size(148, 55);
            Controls.Add(label3);
            Controls.Add(lblWarn);
            Controls.Add(label2);
            Controls.Add(lblMin);
            Controls.Add(lblSecond);
            Cursor = Cursors.SizeAll;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "StandFrm";
            Opacity = 0.85D;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "standFrm";
            TopMost = true;
            FormClosing += MainFrm_FormClosing;
            Load += Form1_Load;
            MouseDown += WorkFrm_MouseDown;
            MouseMove += WorkFrm_MouseMove;
            MouseUp += WorkFrm_MouseUp;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerWrk;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblWarn;
    }
}