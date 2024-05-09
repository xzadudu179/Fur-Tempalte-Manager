namespace WinFormsApp1;

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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        templateBox = new ListBox();
        templateNameTextBox = new TextBox();
        label1 = new Label();
        templateAuthorTextBox = new TextBox();
        templateNameLabel = new Label();
        label2 = new Label();
        InputButton = new Button();
        label3 = new Label();
        templateCostTextBox = new TextBox();
        label4 = new Label();
        label5 = new Label();
        templateUsageComboBox = new ComboBox();
        label6 = new Label();
        templateSellerId = new TextBox();
        label7 = new Label();
        templateSellerName = new TextBox();
        InputAllButton = new Button();
        label8 = new Label();
        templateGroupCountTextBox = new TextBox();
        label9 = new Label();
        templateDeliveryWaysComboBox = new ComboBox();
        label10 = new Label();
        templateAgreementTextBox = new TextBox();
        chooseFolderButton = new Button();
        folderLabel = new Label();
        label11 = new Label();
        clearButton = new Button();
        menuStrip1 = new MenuStrip();
        settingsItem = new ToolStripMenuItem();
        resetTemplateFolderItem = new ToolStripMenuItem();
        infoStrip = new ToolStripMenuItem();
        templatePathInfo = new ToolStripMenuItem();
        helpMenuStrip = new ToolStripMenuItem();
        statusStrip1 = new StatusStrip();
        importStatusStrip = new ToolStripStatusLabel();
        menuStrip1.SuspendLayout();
        statusStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // templateBox
        // 
        templateBox.AllowDrop = true;
        templateBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        templateBox.FormattingEnabled = true;
        templateBox.ItemHeight = 17;
        templateBox.Location = new Point(12, 114);
        templateBox.Name = "templateBox";
        templateBox.SelectionMode = SelectionMode.MultiExtended;
        templateBox.Size = new Size(264, 276);
        templateBox.TabIndex = 0;
        templateBox.SelectedIndexChanged += templateBox_SelectedIndexChanged;
        templateBox.DragDrop += templateBox_DragDrop;
        templateBox.DragEnter += templateBox_DragEnter;
        templateBox.DragLeave += templateBox_DragLeave;
        // 
        // templateNameTextBox
        // 
        templateNameTextBox.Location = new Point(526, 49);
        templateNameTextBox.Name = "templateNameTextBox";
        templateNameTextBox.Size = new Size(100, 23);
        templateNameTextBox.TabIndex = 1;
        templateNameTextBox.TextChanged += templateNameTextBox_TextChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(500, 52);
        label1.Name = "label1";
        label1.Size = new Size(23, 17);
        label1.TabIndex = 2;
        label1.Text = "名:";
        // 
        // templateAuthorTextBox
        // 
        templateAuthorTextBox.Location = new Point(376, 49);
        templateAuthorTextBox.Name = "templateAuthorTextBox";
        templateAuthorTextBox.Size = new Size(118, 23);
        templateAuthorTextBox.TabIndex = 3;
        templateAuthorTextBox.TextChanged += templateAuthorTextBox_TextChanged;
        // 
        // templateNameLabel
        // 
        templateNameLabel.AutoSize = true;
        templateNameLabel.Location = new Point(282, 52);
        templateNameLabel.Name = "templateNameLabel";
        templateNameLabel.Size = new Size(88, 17);
        templateNameLabel.TabIndex = 4;
        templateNameLabel.Text = "模板牌名(可选)";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(12, 32);
        label2.Name = "label2";
        label2.Size = new Size(219, 17);
        label2.TabIndex = 5;
        label2.Text = "请将模板的psd文件夹拖拽至此或选择...";
        // 
        // InputButton
        // 
        InputButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        InputButton.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        InputButton.Location = new Point(12, 396);
        InputButton.Name = "InputButton";
        InputButton.RightToLeft = RightToLeft.No;
        InputButton.Size = new Size(130, 45);
        InputButton.TabIndex = 6;
        InputButton.Text = "导入所选";
        InputButton.UseVisualStyleBackColor = true;
        InputButton.Click += InputButton_Click;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(282, 80);
        label3.Name = "label3";
        label3.Size = new Size(56, 17);
        label3.TabIndex = 7;
        label3.Text = "模板价格";
        // 
        // templateCostTextBox
        // 
        templateCostTextBox.Location = new Point(376, 77);
        templateCostTextBox.Name = "templateCostTextBox";
        templateCostTextBox.Size = new Size(118, 23);
        templateCostTextBox.TabIndex = 8;
        templateCostTextBox.Leave += templateCostTextBox_Leave;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(500, 80);
        label4.Name = "label4";
        label4.Size = new Size(13, 17);
        label4.TabIndex = 9;
        label4.Text = "r";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(282, 109);
        label5.Name = "label5";
        label5.Size = new Size(56, 17);
        label5.TabIndex = 10;
        label5.Text = "模板用途";
        // 
        // templateUsageComboBox
        // 
        templateUsageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        templateUsageComboBox.FormattingEnabled = true;
        templateUsageComboBox.Items.AddRange(new object[] { "商用", "使用", "商使合一" });
        templateUsageComboBox.Location = new Point(376, 106);
        templateUsageComboBox.Name = "templateUsageComboBox";
        templateUsageComboBox.Size = new Size(118, 25);
        templateUsageComboBox.TabIndex = 13;
        templateUsageComboBox.SelectedIndexChanged += templateUsageComboBox_SelectedIndexChanged;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(282, 140);
        label6.Name = "label6";
        label6.Size = new Size(72, 17);
        label6.TabIndex = 14;
        label6.Text = "买商老师qq";
        // 
        // templateSellerId
        // 
        templateSellerId.Location = new Point(376, 137);
        templateSellerId.Name = "templateSellerId";
        templateSellerId.Size = new Size(118, 23);
        templateSellerId.TabIndex = 15;
        templateSellerId.Leave += templateSellerId_Leave;
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new Point(500, 140);
        label7.Name = "label7";
        label7.Size = new Size(64, 17);
        label7.TabIndex = 16;
        label7.Text = "备注(可选)";
        // 
        // templateSellerName
        // 
        templateSellerName.Location = new Point(570, 137);
        templateSellerName.Name = "templateSellerName";
        templateSellerName.Size = new Size(100, 23);
        templateSellerName.TabIndex = 17;
        templateSellerName.TextChanged += templateSellerName_TextChanged;
        // 
        // InputAllButton
        // 
        InputAllButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        InputAllButton.Location = new Point(148, 396);
        InputAllButton.Name = "InputAllButton";
        InputAllButton.Size = new Size(130, 45);
        InputAllButton.TabIndex = 18;
        InputAllButton.Text = "全部导入";
        InputAllButton.UseVisualStyleBackColor = true;
        InputAllButton.Click += InputAllButton_Click;
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(282, 169);
        label8.Name = "label8";
        label8.Size = new Size(80, 17);
        label8.TabIndex = 19;
        label8.Text = "模板统计群数";
        // 
        // templateGroupCountTextBox
        // 
        templateGroupCountTextBox.Location = new Point(376, 166);
        templateGroupCountTextBox.Name = "templateGroupCountTextBox";
        templateGroupCountTextBox.Size = new Size(117, 23);
        templateGroupCountTextBox.TabIndex = 20;
        templateGroupCountTextBox.Leave += templateGroupCountTextBox_Leave;
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new Point(282, 198);
        label9.Name = "label9";
        label9.Size = new Size(80, 17);
        label9.TabIndex = 21;
        label9.Text = "模板发货方式";
        // 
        // templateDeliveryWaysComboBox
        // 
        templateDeliveryWaysComboBox.DisplayMember = "商用";
        templateDeliveryWaysComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        templateDeliveryWaysComboBox.FormattingEnabled = true;
        templateDeliveryWaysComboBox.Items.AddRange(new object[] { "群发", "云发", "私发" });
        templateDeliveryWaysComboBox.Location = new Point(376, 195);
        templateDeliveryWaysComboBox.Name = "templateDeliveryWaysComboBox";
        templateDeliveryWaysComboBox.Size = new Size(117, 25);
        templateDeliveryWaysComboBox.TabIndex = 22;
        templateDeliveryWaysComboBox.ValueMember = "商用";
        templateDeliveryWaysComboBox.SelectedIndexChanged += templateDeliveryWaysComboBox_SelectedIndexChanged;
        // 
        // label10
        // 
        label10.AutoSize = true;
        label10.Location = new Point(282, 234);
        label10.Name = "label10";
        label10.Size = new Size(88, 17);
        label10.TabIndex = 23;
        label10.Text = "模板规定(可选)";
        // 
        // templateAgreementTextBox
        // 
        templateAgreementTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        templateAgreementTextBox.Location = new Point(282, 259);
        templateAgreementTextBox.MaxLength = 65535;
        templateAgreementTextBox.Multiline = true;
        templateAgreementTextBox.Name = "templateAgreementTextBox";
        templateAgreementTextBox.ScrollBars = ScrollBars.Vertical;
        templateAgreementTextBox.Size = new Size(385, 182);
        templateAgreementTextBox.TabIndex = 24;
        templateAgreementTextBox.TextChanged += templateAgreementTextBox_TextChanged;
        // 
        // chooseFolderButton
        // 
        chooseFolderButton.Location = new Point(12, 52);
        chooseFolderButton.Name = "chooseFolderButton";
        chooseFolderButton.Size = new Size(96, 28);
        chooseFolderButton.TabIndex = 25;
        chooseFolderButton.Text = "选择文件夹";
        chooseFolderButton.UseVisualStyleBackColor = true;
        chooseFolderButton.Click += chooseFolderButton_Click;
        // 
        // folderLabel
        // 
        folderLabel.Location = new Point(114, 58);
        folderLabel.Name = "folderLabel";
        folderLabel.Size = new Size(162, 50);
        folderLabel.TabIndex = 26;
        folderLabel.Text = "...";
        // 
        // label11
        // 
        label11.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        label11.BackColor = SystemColors.ControlDark;
        label11.Location = new Point(282, 228);
        label11.Name = "label11";
        label11.Size = new Size(385, 1);
        label11.TabIndex = 27;
        // 
        // clearButton
        // 
        clearButton.Location = new Point(12, 80);
        clearButton.Name = "clearButton";
        clearButton.Size = new Size(96, 28);
        clearButton.TabIndex = 28;
        clearButton.Text = "清空";
        clearButton.UseVisualStyleBackColor = true;
        clearButton.Click += clearButton_Click;
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new ToolStripItem[] { settingsItem, infoStrip, helpMenuStrip });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(679, 25);
        menuStrip1.TabIndex = 29;
        menuStrip1.Text = "menuStrip1";
        // 
        // settingsItem
        // 
        settingsItem.DropDownItems.AddRange(new ToolStripItem[] { resetTemplateFolderItem });
        settingsItem.Name = "settingsItem";
        settingsItem.Size = new Size(44, 21);
        settingsItem.Text = "设置";
        // 
        // resetTemplateFolderItem
        // 
        resetTemplateFolderItem.Name = "resetTemplateFolderItem";
        resetTemplateFolderItem.Size = new Size(160, 22);
        resetTemplateFolderItem.Text = "重设模板文件夹";
        resetTemplateFolderItem.Click += resetTemplateFolderItem_Click;
        // 
        // infoStrip
        // 
        infoStrip.DropDownItems.AddRange(new ToolStripItem[] { templatePathInfo });
        infoStrip.Name = "infoStrip";
        infoStrip.Size = new Size(44, 21);
        infoStrip.Text = "查看";
        // 
        // templatePathInfo
        // 
        templatePathInfo.Name = "templatePathInfo";
        templatePathInfo.Size = new Size(160, 22);
        templatePathInfo.Text = "模板文件夹路径";
        templatePathInfo.Click += templatePathInfo_Click;
        // 
        // helpMenuStrip
        // 
        helpMenuStrip.Name = "helpMenuStrip";
        helpMenuStrip.Size = new Size(44, 21);
        helpMenuStrip.Text = "帮助";
        helpMenuStrip.Click += helpMenuStrip_Click;
        // 
        // statusStrip1
        // 
        statusStrip1.Items.AddRange(new ToolStripItem[] { importStatusStrip });
        statusStrip1.Location = new Point(0, 456);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Size = new Size(679, 22);
        statusStrip1.TabIndex = 30;
        statusStrip1.Text = "statusStrip1";
        // 
        // importStatusStrip
        // 
        importStatusStrip.Name = "importStatusStrip";
        importStatusStrip.Size = new Size(44, 17);
        importStatusStrip.Text = "闲置中";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(679, 478);
        Controls.Add(statusStrip1);
        Controls.Add(clearButton);
        Controls.Add(label11);
        Controls.Add(folderLabel);
        Controls.Add(chooseFolderButton);
        Controls.Add(templateAgreementTextBox);
        Controls.Add(label10);
        Controls.Add(templateDeliveryWaysComboBox);
        Controls.Add(label9);
        Controls.Add(templateGroupCountTextBox);
        Controls.Add(label8);
        Controls.Add(InputAllButton);
        Controls.Add(templateSellerName);
        Controls.Add(label7);
        Controls.Add(templateSellerId);
        Controls.Add(label6);
        Controls.Add(templateUsageComboBox);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(templateCostTextBox);
        Controls.Add(label3);
        Controls.Add(InputButton);
        Controls.Add(label2);
        Controls.Add(templateNameLabel);
        Controls.Add(templateAuthorTextBox);
        Controls.Add(label1);
        Controls.Add(templateNameTextBox);
        Controls.Add(templateBox);
        Controls.Add(menuStrip1);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MainMenuStrip = menuStrip1;
        MinimumSize = new Size(695, 453);
        Name = "Form1";
        Text = "模板导入工具";
        Load += Form1_Load;
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ListBox templateBox;
    private TextBox templateNameTextBox;
    private Label label1;
    private TextBox templateAuthorTextBox;
    private Label templateNameLabel;
    private Label label2;
    private Button InputButton;
    private Label label3;
    private TextBox templateCostTextBox;
    private Label label4;
    private Label label5;
    private ComboBox templateUsageComboBox;
    private Label label6;
    private TextBox templateSellerId;
    private Label label7;
    private TextBox templateSellerName;
    private Button InputAllButton;
    private Label label8;
    private TextBox templateGroupCountTextBox;
    private Label label9;
    private ComboBox templateDeliveryWaysComboBox;
    private Label label10;
    private TextBox templateAgreementTextBox;
    private Button chooseFolderButton;
    private Label folderLabel;
    private Label label11;
    private Button clearButton;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem settingsItem;
    private ToolStripMenuItem resetTemplateFolderItem;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel importStatusStrip;
    private ToolStripMenuItem infoStrip;
    private ToolStripMenuItem templatePathInfo;
    private ToolStripMenuItem helpMenuStrip;
}