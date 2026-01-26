using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reminder
{
    public partial class WorkFrm : Form
    {
        private int wrk_minutes;//工作时间(分)
        private int wrk_seconds;//工作时间(秒)
        private int wrk_m;
        private int rst_seconds;//休息时间(秒)
        private int stand_minutes;//站立办公时间(分)
        private bool input_flag;//是否选中锁定键盘
        private bool strong_reminder_flag;//是否启用强提醒
        private bool left_flag;//鼠标左键是否点击
        private bool allow_move = true;//是否允许移动窗体
        private Point mouseoff;
        private System.Windows.Forms.Timer blinkTimer;//闪烁计时器
        private System.Windows.Forms.Timer shakeTimer;//抖动计时器
        private System.Windows.Forms.Timer colorTimer;//颜色变换计时器
        private int center_x;//窗体中心X坐标
        private int center_y;//窗体中心Y坐标
        private Random rand = new Random();
        private Color[] reminderColors = new Color[]
        {
            Color.Orange, Color.Brown,
            Color.Green, Color.Blue, Color.Indigo, Color.Violet,
            Color.Pink, Color.Cyan, Color.Magenta
        };
        public WorkFrm()
        {
            InitializeComponent();
        }
        //定义一个构造函数，接受前一个窗体传来的参数
        public WorkFrm(int wrk_minutes, int rst_seconds, int stand_minutes, bool input_flag, bool strong_reminder_flag)
        {
            InitializeComponent();
            this.wrk_minutes = wrk_minutes;
            this.rst_seconds = rst_seconds;
            this.stand_minutes = stand_minutes;
            this.wrk_m = wrk_minutes;
            this.input_flag = input_flag;
            this.strong_reminder_flag = strong_reminder_flag;

            center_x = (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Width) / 2 - this.Width / 2;
            center_y = (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Height) / 2 - this.Height / 2;

            // 初始化强提醒Timer
            blinkTimer = new System.Windows.Forms.Timer();
            blinkTimer.Interval = 150; // 150ms闪烁一次
            blinkTimer.Tick += BlinkTimer_Tick;

            shakeTimer = new System.Windows.Forms.Timer();
            shakeTimer.Interval = 30; // 30ms抖动一次
            shakeTimer.Tick += ShakeTimer_Tick;

            colorTimer = new System.Windows.Forms.Timer();
            colorTimer.Interval = 200; // 200ms变换一次颜色
            colorTimer.Tick += ColorTimer_Tick;

            int x = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Width - 148;
            int y = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Height - 56;
            Point p = new Point(x, y);
            this.Location = p;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //任务栏高度
            //Size OutTaskBarSize = new Size(SystemInformation.WorkingArea.Width, SystemInformation.WorkingArea.Height);
            //Size ScreenSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            //this.Height = ScreenSize.Height - OutTaskBarSize.Height;
            //Size TaskBarSize;

            //TaskBarSize = new Size(
            //                (ScreenSize.Width - (ScreenSize.Width - OutTaskBarSize.Width)),
            //                (ScreenSize.Height - OutTaskBarSize.Height)
            //               );


            wrk_seconds = 0;

            if (wrk_seconds >= 10)
            {
                lblSecond.Text = wrk_seconds.ToString();
            }
            else
            {
                lblSecond.Text = "0" + wrk_seconds.ToString();
            }

            if (wrk_minutes>=10) {
                lblMin.Text = wrk_minutes.ToString();
            }
            else
            {
                lblMin.Text = "0"+wrk_minutes.ToString();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timing();
        }

        /// <summary>
        /// 递归的方式倒计时
        /// </summary>
        public  void timing()
        {
            Warn();

            if (wrk_seconds > 0)
            {
                wrk_seconds = wrk_seconds - 1;
                if (wrk_seconds >= 10)
                {
                    lblSecond.Text = wrk_seconds.ToString();
                }
                else
                {
                    lblSecond.Text = "0"+wrk_seconds.ToString();
                }

            }
            else //秒=0时，分钟-1
            {
                timerWrk.Enabled = false;
                wrk_minutes--;
                if (wrk_minutes >= 10)
                {
                    lblMin.Text = wrk_minutes.ToString();
                }
                else
                {
                    lblMin.Text = "0"+wrk_minutes.ToString();
                }

                if (wrk_minutes > -1) //若分钟不为0，秒回到60，继续递归
                {
                    timerWrk.Enabled = true;
                    wrk_seconds = 60;

                    timing();
                }
                else
                {
                    this.Close();
                    RestFrm restFrm = new RestFrm(rst_seconds, wrk_m, stand_minutes, input_flag, strong_reminder_flag);
                    restFrm.ShowDialog();
                }
            }
        }

        /// <summary>
        /// 工作的最后15秒提醒
        /// </summary>
        private void Warn()
        {
            if (wrk_minutes == 0 && wrk_seconds <= 16)
            {
                if (wrk_seconds == 16) {
                    this.BackColor = Color.Red;
                    lblWarn.ForeColor = Color.Yellow;
                    lblWarn.Text = "该休息了！";
                    Point p = new Point(center_x, center_y);
                    this.Location = p;
                    allow_move = false;
                }

                // 强提醒
                if (strong_reminder_flag)
                {
                    // 结束前15秒：闪烁
                    if (!blinkTimer.Enabled && wrk_seconds == 16)
                    {
                        blinkTimer.Start();
                    }
                    if (wrk_seconds == 6)
                    {
                        // 停止闪烁
                        blinkTimer.Stop();
                        // 确保文字可见
                        lblWarn.Visible = true;
                        int flag = rand.Next(2);
                        // 结束前5秒：抖动或变换颜色
                        if (flag == 0 && !shakeTimer.Enabled)
                        {
                            shakeTimer.Start();
                        }
                        else if (flag == 1 && !colorTimer.Enabled)
                        {
                            colorTimer.Start();
                        }
                    }
                    // 最后0秒停止强提醒
                    if (wrk_seconds == 0)
                    {
                        blinkTimer.Stop();
                        shakeTimer.Stop();
                        colorTimer.Stop();
                        // 确保文字可见
                        lblWarn.Visible = true;
                        this.BackColor = Color.Red;
                    }
                }
            }
        }

        /// <summary>
        /// 让程序不显示在alt+Tab视图窗体中
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_APPWINDOW = 0x40000;
                const int WS_EX_TOOLWINDOW = 0x80;
                CreateParams cp = base.CreateParams;
                cp.ExStyle &= (~WS_EX_APPWINDOW);    // 不显示在TaskBar
                cp.ExStyle |= WS_EX_TOOLWINDOW;      // 不显示在Alt+Tab
                return cp;
            }
        }



        private void WorkFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 停止所有Timer以防止访问已释放的对象
            blinkTimer.Stop();
            shakeTimer.Stop();
            colorTimer.Stop();
        }

        private void LblSecond_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
        private void mouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseoff = new Point(e.X, e.Y);
                left_flag = true;
            }
        }
        private void mouseMove()
        {
            if (left_flag && allow_move)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(-mouseoff.X, -mouseoff.Y);//这里注意下-的用意，offset
                Location = mouseSet;
            }
        }
        private void mouseUp()
        {
            if (left_flag)
            {
                left_flag = false;
            }
        }
        private void WorkFrm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown(e);
        }

        private void WorkFrm_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove();
        }

        private void WorkFrm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseUp();
        }



        private void LblWarn_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void LblWarn_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void LblWarn_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            // 检查窗体是否已经被释放
            if (this.IsDisposed || !this.IsHandleCreated)
            {
                blinkTimer.Stop();
                return;
            }
            // 切换可见状态
            lblWarn.Visible = !lblWarn.Visible;
        }

        private void ColorTimer_Tick(object sender, EventArgs e)
        {
            // 检查窗体是否已经被释放
            if (this.IsDisposed || !this.IsHandleCreated)
            {
                colorTimer.Stop();
                return;
            }
            // 随机变换背景颜色
            this.BackColor = reminderColors[rand.Next(reminderColors.Length)];
        }

        private void ShakeTimer_Tick(object sender, EventArgs e)
        {
            // 检查窗体是否已经被释放
            if (this.IsDisposed || !this.IsHandleCreated)
            {
                shakeTimer.Stop();
                return;
            }

            // 抖动逻辑
            int offset = 1;
            if (this.Location.X == center_x && this.Location.Y == center_y)
            {
                this.Location = new Point(center_x + offset, center_y - offset);
            }
            else if (this.Location.X == center_x + offset && this.Location.Y == center_y - offset)
            {
                this.Location = new Point(center_x - offset, center_y - offset);
            }
            else if (this.Location.X == center_x - offset && this.Location.Y == center_y - offset)
            {
                this.Location = new Point(center_x + offset, center_y + offset);
            }
            else if (this.Location.X == center_x + offset && this.Location.Y == center_y + offset)
            {
                this.Location = new Point(center_x - offset, center_y + offset);
            }
            else if (this.Location.X == center_x - offset && this.Location.Y == center_y + offset)
            {
                this.Location = new Point(center_x + offset, center_y - offset);
            }
        }
    }
}
