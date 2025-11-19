namespace BlevDetEnKlassikerEditor
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            menuStrip1 = new MenuStrip();
            arkivToolStripMenuItem = new ToolStripMenuItem();
            avslutaToolStripMenuItem = new ToolStripMenuItem();
            åtgärderToolStripMenuItem = new ToolStripMenuItem();
            skapaNyttAvsnittToolStripMenuItem = new ToolStripMenuItem();
            redigeraAvsnittToolStripMenuItem = new ToolStripMenuItem();
            taBortAvsnittToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            skapaBildFörMarkeratAvsnittskrivÖverToolStripMenuItem = new ToolStripMenuItem();
            skapaBilderSomSaknasToolStripMenuItem = new ToolStripMenuItem();
            genereraSidaToolStripMenuItem = new ToolStripMenuItem();
            listView1 = new ListView();
            toolStripMenuItem2 = new ToolStripSeparator();
            omnumreraToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { arkivToolStripMenuItem, åtgärderToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(850, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // arkivToolStripMenuItem
            // 
            arkivToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { avslutaToolStripMenuItem });
            arkivToolStripMenuItem.Name = "arkivToolStripMenuItem";
            arkivToolStripMenuItem.Size = new Size(46, 20);
            arkivToolStripMenuItem.Text = "Arkiv";
            // 
            // avslutaToolStripMenuItem
            // 
            avslutaToolStripMenuItem.Name = "avslutaToolStripMenuItem";
            avslutaToolStripMenuItem.Size = new Size(113, 22);
            avslutaToolStripMenuItem.Text = "Avsluta";
            avslutaToolStripMenuItem.Click += avslutaToolStripMenuItem_Click;
            // 
            // åtgärderToolStripMenuItem
            // 
            åtgärderToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { skapaNyttAvsnittToolStripMenuItem, redigeraAvsnittToolStripMenuItem, taBortAvsnittToolStripMenuItem, toolStripMenuItem1, omnumreraToolStripMenuItem, toolStripMenuItem2, skapaBildFörMarkeratAvsnittskrivÖverToolStripMenuItem, skapaBilderSomSaknasToolStripMenuItem, genereraSidaToolStripMenuItem });
            åtgärderToolStripMenuItem.Name = "åtgärderToolStripMenuItem";
            åtgärderToolStripMenuItem.Size = new Size(65, 20);
            åtgärderToolStripMenuItem.Text = "Åtgärder";
            // 
            // skapaNyttAvsnittToolStripMenuItem
            // 
            skapaNyttAvsnittToolStripMenuItem.Name = "skapaNyttAvsnittToolStripMenuItem";
            skapaNyttAvsnittToolStripMenuItem.Size = new Size(295, 22);
            skapaNyttAvsnittToolStripMenuItem.Text = "Skapa nytt avsnitt";
            skapaNyttAvsnittToolStripMenuItem.Click += skapaNyttAvsnittToolStripMenuItem_Click;
            // 
            // redigeraAvsnittToolStripMenuItem
            // 
            redigeraAvsnittToolStripMenuItem.Name = "redigeraAvsnittToolStripMenuItem";
            redigeraAvsnittToolStripMenuItem.Size = new Size(295, 22);
            redigeraAvsnittToolStripMenuItem.Text = "Redigera avsnitt...";
            redigeraAvsnittToolStripMenuItem.Click += redigeraAvsnittToolStripMenuItem_Click;
            // 
            // taBortAvsnittToolStripMenuItem
            // 
            taBortAvsnittToolStripMenuItem.Name = "taBortAvsnittToolStripMenuItem";
            taBortAvsnittToolStripMenuItem.Size = new Size(295, 22);
            taBortAvsnittToolStripMenuItem.Text = "Ta bort avsnitt";
            taBortAvsnittToolStripMenuItem.Click += taBortAvsnittToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(292, 6);
            // 
            // skapaBildFörMarkeratAvsnittskrivÖverToolStripMenuItem
            // 
            skapaBildFörMarkeratAvsnittskrivÖverToolStripMenuItem.Name = "skapaBildFörMarkeratAvsnittskrivÖverToolStripMenuItem";
            skapaBildFörMarkeratAvsnittskrivÖverToolStripMenuItem.Size = new Size(295, 22);
            skapaBildFörMarkeratAvsnittskrivÖverToolStripMenuItem.Text = "Skapa bild för markerat avsnitt (skriv över)";
            skapaBildFörMarkeratAvsnittskrivÖverToolStripMenuItem.Click += skapaBildFörMarkeratAvsnittskrivÖverToolStripMenuItem_Click;
            // 
            // skapaBilderSomSaknasToolStripMenuItem
            // 
            skapaBilderSomSaknasToolStripMenuItem.Name = "skapaBilderSomSaknasToolStripMenuItem";
            skapaBilderSomSaknasToolStripMenuItem.Size = new Size(295, 22);
            skapaBilderSomSaknasToolStripMenuItem.Text = "Skapa bilder som saknas";
            skapaBilderSomSaknasToolStripMenuItem.Click += skapaBilderSomSaknasToolStripMenuItem_Click;
            // 
            // genereraSidaToolStripMenuItem
            // 
            genereraSidaToolStripMenuItem.Name = "genereraSidaToolStripMenuItem";
            genereraSidaToolStripMenuItem.Size = new Size(295, 22);
            genereraSidaToolStripMenuItem.Text = "Generera sida";
            genereraSidaToolStripMenuItem.Click += genereraSidaToolStripMenuItem_Click;
            // 
            // listView1
            // 
            listView1.Dock = DockStyle.Fill;
            listView1.FullRowSelect = true;
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView1.Location = new Point(0, 24);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(850, 475);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.MouseDoubleClick += listView1_MouseDoubleClick;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(292, 6);
            // 
            // omnumreraToolStripMenuItem
            // 
            omnumreraToolStripMenuItem.Name = "omnumreraToolStripMenuItem";
            omnumreraToolStripMenuItem.Size = new Size(295, 22);
            omnumreraToolStripMenuItem.Text = "Omnumrera";
            omnumreraToolStripMenuItem.Click += omnumreraToolStripMenuItem_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 499);
            Controls.Add(listView1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "MainWindow";
            Text = "Blev det en klassiker?";
            Load += MainWindow_Load;
            Shown += MainWindow_Shown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ListView listView1;
        private ToolStripMenuItem arkivToolStripMenuItem;
        private ToolStripMenuItem avslutaToolStripMenuItem;
        private ToolStripMenuItem åtgärderToolStripMenuItem;
        private ToolStripMenuItem skapaBilderSomSaknasToolStripMenuItem;
        private ToolStripMenuItem genereraSidaToolStripMenuItem;
        private ToolStripMenuItem skapaNyttAvsnittToolStripMenuItem;
        private ToolStripMenuItem skapaBildFörMarkeratAvsnittskrivÖverToolStripMenuItem;
        private ToolStripMenuItem redigeraAvsnittToolStripMenuItem;
        private ToolStripMenuItem taBortAvsnittToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem omnumreraToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
    }
}
