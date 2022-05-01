using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadMFI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm child = new ChildForm();
            child.MdiParent = this;
            child.Show();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var child = (ChildForm)this.ActiveMdiChild;
                child.TextBox.Undo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var child = (ChildForm)this.ActiveMdiChild;
                child.TextBox.Redo();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var child = (ChildForm)this.ActiveMdiChild;
                child.TextBox.Cut();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var child = (ChildForm)this.ActiveMdiChild;
                child.TextBox.Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var child = (ChildForm)this.ActiveMdiChild;
                child.TextBox.Paste();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Title = "Open document";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                ChildForm child = new ChildForm();
                child.MdiParent = this;
                using (StreamReader sr = new StreamReader(openfile.FileName))
                {
                    child.TextBox.Text = sr.ReadToEnd();
                    sr.Close();
                }
                child.Show();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Title = "Save file as";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter txtoutput = new StreamWriter(savefile.FileName);
                var child = (ChildForm)this.ActiveMdiChild;
                txtoutput.Write(child.TextBox.Text);
                txtoutput.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new AboutBox()).ShowDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var child = (ChildForm)this.ActiveMdiChild;
                child.Close();
            }
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var child = (ChildForm)this.ActiveMdiChild;
                ColorDialog MyDialog = new ColorDialog();
                MyDialog.AllowFullOpen = false;
                MyDialog.Color = child.TextBox.ForeColor;

                if (MyDialog.ShowDialog() == DialogResult.OK)
                    child.TextBox.ForeColor = MyDialog.Color;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var child = (ChildForm)this.ActiveMdiChild;

                FontDialog fontDialog1 = new FontDialog();
                fontDialog1.ShowColor = true;

                fontDialog1.Font = child.TextBox.Font;
                fontDialog1.Color = child.TextBox.ForeColor;

                if (fontDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    child.TextBox.Font = fontDialog1.Font;
                    child.TextBox.ForeColor = fontDialog1.Color;
                }
            }
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void minimizeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.WindowState = FormWindowState.Minimized;
            }
        }

        private void maximizeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.WindowState = FormWindowState.Normal;
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem.PerformClick();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem.PerformClick();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem.PerformClick();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem.PerformClick();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem.PerformClick();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem.PerformClick();
        }

        private void toolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolBarToolStripMenuItem.Checked = !toolBarToolStripMenuItem.Checked;
            toolStrip1.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var child = (ChildForm)this.ActiveMdiChild;
                var data = child.TextBox.Text;
                if (data != null) 
                {
                    int key;
                    int.TryParse(keyBox.Text, out key);
                    CaesarCipher caesarCipher = new CaesarCipher(key);
                    var encryptedData = caesarCipher.Encrypt(data);
                    child.TextBox.Text = encryptedData;
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var child = (ChildForm)this.ActiveMdiChild;
                var data = child.TextBox.Text;
                if (data != null)
                {
                    int key;
                    int.TryParse(keyBox.Text, out key);
                    CaesarCipher caesarCipher = new CaesarCipher(key);
                    var encryptedData = caesarCipher.Decrypt(data);
                    child.TextBox.Text = encryptedData;
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var child = (ChildForm)this.ActiveMdiChild;
            var data = child.TextBox.Text;
            if (data != null)
            {
                var resultText = "";
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.Title = "Open document for compare";
                if (openfile.ShowDialog() == DialogResult.OK)
                {

                    using (StreamReader sr = new StreamReader(openfile.FileName))
                    {
                        resultText = sr.ReadToEnd();
                        sr.Close();
                    }
                }
                int i = 0;
                for (; i < 1000; i++)
                {
                    CaesarCipher caesarCipher = new CaesarCipher(i);
                    if (caesarCipher.Encrypt(resultText) == data) 
                    {
                        MessageBox.Show($"Key = {i}");
                        break;
                    }
                }
                if (i == 1000) 
                {
                    MessageBox.Show("Key was not found");
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var child = (ChildForm)this.ActiveMdiChild;
            var data = child.TextBox.Text;
            if (data != null)
            {
                FrequencyTable frequencyTable = new FrequencyTable(data);
                MessageBox.Show(frequencyTable.ToString());
            }
        }

        private void encodeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var data = (keyBox.Text).Split(' ');
            if (data.Length == 2 && int.TryParse(data[0], out int a) && int.TryParse(data[1], out int b)) 
            {
                LiniarTrithemiusCipher liniarTrithemiusCipher = new LiniarTrithemiusCipher(a, b);
                var child = (ChildForm)this.ActiveMdiChild;
                var dataText = child.TextBox.Text;
                var result = liniarTrithemiusCipher.Encrypt(dataText);
                child.TextBox.Text = result;
            }
        }

        private void decodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var data = (keyBox.Text).Split(' ');
            if (data.Length == 2 && int.TryParse(data[0], out int a) && int.TryParse(data[1], out int b))
            {
                LiniarTrithemiusCipher liniarTrithemiusCipher = new LiniarTrithemiusCipher(a, b);
                var child = (ChildForm)this.ActiveMdiChild;
                var dataText = child.TextBox.Text;
                var result = liniarTrithemiusCipher.Decrypt(dataText);
                child.TextBox.Text = result;
            }
        }

        private void encodeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var data = (keyBox.Text).Split(' ');
            if (data.Length == 3 && int.TryParse(data[0], out int a) && int.TryParse(data[1], out int b) && int.TryParse(data[2], out int c))
            {
                NoLiniarTrithemiusCipher unliniarTrithemiusCipher = new NoLiniarTrithemiusCipher(a, b, c);
                var child = (ChildForm)this.ActiveMdiChild;
                var dataText = child.TextBox.Text;
                var result = unliniarTrithemiusCipher.Encrypt(dataText);
                child.TextBox.Text = result;
            }
        }

        private void decodeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var data = (keyBox.Text).Split(' ');
            if (data.Length == 3 && int.TryParse(data[0], out int a) && int.TryParse(data[1], out int b) && int.TryParse(data[2], out int c))
            {
                NoLiniarTrithemiusCipher unliniarTrithemiusCipher = new NoLiniarTrithemiusCipher(a, b, c);
                var child = (ChildForm)this.ActiveMdiChild;
                var dataText = child.TextBox.Text;
                var result = unliniarTrithemiusCipher.Decrypt(dataText);
                child.TextBox.Text = result;
            }
        }

        private void encodeToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var data = keyBox.Text;
            if (data != null)
            {
                HasloTrithemiusCipher hasloTrithemiusCipher = new HasloTrithemiusCipher(data);
                var child = (ChildForm)this.ActiveMdiChild;
                var dataText = child.TextBox.Text;
                var result = hasloTrithemiusCipher.Encrypt(dataText);
                child.TextBox.Text = result;
            }
        }

        private void decodeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var data = keyBox.Text;
            if (data != null)
            {
                HasloTrithemiusCipher hasloTrithemiusCipher = new HasloTrithemiusCipher(data);
                var child = (ChildForm)this.ActiveMdiChild;
                var dataText = child.TextBox.Text;
                var result = hasloTrithemiusCipher.Decrypt(dataText);
                child.TextBox.Text = result;
            }
        }

        private void encryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gamma gamma = new Gamma();
            var child = (ChildForm)this.ActiveMdiChild;
            var dataText = child.TextBox.Text;
            var result = gamma.Encrypt(dataText);
            child.TextBox.Text = result;
            keyBox.Text = gamma.GammaValue;
        }

        private void decodeToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Gamma gamma = new Gamma();
            gamma.GammaValue = keyBox.Text;
            var child = (ChildForm)this.ActiveMdiChild;
            var dataText = child.TextBox.Text;
            if (keyBox.Text.Length > 0) {
                var result = gamma.Decrypt(dataText);
                child.TextBox.Text = result;
            }
        }

        private void encryptToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Vinezher vinezher = new Vinezher();
            var child = (ChildForm)this.ActiveMdiChild;
            var dataText = child.TextBox.Text;
            if (keyBox.Text.Length > 0)
            {
                var result = vinezher.Encrypt(dataText, keyBox.Text);
                child.TextBox.Text = result;
            }
        }

        private void decryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vinezher vinezher = new Vinezher();
            var child = (ChildForm)this.ActiveMdiChild;
            var dataText = child.TextBox.Text;
            if (keyBox.Text.Length > 0)
            {
                var result = vinezher.Decrypt(dataText, keyBox.Text);
                child.TextBox.Text = result;
            }
        }
    }
}
