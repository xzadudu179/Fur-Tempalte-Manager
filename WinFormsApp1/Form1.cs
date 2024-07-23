using System.IO;
using System.Text.RegularExpressions;
namespace WinFormsApp1;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }
    string folderLabelLastStat = "...";
    List<string> templatesFilePaths = [];
    string templatesFolderPath = "";
    Dictionary<string, string> SellerIdName = [];
    readonly string configpath = "config.txt";
    // 配置文件 ↓
    #region config
    string templatePath = "";
    #endregion

    /// <summary>
    /// 加载
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Form1_Load(object sender, EventArgs e)
    {
        refreshFolderContentButton.Enabled = false;
        InputButton.Enabled = false;
        InputAllButton.Enabled = false;
        clearButton.Enabled = false;
        LoadConfig();
        if (templatePath == "")
        {
            MessageBox.Show("你没有设置模板统计文件夹, 默认将在程序所在文件夹里创建。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        // 加载买商老师QQ
        LoadSellerId();
    }

    private void LoadSellerId()
    {
        foreach (string file in Directory.GetDirectories(templatePath))
        {
            try
            {
                SellerIdName.Add(Path.GetFileName(file).Split("-")[0], string.Join("-", Path.GetFileName(file).Split("-")[1..])[2..]);
            }
            catch { }
            string name = string.Join("-", Path.GetFileName(file).Split("-")[1..])[2..];
            string id = Path.GetFileName(file).Split("-")[0];
            //templateSellerIdComboBox.Items.Add(Path.GetFileName(file).Split("-")[0] + (name != "" ? $" ({name})" : ""));
            // 只显示id
            templateSellerIdComboBox.Items.Add((name != "" ? $" {name}" : id));
        }
    }

    private void LoadConfig()
    {
        if (File.Exists(configpath))
        {
            bool hasTemplatePath = false;
            string[] lines = File.ReadAllLines(configpath);
            List<string> newLines = [];
            foreach (string line in lines)
            {
                if (line.Split("=")[0] == "templatePath")
                {
                    if (line.Split("=")[1] == "")
                    {
                        continue;
                    }
                    try
                    {
                        // 检测文件夹是否有效
                        Directory.GetDirectories(line.Split("=")[1]);
                        hasTemplatePath = true;
                    }
                    catch
                    {
                        continue;
                    }
                }
                newLines.Add(line);
            }
            if (!hasTemplatePath)
            {
                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    dialog.Description = "请选择模板统计文件夹";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        templatePath = dialog.SelectedPath;
                    }
                }
                newLines.Add($"templatePath={templatePath}");
            }
            File.WriteAllLines(configpath, newLines);
            string[] linesNew = File.ReadAllLines(configpath);
            foreach (string line in linesNew)
            {
                if (line.Split("=")[0] == "templatePath")
                {
                    templatePath = line.Split("=")[1];
                    break;
                }
            }
        }
        else
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "请选择模板统计文件夹";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    templatePath = dialog.SelectedPath;
                }
            }
            using (StreamWriter writer = new(configpath))
            {
                writer.WriteLine($"templatePath={templatePath}");
            }
        }
    }

    /// <summary>
    /// 拖拽中
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void templateBox_DragEnter(object sender, DragEventArgs e)
    {
        string path;
        if (!e.Data!.GetDataPresent(DataFormats.FileDrop))
        {
            e.Effect = DragDropEffects.None;
            return;
        }
        e.Effect = DragDropEffects.Link;
        try
        {
            path = ((Array)e.Data!.GetData(DataFormats.FileDrop)!).GetValue(0)!.ToString()!;
        }
        catch
        {
            return;
        }
        if (!Directory.Exists(path))
        {
            e.Effect = DragDropEffects.None;
            return;
        }
        folderLabelLastStat = folderLabel.Text;
        folderLabel.Text = $"已检测到文件夹 \"{Path.GetFileName(path)}\"。";
    }

    /// <summary>
    /// 拖拽至文件夹
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void templateBox_DragDrop(object sender, DragEventArgs e)
    {
        string path;
        try
        {
            path = ((Array)e.Data!.GetData(DataFormats.FileDrop)!).GetValue(0)!.ToString()!;
        }
        catch
        {
            return;
        }
        if (!Directory.Exists(path))
        {
            MessageBox.Show("请拖入文件夹", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        LoadFileInPath(path);
        //templateBox.Items.Clear();

    }

    private void LoadFileInPath(string path)
    {
        foreach (string file in Directory.GetFiles(path))
        {
            templateBox.Items.Add(Path.GetFileName(file));
            do
            {
                templatesFilePaths.Add("");
            } while (templateBox.Items.IndexOf(Path.GetFileName(file)) - 1 > templatesFilePaths.Count);
            templatesFilePaths[templateBox.Items.IndexOf(Path.GetFileName(file))] = file;
        }
        templatesFolderPath = path;
        folderLabel.Text = $"已选择 \"{Path.GetFileName(path)}\"。";
        clearButton.Enabled = true;
        refreshFolderContentButton.Enabled = true;
        RefreshInputButtonState();
    }
    private static string GetNumbers(string input)
    {
        // 使用正则表达式匹配数字
        string pattern = @"\d+";
        MatchCollection matches = Regex.Matches(input, pattern);

        // 将匹配到的数字连接成一个字符串
        string result = "";
        foreach (Match match in matches.Cast<Match>())
        {
            result += match.Value;
        }

        return result;
    }

    static string GetFloatStr(string input)
    {
        // 使用正则表达式提取数字部分
        string pattern = @"[-+]?\d*\.?\d+";
        Match match = Regex.Match(input, pattern);

        // 如果匹配成功，则尝试将匹配到的字符串转换为浮点数
        if (match.Success)
        {
            string numberStr = match.Value;
            if (float.TryParse(numberStr, out _))
            {
                return numberStr;
            }
        }

        // 如果匹配失败或者转换失败，则返回默认值 0
        return input;
    }

    private string ParseToNumberFormat(string text)
    {
        if (int.TryParse(text, out _))
        {
            return text;
        }
        return GetNumbers(text);
    }

    /// <summary>
    /// 刷新导入按钮状态
    /// </summary>
    private void RefreshInputButtonState()
    {
        InputAllButton.Enabled = false;
        InputButton.Enabled = false;
        //if (templateAuthorTextBox.Text.Contains('_')) return;
        if (templateNameTextBox.Text == "") return;
        if (templateCostTextBox.Text == "") return;
        if (templateUsageComboBox.SelectedIndex < 0) return;
        if (templateSellerIdComboBox.Text == "") return;
        if (!double.TryParse(templateSellerIdComboBox.Text, out _)) return;
        //if (templateSellerName.Text.Contains('_')) return;
        if (templateGroupCountTextBox.Text == "") return;
        if (templateDeliveryWaysComboBox.SelectedIndex < 0) return;
        if (templateBox.Items.Count <= 0) return;
        InputAllButton.Enabled = true;
        if (templateBox.SelectedIndex < 0) return;
        InputButton.Enabled = true;
    }



    /// <summary>
    /// 用途
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void templateUsageComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshInputButtonState();
    }


    /// <summary>
    /// 模板牌名
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void templateAuthorTextBox_TextChanged(object sender, EventArgs e)
    {
        RefreshInputButtonState();
    }

    /// <summary>
    /// 模板名
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void templateNameTextBox_TextChanged(object sender, EventArgs e)
    {
        RefreshInputButtonState();
    }

    /// <summary>
    /// 模板价格
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void templateCostTextBox_Leave(object sender, EventArgs e)
    {
        float value;
        float.TryParse(GetFloatStr(templateCostTextBox.Text), out value);
        templateCostTextBox.Text = value.ToString("0.00");
        RefreshInputButtonState();
    }

    /// <summary>
    /// 模板买商老师QQ
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void templateSellerIdComboBox_Leave(object sender, EventArgs e)
    {
        templateSellerIdComboBox.Text = ParseToNumberFormat(templateSellerIdComboBox.Text);
        RefreshInputButtonState();
    }

    /// <summary>
    /// 模板买商老师备注
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void templateSellerName_TextChanged(object sender, EventArgs e)
    {
        RefreshInputButtonState();
    }

    /// <summary>
    /// 模板统计群数量
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void templateGroupCountTextBox_Leave(object sender, EventArgs e)
    {
        templateGroupCountTextBox.Text = ParseToNumberFormat(templateGroupCountTextBox.Text);
        RefreshInputButtonState();
    }

    /// <summary>
    /// 模板发货方式
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void templateDeliveryWaysComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshInputButtonState();
    }

    /// <summary>
    /// 导入
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void InputButton_Click(object sender, EventArgs e)
    {
        this.Cursor = Cursors.WaitCursor;
        importStatusStrip.Text = "导入中...";
        int[] indexs = templateBox.SelectedIndices.Cast<int>().ToArray();
        string[] selectedPaths = (from index in indexs select templatesFilePaths[index]).ToArray();
        //MessageBox.Show(selectedPaths.ToString());
        if (!ImportTemplate(selectedPaths))
        {
            this.Cursor = Cursors.Default;
            importStatusStrip.Text = "闲置中";
            return;
        }
        importStatusStrip.Text = "闲置中";
        this.Cursor = Cursors.Default;
        //foreach (int index in templateBox.SelectedIndices)
        //{
        //    templatesFilePaths.RemoveAt(index);
        //    templateBox.Items.RemoveAt(index);
        //}
        RefreshInputButtonState();
    }

    /// <summary>
    /// 导入模板
    /// </summary>
    private bool ImportTemplate(string[] templates)
    {
        if (templates.Length <= 0) return false;
        int cratedFileCount = 0;
        //MessageBox.Show(templatePath);
        string path = $"{templatePath}\\{templateSellerIdComboBox.Text}-{(templateSellerName.Text != "" ? "备注" + templateSellerName.Text : "")}";
        string[] directories = Directory.GetDirectories(templatePath);
        foreach (string directory in directories)
        {
            // 判断该QQ的文件夹是否存在
            if (Path.GetFileName(directory).Split("-")[0] != templateSellerIdComboBox.Text) continue;
            path = directory;
            //MessageBox.Show($"存在QQ为{templateSellerIdComboBox.Text}的文件夹{Path.GetFileName(directory).Split("-")[0]}");
            try
            {
                // 如果备注名一致或没填写备注名则继续
                if (Path.GetFileName(directory).Split("-")[1][2..] == templateSellerName.Text || templateSellerName.Text == "") continue;
            }
            catch
            {
                // 本身就没有备注名
                continue;
            }
            DialogResult sellerNameResult = MessageBox.Show($"当前对于QQ\"{templateSellerIdComboBox.Text}\"的备注名不一致, 原备注名为\"{Path.GetFileName(directory).Split("-")[1][2..]}\", 当前填写备注名为\"{templateSellerName.Text}\", 是否重命名为\"{path}\"？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sellerNameResult == DialogResult.Yes)
            {
                try
                {
                    //MessageBox.Show(path);
                    //MessageBox.Show(directory);
                    Directory.Move(directory, path);
                    MessageBox.Show($"成功将文件夹重命名为{Path.GetFileName(path)}。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"重命名失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    path = directory;
                }
            }
            else
            {
                path = directory;
            }
        }
        try
        {
            // 尝试创建文件夹
            Directory.CreateDirectory(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"无法创建 {path} 文件夹: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        // 创建基本信息
        Directory.CreateDirectory(path + "\\!购买记录");
        bool isCostInt = int.TryParse(templateCostTextBox.Text, out int costInt);
        string usage = templateUsageComboBox.Text switch
        {
            "商用" => "商",
            "使用" => "使",
            "商使合一" => "商+使",
            _ => templateUsageComboBox.Text,
        };
        string deliWays = templateDeliveryWaysComboBox.Text switch
        {
            "群发" => "群",
            "云发" => "云",
            "私发" => "私",
            _ => "ERROR",
        };
        if (usage == "ERROR" || deliWays == "ERROR")
        {
            MessageBox.Show("用途或发货方式选择错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        //int templateCount = templates.Length;
        // 模板名
        string templateAuthor = templateAuthorTextBox.Text.Trim().Replace(" ", "-");
        if (templateAuthor != "")
        {
            // 在最后一个字符是牌的情况下
            if (templateAuthor[^1] == '牌')
            {
                // 如果倒数第二个字符是牌则不加牌, 否则加牌
                if (templateAuthor.Length == 1)
                {
                    templateAuthor += '牌';
                }               
            }
            else
            {
                templateAuthor += '牌';
            }
        }
        else
        {
            templateAuthor = "不知道什么牌";
        }
        string templateName = templateNameTextBox.Text.Trim().Replace(" ", "-");
        string templateFullName = templateAuthor + " " + templateName;
        // 创建模板文件夹名称
        string templateFolderName = $"{templateGroupCountTextBox.Text}q_{double.Parse(templateCostTextBox.Text):G}r_{usage}_{deliWays}_{templateFullName}_数{templateName.Split('+').Length}";

        string[] templateDirectories = Directory.GetDirectories(path);
        foreach (string directory in templateDirectories)
        {
            if (Path.GetFileName(directory)[0] == '!') continue;
            if (Path.GetFileName(directory).Split("_")[4] == templateFullName)
            {
                // 检测是否存在路径
                DialogResult result = MessageBox.Show($"已存在模板名为\"{templateAuthor + " " + templateNameTextBox.Text}\"的模板文件夹, 是否仍然添加？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return false;
                }
            }
        }
        string templateFolderPath = path + "\\" + templateFolderName;
        Directory.CreateDirectory(templateFolderPath);
        foreach (string template in templates)
        {
            try
            {
                File.Copy(template, templateFolderPath + "\\" + Path.GetFileName(template), true);
                cratedFileCount++;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"复制 \"{template}\" 文件时出现错误，跳过该文件, 错误信息: {ex}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // 创建规定
        if (templateAgreementTextBox.Text != "")
        {
            try
            {
                using (FileStream fs = File.Create(templateFolderPath + "\\规定.txt"))
                {
                    // 使用文件流创建 StreamWriter
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        // 将文本写入文件
                        writer.WriteLine(templateAgreementTextBox.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"创建规定文件时出现错误，停止创建, 错误信息: {ex}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        if (cratedFileCount <= 0)
        {
            return false;
        }
        MessageBox.Show($"已成功将文件复制至文件夹{templateFolderPath}", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return true;
    }

    /// <summary>
    /// 全部导入
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void InputAllButton_Click(object sender, EventArgs e)
    {
        importStatusStrip.Text = "导入中...";
        this.Cursor = Cursors.WaitCursor;
        if (!ImportTemplate(templatesFilePaths.ToArray()))
        {
            importStatusStrip.Text = "闲置中";
            this.Cursor = Cursors.Default;
            return;
        }
        importStatusStrip.Text = "闲置中";
        this.Cursor = Cursors.Default;
        templatesFilePaths.Clear();
        Clear();
        RefreshInputButtonState();
    }

    /// <summary>
    /// 选择文件夹
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void chooseFolderButton_Click(object sender, EventArgs e)
    {
        using (FolderBrowserDialog dialog = new FolderBrowserDialog())
        {
            dialog.Description = "请选择模板工程文件夹";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                templatesFolderPath = dialog.SelectedPath;
                LoadFileInPath(dialog.SelectedPath);
            }
        }
    }

    private void templateAgreementTextBox_TextChanged(object sender, EventArgs e)
    {
        RefreshInputButtonState();
    }

    /// <summary>
    /// 清空
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void clearButton_Click(object sender, EventArgs e)
    {
        Clear();
        RefreshInputButtonState();
    }
    private void Clear()
    {
        refreshFolderContentButton.Enabled = false;
        templatesFilePaths.Clear();
        templateBox.Items.Clear();
        InputButton.Enabled = false;
        InputAllButton.Enabled = false;
        templatesFolderPath = "";
        folderLabel.Text = "...";
        clearButton.Enabled = false;
    }
    private void templateBox_DragLeave(object sender, EventArgs e)
    {
        folderLabel.Text = folderLabelLastStat;
    }

    /// <summary>
    /// 重设模板文件夹
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void resetTemplateFolderItem_Click(object sender, EventArgs e)
    {
        if (!File.Exists(configpath))
        {
            LoadConfig();
            return;
        }
        string[] lines = File.ReadAllLines(configpath);
        List<string> newLines = [];
        using (FolderBrowserDialog dialog = new FolderBrowserDialog())
        {
            dialog.Description = "请选择模板统计文件夹";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                templatePath = dialog.SelectedPath;
            }
        }
        bool hasTemplatePathItem = false;
        foreach (string line in lines)
        {
            if (line.Split("=")[0] == "templatePath")
            {
                newLines.Add($"templatePath={templatePath}");
                hasTemplatePathItem = true;
                continue;
            }
            newLines.Add(line);
        }
        if (!hasTemplatePathItem)
        {
            newLines.Add($"templatePath={templatePath}");
        }
        File.WriteAllLines(configpath, newLines);
    }

    private void templateBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshInputButtonState();
    }

    /// <summary>
    /// 刷新
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void refreshFolderContentButton_Click(object sender, EventArgs e)
    {
        templateBox.Items.Clear();
        LoadFileInPath(templatesFolderPath);
    }

    private void templatePathInfo_Click(object sender, EventArgs e)
    {
        MessageBox.Show($"模板文件夹路径为{templatePath}。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void helpMenuStrip_Click(object sender, EventArgs e)
    {
        MessageBox.Show($"    拖拽或选择存放模板工程文件的文件夹到左侧的工具栏，之后在右侧填写模板信息。在列表栏选择需要的工程文件（可多选）后按下\"导入所选\"进行导入，或是使用\"全部导入\"导入列表中的所有工程文件。\n\n" +
                         "    第一次打开该程序时会要求选择模板存放的文件夹，之后可在\"设置\"栏里进行更改，或在\"信息\"栏里查看。\n\n" +
                         "    注意: 模板名以'+'分割多个模板名，多个模板名会被记录在模板数量里", "帮助", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void templateSellerIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        string boxTextString = templateSellerIdComboBox.Text.Split('(')[0];
        templateSellerIdComboBox.Text = boxTextString[..(boxTextString.Length - 1)];
        templateSellerName.Text = SellerIdName[templateSellerIdComboBox.Text];
        templateSellerIdComboBox.Text = ParseToNumberFormat(templateSellerIdComboBox.Text);
        RefreshInputButtonState();
    }
}