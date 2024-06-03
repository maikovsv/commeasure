namespace meas
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveXmlToolStripMenuItem = new ToolStripMenuItem();
            openXmlToolStripMenuItem = new ToolStripMenuItem();
            separaToolStripMenuItem = new ToolStripSeparator();
            ecitToolStripMenuItem = new ToolStripMenuItem();
            deviceToolStripMenuItem = new ToolStripMenuItem();
            connectToolStripMenuItem = new ToolStripMenuItem();
            getStatusToolStripMenuItem = new ToolStripMenuItem();
            measureToolStripMenuItem = new ToolStripMenuItem();
            getDataToolStripMenuItem = new ToolStripMenuItem();
            calibrationToolStripMenuItem = new ToolStripMenuItem();
            getToolStripMenuItem = new ToolStripMenuItem();
            add0ToolStripMenuItem = new ToolStripMenuItem();
            separator2ToolStripMenuItem = new ToolStripSeparator();
            linearToolStripMenuItem = new ToolStripMenuItem();
            cubicToolStripMenuItem = new ToolStripMenuItem();
            expToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            toolStripStatusLabel4 = new ToolStripStatusLabel();
            toolStripStatusLabel5 = new ToolStripStatusLabel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            timeoutBox = new NumericUpDown();
            label9 = new Label();
            dConnect = new Button();
            button2 = new Button();
            typeLabel = new Label();
            IDLabel = new Label();
            statusLabel = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            Connect = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            stopBitsBox = new ComboBox();
            parityBox = new ComboBox();
            dataBitsBox = new TextBox();
            label2 = new Label();
            baudRateBox = new TextBox();
            label1 = new Label();
            comPorts = new ComboBox();
            tabPage2 = new TabPage();
            dataGridView1 = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            time = new DataGridViewTextBoxColumn();
            res = new DataGridViewTextBoxColumn();
            k = new DataGridViewTextBoxColumn();
            val = new DataGridViewTextBoxColumn();
            tabPage3 = new TabPage();
            label10 = new Label();
            dataGridView2 = new DataGridView();
            IdCal = new DataGridViewTextBoxColumn();
            Use = new DataGridViewCheckBoxColumn();
            Measure = new DataGridViewTextBoxColumn();
            ValueCal = new DataGridViewTextBoxColumn();
            comTimer = new System.Windows.Forms.Timer(components);
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)timeoutBox).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, deviceToolStripMenuItem, calibrationToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(914, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveXmlToolStripMenuItem, openXmlToolStripMenuItem, separaToolStripMenuItem, ecitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveXmlToolStripMenuItem
            // 
            saveXmlToolStripMenuItem.Name = "saveXmlToolStripMenuItem";
            saveXmlToolStripMenuItem.Size = new Size(128, 26);
            saveXmlToolStripMenuItem.Text = "Save";
            saveXmlToolStripMenuItem.Click += saveXmlToolStripMenuItem_Click;
            // 
            // openXmlToolStripMenuItem
            // 
            openXmlToolStripMenuItem.Name = "openXmlToolStripMenuItem";
            openXmlToolStripMenuItem.Size = new Size(128, 26);
            openXmlToolStripMenuItem.Text = "Open";
            openXmlToolStripMenuItem.Click += openXmlToolStripMenuItem_Click;
            // 
            // separaToolStripMenuItem
            // 
            separaToolStripMenuItem.Name = "separaToolStripMenuItem";
            separaToolStripMenuItem.Size = new Size(125, 6);
            // 
            // ecitToolStripMenuItem
            // 
            ecitToolStripMenuItem.Name = "ecitToolStripMenuItem";
            ecitToolStripMenuItem.Size = new Size(128, 26);
            ecitToolStripMenuItem.Text = "Exit";
            ecitToolStripMenuItem.Click += ecitToolStripMenuItem_Click;
            // 
            // deviceToolStripMenuItem
            // 
            deviceToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { connectToolStripMenuItem, getStatusToolStripMenuItem, measureToolStripMenuItem, getDataToolStripMenuItem });
            deviceToolStripMenuItem.Name = "deviceToolStripMenuItem";
            deviceToolStripMenuItem.Size = new Size(68, 24);
            deviceToolStripMenuItem.Text = "Device";
            // 
            // connectToolStripMenuItem
            // 
            connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            connectToolStripMenuItem.Size = new Size(157, 26);
            connectToolStripMenuItem.Text = "Connect";
            connectToolStripMenuItem.Click += connectToolStripMenuItem_Click;
            // 
            // getStatusToolStripMenuItem
            // 
            getStatusToolStripMenuItem.Name = "getStatusToolStripMenuItem";
            getStatusToolStripMenuItem.Size = new Size(157, 26);
            getStatusToolStripMenuItem.Text = "Get status";
            getStatusToolStripMenuItem.Click += getStatusToolStripMenuItem_Click;
            // 
            // measureToolStripMenuItem
            // 
            measureToolStripMenuItem.Name = "measureToolStripMenuItem";
            measureToolStripMenuItem.Size = new Size(157, 26);
            measureToolStripMenuItem.Text = "Measure";
            measureToolStripMenuItem.Click += measureToolStripMenuItem_Click;
            // 
            // getDataToolStripMenuItem
            // 
            getDataToolStripMenuItem.Name = "getDataToolStripMenuItem";
            getDataToolStripMenuItem.Size = new Size(157, 26);
            getDataToolStripMenuItem.Text = "Get data";
            getDataToolStripMenuItem.Click += getDataToolStripMenuItem_Click;
            // 
            // calibrationToolStripMenuItem
            // 
            calibrationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { getToolStripMenuItem, add0ToolStripMenuItem, separator2ToolStripMenuItem, linearToolStripMenuItem, cubicToolStripMenuItem, expToolStripMenuItem });
            calibrationToolStripMenuItem.Name = "calibrationToolStripMenuItem";
            calibrationToolStripMenuItem.Size = new Size(96, 24);
            calibrationToolStripMenuItem.Text = "Calibration";
            // 
            // getToolStripMenuItem
            // 
            getToolStripMenuItem.Name = "getToolStripMenuItem";
            getToolStripMenuItem.Size = new Size(175, 26);
            getToolStripMenuItem.Text = "Get measure";
            getToolStripMenuItem.Click += getToolStripMenuItem_Click;
            // 
            // add0ToolStripMenuItem
            // 
            add0ToolStripMenuItem.Name = "add0ToolStripMenuItem";
            add0ToolStripMenuItem.Size = new Size(175, 26);
            add0ToolStripMenuItem.Text = "Force (0;0)";
            add0ToolStripMenuItem.Click += add0ToolStripMenuItem_Click;
            // 
            // separator2ToolStripMenuItem
            // 
            separator2ToolStripMenuItem.Name = "separator2ToolStripMenuItem";
            separator2ToolStripMenuItem.Size = new Size(172, 6);
            // 
            // linearToolStripMenuItem
            // 
            linearToolStripMenuItem.Name = "linearToolStripMenuItem";
            linearToolStripMenuItem.Size = new Size(175, 26);
            linearToolStripMenuItem.Text = "Linear";
            linearToolStripMenuItem.Click += linearToolStripMenuItem_Click;
            // 
            // cubicToolStripMenuItem
            // 
            cubicToolStripMenuItem.Enabled = false;
            cubicToolStripMenuItem.Name = "cubicToolStripMenuItem";
            cubicToolStripMenuItem.Size = new Size(175, 26);
            cubicToolStripMenuItem.Text = "Cubic";
            // 
            // expToolStripMenuItem
            // 
            expToolStripMenuItem.Enabled = false;
            expToolStripMenuItem.Name = "expToolStripMenuItem";
            expToolStripMenuItem.Size = new Size(175, 26);
            expToolStripMenuItem.Text = "Exp";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2, toolStripStatusLabel3, toolStripStatusLabel4, toolStripStatusLabel5 });
            statusStrip1.Location = new Point(0, 574);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(914, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 20);
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(13, 20);
            toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(0, 20);
            // 
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new Size(98, 20);
            toolStripStatusLabel4.Text = "| Last packet: ";
            // 
            // toolStripStatusLabel5
            // 
            toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            toolStripStatusLabel5.Size = new Size(21, 20);
            toolStripStatusLabel5.Text = "__";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 30);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(914, 544);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(timeoutBox);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(dConnect);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(typeLabel);
            tabPage1.Controls.Add(IDLabel);
            tabPage1.Controls.Add(statusLabel);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(Connect);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(stopBitsBox);
            tabPage1.Controls.Add(parityBox);
            tabPage1.Controls.Add(dataBitsBox);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(baudRateBox);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(comPorts);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(906, 511);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Device";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // timeoutBox
            // 
            timeoutBox.Location = new Point(97, 201);
            timeoutBox.Margin = new Padding(3, 4, 3, 4);
            timeoutBox.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            timeoutBox.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            timeoutBox.Name = "timeoutBox";
            timeoutBox.Size = new Size(64, 27);
            timeoutBox.TabIndex = 6;
            timeoutBox.Value = new decimal(new int[] { 200, 0, 0, 0 });
            timeoutBox.ValueChanged += timeoutBox_ValueChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(9, 205);
            label9.Name = "label9";
            label9.Size = new Size(100, 20);
            label9.TabIndex = 19;
            label9.Text = "Timeout (ms):";
            // 
            // dConnect
            // 
            dConnect.Location = new Point(201, 161);
            dConnect.Margin = new Padding(3, 4, 3, 4);
            dConnect.Name = "dConnect";
            dConnect.Size = new Size(86, 31);
            dConnect.TabIndex = 11;
            dConnect.Text = "Disconnect";
            dConnect.UseVisualStyleBackColor = true;
            dConnect.Click += dConnect_Click;
            // 
            // button2
            // 
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(168, 8);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(26, 31);
            button2.TabIndex = 1;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // typeLabel
            // 
            typeLabel.AutoSize = true;
            typeLabel.Location = new Point(282, 89);
            typeLabel.Name = "typeLabel";
            typeLabel.Size = new Size(36, 20);
            typeLabel.TabIndex = 16;
            typeLabel.Text = "N/A";
            // 
            // IDLabel
            // 
            IDLabel.AutoSize = true;
            IDLabel.Location = new Point(282, 51);
            IDLabel.Name = "IDLabel";
            IDLabel.Size = new Size(36, 20);
            IDLabel.TabIndex = 15;
            IDLabel.Text = "N/A";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(282, 12);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(107, 20);
            statusLabel.TabIndex = 14;
            statusLabel.Text = "Not connected";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(201, 89);
            label8.Name = "label8";
            label8.Size = new Size(40, 20);
            label8.TabIndex = 13;
            label8.Text = "Type";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(201, 51);
            label7.Name = "label7";
            label7.Size = new Size(24, 20);
            label7.TabIndex = 12;
            label7.Text = "ID";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(201, 12);
            label6.Name = "label6";
            label6.Size = new Size(49, 20);
            label6.TabIndex = 11;
            label6.Text = "Status";
            // 
            // Connect
            // 
            Connect.Location = new Point(201, 123);
            Connect.Margin = new Padding(3, 4, 3, 4);
            Connect.Name = "Connect";
            Connect.Size = new Size(86, 31);
            Connect.TabIndex = 10;
            Connect.Text = "Connect";
            Connect.UseVisualStyleBackColor = true;
            Connect.Click += Connect_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 167);
            label5.Name = "label5";
            label5.Size = new Size(71, 20);
            label5.TabIndex = 9;
            label5.Text = "Stop bits:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 128);
            label4.Name = "label4";
            label4.Size = new Size(48, 20);
            label4.TabIndex = 8;
            label4.Text = "Parity:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 89);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 7;
            label3.Text = "Data bits:";
            // 
            // stopBitsBox
            // 
            stopBitsBox.FormattingEnabled = true;
            stopBitsBox.Items.AddRange(new object[] { "0", "1", "1.5", "2" });
            stopBitsBox.Location = new Point(97, 163);
            stopBitsBox.Margin = new Padding(3, 4, 3, 4);
            stopBitsBox.Name = "stopBitsBox";
            stopBitsBox.Size = new Size(63, 28);
            stopBitsBox.TabIndex = 5;
            stopBitsBox.Text = "1";
            // 
            // parityBox
            // 
            parityBox.FormattingEnabled = true;
            parityBox.Items.AddRange(new object[] { "None", "Odd", "Even" });
            parityBox.Location = new Point(97, 124);
            parityBox.Margin = new Padding(3, 4, 3, 4);
            parityBox.Name = "parityBox";
            parityBox.Size = new Size(63, 28);
            parityBox.TabIndex = 4;
            parityBox.Text = "None";
            // 
            // dataBitsBox
            // 
            dataBitsBox.Location = new Point(97, 85);
            dataBitsBox.Margin = new Padding(3, 4, 3, 4);
            dataBitsBox.Name = "dataBitsBox";
            dataBitsBox.Size = new Size(63, 27);
            dataBitsBox.TabIndex = 3;
            dataBitsBox.Text = "8";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 51);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 3;
            label2.Text = "Baud (b/s):";
            // 
            // baudRateBox
            // 
            baudRateBox.Location = new Point(97, 47);
            baudRateBox.Margin = new Padding(3, 4, 3, 4);
            baudRateBox.Name = "baudRateBox";
            baudRateBox.Size = new Size(63, 27);
            baudRateBox.TabIndex = 2;
            baudRateBox.Text = "115200";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 12);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 1;
            label1.Text = "Port:";
            // 
            // comPorts
            // 
            comPorts.FormattingEnabled = true;
            comPorts.Location = new Point(53, 8);
            comPorts.Margin = new Padding(3, 4, 3, 4);
            comPorts.Name = "comPorts";
            comPorts.Size = new Size(108, 28);
            comPorts.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(906, 506);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Measure";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, time, res, k, val });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 4);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(900, 498);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // id
            // 
            id.HeaderText = "id";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.ReadOnly = true;
            id.Width = 125;
            // 
            // time
            // 
            time.HeaderText = "time";
            time.MinimumWidth = 6;
            time.Name = "time";
            time.ReadOnly = true;
            time.Width = 125;
            // 
            // res
            // 
            res.HeaderText = "res";
            res.MinimumWidth = 6;
            res.Name = "res";
            res.ReadOnly = true;
            res.Width = 125;
            // 
            // k
            // 
            k.HeaderText = "k";
            k.MinimumWidth = 6;
            k.Name = "k";
            k.Width = 125;
            // 
            // val
            // 
            val.HeaderText = "val";
            val.MinimumWidth = 6;
            val.Name = "val";
            val.ReadOnly = true;
            val.Width = 125;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label10);
            tabPage3.Controls.Add(dataGridView2);
            tabPage3.ImeMode = ImeMode.NoControl;
            tabPage3.Location = new Point(4, 29);
            tabPage3.Margin = new Padding(3, 4, 3, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(906, 506);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Calibration";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(721, 49);
            label10.Name = "label10";
            label10.Size = new Size(60, 20);
            label10.TabIndex = 1;
            label10.Text = "y=ax+b";
            // 
            // dataGridView2
            // 
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { IdCal, Use, Measure, ValueCal });
            dataGridView2.Location = new Point(3, 4);
            dataGridView2.Margin = new Padding(3, 4, 3, 4);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(695, 493);
            dataGridView2.TabIndex = 0;
            // 
            // IdCal
            // 
            IdCal.Frozen = true;
            IdCal.HeaderText = "Id";
            IdCal.MinimumWidth = 6;
            IdCal.Name = "IdCal";
            IdCal.ReadOnly = true;
            IdCal.Width = 125;
            // 
            // Use
            // 
            Use.HeaderText = "Use";
            Use.MinimumWidth = 6;
            Use.Name = "Use";
            Use.Width = 125;
            // 
            // Measure
            // 
            Measure.HeaderText = "Measure";
            Measure.MinimumWidth = 6;
            Measure.Name = "Measure";
            Measure.Width = 125;
            // 
            // ValueCal
            // 
            ValueCal.HeaderText = "Value";
            ValueCal.MinimumWidth = 6;
            ValueCal.Name = "ValueCal";
            ValueCal.Width = 125;
            // 
            // comTimer
            // 
            comTimer.Tick += comTimer_Tick;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.Filter = "CSV - файлы (*.csv)|*.csv|TXT - файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog1.FileOk += saveFileDialog1_FileOk;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "CSV - файлы (*.csv)|*.csv|TXT - файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(tabControl1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Magnetic measure device";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)timeoutBox).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveXmlToolStripMenuItem;
        private ToolStripMenuItem openXmlToolStripMenuItem;
        private ToolStripMenuItem deviceToolStripMenuItem;
        private ToolStripSeparator separaToolStripMenuItem;
        private ToolStripMenuItem ecitToolStripMenuItem;
        private StatusStrip statusStrip1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TextBox dataBitsBox;
        private Label label2;
        private TextBox baudRateBox;
        private Label label1;
        private ComboBox comPorts;
        private ComboBox parityBox;
        private Label label5;
        private Label label4;
        private Label label3;
        private ComboBox stopBitsBox;
        private Label statusLabel;
        private Label label8;
        private Label label7;
        private Label label6;
        private Button Connect;
        private Button button2;
        private Label typeLabel;
        private Label IDLabel;
        private Button dConnect;
        private Label label9;
        private System.Windows.Forms.Timer comTimer;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripMenuItem measureToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripMenuItem getStatusToolStripMenuItem;
        private NumericUpDown timeoutBox;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn time;
        private DataGridViewTextBoxColumn res;
        private DataGridViewTextBoxColumn k;
        private DataGridViewTextBoxColumn val;
        private ToolStripMenuItem getDataToolStripMenuItem;
        private ToolStripMenuItem connectToolStripMenuItem;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private ToolStripStatusLabel toolStripStatusLabel4;
        private ToolStripStatusLabel toolStripStatusLabel5;
        private ToolStripMenuItem calibrationToolStripMenuItem;
        private ToolStripMenuItem linearToolStripMenuItem;
        private ToolStripMenuItem cubicToolStripMenuItem;
        private ToolStripMenuItem expToolStripMenuItem;
        private DataGridView dataGridView2;
        private ToolStripMenuItem getToolStripMenuItem;
        private ToolStripSeparator separator2ToolStripMenuItem;
        private DataGridViewTextBoxColumn IdCal;
        private DataGridViewCheckBoxColumn Use;
        private DataGridViewTextBoxColumn Measure;
        private DataGridViewTextBoxColumn ValueCal;
        private ToolStripMenuItem add0ToolStripMenuItem;
        private Label label10;
    }
}
