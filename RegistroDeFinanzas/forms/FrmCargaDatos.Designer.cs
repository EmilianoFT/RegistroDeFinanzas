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
            dgCompras = new DataGridView();
            dgVentas = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblCMTARS = new Label();
            lblVMTARS = new Label();
            label6 = new Label();
            lblCMTUDST = new Label();
            label8 = new Label();
            lblVMTUDST = new Label();
            label10 = new Label();
            lblCPM = new Label();
            label12 = new Label();
            lblVPM = new Label();
            label14 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgCompras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgVentas).BeginInit();
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
            // dgCompras
            // 
            dgCompras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgCompras.Location = new Point(12, 92);
            dgCompras.Name = "dgCompras";
            dgCompras.RowTemplate.Height = 25;
            dgCompras.Size = new Size(554, 346);
            dgCompras.TabIndex = 2;
            dgCompras.CellContentClick += dgCompras_CellContentClick;
            // 
            // dgVentas
            // 
            dgVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgVentas.Location = new Point(594, 92);
            dgVentas.Name = "dgVentas";
            dgVentas.RowTemplate.Height = 25;
            dgVentas.Size = new Size(554, 346);
            dgVentas.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(12, 49);
            label1.Name = "label1";
            label1.Size = new Size(70, 21);
            label1.TabIndex = 4;
            label1.Text = "Compra";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(594, 49);
            label2.Name = "label2";
            label2.Size = new Size(54, 21);
            label2.TabIndex = 5;
            label2.Text = "Venta";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 74);
            label3.Name = "label3";
            label3.Size = new Size(105, 15);
            label3.TabIndex = 6;
            label3.Text = "Monto total (ARS):";
            // 
            // lblCMTARS
            // 
            lblCMTARS.AutoSize = true;
            lblCMTARS.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCMTARS.ForeColor = Color.Red;
            lblCMTARS.Location = new Point(113, 74);
            lblCMTARS.Name = "lblCMTARS";
            lblCMTARS.Size = new Size(69, 15);
            lblCMTARS.TabIndex = 8;
            lblCMTARS.Text = "$ 00000,00";
            lblCMTARS.Click += label5_Click;
            // 
            // lblVMTARS
            // 
            lblVMTARS.AutoSize = true;
            lblVMTARS.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblVMTARS.ForeColor = Color.Red;
            lblVMTARS.Location = new Point(695, 74);
            lblVMTARS.Name = "lblVMTARS";
            lblVMTARS.Size = new Size(69, 15);
            lblVMTARS.TabIndex = 10;
            lblVMTARS.Text = "$ 00000,00";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(594, 74);
            label6.Name = "label6";
            label6.Size = new Size(105, 15);
            label6.TabIndex = 9;
            label6.Text = "Monto total (ARS):";
            // 
            // lblCMTUDST
            // 
            lblCMTUDST.AutoSize = true;
            lblCMTUDST.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCMTUDST.ForeColor = Color.Blue;
            lblCMTUDST.Location = new Point(326, 74);
            lblCMTUDST.Name = "lblCMTUDST";
            lblCMTUDST.Size = new Size(69, 15);
            lblCMTUDST.TabIndex = 12;
            lblCMTUDST.Text = "$ 00000,00";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(219, 74);
            label8.Name = "label8";
            label8.Size = new Size(111, 15);
            label8.TabIndex = 11;
            label8.Text = "Monto total (USDT):";
            // 
            // lblVMTUDST
            // 
            lblVMTUDST.AutoSize = true;
            lblVMTUDST.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblVMTUDST.ForeColor = Color.Blue;
            lblVMTUDST.Location = new Point(916, 74);
            lblVMTUDST.Name = "lblVMTUDST";
            lblVMTUDST.Size = new Size(69, 15);
            lblVMTUDST.TabIndex = 14;
            lblVMTUDST.Text = "$ 00000,00";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(810, 74);
            label10.Name = "label10";
            label10.Size = new Size(111, 15);
            label10.TabIndex = 13;
            label10.Text = "Monto total (USDT):";
            // 
            // lblCPM
            // 
            lblCPM.AutoSize = true;
            lblCPM.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCPM.ForeColor = Color.Green;
            lblCPM.Location = new Point(495, 74);
            lblCPM.Name = "lblCPM";
            lblCPM.Size = new Size(69, 15);
            lblCPM.TabIndex = 16;
            lblCPM.Text = "$ 00000,00";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(401, 74);
            label12.Name = "label12";
            label12.Size = new Size(98, 15);
            label12.TabIndex = 15;
            label12.Text = "Precio Promedio:";
            // 
            // lblVPM
            // 
            lblVPM.AutoSize = true;
            lblVPM.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblVPM.ForeColor = Color.Green;
            lblVPM.Location = new Point(1077, 74);
            lblVPM.Name = "lblVPM";
            lblVPM.Size = new Size(69, 15);
            lblVPM.TabIndex = 18;
            lblVPM.Text = "$ 00000,00";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(984, 74);
            label14.Name = "label14";
            label14.Size = new Size(98, 15);
            label14.TabIndex = 17;
            label14.Text = "Precio Promedio:";
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
            // FrmCargaDatos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1160, 450);
            Controls.Add(button1);
            Controls.Add(lblVPM);
            Controls.Add(label14);
            Controls.Add(lblCPM);
            Controls.Add(label12);
            Controls.Add(lblVMTUDST);
            Controls.Add(label10);
            Controls.Add(lblCMTUDST);
            Controls.Add(label8);
            Controls.Add(lblVMTARS);
            Controls.Add(label6);
            Controls.Add(lblCMTARS);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgVentas);
            Controls.Add(dgCompras);
            Controls.Add(txtPath);
            Controls.Add(btnOfd);
            Name = "FrmCargaDatos";
            Text = "FrmCargaDatos";
            Load += FrmCargaDatos_Load;
            ((System.ComponentModel.ISupportInitialize)dgCompras).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOfd;
        private TextBox txtPath;
        private OpenFileDialog Ofd;
        private DataGridView dgCompras;
        private DataGridView dgVentas;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblCMTARS;
        private Label lblVMTARS;
        private Label label6;
        private Label lblCMTUDST;
        private Label label8;
        private Label lblVMTUDST;
        private Label label10;
        private Label lblCPM;
        private Label label12;
        private Label lblVPM;
        private Label label14;
        private Button button1;
    }
}