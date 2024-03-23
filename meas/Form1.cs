


using System.CodeDom.Compiler;
using System.IO.Ports;
using System.Security.Policy;

namespace meas
{
    public partial class Form1 : Form
    {
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

        private static bool exchange_in_progress = false;
        private byte[] inPacket = new byte[((int)(TComPkt.len - 1) + MAXDATA)];
        private byte[] outPacket = new byte[((int)(TComPkt.len - 1) + MAXDATA)];
        public Form1()
        {
            InitializeComponent();
        }
        static readonly SerialPort _serialPort = new SerialPort();

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

        private void com_refresh()
        {
            comPorts.Items.Clear();
            comPorts.Items.AddRange(SerialPort.GetPortNames());
            if (comPorts.Items.Count > 0)
            {
                comPorts.SelectedItem = comPorts.Items[0];
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
                setStatus2("Sequence error");
                return TPacketStatus.seqErr;
            }
            switch ((TComCmd)inPacket[(int)TComPkt.cmd])
            {
                case TComCmd.cmd_ack:
                    switch ((TComAck)inPacket[(int)TComPkt.data])
                    {
                        case TComAck.com_ack:
                            setStatus2("returned ACK");
                            statusLabel.Text = "Ok!";
                            break;
                        case TComAck.com_nack:
                            setStatus2("returned NOT_ACK");
                            statusLabel.Text = "Nack!";
                            break;
                        default:
                            setStatus2("");
                            break;
                    }
                    break;
                case TComCmd.cmd_get_status:
                    measureToolStripMenuItem.Enabled = false;
                    switch ((TComStatus)inPacket[(int)TComPkt.data])
                    {
                        case TComStatus.status_ready:
                            setStatus2("Ready!");
                            measureToolStripMenuItem.Enabled = true;
                            break;
                        case TComStatus.status_measurement:
                            setStatus2("Measure in progress");
                            break;
                        case TComStatus.status_error:
                            setStatus2("Error code: " + (int)inPacket[(int)TComPkt.data + 1]);
                            break;
                        case TComStatus.status_busy:
                            setStatus2("Busy");
                            break;
                        default:
                            setStatus2("");
                            break;
                    }
                    break;
                case TComCmd.cmd_get_last_data:
                    int s = dataGridView1.Rows.Add();
                    if (s > 0)
                        dataGridView1.Rows[s].Cells[0].Value = (int)(dataGridView1.Rows[s - 1].Cells[0].Value) + 1;
                    else
                        dataGridView1.Rows[s].Cells[0].Value = 0;
                    dataGridView1.Rows[s].Cells[1].Value = DateTime.Now;
                    int num = 0;
                    for (int j = 0; j < LEN_ASCII_NUMBER; j++)
                    {
                        num *= 10;
                        num += inPacket[(int)TComPkt.data + j] - 0x30;
                    }
                    float fraq = 0;
                    for (int j = LEN_ASCII_FRACTIONAL; j > 0; j--)
                    {
                        fraq /= 10;
                        fraq += ((float)inPacket[(int)TComPkt.data + j + LEN_ASCII_NUMBER] - 0x30) / 10;
                    }
                    dataGridView1.Rows[s].Cells[2].Value = (num + fraq);
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

        private void ecitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            com_refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            com_refresh();
        }


        private void setStatus(string s)
        {
            toolStripStatusLabel1.Text = s;
        }

        private void setStatus2(string s)
        {
            toolStripStatusLabel3.Text = s;
        }
        private void Connect_Click(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
            if (comPorts.Items.Count > 0)
            {
                _serialPort.PortName = comPorts.Text;
            }
            else
            {
                setStatus("no ports found");
            }
            _serialPort.BaudRate = Int32.Parse(baudRateBox.Text);
            _serialPort.DataBits = Int32.Parse(dataBitsBox.Text);
            switch (parityBox.Text)
            {
                case "None":
                    _serialPort.Parity = Parity.None;
                    break;
                case "Odd":
                    _serialPort.Parity = Parity.Odd;
                    break;
                case "Even":
                    _serialPort.Parity = Parity.Even;
                    break;
                default:
                    setStatus("parity set error");
                    return;
            }
            switch (stopBitsBox.Text)
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
            _serialPort.PortName = comPorts.Text;
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

        private void dConnect_Click(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
            setStatus("");
        }

        private void comTimer_Tick(object sender, EventArgs e)
        {
            comTimer.Stop();
            packetBox.Text = com_read();
            comPacketHandler();
        }

        private void getStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmdSend(TComCmd.cmd_get_status);
        }

        private void timeoutBox_ValueChanged(object sender, EventArgs e)
        {
            comTimer.Interval = (int)timeoutBox.Value;

        }

        private void measureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmdSend(TComCmd.cmd_get_last_data);
        }
    }
}
