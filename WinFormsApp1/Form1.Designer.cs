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
        components = new System.ComponentModel.Container();
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
        refreshFolderContentButton = new Button();
        timer1 = new System.Windows.Forms.Timer(components);
        templateSellerIdComboBox = new ComboBox();
        menuStrip1.SuspendLayout();
        statusStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // templateBox
        // 
        templateBox.AllowDrop = true;
        templateBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        templateBox.FormattingEnabled = true;
        templateBox.Location = new Point(24, 235);
        templateBox.Margin = new Padding(6, 5, 6, 5);
        templateBox.Name = "templateBox";
        templateBox.SelectionMode = SelectionMode.MultiExtended;
        templateBox.Size = new Size(524, 469);
        templateBox.TabIndex = 0;
        templateBox.SelectedIndexChanged += templateBox_SelectedIndexChanged;
        templateBox.DragDrop += templateBox_DragDrop;
        templateBox.DragEnter += templateBox_DragEnter;
        templateBox.DragLeave += templateBox_DragLeave;
        // 
        // templateNameTextBox
        // 
        templateNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        templateNameTextBox.Location = new Point(1188, 89);
        templateNameTextBox.Margin = new Padding(6, 5, 6, 5);
        templateNameTextBox.Name = "templateNameTextBox";
        templateNameTextBox.Size = new Size(196, 38);
        templateNameTextBox.TabIndex = 1;
        templateNameTextBox.TextChanged += templateNameTextBox_TextChanged;
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        label1.AutoSize = true;
        label1.Location = new Point(1000, 95);
        label1.Margin = new Padding(6, 0, 6, 0);
        label1.Name = "label1";
        label1.Size = new Size(174, 31);
        label1.TabIndex = 2;
        label1.Text = "名(用+号分隔):";
        // 
        // templateAuthorTextBox
        // 
        templateAuthorTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        templateAuthorTextBox.Location = new Point(752, 89);
        templateAuthorTextBox.Margin = new Padding(6, 5, 6, 5);
        templateAuthorTextBox.Name = "templateAuthorTextBox";
        templateAuthorTextBox.Size = new Size(232, 38);
        templateAuthorTextBox.TabIndex = 3;
        templateAuthorTextBox.TextChanged += templateAuthorTextBox_TextChanged;
        // 
        // templateNameLabel
        // 
        templateNameLabel.AutoSize = true;
        templateNameLabel.Location = new Point(564, 95);
        templateNameLabel.Margin = new Padding(6, 0, 6, 0);
        templateNameLabel.Name = "templateNameLabel";
        templateNameLabel.Size = new Size(174, 31);
        templateNameLabel.TabIndex = 4;
        templateNameLabel.Text = "模板牌名(可选)";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(24, 58);
        label2.Margin = new Padding(6, 0, 6, 0);
        label2.Name = "label2";
        label2.Size = new Size(433, 31);
        label2.TabIndex = 5;
        label2.Text = "请将模板的psd文件夹拖拽至此或选择...";
        // 
        // InputButton
        // 
        InputButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        InputButton.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        InputButton.Location = new Point(24, 739);
        InputButton.Margin = new Padding(6, 5, 6, 5);
        InputButton.Name = "InputButton";
        InputButton.RightToLeft = RightToLeft.No;
        InputButton.Size = new Size(260, 82);
        InputButton.TabIndex = 6;
        InputButton.Text = "导入所选";
        InputButton.UseVisualStyleBackColor = true;
        InputButton.Click += InputButton_Click;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(564, 146);
        label3.Margin = new Padding(6, 0, 6, 0);
        label3.Name = "label3";
        label3.Size = new Size(110, 31);
        label3.TabIndex = 7;
        label3.Text = "模板价格";
        // 
        // templateCostTextBox
        // 
        templateCostTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        templateCostTextBox.Location = new Point(752, 140);
        templateCostTextBox.Margin = new Padding(6, 5, 6, 5);
        templateCostTextBox.Name = "templateCostTextBox";
        templateCostTextBox.Size = new Size(232, 38);
        templateCostTextBox.TabIndex = 8;
        templateCostTextBox.Leave += templateCostTextBox_Leave;
        // 
        // label4
        // 
        label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        label4.AutoSize = true;
        label4.Location = new Point(1000, 146);
        label4.Margin = new Padding(6, 0, 6, 0);
        label4.Name = "label4";
        label4.Size = new Size(23, 31);
        label4.TabIndex = 9;
        label4.Text = "r";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(564, 199);
        label5.Margin = new Padding(6, 0, 6, 0);
        label5.Name = "label5";
        label5.Size = new Size(110, 31);
        label5.TabIndex = 10;
        label5.Text = "模板用途";
        // 
        // templateUsageComboBox
        // 
        templateUsageComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        templateUsageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        templateUsageComboBox.FormattingEnabled = true;
        templateUsageComboBox.Items.AddRange(new object[] { "商用", "使用", "商使合一", "买断", "共断" });
        templateUsageComboBox.Location = new Point(752, 193);
        templateUsageComboBox.Margin = new Padding(6, 5, 6, 5);
        templateUsageComboBox.Name = "templateUsageComboBox";
        templateUsageComboBox.Size = new Size(232, 39);
        templateUsageComboBox.TabIndex = 13;
        templateUsageComboBox.SelectedIndexChanged += templateUsageComboBox_SelectedIndexChanged;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(564, 255);
        label6.Margin = new Padding(6, 0, 6, 0);
        label6.Name = "label6";
        label6.Size = new Size(140, 31);
        label6.TabIndex = 14;
        label6.Text = "买商老师qq";
        // 
        // label7
        // 
        label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        label7.AutoSize = true;
        label7.Location = new Point(1000, 255);
        label7.Margin = new Padding(6, 0, 6, 0);
        label7.Name = "label7";
        label7.Size = new Size(132, 31);
        label7.TabIndex = 16;
        label7.Text = "备注(可选):";
        // 
        // templateSellerName
        // 
        templateSellerName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        templateSellerName.Location = new Point(1188, 250);
        templateSellerName.Margin = new Padding(6, 5, 6, 5);
        templateSellerName.Name = "templateSellerName";
        templateSellerName.Size = new Size(196, 38);
        templateSellerName.TabIndex = 17;
        templateSellerName.TextChanged += templateSellerName_TextChanged;
        // 
        // InputAllButton
        // 
        InputAllButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        InputAllButton.Location = new Point(296, 739);
        InputAllButton.Margin = new Padding(6, 5, 6, 5);
        InputAllButton.Name = "InputAllButton";
        InputAllButton.Size = new Size(260, 82);
        InputAllButton.TabIndex = 18;
        InputAllButton.Text = "全部导入";
        InputAllButton.UseVisualStyleBackColor = true;
        InputAllButton.Click += InputAllButton_Click;
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(566, 312);
        label8.Margin = new Padding(6, 0, 6, 0);
        label8.Name = "label8";
        label8.Size = new Size(158, 31);
        label8.TabIndex = 19;
        label8.Text = "模板统计群数";
        // 
        // templateGroupCountTextBox
        // 
        templateGroupCountTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        templateGroupCountTextBox.Location = new Point(754, 306);
        templateGroupCountTextBox.Margin = new Padding(6, 5, 6, 5);
        templateGroupCountTextBox.Name = "templateGroupCountTextBox";
        templateGroupCountTextBox.Size = new Size(230, 38);
        templateGroupCountTextBox.TabIndex = 20;
        templateGroupCountTextBox.Leave += templateGroupCountTextBox_Leave;
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new Point(566, 365);
        label9.Margin = new Padding(6, 0, 6, 0);
        label9.Name = "label9";
        label9.Size = new Size(158, 31);
        label9.TabIndex = 21;
        label9.Text = "模板发货方式";
        // 
        // templateDeliveryWaysComboBox
        // 
        templateDeliveryWaysComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        templateDeliveryWaysComboBox.DisplayMember = "商用";
        templateDeliveryWaysComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        templateDeliveryWaysComboBox.FormattingEnabled = true;
        templateDeliveryWaysComboBox.Items.AddRange(new object[] { "群发", "云发", "私发" });
        templateDeliveryWaysComboBox.Location = new Point(754, 359);
        templateDeliveryWaysComboBox.Margin = new Padding(6, 5, 6, 5);
        templateDeliveryWaysComboBox.Name = "templateDeliveryWaysComboBox";
        templateDeliveryWaysComboBox.Size = new Size(230, 39);
        templateDeliveryWaysComboBox.TabIndex = 22;
        templateDeliveryWaysComboBox.ValueMember = "商用";
        templateDeliveryWaysComboBox.SelectedIndexChanged += templateDeliveryWaysComboBox_SelectedIndexChanged;
        // 
        // label10
        // 
        label10.AutoSize = true;
        label10.Location = new Point(564, 427);
        label10.Margin = new Padding(6, 0, 6, 0);
        label10.Name = "label10";
        label10.Size = new Size(174, 31);
        label10.TabIndex = 23;
        label10.Text = "模板规定(可选)";
        // 
        // templateAgreementTextBox
        // 
        templateAgreementTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        templateAgreementTextBox.Location = new Point(564, 472);
        templateAgreementTextBox.Margin = new Padding(6, 5, 6, 5);
        templateAgreementTextBox.MaxLength = 65535;
        templateAgreementTextBox.Multiline = true;
        templateAgreementTextBox.Name = "templateAgreementTextBox";
        templateAgreementTextBox.ScrollBars = ScrollBars.Vertical;
        templateAgreementTextBox.Size = new Size(840, 345);
        templateAgreementTextBox.TabIndex = 24;
        templateAgreementTextBox.TextChanged += templateAgreementTextBox_TextChanged;
        // 
        // chooseFolderButton
        // 
        chooseFolderButton.Location = new Point(24, 102);
        chooseFolderButton.Margin = new Padding(6, 5, 6, 5);
        chooseFolderButton.Name = "chooseFolderButton";
        chooseFolderButton.Size = new Size(260, 71);
        chooseFolderButton.TabIndex = 25;
        chooseFolderButton.Text = "选择文件夹";
        chooseFolderButton.UseVisualStyleBackColor = true;
        chooseFolderButton.Click += chooseFolderButton_Click;
        // 
        // folderLabel
        // 
        folderLabel.Location = new Point(296, 102);
        folderLabel.Margin = new Padding(6, 0, 6, 0);
        folderLabel.Name = "folderLabel";
        folderLabel.Size = new Size(256, 122);
        folderLabel.TabIndex = 26;
        folderLabel.Text = "...";
        // 
        // label11
        // 
        label11.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        label11.BackColor = SystemColors.ControlDark;
        label11.Location = new Point(564, 416);
        label11.Margin = new Padding(6, 0, 6, 0);
        label11.Name = "label11";
        label11.Size = new Size(844, 2);
        label11.TabIndex = 27;
        // 
        // clearButton
        // 
        clearButton.Location = new Point(156, 179);
        clearButton.Margin = new Padding(6, 5, 6, 5);
        clearButton.Name = "clearButton";
        clearButton.Size = new Size(128, 46);
        clearButton.TabIndex = 28;
        clearButton.Text = "清空";
        clearButton.UseVisualStyleBackColor = true;
        clearButton.Click += clearButton_Click;
        // 
        // menuStrip1
        // 
        menuStrip1.ImageScalingSize = new Size(32, 32);
        menuStrip1.Items.AddRange(new ToolStripItem[] { settingsItem, infoStrip, helpMenuStrip });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Padding = new Padding(12, 4, 0, 4);
        menuStrip1.Size = new Size(1432, 43);
        menuStrip1.TabIndex = 29;
        menuStrip1.Text = "menuStrip1";
        // 
        // settingsItem
        // 
        settingsItem.DropDownItems.AddRange(new ToolStripItem[] { resetTemplateFolderItem });
        settingsItem.Name = "settingsItem";
        settingsItem.Size = new Size(82, 35);
        settingsItem.Text = "设置";
        // 
        // resetTemplateFolderItem
        // 
        resetTemplateFolderItem.Name = "resetTemplateFolderItem";
        resetTemplateFolderItem.Size = new Size(315, 44);
        resetTemplateFolderItem.Text = "重设模板文件夹";
        resetTemplateFolderItem.Click += resetTemplateFolderItem_Click;
        // 
        // infoStrip
        // 
        infoStrip.DropDownItems.AddRange(new ToolStripItem[] { templatePathInfo });
        infoStrip.Name = "infoStrip";
        infoStrip.Size = new Size(82, 35);
        infoStrip.Text = "查看";
        // 
        // templatePathInfo
        // 
        templatePathInfo.Name = "templatePathInfo";
        templatePathInfo.Size = new Size(315, 44);
        templatePathInfo.Text = "模板文件夹路径";
        templatePathInfo.Click += templatePathInfo_Click;
        // 
        // helpMenuStrip
        // 
        helpMenuStrip.Name = "helpMenuStrip";
        helpMenuStrip.Size = new Size(82, 35);
        helpMenuStrip.Text = "帮助";
        helpMenuStrip.Click += helpMenuStrip_Click;
        // 
        // statusStrip1
        // 
        statusStrip1.ImageScalingSize = new Size(32, 32);
        statusStrip1.Items.AddRange(new ToolStripItem[] { importStatusStrip });
        statusStrip1.Location = new Point(0, 847);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Padding = new Padding(2, 0, 28, 0);
        statusStrip1.Size = new Size(1432, 41);
        statusStrip1.TabIndex = 30;
        statusStrip1.Text = "statusStrip1";
        // 
        // importStatusStrip
        // 
        importStatusStrip.Name = "importStatusStrip";
        importStatusStrip.Size = new Size(86, 31);
        importStatusStrip.Text = "闲置中";
        // 
        // refreshFolderContentButton
        // 
        refreshFolderContentButton.Location = new Point(24, 179);
        refreshFolderContentButton.Margin = new Padding(6, 5, 6, 5);
        refreshFolderContentButton.Name = "refreshFolderContentButton";
        refreshFolderContentButton.Size = new Size(128, 46);
        refreshFolderContentButton.TabIndex = 31;
        refreshFolderContentButton.Text = "刷新";
        refreshFolderContentButton.UseVisualStyleBackColor = true;
        refreshFolderContentButton.Click += refreshFolderContentButton_Click;
        // 
        // templateSellerIdComboBox
        // 
        templateSellerIdComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        templateSellerIdComboBox.FormattingEnabled = true;
        templateSellerIdComboBox.Location = new Point(752, 250);
        templateSellerIdComboBox.Margin = new Padding(6, 5, 6, 5);
        templateSellerIdComboBox.Name = "templateSellerIdComboBox";
        templateSellerIdComboBox.Size = new Size(232, 39);
        templateSellerIdComboBox.TabIndex = 32;
        templateSellerIdComboBox.SelectedIndexChanged += templateSellerIdComboBox_SelectedIndexChanged;
        templateSellerIdComboBox.Leave += templateSellerIdComboBox_Leave;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(14F, 31F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1432, 888);
        Controls.Add(templateSellerIdComboBox);
        Controls.Add(refreshFolderContentButton);
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
        Margin = new Padding(6, 5, 6, 5);
        MinimumSize = new Size(1438, 884);
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
    private Button refreshFolderContentButton;
    private System.Windows.Forms.Timer timer1;
    private ComboBox templateSellerIdComboBox;
}