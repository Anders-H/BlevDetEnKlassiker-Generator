namespace BlevDetEnKlassikerEditor
{
    partial class EpisodeDialog
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
            label1 = new Label();
            txtEpisodeNumber = new TextBox();
            txtList1 = new TextBox();
            label2 = new Label();
            txtYear2 = new TextBox();
            label4 = new Label();
            txtList2 = new TextBox();
            label5 = new Label();
            chkPublished = new CheckBox();
            txtPublishedDate = new TextBox();
            label6 = new Label();
            pictureBox1 = new PictureBox();
            btnOk = new Button();
            btnCancel = new Button();
            label3 = new Label();
            txtYear1 = new TextBox();
            txtLengthMinutes = new TextBox();
            label7 = new Label();
            txtLengthSeconds = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 8);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 0;
            label1.Text = "Avsnittsnummer:";
            // 
            // txtEpisodeNumber
            // 
            txtEpisodeNumber.Location = new Point(8, 24);
            txtEpisodeNumber.MaxLength = 4;
            txtEpisodeNumber.Name = "txtEpisodeNumber";
            txtEpisodeNumber.Size = new Size(128, 23);
            txtEpisodeNumber.TabIndex = 1;
            txtEpisodeNumber.Validating += txtEpisodeNumber_Validating;
            // 
            // txtList1
            // 
            txtList1.Location = new Point(8, 68);
            txtList1.MaxLength = 20;
            txtList1.Name = "txtList1";
            txtList1.Size = new Size(200, 23);
            txtList1.TabIndex = 3;
            txtList1.Validating += txtList1_Validating;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 52);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 2;
            label2.Text = "Lista 1:";
            // 
            // txtYear2
            // 
            txtYear2.Location = new Point(212, 112);
            txtYear2.MaxLength = 4;
            txtYear2.Name = "txtYear2";
            txtYear2.Size = new Size(80, 23);
            txtYear2.TabIndex = 9;
            txtYear2.Validating += txtYear2_Validating;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(212, 96);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 8;
            label4.Text = "År 2:";
            // 
            // txtList2
            // 
            txtList2.Location = new Point(8, 112);
            txtList2.MaxLength = 20;
            txtList2.Name = "txtList2";
            txtList2.Size = new Size(200, 23);
            txtList2.TabIndex = 7;
            txtList2.Validating += txtList2_Validating;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 96);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 6;
            label5.Text = "Lista 2:";
            // 
            // chkPublished
            // 
            chkPublished.AutoSize = true;
            chkPublished.Location = new Point(8, 144);
            chkPublished.Name = "chkPublished";
            chkPublished.Size = new Size(82, 19);
            chkPublished.TabIndex = 10;
            chkPublished.Text = "Publicerad";
            chkPublished.UseVisualStyleBackColor = true;
            // 
            // txtPublishedDate
            // 
            txtPublishedDate.Location = new Point(8, 184);
            txtPublishedDate.MaxLength = 10;
            txtPublishedDate.Name = "txtPublishedDate";
            txtPublishedDate.Size = new Size(116, 23);
            txtPublishedDate.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 168);
            label6.Name = "label6";
            label6.Size = new Size(104, 15);
            label6.TabIndex = 11;
            label6.Text = "Publicerad datum:";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(296, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(400, 400);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(136, 380);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 16;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(216, 380);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "Avbryt";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(212, 52);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 4;
            label3.Text = "År 1:";
            // 
            // txtYear1
            // 
            txtYear1.Location = new Point(212, 68);
            txtYear1.MaxLength = 4;
            txtYear1.Name = "txtYear1";
            txtYear1.Size = new Size(80, 23);
            txtYear1.TabIndex = 5;
            txtYear1.Validating += txtYear1_Validating;
            // 
            // txtLengthMinutes
            // 
            txtLengthMinutes.Location = new Point(8, 228);
            txtLengthMinutes.MaxLength = 4;
            txtLengthMinutes.Name = "txtLengthMinutes";
            txtLengthMinutes.Size = new Size(76, 23);
            txtLengthMinutes.TabIndex = 14;
            txtLengthMinutes.Validating += txtLengthMinutes_Validating;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(8, 212);
            label7.Name = "label7";
            label7.Size = new Size(150, 15);
            label7.TabIndex = 13;
            label7.Text = "Längd (minuter, sekunder):";
            // 
            // txtLengthSeconds
            // 
            txtLengthSeconds.Location = new Point(88, 228);
            txtLengthSeconds.MaxLength = 4;
            txtLengthSeconds.Name = "txtLengthSeconds";
            txtLengthSeconds.Size = new Size(76, 23);
            txtLengthSeconds.TabIndex = 15;
            txtLengthSeconds.Validating += txtLengthSeconds_Validating;
            // 
            // EpisodeDialog
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(701, 409);
            Controls.Add(txtLengthSeconds);
            Controls.Add(txtLengthMinutes);
            Controls.Add(label7);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(pictureBox1);
            Controls.Add(txtPublishedDate);
            Controls.Add(label6);
            Controls.Add(chkPublished);
            Controls.Add(txtYear2);
            Controls.Add(label4);
            Controls.Add(txtList2);
            Controls.Add(label5);
            Controls.Add(txtYear1);
            Controls.Add(label3);
            Controls.Add(txtList1);
            Controls.Add(label2);
            Controls.Add(txtEpisodeNumber);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "EpisodeDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Avsnitt";
            Shown += EpisodeDialog_Shown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtEpisodeNumber;
        private TextBox txtList1;
        private Label label2;
        private TextBox txtYear2;
        private Label label4;
        private TextBox txtList2;
        private Label label5;
        private CheckBox chkPublished;
        private TextBox txtPublishedDate;
        private Label label6;
        private PictureBox pictureBox1;
        private Button btnOk;
        private Button btnCancel;
        private Label label3;
        private TextBox txtYear1;
        private TextBox txtLengthMinutes;
        private Label label7;
        private TextBox txtLengthSeconds;
    }
}