using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
        public Form1()
        {
            InitializeComponent();
            linearapprox.a = 0;
            linearapprox.b = 0;
            linearapprox.disp = 0;
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string Path = saveFileDialog1.FileName;
            dataSet1.WriteXml(Path);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataSet1.Tables[0].Rows.Add();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = dataSet1.Tables[0];
            dataGridView1.DataSource = bindingSource1;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string Path = openFileDialog1.FileName;
            dataSet1.ReadXml(Path);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            dataSet2.Tables[0].Rows.Add();

        }
    }
}
