using System.ComponentModel;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

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

        private void buttonTraceroute_Click(object sender, EventArgs e)
        {
            // 异步执行traceroute textboxTracerouteAddr.Text 中的地址 并输出到 richTextBoxTracerouteOut
            // 不打开cmd窗口，输出到 richTextBoxTracerouteOut
            // 使用异步方式执行，tracert的输出每行都实时输出到 richTextBoxTracerouteOut
            // 可以在跟踪过程中点击本按钮停止跟踪

            if (buttonTraceroute.Text == "停止")
            {
                stopCommand = true;
                return;
            }
            buttonTraceroute.Text = "停止";
            buttonTraceroute.ForeColor = Color.Red;
            richTextBoxTracerouteOut.Clear();
            _ = Task.Run(() =>
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "tracert";
                startInfo.Arguments = textBoxTracerouteAddr.Text;
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;

                using (Process process = Process.Start(startInfo))
                {
                    while (!process.StandardOutput.EndOfStream)
                    {
                        string line = process.StandardOutput.ReadLine();
                        if (stopCommand)
                        {
                            process.Kill();
                            break;
                        }
                        richTextBoxTracerouteOut.Invoke(new Action(() =>
                        {
                            richTextBoxTracerouteOut.AppendText(line + "\r\n");
                            richTextBoxTracerouteOut.ScrollToCaret();
                        }));
                    }
                }
                buttonTraceroute.Invoke(new Action(() =>
                {
                    buttonTraceroute.Text = "跟踪";
                    buttonTraceroute.ForeColor = Color.Black;
                }));
            });
        }

        private void textBoxPingAddr_TextChanged(object sender, EventArgs e)
        {
            textBoxPingAddr.Text = removeHttpFix(textBoxPingAddr.Text);
        }

        private static string removeHttpFix(string text)
        {
            // 去掉换行符
            text = text.Replace("\r", "").Replace("\n", "");
            // 去掉http://和https://
            text = text.Replace("http://", "").Replace("https://", "");
            // 去掉空格
            text = text.Replace(" ", "");
            // 去掉/后面的内容
            int index = text.IndexOf('/');
            if (index > 0)
            {
                text = text.Substring(0, index);
            }
            // 去掉:后面的内容
            index = text.IndexOf(':');
            if (index > 0)
            {
                text = text.Substring(0, index);
            }

            return text;
        }

        private void textBoxTracerouteAddr_TextChanged(object sender, EventArgs e)
        {
            textBoxTracerouteAddr.Text = removeHttpFix(textBoxTracerouteAddr.Text);
        }

        private void textBoxDBAddr_TextChanged(object sender, EventArgs e)
        {
            // 如果textBoxDbAddr以http://开头，说明是web服务
            // 需要将textBoxDbAddr中的http://去掉，路径中的/后面的部分去掉，如果有端口号，需要将端口号赋值给textBoxDBPort
            if (textBoxDBAddr.Text.StartsWith("http://"))
            {
                textBoxDBAddr.Text = textBoxDBAddr.Text.Replace("http://", "");
                // 去掉/后面的内容
                int index = textBoxDBAddr.Text.IndexOf('/');
                if (index > 0)
                {
                    textBoxDBAddr.Text = textBoxDBAddr.Text.Substring(0, index);
                }
                // 设置端口
                index = textBoxDBAddr.Text.IndexOf(':');
                if (index > 0)
                {
                    textBoxDBPort.Text = textBoxDBAddr.Text.Substring(index);
                    textBoxDBAddr.Text = textBoxDBAddr.Text.Substring(0, index);
                }
                else
                {
                    textBoxDBPort.Text = "80";
                }
                rbWeb.Checked = true;
            }
            // 如果textBoxDbAddr以https://开头，说明是web服务
            // 需要将textBoxDbAddr中的https://去掉，路径中的/后面的部分去掉，如果有端口号，需要将端口号赋值给textBoxDBPort
            if (textBoxDBAddr.Text.StartsWith("https://"))
            {
                textBoxDBAddr.Text = textBoxDBAddr.Text.Replace("https://", "");
                // 去掉/后面的内容
                int index = textBoxDBAddr.Text.IndexOf('/');
                if (index > 0)
                {
                    textBoxDBAddr.Text = textBoxDBAddr.Text.Substring(0, index);
                }
                // 设置端口
                index = textBoxDBAddr.Text.IndexOf(':');
                if (index > 0)
                {
                    textBoxDBPort.Text = textBoxDBAddr.Text.Substring(index);
                    textBoxDBAddr.Text = textBoxDBAddr.Text.Substring(0, index);
                }
                else
                {
                    textBoxDBPort.Text = "443";
                }
                rbWeb.Checked = true;
            }
        }
    }
}
