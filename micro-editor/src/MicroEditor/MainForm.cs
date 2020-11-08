using System;
using System.Windows.Forms;
using System.IO;
using MicroEditor.Properties;
using System.Diagnostics;
using System.Globalization;

namespace MicroEditor
{
    public partial class MainForm : Form
    {
        #region Constants

        const string CONFIRM = "Are you sure?";
        const string EXT = "txt";
        const string FILTER = "Text Documents (*.txt)|*.txt|Comma Separated Values (*.csv)|*.csv|Hypertext Markup Language Document (*.htm;*.html)|*.htm;*.html|Extended Markup Language Document (*.xml)|*.xml|All Files|*";
        
        #endregion

        #region Attributes

        private string _fileName = "";
        private int _filterIndex = 0;
        private RichTextBoxFinds _finds = RichTextBoxFinds.None;
        private string _findText = "";
        private string _folderName = "";
        private bool _matchCase = false;
        private ReplaceForm _replaceForm;
        private string _savedText = "";

        #endregion

        #region Properties

        public string FindText
        {
            get
            {
                return this._findText;
            }

            set
            {
                this._findText = value;
            }
        }
                
        public bool MatchCase
        {
            get
            {
                return this._matchCase;
            }

            set
            {
                this._matchCase = value;

                if (_matchCase)
                {
                    _finds = RichTextBoxFinds.MatchCase;
                }
                else
                {
                    _finds = RichTextBoxFinds.None;
                }
            }
        }

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.LoadSettings();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.CheckOut(e);
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            this.New();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.New();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            this.Open();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Open();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SaveAs();
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            this.Print();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Print();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.PrintPreview();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Redo();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            this.Cut();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            this.Copy();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            this.Paste();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Paste();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowFind();
        }

        public void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FindNext();
        }

        private void findPreviousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FindPrevious();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowReplace();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SelectAll();
        }

        private void upperCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.UpperCase();
        }

        private void lowerCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LowerCase();
        }

        private void titleCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TitleCase();
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DisplayBackground();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DisplayColor();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DisplayFont();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            this.Help();
        }

        private void onlineHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Help();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.About();
        }

        private void closeLabel_Click(object sender, EventArgs e)
        {
            this.HideSearchPanel();
        }

        private void findTextBox_TextChanged(object sender, EventArgs e)
        {
            this.FindText = this.findTextBox.Text;
            this.AutoFind();
        }

        private void findTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(Keys.Return)))
            {
                this.FindNext();
            }
            else if (e.KeyChar.Equals(Convert.ToChar(Keys.Escape)))
            {
                this.HideSearchPanel();
            }
        }

        private void findPreviousLabel_Click(object sender, EventArgs e)
        {
            this.FindPrevious();
        }

        private void findNextLabel_Click(object sender, EventArgs e)
        {
            this.FindNext();
        }

        private void matchCaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.ToggleMatchCase();
        }
        
        #endregion

        #region Methods

        private void About()
        {
            MessageBox.Show("\x00b5Editor (MicroEditor), a minimalist text editor.\n\nCreated by Diogo Schneider - 2009, 2017.", "About \x00b5Editor");
        }

        public void AutoFind()
        {
            if (this.FindText.Length > 0)
            {
                this.richTextBox.Find(this.FindText, this.richTextBox.SelectionStart, this.richTextBox.TextLength, _finds);
            }
            else
            {
                this.richTextBox.SelectionLength = 0;
            }
        }

        private void CheckOut(FormClosingEventArgs e)
        {
            if (!(this.richTextBox.Text.Equals(this._savedText) || (MessageBox.Show(CONFIRM, "Exit", MessageBoxButtons.YesNo) != DialogResult.No)))
            {
                e.Cancel = true;
            }
            else
            {
                this.SaveSettings();
            }
        }

        private void Copy()
        {
            if (this.richTextBox.SelectedText.Length > 0)
            {
                Clipboard.SetText(this.richTextBox.SelectedText);
            }
        }

        private void Cut()
        {
            this.Copy();
            this.richTextBox.SelectedText = "";
        }

        private void DisplayBackground()
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = this.richTextBox.BackColor;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox.BackColor = dialog.Color;
            }
        }

        private void DisplayColor()
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = this.richTextBox.ForeColor;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox.ForeColor = dialog.Color;
            }
        }

        private void DisplayFont()
        {
            FontDialog dialog = new FontDialog();
            dialog.Font = this.richTextBox.Font;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox.Font = dialog.Font;
            }
        }

        public void FindNext()
        {
            if (this.richTextBox.Find(this.FindText, this.richTextBox.SelectionStart + this.richTextBox.SelectionLength, this.richTextBox.TextLength, _finds) == -1)
            {
                this.richTextBox.Find(this.FindText, 0, this.richTextBox.TextLength, _finds);
            }
        }

        private void FindPrevious()
        {
            if (this.richTextBox.Find(this.FindText, 0, this.richTextBox.SelectionStart, _finds | RichTextBoxFinds.Reverse) == -1)
            {
                this.richTextBox.Find(this.FindText, 0, this.richTextBox.TextLength, _finds | RichTextBoxFinds.Reverse);
            }
        }

        private void Help()
        {
            try
            {
                Process.Start("https://diogoschneider.github.io/micro-editor/");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, exception.Source, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void HideSearchPanel()
        {
            this.searchPanel.Visible = false;
            this.richTextBox.Focus();
        }

        private void LoadSettings()
        {
            base.Location = Settings.Default.Location;
            base.Size = Settings.Default.Size;
            this.richTextBox.BackColor = Settings.Default.Background;
            this.richTextBox.Font = Settings.Default.Font;
            this.richTextBox.ForeColor = Settings.Default.Color;
        }

        private void LowerCase()
        {
            this.richTextBox.SelectedText = CultureInfo.InvariantCulture.TextInfo.ToLower(this.richTextBox.SelectedText);
        }

        private void New()
        {
            if (this.richTextBox.Text.Equals(this._savedText) || (MessageBox.Show(CONFIRM, "New", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                this.richTextBox.Clear();
                this._savedText = "";
            }
        }

        private void Open()
        {
            if (this.richTextBox.Text.Equals(this._savedText) || (MessageBox.Show(CONFIRM, "Open", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.InitialDirectory = this._folderName;
                dialog.DefaultExt = EXT;
                dialog.Filter = FILTER;
                dialog.FilterIndex = this._filterIndex;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this._fileName = dialog.FileName;
                    this._folderName = Path.GetDirectoryName(this._fileName);
                    this._filterIndex = dialog.FilterIndex;
                    this.richTextBox.LoadFile(this._fileName, RichTextBoxStreamType.PlainText);
                    this._savedText = this.richTextBox.Text;
                    this.SetTitle();
                }
            }
        }

        private void Paste()
        {
            if (Clipboard.ContainsText())
            {
                string text = Clipboard.GetText();
                Clipboard.SetText(Clipboard.GetText(TextDataFormat.UnicodeText));
                this.richTextBox.Paste();
                Clipboard.SetText(text);
            }
        }

        private void Print()
        {
            //TODO: Print feature.
        }

        private void PrintPreview()
        {
            //TODO: Print Preview feature.
        }

        private void Redo()
        {
            this.richTextBox.Redo();
        }

        public void Replace(string text)
        {
            if (this.richTextBox.SelectedText.Length > 0)
            {
                this.richTextBox.SelectedText = text;
                this.FindNext();
            }
        }

        public void ReplaceAll(string text)
        {
            if (this.richTextBox.Find(this.FindText, 0, this.richTextBox.TextLength, _finds) > -1)
            {
                this.richTextBox.SelectedText = text;

                while (this.richTextBox.Find(this.FindText, this.richTextBox.SelectionStart, this.richTextBox.TextLength, _finds) > -1)
                {
                    this.richTextBox.SelectedText = text;
                }
            }
        }
        
        private void Save()
        {
            if (this._fileName.Length > 0)
            {
                this.WriteFile();
            }
            else
            {
                this.SaveAs();
            }
        }

        private void SaveAs()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = this._folderName;
            dialog.DefaultExt = EXT;
            dialog.Filter = FILTER;
            dialog.FilterIndex = this._filterIndex;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this._fileName = dialog.FileName;
                this._folderName = Path.GetDirectoryName(this._fileName);
                this._filterIndex = dialog.FilterIndex;
                this.WriteFile();
                this.SetTitle();
            }
        }

        private void SaveSettings()
        {
            Settings.Default.Background = this.richTextBox.BackColor;
            Settings.Default.Color = this.richTextBox.ForeColor;
            Settings.Default.Font = this.richTextBox.Font;
            Settings.Default.Location = base.Location;

            if (base.WindowState == FormWindowState.Normal)
            {
                Settings.Default.Size = base.Size;
            }
            else
            {
                Settings.Default.Size = base.RestoreBounds.Size;
            }

            Settings.Default.Save();
        }

        private void SelectAll()
        {
            this.richTextBox.SelectAll();
        }

        private void SetTitle()
        {
            this.Text = Path.GetFileName(this._fileName) + " - " + base.ProductName;
        }

        private void ShowFind()
        {
            this.searchPanel.Visible = true;
            this.findTextBox.Focus();
        }

        private void ShowReplace()
        {
            if ((this._replaceForm != null) && this._replaceForm.Visible)
            {
                this._replaceForm.Focus();
            }
            else
            {
                this._replaceForm = new ReplaceForm(this);
                this._replaceForm.Show();
            }
        }

        private void TitleCase()
        {
            this.richTextBox.SelectedText = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(CultureInfo.InvariantCulture.TextInfo.ToLower(this.richTextBox.SelectedText));
        }

        private void ToggleMatchCase()
        {
            this.MatchCase = this.matchCaseCheckBox.Checked;
        }

        private void Undo()
        {
            this.richTextBox.Undo();
        }

        private void UpperCase()
        {
            this.richTextBox.SelectedText = CultureInfo.InvariantCulture.TextInfo.ToUpper(this.richTextBox.SelectedText);
        }

        private void WriteFile()
        {
            this.richTextBox.SaveFile(this._fileName, RichTextBoxStreamType.PlainText);
            this._savedText = this.richTextBox.Text;
        }

        #endregion
    }
}
