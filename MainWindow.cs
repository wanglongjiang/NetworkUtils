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
                    string message = "δ֪����";
                    if (pingReply != null)
                    {
                        if (pingReply.Status == IPStatus.Success)
                        {
                            message = $"���� {pingReply.Address.MapToIPv4().ToString()} �Ļظ����ֽ�={pingReply.Buffer.Length} ʱ��={pingReply.RoundtripTime}ms TTL={(pingReply.Options != null ? pingReply.Options.Ttl : "")}";
                            success++;
                            {
                                minTime = Math.Min(minTime, pingReply.RoundtripTime);
                                maxTime = Math.Max(maxTime, pingReply.RoundtripTime);
                                totalTime += pingReply.RoundtripTime;
                            }
                        }
                        else if (pingReply.Status == IPStatus.TimedOut)
                        {
                            message = "���ӳ�ʱ";
                        }
                        else if (pingReply.Status == IPStatus.Unknown)
                        {
                            message = "�Ҳ���������";
                        }
                    }
                    worker.ReportProgress(0, message);
                    Thread.Sleep(1000);
                }
                e.Result = $"���ݰ����ѷ��� = {total}���ѽ��� = {success}����ʧ = {total - success} ({(total > 0 ? Math.Round((total - success) / (double)total, 2) * 100 : "NaN")}% ��ʧ)��   ʱ�䣺��� = {minTime}ms��� = {maxTime}ms��ƽ�� = {(success > 0 ? totalTime / success : "NaN")}ms";
            }
            catch (PingException pingException)
            {
                e.Result = "��������\r\n" + pingException.ToString();
            }
            if (stopCommand)
            {
                stopCommand = false;
            }
        }
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("���繤��������������������С���߼��ϣ������������ʲô�ġ�", "���������������繤����");
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
            if (buttonDBTelnet.Text == "��������...")
            {
                return;
            }
            buttonDBTelnet.Text = "��������...";
            buttonDBTelnet.ForeColor = Color.Red;
            if (textBoxDBAddr.Text == "" || textBoxDBPort.Text == "")
            {
                MessageBox.Show("���������������ַ�Ͷ˿�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    richTextBoxDbOut.AppendText($"{textBoxDBAddr.Text}:{textBoxDBPort.Text} ���ӳɹ�");
                    richTextBoxDbOut.SelectionColor = richTextBoxDbOut.ForeColor;
                }
                else
                {
                    richTextBoxDbOut.SelectionStart = richTextBoxDbOut.TextLength;
                    richTextBoxDbOut.SelectionLength = 0;
                    richTextBoxDbOut.SelectionColor = Color.Red;
                    richTextBoxDbOut.AppendText($"{textBoxDBAddr.Text}:{textBoxDBPort.Text} ����ʧ��");
                    richTextBoxDbOut.SelectionColor = richTextBoxDbOut.ForeColor;
                }
            }
            catch (SocketException sex)
            {
                richTextBoxDbOut.SelectionStart = richTextBoxDbOut.TextLength;
                richTextBoxDbOut.SelectionLength = 0;
                richTextBoxDbOut.SelectionColor = Color.Red;
                richTextBoxDbOut.AppendText($"{textBoxDBAddr.Text}:{textBoxDBPort.Text} ����ʧ�ܣ�������Ϣ��{sex.Message}");
                richTextBoxDbOut.SelectionColor = richTextBoxDbOut.ForeColor;
            }
            richTextBoxDbOut.AppendText("\r\n");
            richTextBoxDbOut.ScrollToCaret();
            buttonDBTelnet.Text = "����";
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
