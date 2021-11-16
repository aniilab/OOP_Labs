
namespace LabXML
{
    partial class XMLForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XMLForm));
            this.nameCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.realeseDateCheckBox = new System.Windows.Forms.CheckBox();
            this.genreCheckBox = new System.Windows.Forms.CheckBox();
            this.timeCheckBox = new System.Windows.Forms.CheckBox();
            this.budgetCheckBox = new System.Windows.Forms.CheckBox();
            this.productionCheckBox = new System.Windows.Forms.CheckBox();
            this.countryCheckBox = new System.Windows.Forms.CheckBox();
            this.watchedCheckBox = new System.Windows.Forms.CheckBox();
            this.nameComboBox = new System.Windows.Forms.ComboBox();
            this.dateComboBox = new System.Windows.Forms.ComboBox();
            this.GenreComboBox = new System.Windows.Forms.ComboBox();
            this.TimeComboBox = new System.Windows.Forms.ComboBox();
            this.BudgetComboBox = new System.Windows.Forms.ComboBox();
            this.ProductionComboBox = new System.Windows.Forms.ComboBox();
            this.CountryComboBox = new System.Windows.Forms.ComboBox();
            this.WatchedComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DOMradioButton = new System.Windows.Forms.RadioButton();
            this.SAXradioButton = new System.Windows.Forms.RadioButton();
            this.LINQtoXMLradioButton = new System.Windows.Forms.RadioButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.transformButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.Author = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameCheckBox
            // 
            this.nameCheckBox.AutoSize = true;
            this.nameCheckBox.Font = new System.Drawing.Font("Lucida Console", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameCheckBox.Location = new System.Drawing.Point(28, 102);
            this.nameCheckBox.Name = "nameCheckBox";
            this.nameCheckBox.Size = new System.Drawing.Size(88, 26);
            this.nameCheckBox.TabIndex = 0;
            this.nameCheckBox.Text = "Name";
            this.nameCheckBox.UseVisualStyleBackColor = true;
            this.nameCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("OCR A Extended", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(38, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Movie Sort Info";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // realeseDateCheckBox
            // 
            this.realeseDateCheckBox.AutoSize = true;
            this.realeseDateCheckBox.Font = new System.Drawing.Font("Lucida Console", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.realeseDateCheckBox.Location = new System.Drawing.Point(28, 163);
            this.realeseDateCheckBox.Name = "realeseDateCheckBox";
            this.realeseDateCheckBox.Size = new System.Drawing.Size(192, 26);
            this.realeseDateCheckBox.TabIndex = 2;
            this.realeseDateCheckBox.Text = "Release Date";
            this.realeseDateCheckBox.UseVisualStyleBackColor = true;
            this.realeseDateCheckBox.CheckedChanged += new System.EventHandler(this.realeseDateCheckBox_CheckedChanged);
            // 
            // genreCheckBox
            // 
            this.genreCheckBox.AutoSize = true;
            this.genreCheckBox.Font = new System.Drawing.Font("Lucida Console", 11F);
            this.genreCheckBox.Location = new System.Drawing.Point(28, 233);
            this.genreCheckBox.Name = "genreCheckBox";
            this.genreCheckBox.Size = new System.Drawing.Size(101, 26);
            this.genreCheckBox.TabIndex = 3;
            this.genreCheckBox.Text = "Genre";
            this.genreCheckBox.UseVisualStyleBackColor = true;
            this.genreCheckBox.CheckedChanged += new System.EventHandler(this.genreCheckBox_CheckedChanged);
            // 
            // timeCheckBox
            // 
            this.timeCheckBox.AutoSize = true;
            this.timeCheckBox.Font = new System.Drawing.Font("Lucida Console", 11F);
            this.timeCheckBox.Location = new System.Drawing.Point(28, 298);
            this.timeCheckBox.Name = "timeCheckBox";
            this.timeCheckBox.Size = new System.Drawing.Size(192, 26);
            this.timeCheckBox.TabIndex = 4;
            this.timeCheckBox.Text = "Running Time";
            this.timeCheckBox.UseVisualStyleBackColor = true;
            this.timeCheckBox.CheckedChanged += new System.EventHandler(this.timeCheckBox_CheckedChanged);
            // 
            // budgetCheckBox
            // 
            this.budgetCheckBox.AutoSize = true;
            this.budgetCheckBox.Font = new System.Drawing.Font("Lucida Console", 11F);
            this.budgetCheckBox.Location = new System.Drawing.Point(28, 362);
            this.budgetCheckBox.Name = "budgetCheckBox";
            this.budgetCheckBox.Size = new System.Drawing.Size(114, 26);
            this.budgetCheckBox.TabIndex = 5;
            this.budgetCheckBox.Text = "Budget";
            this.budgetCheckBox.UseVisualStyleBackColor = true;
            this.budgetCheckBox.CheckedChanged += new System.EventHandler(this.budgetCheckBox_CheckedChanged);
            // 
            // productionCheckBox
            // 
            this.productionCheckBox.AutoSize = true;
            this.productionCheckBox.Font = new System.Drawing.Font("Lucida Console", 11F);
            this.productionCheckBox.Location = new System.Drawing.Point(28, 431);
            this.productionCheckBox.Name = "productionCheckBox";
            this.productionCheckBox.Size = new System.Drawing.Size(166, 26);
            this.productionCheckBox.TabIndex = 6;
            this.productionCheckBox.Text = "Production";
            this.productionCheckBox.UseVisualStyleBackColor = true;
            this.productionCheckBox.CheckedChanged += new System.EventHandler(this.productionCheckBox_CheckedChanged);
            // 
            // countryCheckBox
            // 
            this.countryCheckBox.AutoSize = true;
            this.countryCheckBox.Font = new System.Drawing.Font("Lucida Console", 11F);
            this.countryCheckBox.Location = new System.Drawing.Point(28, 492);
            this.countryCheckBox.Name = "countryCheckBox";
            this.countryCheckBox.Size = new System.Drawing.Size(127, 26);
            this.countryCheckBox.TabIndex = 7;
            this.countryCheckBox.Text = "Country";
            this.countryCheckBox.UseVisualStyleBackColor = true;
            this.countryCheckBox.CheckedChanged += new System.EventHandler(this.countryCheckBox_CheckedChanged);
            // 
            // watchedCheckBox
            // 
            this.watchedCheckBox.AutoSize = true;
            this.watchedCheckBox.Font = new System.Drawing.Font("Lucida Console", 11F);
            this.watchedCheckBox.Location = new System.Drawing.Point(28, 562);
            this.watchedCheckBox.Name = "watchedCheckBox";
            this.watchedCheckBox.Size = new System.Drawing.Size(127, 26);
            this.watchedCheckBox.TabIndex = 8;
            this.watchedCheckBox.Text = "Watched";
            this.watchedCheckBox.UseVisualStyleBackColor = true;
            this.watchedCheckBox.CheckedChanged += new System.EventHandler(this.watchedCheckBox_CheckedChanged);
            // 
            // nameComboBox
            // 
            this.nameComboBox.BackColor = System.Drawing.Color.MintCream;
            this.nameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nameComboBox.FormattingEnabled = true;
            this.nameComboBox.Location = new System.Drawing.Point(244, 100);
            this.nameComboBox.Name = "nameComboBox";
            this.nameComboBox.Size = new System.Drawing.Size(188, 28);
            this.nameComboBox.TabIndex = 9;
            // 
            // dateComboBox
            // 
            this.dateComboBox.BackColor = System.Drawing.Color.MintCream;
            this.dateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dateComboBox.FormattingEnabled = true;
            this.dateComboBox.Location = new System.Drawing.Point(244, 163);
            this.dateComboBox.Name = "dateComboBox";
            this.dateComboBox.Size = new System.Drawing.Size(188, 28);
            this.dateComboBox.TabIndex = 10;
            // 
            // GenreComboBox
            // 
            this.GenreComboBox.BackColor = System.Drawing.Color.MintCream;
            this.GenreComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GenreComboBox.FormattingEnabled = true;
            this.GenreComboBox.Location = new System.Drawing.Point(244, 231);
            this.GenreComboBox.Name = "GenreComboBox";
            this.GenreComboBox.Size = new System.Drawing.Size(188, 28);
            this.GenreComboBox.TabIndex = 11;
            // 
            // TimeComboBox
            // 
            this.TimeComboBox.BackColor = System.Drawing.Color.MintCream;
            this.TimeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimeComboBox.FormattingEnabled = true;
            this.TimeComboBox.Location = new System.Drawing.Point(244, 296);
            this.TimeComboBox.Name = "TimeComboBox";
            this.TimeComboBox.Size = new System.Drawing.Size(188, 28);
            this.TimeComboBox.TabIndex = 12;
            // 
            // BudgetComboBox
            // 
            this.BudgetComboBox.BackColor = System.Drawing.Color.MintCream;
            this.BudgetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BudgetComboBox.FormattingEnabled = true;
            this.BudgetComboBox.Location = new System.Drawing.Point(244, 360);
            this.BudgetComboBox.Name = "BudgetComboBox";
            this.BudgetComboBox.Size = new System.Drawing.Size(188, 28);
            this.BudgetComboBox.TabIndex = 13;
            // 
            // ProductionComboBox
            // 
            this.ProductionComboBox.BackColor = System.Drawing.Color.MintCream;
            this.ProductionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProductionComboBox.FormattingEnabled = true;
            this.ProductionComboBox.Location = new System.Drawing.Point(244, 429);
            this.ProductionComboBox.Name = "ProductionComboBox";
            this.ProductionComboBox.Size = new System.Drawing.Size(188, 28);
            this.ProductionComboBox.TabIndex = 14;
            // 
            // CountryComboBox
            // 
            this.CountryComboBox.BackColor = System.Drawing.Color.MintCream;
            this.CountryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CountryComboBox.FormattingEnabled = true;
            this.CountryComboBox.Location = new System.Drawing.Point(244, 490);
            this.CountryComboBox.Name = "CountryComboBox";
            this.CountryComboBox.Size = new System.Drawing.Size(188, 28);
            this.CountryComboBox.TabIndex = 15;
            // 
            // WatchedComboBox
            // 
            this.WatchedComboBox.BackColor = System.Drawing.Color.MintCream;
            this.WatchedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WatchedComboBox.FormattingEnabled = true;
            this.WatchedComboBox.Location = new System.Drawing.Point(244, 560);
            this.WatchedComboBox.Name = "WatchedComboBox";
            this.WatchedComboBox.Size = new System.Drawing.Size(188, 28);
            this.WatchedComboBox.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("OCR A Extended", 16F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(157, 654);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 35);
            this.label2.TabIndex = 17;
            this.label2.Text = "Methods:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // DOMradioButton
            // 
            this.DOMradioButton.AutoSize = true;
            this.DOMradioButton.Font = new System.Drawing.Font("Lucida Console", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DOMradioButton.Location = new System.Drawing.Point(55, 721);
            this.DOMradioButton.Name = "DOMradioButton";
            this.DOMradioButton.Size = new System.Drawing.Size(74, 26);
            this.DOMradioButton.TabIndex = 18;
            this.DOMradioButton.TabStop = true;
            this.DOMradioButton.Text = "DOM";
            this.DOMradioButton.UseVisualStyleBackColor = true;
            // 
            // SAXradioButton
            // 
            this.SAXradioButton.AutoSize = true;
            this.SAXradioButton.Font = new System.Drawing.Font("Lucida Console", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SAXradioButton.Location = new System.Drawing.Point(202, 721);
            this.SAXradioButton.Name = "SAXradioButton";
            this.SAXradioButton.Size = new System.Drawing.Size(74, 26);
            this.SAXradioButton.TabIndex = 19;
            this.SAXradioButton.TabStop = true;
            this.SAXradioButton.Text = "SAX";
            this.SAXradioButton.UseVisualStyleBackColor = true;
            // 
            // LINQtoXMLradioButton
            // 
            this.LINQtoXMLradioButton.AutoSize = true;
            this.LINQtoXMLradioButton.Font = new System.Drawing.Font("Lucida Console", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LINQtoXMLradioButton.Location = new System.Drawing.Point(331, 721);
            this.LINQtoXMLradioButton.Name = "LINQtoXMLradioButton";
            this.LINQtoXMLradioButton.Size = new System.Drawing.Size(178, 26);
            this.LINQtoXMLradioButton.TabIndex = 20;
            this.LINQtoXMLradioButton.TabStop = true;
            this.LINQtoXMLradioButton.Text = "LINQ to XML";
            this.LINQtoXMLradioButton.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.richTextBox1.Location = new System.Drawing.Point(525, 100);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(613, 472);
            this.richTextBox1.TabIndex = 21;
            this.richTextBox1.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("OCR A Extended", 16F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(545, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 35);
            this.label3.TabIndex = 22;
            this.label3.Text = "Result";
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.searchButton.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchButton.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.searchButton.Location = new System.Drawing.Point(163, 788);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(160, 51);
            this.searchButton.TabIndex = 23;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClearButton.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClearButton.Location = new System.Drawing.Point(535, 588);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(228, 51);
            this.ClearButton.TabIndex = 24;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // transformButton
            // 
            this.transformButton.BackColor = System.Drawing.Color.DarkSlateGray;
            this.transformButton.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.transformButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.transformButton.Location = new System.Drawing.Point(793, 588);
            this.transformButton.Name = "transformButton";
            this.transformButton.Size = new System.Drawing.Size(345, 51);
            this.transformButton.TabIndex = 25;
            this.transformButton.Text = "Transform to HTML";
            this.transformButton.UseVisualStyleBackColor = false;
            this.transformButton.Click += new System.EventHandler(this.transformButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem5});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1148, 33);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFile,
            this.saveFile});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(54, 29);
            this.toolStripMenuItem2.Text = "File";
            // 
            // openFile
            // 
            this.openFile.Image = ((System.Drawing.Image)(resources.GetObject("openFile.Image")));
            this.openFile.Name = "openFile";
            this.openFile.ShortcutKeyDisplayString = "Ctrl+O";
            this.openFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFile.Size = new System.Drawing.Size(223, 34);
            this.openFile.Text = "Open";
            // 
            // saveFile
            // 
            this.saveFile.Image = ((System.Drawing.Image)(resources.GetObject("saveFile.Image")));
            this.saveFile.Name = "saveFile";
            this.saveFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveFile.Size = new System.Drawing.Size(223, 34);
            this.saveFile.Text = "Save";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpMenu,
            this.Author});
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(60, 29);
            this.toolStripMenuItem5.Text = "Info";
            // 
            // helpMenu
            // 
            this.helpMenu.Image = ((System.Drawing.Image)(resources.GetObject("helpMenu.Image")));
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(169, 34);
            this.helpMenu.Text = "Help";
            this.helpMenu.Click += new System.EventHandler(this.helpMenu_Click);
            // 
            // Author
            // 
            this.Author.Image = ((System.Drawing.Image)(resources.GetObject("Author.Image")));
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(169, 34);
            this.Author.Text = "Author";
            this.Author.Click += new System.EventHandler(this.Author_Click);
            // 
            // XMLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1148, 898);
            this.Controls.Add(this.transformButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.LINQtoXMLradioButton);
            this.Controls.Add(this.SAXradioButton);
            this.Controls.Add(this.DOMradioButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WatchedComboBox);
            this.Controls.Add(this.CountryComboBox);
            this.Controls.Add(this.ProductionComboBox);
            this.Controls.Add(this.BudgetComboBox);
            this.Controls.Add(this.TimeComboBox);
            this.Controls.Add(this.GenreComboBox);
            this.Controls.Add(this.dateComboBox);
            this.Controls.Add(this.nameComboBox);
            this.Controls.Add(this.watchedCheckBox);
            this.Controls.Add(this.countryCheckBox);
            this.Controls.Add(this.productionCheckBox);
            this.Controls.Add(this.budgetCheckBox);
            this.Controls.Add(this.timeCheckBox);
            this.Controls.Add(this.genreCheckBox);
            this.Controls.Add(this.realeseDateCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameCheckBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "XMLForm";
            this.Text = "XMLMovies";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XMLForm_FormClosing);
            this.Load += new System.EventHandler(this.XMLForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox nameCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox realeseDateCheckBox;
        private System.Windows.Forms.CheckBox genreCheckBox;
        private System.Windows.Forms.CheckBox timeCheckBox;
        private System.Windows.Forms.CheckBox budgetCheckBox;
        private System.Windows.Forms.CheckBox productionCheckBox;
        private System.Windows.Forms.CheckBox countryCheckBox;
        private System.Windows.Forms.CheckBox watchedCheckBox;
        private System.Windows.Forms.ComboBox nameComboBox;
        private System.Windows.Forms.ComboBox dateComboBox;
        private System.Windows.Forms.ComboBox GenreComboBox;
        private System.Windows.Forms.ComboBox TimeComboBox;
        private System.Windows.Forms.ComboBox BudgetComboBox;
        private System.Windows.Forms.ComboBox ProductionComboBox;
        private System.Windows.Forms.ComboBox CountryComboBox;
        private System.Windows.Forms.ComboBox WatchedComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton DOMradioButton;
        private System.Windows.Forms.RadioButton SAXradioButton;
        private System.Windows.Forms.RadioButton LINQtoXMLradioButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button transformButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem openFile;
        private System.Windows.Forms.ToolStripMenuItem saveFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem Author;
    }
}

