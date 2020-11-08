using System;
using System.Windows.Forms;

namespace MicroEditor
{
    public partial class ReplaceForm : Form
    {
        #region Attributes

        private MainForm _parent;

        #endregion

        #region Constructor

        public ReplaceForm(MainForm parent)
        {
            InitializeComponent();
            this._parent = parent;
            this.findWhatTextBox.Text = this._parent.FindText;
            this.findWhatTextBox.SelectAll();
        }

        #endregion

        #region Events

        private void findWhatTextBox_TextChanged(object sender, EventArgs e)
        {
            this.AutoFind();
        }

        private void findWhatTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(Keys.Return)))
            {
                this.findButton_Click(sender, e);
            }
            else if (e.KeyChar.Equals(Convert.ToChar(Keys.Escape)))
            {
                this.Close();
            }

        }

        private void findButton_Click(object sender, EventArgs e)
        {
            this.FindNext();
        }

        private void replaceButton_Click(object sender, EventArgs e)
        {
            this.Replace();
        }

        private void replaceAllButton_Click(object sender, EventArgs e)
        {
            this.ReplaceAll();
        }

        private void matchCaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.ToggleMatchCase();
        }

        #endregion

        #region Methods

        private void AutoFind()
        {
            this._parent.FindText = this.findWhatTextBox.Text;
            this._parent.AutoFind();
        }

        private void FindNext()
        {
            this._parent.FindText = this.findWhatTextBox.Text;
            this._parent.FindNext();
        }

        private void Replace()
        {
            this._parent.FindText = this.findWhatTextBox.Text;
            this._parent.Replace(this.replaceWithTextBox.Text);
        }

        private void ReplaceAll()
        {
            this._parent.FindText = this.findWhatTextBox.Text;
            this._parent.ReplaceAll(this.replaceWithTextBox.Text);
        }

        private void ToggleMatchCase()
        {
            this._parent.MatchCase = this.matchCaseCheckBox.Checked;
        }

        #endregion
    }
}
