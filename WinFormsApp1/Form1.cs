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
    // �����ļ� ��
    #region config
    string templatePath = "";
    #endregion

    /// <summary>
    /// ����
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
            MessageBox.Show("��û������ģ��ͳ���ļ���, Ĭ�Ͻ��ڳ��������ļ����ﴴ����", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        // ����������ʦQQ
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
            // ֻ��ʾid
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
                        // ����ļ����Ƿ���Ч
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
                    dialog.Description = "��ѡ��ģ��ͳ���ļ���";
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
                dialog.Description = "��ѡ��ģ��ͳ���ļ���";
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
    /// ��ק��
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
        folderLabel.Text = $"�Ѽ�⵽�ļ��� \"{Path.GetFileName(path)}\"��";
    }

    /// <summary>
    /// ��ק���ļ���
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
            MessageBox.Show("�������ļ���", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        folderLabel.Text = $"��ѡ�� \"{Path.GetFileName(path)}\"��";
        clearButton.Enabled = true;
        refreshFolderContentButton.Enabled = true;
        RefreshInputButtonState();
    }
    private static string GetNumbers(string input)
    {
        // ʹ��������ʽƥ������
        string pattern = @"\d+";
        MatchCollection matches = Regex.Matches(input, pattern);

        // ��ƥ�䵽���������ӳ�һ���ַ���
        string result = "";
        foreach (Match match in matches.Cast<Match>())
        {
            result += match.Value;
        }

        return result;
    }

    static string GetFloatStr(string input)
    {
        // ʹ��������ʽ��ȡ���ֲ���
        string pattern = @"[-+]?\d*\.?\d+";
        Match match = Regex.Match(input, pattern);

        // ���ƥ��ɹ������Խ�ƥ�䵽���ַ���ת��Ϊ������
        if (match.Success)
        {
            string numberStr = match.Value;
            if (float.TryParse(numberStr, out _))
            {
                return numberStr;
            }
        }

        // ���ƥ��ʧ�ܻ���ת��ʧ�ܣ��򷵻�Ĭ��ֵ 0
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
    /// ˢ�µ��밴ť״̬
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
    /// ��;
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void templateUsageComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshInputButtonState();
    }


    /// <summary>
    /// ģ������
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void templateAuthorTextBox_TextChanged(object sender, EventArgs e)
    {
        RefreshInputButtonState();
    }

    /// <summary>
    /// ģ����
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void templateNameTextBox_TextChanged(object sender, EventArgs e)
    {
        RefreshInputButtonState();
    }

    /// <summary>
    /// ģ��۸�
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
    /// ģ��������ʦQQ
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void templateSellerIdComboBox_Leave(object sender, EventArgs e)
    {
        templateSellerIdComboBox.Text = ParseToNumberFormat(templateSellerIdComboBox.Text);
        RefreshInputButtonState();
    }

    /// <summary>
    /// ģ��������ʦ��ע
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void templateSellerName_TextChanged(object sender, EventArgs e)
    {
        RefreshInputButtonState();
    }

    /// <summary>
    /// ģ��ͳ��Ⱥ����
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void templateGroupCountTextBox_Leave(object sender, EventArgs e)
    {
        templateGroupCountTextBox.Text = ParseToNumberFormat(templateGroupCountTextBox.Text);
        RefreshInputButtonState();
    }

    /// <summary>
    /// ģ�巢����ʽ
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void templateDeliveryWaysComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshInputButtonState();
    }

    /// <summary>
    /// ����
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void InputButton_Click(object sender, EventArgs e)
    {
        this.Cursor = Cursors.WaitCursor;
        importStatusStrip.Text = "������...";
        int[] indexs = templateBox.SelectedIndices.Cast<int>().ToArray();
        string[] selectedPaths = (from index in indexs select templatesFilePaths[index]).ToArray();
        //MessageBox.Show(selectedPaths.ToString());
        if (!ImportTemplate(selectedPaths))
        {
            this.Cursor = Cursors.Default;
            importStatusStrip.Text = "������";
            return;
        }
        importStatusStrip.Text = "������";
        this.Cursor = Cursors.Default;
        //foreach (int index in templateBox.SelectedIndices)
        //{
        //    templatesFilePaths.RemoveAt(index);
        //    templateBox.Items.RemoveAt(index);
        //}
        RefreshInputButtonState();
    }

    /// <summary>
    /// ����ģ��
    /// </summary>
    private bool ImportTemplate(string[] templates)
    {
        if (templates.Length <= 0) return false;
        int cratedFileCount = 0;
        //MessageBox.Show(templatePath);
        string path = $"{templatePath}\\{templateSellerIdComboBox.Text}-{(templateSellerName.Text != "" ? "��ע" + templateSellerName.Text : "")}";
        string[] directories = Directory.GetDirectories(templatePath);
        foreach (string directory in directories)
        {
            // �жϸ�QQ���ļ����Ƿ����
            if (Path.GetFileName(directory).Split("-")[0] != templateSellerIdComboBox.Text) continue;
            path = directory;
            //MessageBox.Show($"����QQΪ{templateSellerIdComboBox.Text}���ļ���{Path.GetFileName(directory).Split("-")[0]}");
            try
            {
                // �����ע��һ�»�û��д��ע�������
                if (Path.GetFileName(directory).Split("-")[1][2..] == templateSellerName.Text || templateSellerName.Text == "") continue;
            }
            catch
            {
                // �����û�б�ע��
                continue;
            }
            DialogResult sellerNameResult = MessageBox.Show($"��ǰ����QQ\"{templateSellerIdComboBox.Text}\"�ı�ע����һ��, ԭ��ע��Ϊ\"{Path.GetFileName(directory).Split("-")[1][2..]}\", ��ǰ��д��ע��Ϊ\"{templateSellerName.Text}\", �Ƿ�������Ϊ\"{path}\"��", "����", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sellerNameResult == DialogResult.Yes)
            {
                try
                {
                    //MessageBox.Show(path);
                    //MessageBox.Show(directory);
                    Directory.Move(directory, path);
                    MessageBox.Show($"�ɹ����ļ���������Ϊ{Path.GetFileName(path)}��", "��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������ʧ��: {ex.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // ���Դ����ļ���
            Directory.CreateDirectory(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"�޷����� {path} �ļ���: {ex.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        // ����������Ϣ
        Directory.CreateDirectory(path + "\\!�����¼");
        bool isCostInt = int.TryParse(templateCostTextBox.Text, out int costInt);
        string usage = templateUsageComboBox.Text switch
        {
            "����" => "��",
            "ʹ��" => "ʹ",
            "��ʹ��һ" => "��+ʹ",
            _ => templateUsageComboBox.Text,
        };
        string deliWays = templateDeliveryWaysComboBox.Text switch
        {
            "Ⱥ��" => "Ⱥ",
            "�Ʒ�" => "��",
            "˽��" => "˽",
            _ => "ERROR",
        };
        if (usage == "ERROR" || deliWays == "ERROR")
        {
            MessageBox.Show("��;�򷢻���ʽѡ�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        //int templateCount = templates.Length;
        // ģ����
        string templateAuthor = templateAuthorTextBox.Text.Trim().Replace(" ", "-");
        if (templateAuthor != "")
        {
            // �����һ���ַ����Ƶ������
            if (templateAuthor[^1] == '��')
            {
                // ��������ڶ����ַ������򲻼���, �������
                if (templateAuthor.Length == 1)
                {
                    templateAuthor += '��';
                }               
            }
            else
            {
                templateAuthor += '��';
            }
        }
        else
        {
            templateAuthor = "��֪��ʲô��";
        }
        string templateName = templateNameTextBox.Text.Trim().Replace(" ", "-");
        string templateFullName = templateAuthor + " " + templateName;
        // ����ģ���ļ�������
        string templateFolderName = $"{templateGroupCountTextBox.Text}q_{double.Parse(templateCostTextBox.Text):G}r_{usage}_{deliWays}_{templateFullName}_��{templateName.Split('+').Length}";

        string[] templateDirectories = Directory.GetDirectories(path);
        foreach (string directory in templateDirectories)
        {
            if (Path.GetFileName(directory)[0] == '!') continue;
            if (Path.GetFileName(directory).Split("_")[4] == templateFullName)
            {
                // ����Ƿ����·��
                DialogResult result = MessageBox.Show($"�Ѵ���ģ����Ϊ\"{templateAuthor + " " + templateNameTextBox.Text}\"��ģ���ļ���, �Ƿ���Ȼ��ӣ�", "����", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
                MessageBox.Show($"���� \"{template}\" �ļ�ʱ���ִ����������ļ�, ������Ϣ: {ex}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // �����涨
        if (templateAgreementTextBox.Text != "")
        {
            try
            {
                using (FileStream fs = File.Create(templateFolderPath + "\\�涨.txt"))
                {
                    // ʹ���ļ������� StreamWriter
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        // ���ı�д���ļ�
                        writer.WriteLine(templateAgreementTextBox.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"�����涨�ļ�ʱ���ִ���ֹͣ����, ������Ϣ: {ex}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        if (cratedFileCount <= 0)
        {
            return false;
        }
        MessageBox.Show($"�ѳɹ����ļ��������ļ���{templateFolderPath}", "���", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return true;
    }

    /// <summary>
    /// ȫ������
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void InputAllButton_Click(object sender, EventArgs e)
    {
        importStatusStrip.Text = "������...";
        this.Cursor = Cursors.WaitCursor;
        if (!ImportTemplate(templatesFilePaths.ToArray()))
        {
            importStatusStrip.Text = "������";
            this.Cursor = Cursors.Default;
            return;
        }
        importStatusStrip.Text = "������";
        this.Cursor = Cursors.Default;
        templatesFilePaths.Clear();
        Clear();
        RefreshInputButtonState();
    }

    /// <summary>
    /// ѡ���ļ���
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void chooseFolderButton_Click(object sender, EventArgs e)
    {
        using (FolderBrowserDialog dialog = new FolderBrowserDialog())
        {
            dialog.Description = "��ѡ��ģ�幤���ļ���";
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
    /// ���
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
    /// ����ģ���ļ���
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
            dialog.Description = "��ѡ��ģ��ͳ���ļ���";
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
    /// ˢ��
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
        MessageBox.Show($"ģ���ļ���·��Ϊ{templatePath}��", "��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void helpMenuStrip_Click(object sender, EventArgs e)
    {
        MessageBox.Show($"    ��ק��ѡ����ģ�幤���ļ����ļ��е����Ĺ�������֮�����Ҳ���дģ����Ϣ�����б���ѡ����Ҫ�Ĺ����ļ����ɶ�ѡ������\"������ѡ\"���е��룬����ʹ��\"ȫ������\"�����б��е����й����ļ���\n\n" +
                         "    ��һ�δ򿪸ó���ʱ��Ҫ��ѡ��ģ���ŵ��ļ��У�֮�����\"����\"������и��ģ�����\"��Ϣ\"����鿴��\n\n" +
                         "    ע��: ģ������'+'�ָ���ģ���������ģ�����ᱻ��¼��ģ��������", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
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