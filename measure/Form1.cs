using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace measure
{
    public partial class Form1 : Form
    {
        private bool calibration = false;
        private const int MAXDATA = 0xF;
        private const int LEN_ASCII_NUMBER = 0x3;
        private const int LEN_ASCII_FRACTIONAL = 0x4;
        /**
        * @brief command codes
        */
        enum TComCmd
        {
            cmd_ack,                /*!< request ack/nack */
            cmd_get_status,         /*!< status / static request */
            cmd_get_last_data,     /*!< last data request */
            cmd_measure             /*!< measure start */
        };

        enum TComStatus
        {
            status_ready,                     /*!< avaiting orders */
            status_measurement,                /*!< measurement in progress */
            status_error,                     /*!< have any error */
            status_busy,                     /*!< can't ansver / receive now */
        };
        enum TComPkt
        {
            crc = 0,                /*!< checksumm */
            cmd,               /*!< command code */
            seq,                /*!< sequense number */
            datalen,            /*!< data length */
            data,     /*!< data array */
            len
        };

        struct LinearCoef
        {
            public float a;
            public float b;
            public float disp;
            public bool calibrated;
        };

        enum TComAck
        {
            com_ack = 0x06,             /*!< acknowledgement */
            com_nack = 0x15                /*!< negative acknowledgment */
        };

        enum TPacketStatus
        {
            ok = 0,
            crcErr,
            seqErr,

        }

        private static LinearCoef linearapprox = new LinearCoef();

        private static bool exchange_in_progress = false;
        private byte[] inPacket = new byte[30];
        private byte[] outPacket = new byte[((int)(TComPkt.len - 1) + MAXDATA)];
        static readonly SerialPort _serialPort = new SerialPort();

        public Form1()
        {
            InitializeComponent();
            linearapprox.a = 0;
            linearapprox.b = 0;
            linearapprox.disp = 0;
        }
        private string com_read()
        {
            string res = "";
            if (!_serialPort.IsOpen)
            {
                exchange_in_progress = false;
                return res;
            }
            int i = 0;
            while (_serialPort.BytesToRead > 0)
            {
                byte getted = (byte)_serialPort.ReadByte();
                inPacket[i++] = getted;
                res += " 0x";
                byte tmp = (byte)(getted / 16);
                if (tmp > 9)
                {
                    res += (char)(tmp + 'A' - 10);
                }
                else
                {
                    res += tmp;
                }
                tmp = (byte)(getted % 16);
                if (tmp > 9)
                {
                    res += (char)(tmp + 'A' - 10);
                }
                else
                {
                    res += tmp;
                }
            }
            exchange_in_progress = false;
            return res;
        }
        private void com_send()
        {
            if (_serialPort.IsOpen)
            {
                if (++outPacket[(int)TComPkt.seq] > 255)
                    outPacket[(int)TComPkt.seq] = 0;
                _serialPort.Write(outPacket, 0, (int)(TComPkt.len - 1) + outPacket[(int)TComPkt.datalen]);
                comTimer.Start();
            }
        }


        private TPacketStatus comPacketHandler()
        {
            /*if (crcIsNotOk)
            {
                setStatus2("Check summ error");                
                return TPacketStatus.crcErr
            }*/
            if (inPacket[(int)TComPkt.seq] != outPacket[(int)TComPkt.seq])
            {
                setStatus("Sequence error!");
                return TPacketStatus.seqErr;
            }
            switch ((TComCmd)inPacket[(int)TComPkt.cmd])
            {
                case TComCmd.cmd_ack:
                    switch ((TComAck)inPacket[(int)TComPkt.data])
                    {
                        case TComAck.com_ack:
                            statusLabel.Text = "Ok!";
                            break;
                        case TComAck.com_nack:
                            statusLabel.Text = "Nack!";
                            break;
                        default:
                            break;
                    }
                    break;
                case TComCmd.cmd_get_status:
                    switch ((TComStatus)inPacket[(int)TComPkt.data])
                    {
                        case TComStatus.status_ready:
                            break;
                        case TComStatus.status_measurement:
                            break;
                        case TComStatus.status_error:
                            break;
                        case TComStatus.status_busy:
                            break;
                        default:
                            break;
                    }
                    break;
                case TComCmd.cmd_get_last_data:
                    if (calibration)
                    {
                        dataSet2.Tables[0].Rows.Add();
                        int num = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            num *= 10;
                            num += inPacket[(int)TComPkt.data + j] - 48;
                        }
                        int fraq = 0;
                        for (int j = 4; j < 8; j++)
                        {
                            fraq *= 10;
                            fraq += inPacket[(int)TComPkt.data + j] - 48;
                        }
                        dataSet2.Tables[0].Columns[1].ReadOnly = false;
                        dataSet2.Tables[0].Rows[dataSet2.Tables[0].Rows.Count-1][1] = (num + (float)fraq / System.Math.Pow(10, (int)System.Math.Log10(fraq) + 1));
                        dataSet2.Tables[0].Columns[1].ReadOnly = true;
                        calibration = false;
                    }
                    else
                    {
                        dataSet1.Tables[0].Rows.Add();
                        dataSet1.Tables[0].Columns[3].ReadOnly = false;
                        dataSet1.Tables[0].Rows[dataSet1.Tables[0].Rows.Count - 1][3] = DateTime.Now;
                        dataSet1.Tables[0].Columns[3].ReadOnly = true;
                        int num = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            num *= 10;
                            num += inPacket[(int)TComPkt.data + j] - 48;
                        }
                        int fraq = 0;
                        for (int j = 4; j < 8; j++)
                        {
                            fraq *= 10;
                            fraq += inPacket[(int)TComPkt.data + j] - 48;
                        }
                        double val = (num + (float)fraq / System.Math.Pow(10, (int)System.Math.Log10(fraq) + 1));
                        dataSet1.Tables[0].Columns[2].ReadOnly = false;
                        dataSet1.Tables[0].Rows[dataSet1.Tables[0].Rows.Count - 1][2] = val;
                        dataSet1.Tables[0].Columns[2].ReadOnly = true;
                        if (linearapprox.calibrated)
                        {
                            dataSet1.Tables[0].Columns[1].ReadOnly = false;
                            dataSet1.Tables[0].Rows[dataSet1.Tables[0].Rows.Count - 1][1] = linearapprox.a * val + linearapprox.b;
                            dataSet1.Tables[0].Columns[1].ReadOnly = true;
                        }
                    }
                    break;
                case TComCmd.cmd_measure:
                    break;
                default:
                    break;
            }
            return TPacketStatus.ok;
        }

        private void cmdSend(TComCmd c)
        {
            if (exchange_in_progress)
                return;
            exchange_in_progress = true;
            outPacket[(int)TComPkt.cmd] = (byte)c;
            switch (c)
            {
                case TComCmd.cmd_ack:
                    outPacket[(int)TComPkt.datalen] = 0;
                    break;
                case TComCmd.cmd_get_status:
                    outPacket[(int)TComPkt.datalen] = 0;
                    break;
                case TComCmd.cmd_get_last_data:
                    outPacket[(int)TComPkt.datalen] = 0;
                    break;
                case TComCmd.cmd_measure:
                    outPacket[(int)TComPkt.datalen] = 0;
                    break;
                default:
                    break;
            }
            com_send();
        }

        private void com_refresh()
        {
            comboBox1_com.Items.Clear();
            comboBox1_com.Items.AddRange(SerialPort.GetPortNames());
            if (comboBox1_com.Items.Count > 0)
            {
                comboBox1_com.SelectedItem = comboBox1_com.Items[0];
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string Path = saveFileDialog1.FileName;
            if (tabControl1.SelectedTab == tabControl1.TabPages[1])
            {
                dataSet1.WriteXml(Path);
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages[2])
            {
                dataSet2.WriteXml(Path);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cmdSend(TComCmd.cmd_measure);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = dataSet1.Tables[0];
            dataGridView1.DataSource = bindingSource1;
            com_refresh();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string Path = openFileDialog1.FileName;
            if (tabControl1.SelectedTab == tabControl1.TabPages[1])
            {
                dataSet1.ReadXml(Path);
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages[2])
            {
                dataSet2.ReadXml(Path);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void button1_add_Click(object sender, EventArgs e)
        {
            cmdSend(TComCmd.cmd_measure);

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void comRefresh_Click(object sender, EventArgs e)
        {
            com_refresh();
        }

        private void numericUpDown1_timeout_ValueChanged(object sender, EventArgs e)
        {
            comTimer.Interval = (int)numericUpDown1_timeout.Value;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
        }

        private void comTimer_Tick(object sender, EventArgs e)
        {
            comTimer.Stop();
            toolStripStatusLabel3.Text = com_read();
            comPacketHandler();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
            if (comboBox1_com.Items.Count > 0)
            {
                _serialPort.PortName = comboBox1_com.Text;
            }
            else
            {
                setStatus("no ports found");
            }
            _serialPort.BaudRate = Int32.Parse(textBox1_baud.Text);
            _serialPort.DataBits = Int32.Parse(textBox1_data.Text);
            switch (comboBox1_parity.Text)
            {
                case "NONE":
                    _serialPort.Parity = Parity.None;
                    break;
                case "ODD":
                    _serialPort.Parity = Parity.Odd;
                    break;
                case "EVEN":
                    _serialPort.Parity = Parity.Even;
                    break;
                default:
                    setStatus("parity set error");
                    return;
            }
            switch (comboBox1_stop.Text)
            {
                case "0":
                    _serialPort.StopBits = StopBits.None;
                    break;
                case "1":
                    _serialPort.StopBits = StopBits.One;
                    break;
                case "1.5":
                    _serialPort.StopBits = StopBits.OnePointFive;
                    break;
                case "2":
                    _serialPort.StopBits = StopBits.Two;
                    break;
                default:
                    setStatus("stop bit set error");
                    return;
            }
            _serialPort.PortName = comboBox1_com.Text;
            _serialPort.Open();
            if (!_serialPort.IsOpen)
            {
                setStatus("port open error");
                return;
            }
            setStatus("opend " +
                _serialPort.PortName + " (" +
                _serialPort.BaudRate + "," +
                _serialPort.DataBits + "," +
                _serialPort.Parity + "," +
                _serialPort.StopBits + ")");
            cmdSend(TComCmd.cmd_ack);
        }

        private void setStatus(string s)
        {
            toolStripStatusLabel1.Text = s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmdSend(TComCmd.cmd_get_last_data);
            calibration = false;
        }

        private void GetCalibr_Click(object sender, EventArgs e)
        {
            cmdSend(TComCmd.cmd_get_last_data);
            calibration = true;
        }
        private void linear_calc()
        {
            int rs = dataGridView2.Rows.Count;
            int n = 0;
            if (rs > 1)
            {
                float sx = 0;
                float sy = 0;
                float sx2 = 0;
                float syx = 0;
                for (int i = 0; i < rs - 1; i++)
                {
                    if (null == (dataSet2.Tables[0].Rows[i][2]))
                    {
                        continue;
                    }
                    n++;
                    float x = float.Parse(dataSet2.Tables[0].Rows[i][1].ToString());
                    float y = float.Parse(dataSet2.Tables[0].Rows[i][2].ToString());
                    sx += x;
                    sx2 += x * x;
                    syx += y * x;
                    sy += y;
                }
                if (n < 2)
                {
                    linearapprox.calibrated = false;
                    return;
                }
                sx /= n;
                sx2 /= n;
                syx /= n;
                sy /= n;
                if ((sx2 - sx * sx) != 0)
                {
                    linearapprox.a = (syx - sx * sy) / (sx2 - sx * sx);
                    linearapprox.b = sy - linearapprox.a * sx;
                    formula.Text = "y = " + linearapprox.a.ToString("0.00") + "x " + (linearapprox.b < 0 ? "-" : "+") + " " + Math.Abs(linearapprox.b).ToString("0.00");
                    linearapprox.calibrated = true;
                }
            }
        }

        private void calc_linear_Click(object sender, EventArgs e)
        {
            linear_calc();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages[0])
            {
                openToolStripMenuItem.Enabled = false;
                closeToolStripMenuItem.Enabled = false;
            }
            else
            {
                openToolStripMenuItem.Enabled = true;
                closeToolStripMenuItem.Enabled = true;
            }

        }

        private void reCalc_Click(object sender, EventArgs e)
        {
            if (linearapprox.calibrated)
            {
                dataSet1.Tables[0].Columns[1].ReadOnly = false;
                for (int i = 0; i < dataSet1.Tables[0].Rows.Count; i++)
                {
                    double val = float.Parse(dataSet1.Tables[0].Rows[i][2].ToString());
                    dataSet1.Tables[0].Rows[i][1] = linearapprox.a * val + linearapprox.b;

                }
                dataSet1.Tables[0].Columns[1].ReadOnly = true;
            }
        }
    }
}
