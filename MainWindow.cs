using System.ComponentModel;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace NetworkUtils
{
    public partial class NetworkUtils : Form
    {
        public NetworkUtils()
        {
            InitializeComponent();
        }

        private void checkBoxPingNums_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxPingNums.Checked)
            {
                remainderPingTimes = 0;
            }
        }


        private void DoPing(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int success = 0; int total = 0;
            long minTime = long.MaxValue;
            long maxTime = long.MinValue;
            long totalTime = 0;
            try
            {
                while (!stopCommand && (checkBoxPingNums.Checked || remainderPingTimes > 0))
                {
                    if (remainderPingTimes > 0)
                    {
                        remainderPingTimes--;
                    }
                    total++;
                    Ping ping = new Ping();
                    byte[] buffer = Encoding.ASCII.GetBytes("Hello123456789012345678901234567");
                    PingOptions options = new PingOptions();
                    options.DontFragment = true;
                    PingReply pingReply = ping.Send(textBoxPingAddr.Text, 120, buffer, options);
                    string message = "未知错误";
                    if (pingReply != null)
                    {
                        if (pingReply.Status == IPStatus.Success)
                        {
                            message = $"来自 {pingReply.Address.MapToIPv4().ToString()} 的回复：字节={pingReply.Buffer.Length} 时间={pingReply.RoundtripTime}ms TTL={(pingReply.Options != null ? pingReply.Options.Ttl : "")}";
                            success++;
                            {
                                minTime = Math.Min(minTime, pingReply.RoundtripTime);
                                maxTime = Math.Max(maxTime, pingReply.RoundtripTime);
                                totalTime += pingReply.RoundtripTime;
                            }
                        }
                        else if (pingReply.Status == IPStatus.TimedOut)
                        {
                            message = "连接超时";
                        }
                        else if (pingReply.Status == IPStatus.Unknown)
                        {
                            message = "找不到服务器";
                        }
                    }
                    worker.ReportProgress(0, message);
                    Thread.Sleep(1000);
                }
                e.Result = $"数据包：已发送 = {total}，已接收 = {success}，丢失 = {total - success} ({(total > 0 ? Math.Round((total - success) / (double)total, 2) * 100 : "NaN")}% 丢失)，   时间：最短 = {minTime}ms，最长 = {maxTime}ms，平均 = {(success > 0 ? totalTime / success : "NaN")}ms";
            }
            catch (PingException pingException)
            {
                e.Result = "发生错误：\r\n" + pingException.ToString();
            }
            if (stopCommand)
            {
                stopCommand = false;
            }
        }
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("网络工具箱是老王开发的网络小工具集合，用于网络测试什么的。", "关于王龙江的网络工具箱");
        }

        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopCommand = true;
        }

        private void textBoxPingAddr_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonPing_Click(sender, e);
            }
        }

        private void textBoxPingAddr_Enter(object sender, EventArgs e)
        {
            textBoxPingAddr.SelectionStart = 0;
            textBoxPingAddr.SelectionLength = textBoxPingAddr.TextLength;
        }

        private void tabPagePing_Enter(object sender, EventArgs e)
        {
            textBoxPingAddr.Focus();
        }

        private void rbMysql_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMysql.Checked)
            {
                textBoxDBPort.Text = "3306";
            }
        }

        private void textBoxDBPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void rbOracle_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOracle.Checked)
            {
                textBoxDBPort.Text = "1521";
            }
        }

        private void rbSqlserver_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSqlserver.Checked)
            {
                textBoxDBPort.Text = "1433";
            }
        }

        private void rbOther_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOther.Checked)
            {
                textBoxDBPort.Select();
                textBoxDBPort.Focus();
            }
        }

        private async void buttonDBTelnet_Click(object sender, EventArgs e)
        {
            if (buttonDBTelnet.Text == "正在连接...")
            {
                return;
            }
            buttonDBTelnet.Text = "正在连接...";
            buttonDBTelnet.ForeColor = Color.Red;
            if (textBoxDBAddr.Text == "" || textBoxDBPort.Text == "")
            {
                MessageBox.Show("必须输入服务器地址和端口", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using TcpClient tcpClient = new TcpClient();
            try
            {
                await tcpClient.ConnectAsync(textBoxDBAddr.Text, int.Parse(textBoxDBPort.Text));
                if (tcpClient.Connected)
                {
                    richTextBoxDbOut.SelectionStart = richTextBoxDbOut.TextLength;
                    richTextBoxDbOut.SelectionLength = 0;
                    richTextBoxDbOut.SelectionColor = Color.Green;
                    richTextBoxDbOut.AppendText($"{textBoxDBAddr.Text}:{textBoxDBPort.Text} 连接成功");
                    richTextBoxDbOut.SelectionColor = richTextBoxDbOut.ForeColor;
                }
                else
                {
                    richTextBoxDbOut.SelectionStart = richTextBoxDbOut.TextLength;
                    richTextBoxDbOut.SelectionLength = 0;
                    richTextBoxDbOut.SelectionColor = Color.Red;
                    richTextBoxDbOut.AppendText($"{textBoxDBAddr.Text}:{textBoxDBPort.Text} 连接失败");
                    richTextBoxDbOut.SelectionColor = richTextBoxDbOut.ForeColor;
                }
            }
            catch (SocketException sex)
            {
                richTextBoxDbOut.SelectionStart = richTextBoxDbOut.TextLength;
                richTextBoxDbOut.SelectionLength = 0;
                richTextBoxDbOut.SelectionColor = Color.Red;
                richTextBoxDbOut.AppendText($"{textBoxDBAddr.Text}:{textBoxDBPort.Text} 连接失败，错误消息：{sex.Message}");
                richTextBoxDbOut.SelectionColor = richTextBoxDbOut.ForeColor;
            }
            richTextBoxDbOut.AppendText("\r\n");
            richTextBoxDbOut.ScrollToCaret();
            buttonDBTelnet.Text = "连接";
            buttonDBTelnet.ForeColor = Color.Black;
        }

        private void rbRedis_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRedis.Checked)
            {
                textBoxDBPort.Text = "6379";
            }
        }

        private void rbWeb_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWeb.Checked)
            {
                textBoxDBPort.Text = "80";
            }
        }

        private void rbSSH_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSSH.Checked)
            {
                textBoxDBPort.Text = "22";
            }
        }

        private void buttonPingInShell_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.RedirectStandardInput = true;
            startInfo.UseShellExecute = false;

            using (Process process = Process.Start(startInfo))
            {
                process.StandardInput.WriteLine($"ping {textBoxPingAddr.Text}");
                process.WaitForExit();
            }
        }

        private void buttonTelnetOnShell_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.RedirectStandardInput = true;
            startInfo.UseShellExecute = false;

            using (Process process = Process.Start(startInfo))
            {
                process.StandardInput.WriteLine($"telnet {textBoxDBAddr.Text} {textBoxDBPort.Text}");
                process.WaitForExit();
            }
        }
    }
}
