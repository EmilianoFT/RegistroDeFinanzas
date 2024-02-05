namespace RegistroDeFinanzas.forms
{
    partial class FrmCargaDatos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnOfd = new Button();
            txtPath = new TextBox();
            Ofd = new OpenFileDialog();
            button1 = new Button();
            groupBox1 = new GroupBox();
            lblCPM = new Label();
            label12 = new Label();
            lblCMTUDST = new Label();
            label8 = new Label();
            lblCMTARS = new Label();
            label3 = new Label();
            dgCompras = new DataGridView();
            groupBox2 = new GroupBox();
            dgVentas = new DataGridView();
            lblVPM = new Label();
            lblVMTUDST = new Label();
            lblVMTARS = new Label();
            label4 = new Label();
            label7 = new Label();
            label11 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            groupBox3 = new GroupBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgCompras).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgVentas).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // btnOfd
            // 
            btnOfd.Location = new Point(1004, 12);
            btnOfd.Name = "btnOfd";
            btnOfd.Size = new Size(27, 23);
            btnOfd.TabIndex = 0;
            btnOfd.Text = "...";
            btnOfd.UseVisualStyleBackColor = true;
            btnOfd.Click += btnOfd_Click;
            // 
            // txtPath
            // 
            txtPath.Location = new Point(12, 12);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(986, 23);
            txtPath.TabIndex = 1;
            // 
            // Ofd
            // 
            Ofd.FileOk += Ofd_FileOk;
            // 
            // button1
            // 
            button1.Location = new Point(1073, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 19;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblCPM);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(lblCMTUDST);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(lblCMTARS);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dgCompras);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.Blue;
            groupBox1.Location = new Point(12, 49);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(576, 500);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "Compra";
            // 
            // lblCPM
            // 
            lblCPM.AutoSize = true;
            lblCPM.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCPM.ForeColor = Color.Green;
            lblCPM.Location = new Point(175, 84);
            lblCPM.Name = "lblCPM";
            lblCPM.Size = new Size(69, 15);
            lblCPM.TabIndex = 23;
            lblCPM.Text = "$ 00000,00";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 79);
            label12.Name = "label12";
            label12.Size = new Size(128, 20);
            label12.TabIndex = 22;
            label12.Text = "Precio Promedio:";
            // 
            // lblCMTUDST
            // 
            lblCMTUDST.AutoSize = true;
            lblCMTUDST.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCMTUDST.ForeColor = Color.Blue;
            lblCMTUDST.Location = new Point(175, 56);
            lblCMTUDST.Name = "lblCMTUDST";
            lblCMTUDST.Size = new Size(69, 15);
            lblCMTUDST.TabIndex = 21;
            lblCMTUDST.Text = "$ 00000,00";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 52);
            label8.Name = "label8";
            label8.Size = new Size(151, 20);
            label8.TabIndex = 20;
            label8.Text = "Monto total (USDT):";
            // 
            // lblCMTARS
            // 
            lblCMTARS.AutoSize = true;
            lblCMTARS.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCMTARS.ForeColor = Color.Red;
            lblCMTARS.Location = new Point(175, 29);
            lblCMTARS.Name = "lblCMTARS";
            lblCMTARS.Size = new Size(69, 15);
            lblCMTARS.TabIndex = 19;
            lblCMTARS.Text = "$ 00000,00";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 25);
            label3.Name = "label3";
            label3.Size = new Size(142, 20);
            label3.TabIndex = 18;
            label3.Text = "Monto total (ARS):";
            // 
            // dgCompras
            // 
            dgCompras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgCompras.Location = new Point(6, 102);
            dgCompras.Name = "dgCompras";
            dgCompras.RowTemplate.Height = 25;
            dgCompras.Size = new Size(564, 392);
            dgCompras.TabIndex = 17;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgVentas);
            groupBox2.Controls.Add(lblVPM);
            groupBox2.Controls.Add(lblVMTUDST);
            groupBox2.Controls.Add(lblVMTARS);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label11);
            groupBox2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.ForeColor = Color.Crimson;
            groupBox2.Location = new Point(594, 49);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(576, 500);
            groupBox2.TabIndex = 21;
            groupBox2.TabStop = false;
            groupBox2.Text = "Venta";
            // 
            // dgVentas
            // 
            dgVentas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dgVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgVentas.Location = new Point(6, 102);
            dgVentas.Name = "dgVentas";
            dgVentas.RowTemplate.Height = 25;
            dgVentas.Size = new Size(564, 392);
            dgVentas.TabIndex = 26;
            // 
            // lblVPM
            // 
            lblVPM.AutoSize = true;
            lblVPM.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblVPM.ForeColor = Color.Green;
            lblVPM.Location = new Point(197, 83);
            lblVPM.Name = "lblVPM";
            lblVPM.Size = new Size(69, 15);
            lblVPM.TabIndex = 25;
            lblVPM.Text = "$ 00000,00";
            // 
            // lblVMTUDST
            // 
            lblVMTUDST.AutoSize = true;
            lblVMTUDST.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblVMTUDST.ForeColor = Color.Blue;
            lblVMTUDST.Location = new Point(197, 56);
            lblVMTUDST.Name = "lblVMTUDST";
            lblVMTUDST.Size = new Size(69, 15);
            lblVMTUDST.TabIndex = 24;
            lblVMTUDST.Text = "$ 00000,00";
            // 
            // lblVMTARS
            // 
            lblVMTARS.AutoSize = true;
            lblVMTARS.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblVMTARS.ForeColor = Color.Red;
            lblVMTARS.Location = new Point(197, 29);
            lblVMTARS.Name = "lblVMTARS";
            lblVMTARS.Size = new Size(69, 15);
            lblVMTARS.TabIndex = 23;
            lblVMTARS.Text = "$ 00000,00";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 79);
            label4.Name = "label4";
            label4.Size = new Size(128, 20);
            label4.TabIndex = 22;
            label4.Text = "Precio Promedio:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 52);
            label7.Name = "label7";
            label7.Size = new Size(151, 20);
            label7.TabIndex = 20;
            label7.Text = "Monto total (USDT):";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 25);
            label11.Name = "label11";
            label11.Size = new Size(142, 20);
            label11.TabIndex = 18;
            label11.Text = "Monto total (ARS):";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(1176, 58);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(554, 890);
            tabControl1.TabIndex = 22;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(546, 862);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(192, 72);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Location = new Point(12, 552);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1158, 396);
            groupBox3.TabIndex = 23;
            groupBox3.TabStop = false;
            groupBox3.Text = "Resumen";
            // 
            // FrmCargaDatos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1742, 960);
            Controls.Add(groupBox3);
            Controls.Add(tabControl1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(txtPath);
            Controls.Add(btnOfd);
            MinimumSize = new Size(1758, 999);
            Name = "FrmCargaDatos";
            Text = "FrmCargaDatos";
            Activated += FrmCargaDatos_Activated;
            Load += FrmCargaDatos_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgCompras).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgVentas).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOfd;
        private TextBox txtPath;
        private OpenFileDialog Ofd;
        private Button button1;
        private GroupBox groupBox1;
        private Label lblCPM;
        private Label label12;
        private Label lblCMTUDST;
        private Label label8;
        private Label lblCMTARS;
        private Label label3;
        private DataGridView dgCompras;
        private GroupBox groupBox2;
        private DataGridView dgVentas;
        private Label lblVPM;
        private Label lblVMTUDST;
        private Label lblVMTARS;
        private Label label4;
        private Label label7;
        private Label label11;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox groupBox3;
    }
}