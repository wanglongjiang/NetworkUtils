
using System.ComponentModel;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;
using System.Text.RegularExpressions;

namespace NetworkUtils
{
    partial class NetworkUtils
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPagePing = new TabPage();
            panel2 = new Panel();
            richTextBoxPingOut = new RichTextBox();
            panel1 = new Panel();
            buttonPingInShell = new Button();
            textBoxPingAddr = new TextBox();
            checkBoxPingNums = new CheckBox();
            buttonPing = new Button();
            tabPageDatabase = new TabPage();
            panel5 = new Panel();
            richTextBoxDbOut = new RichTextBox();
            panel4 = new Panel();
            buttonTelnetOnShell = new Button();
            label1 = new Label();
            textBoxDBPort = new TextBox();
            groupBoxDBType = new GroupBox();
            rbSSH = new RadioButton();
            rbWeb = new RadioButton();
            rbRedis = new RadioButton();
            rbOther = new RadioButton();
            rbSqlserver = new RadioButton();
            rbOracle = new RadioButton();
            rbMysql = new RadioButton();
            buttonDBTelnet = new Button();
            textBoxDBAddr = new TextBox();
            tabPageTraceroute = new TabPage();
            panel6 = new Panel();
            richTextBoxTracerouteOut = new RichTextBox();
            panel3 = new Panel();
            buttonTraceroute = new Button();
            textBoxTracerouteAddr = new TextBox();
            menuStrip1 = new MenuStrip();
            FileToolStripMenuItem = new ToolStripMenuItem();
            StopToolStripMenuItem = new ToolStripMenuItem();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            HelpToolStripMenuItem = new ToolStripMenuItem();
            AboutToolStripMenuItem = new ToolStripMenuItem();
            panelStatus = new Panel();
            labelStatus = new Label();
            tabControl1.SuspendLayout();
            tabPagePing.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            tabPageDatabase.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            groupBoxDBType.SuspendLayout();
            tabPageTraceroute.SuspendLayout();
            panel6.SuspendLayout();
            panel3.SuspendLayout();
            menuStrip1.SuspendLayout();
            panelStatus.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPagePing);
            tabControl1.Controls.Add(tabPageDatabase);
            tabControl1.Controls.Add(tabPageTraceroute);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 25);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1008, 536);
            tabControl1.TabIndex = 0;
            // 
            // tabPagePing
            // 
            tabPagePing.Controls.Add(panel2);
            tabPagePing.Controls.Add(panel1);
            tabPagePing.Location = new Point(4, 26);
            tabPagePing.Name = "tabPagePing";
            tabPagePing.Padding = new Padding(3);
            tabPagePing.Size = new Size(1000, 506);
            tabPagePing.TabIndex = 0;
            tabPagePing.Text = "Ping";
            tabPagePing.UseVisualStyleBackColor = true;
            tabPagePing.Enter += tabPagePing_Enter;
            // 
            // panel2
            // 
            panel2.Controls.Add(richTextBoxPingOut);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 50);
            panel2.Name = "panel2";
            panel2.Size = new Size(994, 453);
            panel2.TabIndex = 5;
            // 
            // richTextBoxPingOut
            // 
            richTextBoxPingOut.BackColor = Color.Black;
            richTextBoxPingOut.Dock = DockStyle.Fill;
            richTextBoxPingOut.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            richTextBoxPingOut.ForeColor = Color.White;
            richTextBoxPingOut.Location = new Point(0, 0);
            richTextBoxPingOut.Name = "richTextBoxPingOut";
            richTextBoxPingOut.ReadOnly = true;
            richTextBoxPingOut.Size = new Size(994, 453);
            richTextBoxPingOut.TabIndex = 4;
            richTextBoxPingOut.Text = "";
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonPingInShell);
            panel1.Controls.Add(textBoxPingAddr);
            panel1.Controls.Add(checkBoxPingNums);
            panel1.Controls.Add(buttonPing);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(994, 47);
            panel1.TabIndex = 4;
            // 
            // buttonPingInShell
            // 
            buttonPingInShell.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            buttonPingInShell.Location = new Point(587, 4);
            buttonPingInShell.Name = "buttonPingInShell";
            buttonPingInShell.Size = new Size(118, 34);
            buttonPingInShell.TabIndex = 4;
            buttonPingInShell.Text = "系统Ping";
            buttonPingInShell.UseVisualStyleBackColor = true;
            buttonPingInShell.Click += buttonPingInShell_Click;
            // 
            // textBoxPingAddr
            // 
            textBoxPingAddr.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            textBoxPingAddr.Location = new Point(3, 6);
            textBoxPingAddr.Name = "textBoxPingAddr";
            textBoxPingAddr.Size = new Size(359, 32);
            textBoxPingAddr.TabIndex = 0;
            textBoxPingAddr.Text = "www.baidu.com";
            textBoxPingAddr.Enter += textBoxPingAddr_Enter;
            textBoxPingAddr.KeyUp += textBoxPingAddr_KeyUp;
            // 
            // checkBoxPingNums
            // 
            checkBoxPingNums.AutoSize = true;
            checkBoxPingNums.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            checkBoxPingNums.Location = new Point(471, 7);
            checkBoxPingNums.Name = "checkBoxPingNums";
            checkBoxPingNums.Size = new Size(110, 29);
            checkBoxPingNums.TabIndex = 3;
            checkBoxPingNums.Text = "无限Ping";
            checkBoxPingNums.UseVisualStyleBackColor = true;
            checkBoxPingNums.CheckedChanged += checkBoxPingNums_CheckedChanged;
            // 
            // buttonPing
            // 
            buttonPing.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            buttonPing.Location = new Point(368, 3);
            buttonPing.Name = "buttonPing";
            buttonPing.Size = new Size(97, 34);
            buttonPing.TabIndex = 1;
            buttonPing.Text = "Ping";
            buttonPing.UseVisualStyleBackColor = true;
            buttonPing.Click += buttonPing_Click;
            // 
            // tabPageDatabase
            // 
            tabPageDatabase.Controls.Add(panel5);
            tabPageDatabase.Controls.Add(panel4);
            tabPageDatabase.Location = new Point(4, 26);
            tabPageDatabase.Name = "tabPageDatabase";
            tabPageDatabase.Padding = new Padding(3);
            tabPageDatabase.Size = new Size(1000, 506);
            tabPageDatabase.TabIndex = 1;
            tabPageDatabase.Text = "端口连接";
            tabPageDatabase.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.Controls.Add(richTextBoxDbOut);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 111);
            panel5.Name = "panel5";
            panel5.Size = new Size(994, 392);
            panel5.TabIndex = 1;
            // 
            // richTextBoxDbOut
            // 
            richTextBoxDbOut.BackColor = Color.Black;
            richTextBoxDbOut.Dock = DockStyle.Fill;
            richTextBoxDbOut.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            richTextBoxDbOut.ForeColor = Color.White;
            richTextBoxDbOut.Location = new Point(0, 0);
            richTextBoxDbOut.Name = "richTextBoxDbOut";
            richTextBoxDbOut.ReadOnly = true;
            richTextBoxDbOut.Size = new Size(994, 392);
            richTextBoxDbOut.TabIndex = 5;
            richTextBoxDbOut.Text = "";
            // 
            // panel4
            // 
            panel4.Controls.Add(buttonTelnetOnShell);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(textBoxDBPort);
            panel4.Controls.Add(groupBoxDBType);
            panel4.Controls.Add(buttonDBTelnet);
            panel4.Controls.Add(textBoxDBAddr);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(994, 108);
            panel4.TabIndex = 0;
            // 
            // buttonTelnetOnShell
            // 
            buttonTelnetOnShell.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            buttonTelnetOnShell.Location = new Point(646, 3);
            buttonTelnetOnShell.Name = "buttonTelnetOnShell";
            buttonTelnetOnShell.Size = new Size(158, 34);
            buttonTelnetOnShell.TabIndex = 6;
            buttonTelnetOnShell.Text = "系统Telnet";
            buttonTelnetOnShell.UseVisualStyleBackColor = true;
            buttonTelnetOnShell.Click += buttonTelnetOnShell_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(370, 13);
            label1.Name = "label1";
            label1.Size = new Size(20, 17);
            label1.TabIndex = 5;
            label1.Text = "：";
            // 
            // textBoxDBPort
            // 
            textBoxDBPort.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            textBoxDBPort.Location = new Point(396, 3);
            textBoxDBPort.Name = "textBoxDBPort";
            textBoxDBPort.Size = new Size(80, 32);
            textBoxDBPort.TabIndex = 4;
            textBoxDBPort.Text = "3306";
            textBoxDBPort.KeyPress += textBoxDBPort_KeyPress;
            // 
            // groupBoxDBType
            // 
            groupBoxDBType.Controls.Add(rbSSH);
            groupBoxDBType.Controls.Add(rbWeb);
            groupBoxDBType.Controls.Add(rbRedis);
            groupBoxDBType.Controls.Add(rbOther);
            groupBoxDBType.Controls.Add(rbSqlserver);
            groupBoxDBType.Controls.Add(rbOracle);
            groupBoxDBType.Controls.Add(rbMysql);
            groupBoxDBType.Location = new Point(5, 41);
            groupBoxDBType.Name = "groupBoxDBType";
            groupBoxDBType.Size = new Size(635, 60);
            groupBoxDBType.TabIndex = 3;
            groupBoxDBType.TabStop = false;
            groupBoxDBType.Text = "服务器类型";
            // 
            // rbSSH
            // 
            rbSSH.AutoSize = true;
            rbSSH.Location = new Point(377, 25);
            rbSSH.Name = "rbSSH";
            rbSSH.Size = new Size(49, 21);
            rbSSH.TabIndex = 6;
            rbSSH.TabStop = true;
            rbSSH.Text = "SSH";
            rbSSH.UseVisualStyleBackColor = true;
            rbSSH.CheckedChanged += rbSSH_CheckedChanged;
            // 
            // rbWeb
            // 
            rbWeb.AutoSize = true;
            rbWeb.Location = new Point(318, 25);
            rbWeb.Name = "rbWeb";
            rbWeb.Size = new Size(53, 21);
            rbWeb.TabIndex = 5;
            rbWeb.TabStop = true;
            rbWeb.Text = "Web";
            rbWeb.UseVisualStyleBackColor = true;
            rbWeb.CheckedChanged += rbWeb_CheckedChanged;
            // 
            // rbRedis
            // 
            rbRedis.AutoSize = true;
            rbRedis.Location = new Point(254, 25);
            rbRedis.Name = "rbRedis";
            rbRedis.Size = new Size(58, 21);
            rbRedis.TabIndex = 4;
            rbRedis.TabStop = true;
            rbRedis.Text = "Redis";
            rbRedis.UseVisualStyleBackColor = true;
            rbRedis.CheckedChanged += rbRedis_CheckedChanged;
            // 
            // rbOther
            // 
            rbOther.AutoSize = true;
            rbOther.Location = new Point(543, 25);
            rbOther.Name = "rbOther";
            rbOther.Size = new Size(86, 21);
            rbOther.TabIndex = 3;
            rbOther.TabStop = true;
            rbOther.Text = "其他服务器";
            rbOther.UseVisualStyleBackColor = true;
            rbOther.CheckedChanged += rbOther_CheckedChanged;
            // 
            // rbSqlserver
            // 
            rbSqlserver.AutoSize = true;
            rbSqlserver.Location = new Point(162, 25);
            rbSqlserver.Name = "rbSqlserver";
            rbSqlserver.Size = new Size(86, 21);
            rbSqlserver.TabIndex = 2;
            rbSqlserver.TabStop = true;
            rbSqlserver.Text = "SQLServer";
            rbSqlserver.UseVisualStyleBackColor = true;
            rbSqlserver.CheckedChanged += rbSqlserver_CheckedChanged;
            // 
            // rbOracle
            // 
            rbOracle.AutoSize = true;
            rbOracle.Location = new Point(92, 25);
            rbOracle.Name = "rbOracle";
            rbOracle.Size = new Size(64, 21);
            rbOracle.TabIndex = 1;
            rbOracle.TabStop = true;
            rbOracle.Text = "Oracle";
            rbOracle.UseVisualStyleBackColor = true;
            rbOracle.CheckedChanged += rbOracle_CheckedChanged;
            // 
            // rbMysql
            // 
            rbMysql.AutoSize = true;
            rbMysql.Checked = true;
            rbMysql.Location = new Point(19, 25);
            rbMysql.Name = "rbMysql";
            rbMysql.Size = new Size(67, 21);
            rbMysql.TabIndex = 0;
            rbMysql.TabStop = true;
            rbMysql.Text = "MySQL";
            rbMysql.UseVisualStyleBackColor = true;
            rbMysql.CheckedChanged += rbMysql_CheckedChanged;
            // 
            // buttonDBTelnet
            // 
            buttonDBTelnet.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            buttonDBTelnet.Location = new Point(482, 3);
            buttonDBTelnet.Name = "buttonDBTelnet";
            buttonDBTelnet.Size = new Size(158, 34);
            buttonDBTelnet.TabIndex = 2;
            buttonDBTelnet.Text = "连接";
            buttonDBTelnet.UseVisualStyleBackColor = true;
            buttonDBTelnet.Click += buttonDBTelnet_Click;
            // 
            // textBoxDBAddr
            // 
            textBoxDBAddr.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            textBoxDBAddr.Location = new Point(5, 3);
            textBoxDBAddr.Name = "textBoxDBAddr";
            textBoxDBAddr.Size = new Size(359, 32);
            textBoxDBAddr.TabIndex = 1;
            textBoxDBAddr.Text = "localhost";
            // 
            // tabPageTraceroute
            // 
            tabPageTraceroute.Controls.Add(panel6);
            tabPageTraceroute.Controls.Add(panel3);
            tabPageTraceroute.Location = new Point(4, 26);
            tabPageTraceroute.Name = "tabPageTraceroute";
            tabPageTraceroute.Padding = new Padding(3);
            tabPageTraceroute.Size = new Size(1000, 506);
            tabPageTraceroute.TabIndex = 2;
            tabPageTraceroute.Text = "Traceroute";
            tabPageTraceroute.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            panel6.Controls.Add(richTextBoxTracerouteOut);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(3, 44);
            panel6.Name = "panel6";
            panel6.Size = new Size(994, 459);
            panel6.TabIndex = 1;
            // 
            // richTextBoxTracerouteOut
            // 
            richTextBoxTracerouteOut.BackColor = Color.Black;
            richTextBoxTracerouteOut.Dock = DockStyle.Fill;
            richTextBoxTracerouteOut.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            richTextBoxTracerouteOut.ForeColor = Color.White;
            richTextBoxTracerouteOut.Location = new Point(0, 0);
            richTextBoxTracerouteOut.Name = "richTextBoxTracerouteOut";
            richTextBoxTracerouteOut.ReadOnly = true;
            richTextBoxTracerouteOut.Size = new Size(994, 459);
            richTextBoxTracerouteOut.TabIndex = 6;
            richTextBoxTracerouteOut.Text = "";
            // 
            // panel3
            // 
            panel3.Controls.Add(buttonTraceroute);
            panel3.Controls.Add(textBoxTracerouteAddr);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(994, 41);
            panel3.TabIndex = 0;
            // 
            // buttonTraceroute
            // 
            buttonTraceroute.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            buttonTraceroute.Location = new Point(370, 3);
            buttonTraceroute.Name = "buttonTraceroute";
            buttonTraceroute.Size = new Size(158, 34);
            buttonTraceroute.TabIndex = 3;
            buttonTraceroute.Text = "跟踪";
            buttonTraceroute.UseVisualStyleBackColor = true;
            buttonTraceroute.Click += buttonTraceroute_Click;
            // 
            // textBoxTracerouteAddr
            // 
            textBoxTracerouteAddr.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            textBoxTracerouteAddr.Location = new Point(5, 3);
            textBoxTracerouteAddr.Name = "textBoxTracerouteAddr";
            textBoxTracerouteAddr.Size = new Size(359, 32);
            textBoxTracerouteAddr.TabIndex = 2;
            textBoxTracerouteAddr.Text = "localhost";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { FileToolStripMenuItem, HelpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1008, 25);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { StopToolStripMenuItem, ExitToolStripMenuItem });
            FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            FileToolStripMenuItem.Size = new Size(58, 21);
            FileToolStripMenuItem.Text = "文件(&F)";
            // 
            // StopToolStripMenuItem
            // 
            StopToolStripMenuItem.Name = "StopToolStripMenuItem";
            StopToolStripMenuItem.Size = new Size(163, 22);
            StopToolStripMenuItem.Text = "停止当前命令(&S)";
            StopToolStripMenuItem.Click += StopToolStripMenuItem_Click;
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new Size(163, 22);
            ExitToolStripMenuItem.Text = "退出(&Q)";
            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // HelpToolStripMenuItem
            // 
            HelpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AboutToolStripMenuItem });
            HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            HelpToolStripMenuItem.Size = new Size(61, 21);
            HelpToolStripMenuItem.Text = "帮助(&H)";
            // 
            // AboutToolStripMenuItem
            // 
            AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            AboutToolStripMenuItem.Size = new Size(100, 22);
            AboutToolStripMenuItem.Text = "关于";
            AboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            // 
            // panelStatus
            // 
            panelStatus.Controls.Add(labelStatus);
            panelStatus.Dock = DockStyle.Bottom;
            panelStatus.Location = new Point(0, 544);
            panelStatus.Name = "panelStatus";
            panelStatus.Size = new Size(1008, 17);
            panelStatus.TabIndex = 4;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(0, 0);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(32, 17);
            labelStatus.TabIndex = 0;
            labelStatus.Text = "就绪";
            // 
            // NetworkUtils
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 561);
            Controls.Add(panelStatus);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "NetworkUtils";
            Text = "王龙江的网络工具箱";
            tabControl1.ResumeLayout(false);
            tabPagePing.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPageDatabase.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            groupBoxDBType.ResumeLayout(false);
            groupBoxDBType.PerformLayout();
            tabPageTraceroute.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelStatus.ResumeLayout(false);
            panelStatus.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void buttonPing_Click(object sender, EventArgs e)
        {
            if (buttonPing.Text == "Ping")
            {
                if (textBoxPingAddr.Text == "")
                {
                    MessageBox.Show("必须输入服务器地址","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                buttonPing.Text = "Stop";
                buttonPing.ForeColor = Color.Red;
                remainderPingTimes = 5;
                using (BackgroundWorker backgroundWorker = new BackgroundWorker())
                {
                    backgroundWorker.WorkerReportsProgress = true;
                    backgroundWorker.ProgressChanged += delegate (object sender, ProgressChangedEventArgs e)
                    {
                        string msg = e.UserState.ToString();
                        if (msg == "未知错误" || msg == "连接超时" || msg == "找不到服务器" || msg.Contains("发生错误"))
                        {
                            richTextBoxPingOut.SelectionStart = richTextBoxPingOut.TextLength;
                            richTextBoxPingOut.SelectionLength = 0;
                            richTextBoxPingOut.SelectionColor = Color.Red;
                        }
                        richTextBoxPingOut.AppendText(msg);
                        richTextBoxPingOut.SelectionColor = richTextBoxPingOut.ForeColor;
                        richTextBoxPingOut.AppendText("\r\n");
                        richTextBoxPingOut.ScrollToCaret();
                    };
                    backgroundWorker.RunWorkerCompleted += delegate (object sender, RunWorkerCompletedEventArgs e)
                    {
                        string msg = e.Result.ToString();
                        if (msg.Contains("发生错误"))
                        {
                            richTextBoxPingOut.SelectionStart = richTextBoxPingOut.TextLength;
                            richTextBoxPingOut.SelectionLength = 0;
                            richTextBoxPingOut.SelectionColor = Color.Red;
                            richTextBoxPingOut.AppendText(msg);
                            richTextBoxPingOut.SelectionColor = richTextBoxPingOut.ForeColor;
                        }
                        else
                        {
                            int startIndex = richTextBoxPingOut.Text.Length;
                            richTextBoxPingOut.AppendText(msg);
                            string loseP = @"丢失 = (\d+) \(\d+% 丢失\)";
                            MatchCollection matchs = Regex.Matches(msg, loseP);
                            if (matchs.Count > 0)
                            {
                                string loseCount = matchs[0].Groups[1].Value;
                                if (int.Parse(loseCount) > 0)
                                {
                                    richTextBoxPingOut.SelectionStart = startIndex+matchs[0].Groups[0].Index;
                                    richTextBoxPingOut.SelectionLength = matchs[0].Groups[0].Length;
                                    richTextBoxPingOut.SelectionColor = Color.Red;
                                    richTextBoxPingOut.SelectionStart = richTextBoxPingOut.TextLength;
                                    richTextBoxPingOut.SelectionLength = 0;
                                    richTextBoxPingOut.SelectionColor = richTextBoxPingOut.ForeColor;
                                }
                            }
                        }
                        richTextBoxPingOut.AppendText("\r\n");
                        richTextBoxPingOut.ScrollToCaret();
                        labelStatus.Text = "就绪";
                        buttonPing.Text = "Ping";
                        buttonPing.ForeColor = Color.Black;
                    };
                    backgroundWorker.DoWork += DoPing;
                    backgroundWorker.RunWorkerAsync();
                    labelStatus.Text = "正在运行Ping...";
                }
            }
            else
            {
                buttonPing.Text = "Ping";
                buttonPing.ForeColor = Color.Black;
                stopCommand = true;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPagePing;
        private TabPage tabPageDatabase;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem FileToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private ToolStripMenuItem HelpToolStripMenuItem;
        private ToolStripMenuItem AboutToolStripMenuItem;
        private Button buttonPing;
        private TextBox textBoxPingAddr;
        private CheckBox checkBoxPingNums;
        private int remainderPingTimes;
        private bool stopCommand;
        private Panel panel1;
        private Panel panel2;
        private ToolStripMenuItem StopToolStripMenuItem;
        private RichTextBox richTextBoxPingOut;
        private Panel panel5;
        private Panel panel4;
        private Button buttonDBTelnet;
        private TextBox textBoxDBAddr;
        private GroupBox groupBoxDBType;
        private Label label1;
        private TextBox textBoxDBPort;
        private RadioButton rbOracle;
        private RadioButton rbMysql;
        private RadioButton rbSqlserver;
        private RadioButton rbOther;
        private RichTextBox richTextBoxDbOut;
        private Panel panelStatus;
        private Label labelStatus;
        private RadioButton rbRedis;
        private RadioButton rbWeb;
        private RadioButton rbSSH;
        private Button buttonPingInShell;
        private Button buttonTelnetOnShell;
        private TabPage tabPageTraceroute;
        private Panel panel6;
        private RichTextBox richTextBoxTracerouteOut;
        private Panel panel3;
        private Button buttonTraceroute;
        private TextBox textBoxTracerouteAddr;
    }
}
