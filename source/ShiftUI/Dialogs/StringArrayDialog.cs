using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ShiftUI.Dialogs
{
    public interface IEditorDialog
    {
        object Value { get; }
        void ShowEditor();
    }

    public class StringArrayDialog : Form, IEditorDialog
    {
        private string[] lines = null;

        public object Value
        {
            get { return lines; }
        }

        public void ShowEditor()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowDialog();
        }

        public StringArrayDialog()
        {
            this.AllowTransparency = false;
            this.AutoScale = true;
            this.AutoScaleBaseSize = new Size(5, 13);
            this.AutoScroll = false;
            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            this.AutoValidate = AutoValidate.Inherit;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.ClientSize = new Size(397, 391);
            this.WidgetBox = true;
            this.DesktopLocation = new Point(0, 0);
            this.DialogResult = DialogResult.None;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.HelpButton = false;
            this.IsMdiContainer = false;
            this.KeyPreview = false;
            this.MaximizeBox = true;
            this.MaximumSize = new Size(0, 0);
            this.MinimizeBox = true;
            this.MinimumSize = new Size(0, 0);
            this.RightToLeftLayout = false;
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.Size = new Size(397, 391);
            this.SizeGripStyle = SizeGripStyle.Auto;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.TabIndex = 0;
            this.TabStop = true;
            this.TopLevel = true;
            this.TopMost = false;
            this.WindowState = FormWindowState.Normal;
            this.Text = "String collection";
            this.Location = new Point(0, 0);
            this.AutoScaleMode = AutoScaleMode.Inherit;
            this.AutoScrollMargin = new Size(0, 0);
            this.AutoScrollMinSize = new Size(0, 0);
            this.AutoScrollPosition = new Point(0, 0);
            this.Alignment = (ContentAlignment)0;
            this.AccessibleDefaultActionDescription = "";
            this.AccessibleDescription = "";
            this.AccessibleName = "";
            this.AccessibleRole = AccessibleRole.Default;
            this.AllowDrop = false;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.AutoScrollOffset = new Point(0, 0);
            this.BackgroundImageLayout = ImageLayout.Tile;
            this.Capture = false;
            this.CausesValidation = true;
            this.Dock = DockStyle.None;
            this.Enabled = true;
            this.Font = new Font("Microsoft Sans Serif", (float)8.25, (FontStyle)0);
            this.ForeColor = Color.FromArgb(0, 0, 0);
            this.Height = 391;
            this.ImeMode = ImeMode.NoControl;
            this.IsAccessible = false;
            this.Left = 0;
            this.Name = "StringArrayDialog";
            this.RightToLeft = RightToLeft.No;
            this.Top = 0;
            this.UseWaitCursor = false;
            this.Visible = false;
            this.Width = 397;

            rtb_contents = new RichTextBox();
            rtb_contents.AllowDrop = false;
            rtb_contents.AutoSize = false;
            rtb_contents.AutoWordSelection = false;
            rtb_contents.BackgroundImageLayout = ImageLayout.Tile;
            rtb_contents.BulletIndent = 0;
            rtb_contents.DetectUrls = true;
            rtb_contents.EnableAutoDragDrop = false;
            rtb_contents.Font = new Font("Microsoft Sans Serif", (float)8.25, (FontStyle)0);
            rtb_contents.ForeColor = Color.FromArgb(0, 0, 0);
            rtb_contents.LanguageOption = RichTextBoxLanguageOptions.AutoFontSizeAdjust;
            rtb_contents.MaxLength = 2147483647;
            rtb_contents.Multiline = true;
            rtb_contents.RichTextShortcutsEnabled = true;
            rtb_contents.RightMargin = 0;
            rtb_contents.ScrollBars = RichTextBoxScrollBars.Both;
            rtb_contents.SelectedText = "";
            rtb_contents.SelectionAlignment = HorizontalAlignment.Left;
            rtb_contents.SelectionBackColor = Color.FromArgb(240, 240, 240);
            rtb_contents.SelectionBullet = false;
            rtb_contents.SelectionCharOffset = 0;
            rtb_contents.SelectionColor = Color.FromArgb(0, 0, 0);
            rtb_contents.SelectionFont = new Font("Microsoft Sans Serif", (float)8.25, (FontStyle)0);
            rtb_contents.SelectionHangingIndent = 0;
            rtb_contents.SelectionIndent = 0;
            rtb_contents.SelectionLength = 0;
            rtb_contents.SelectionProtected = false;
            rtb_contents.SelectionRightIndent = 0;
            rtb_contents.ShowSelectionMargin = false;
            rtb_contents.Text = "";
            rtb_contents.AcceptsTab = false;
            rtb_contents.BackColor = Color.FromArgb(255, 255, 255);
            rtb_contents.BorderStyle = BorderStyle.Fixed3D;
            rtb_contents.HideSelection = true;
            rtb_contents.Modified = false;
            rtb_contents.ReadOnly = false;
            rtb_contents.SelectionStart = 0;
            rtb_contents.ShortcutsEnabled = true;
            rtb_contents.WordWrap = true;
            rtb_contents.Alignment = (ContentAlignment)0;
            rtb_contents.AccessibleDefaultActionDescription = "";
            rtb_contents.AccessibleDescription = "";
            rtb_contents.AccessibleName = "";
            rtb_contents.AccessibleRole = AccessibleRole.Default;
            rtb_contents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtb_contents.AutoScrollOffset = new Point(0, 0);
            rtb_contents.MaximumSize = new Size(0, 0);
            rtb_contents.MinimumSize = new Size(0, 0);
            rtb_contents.Capture = false;
            rtb_contents.CausesValidation = true;
            rtb_contents.ClientSize = new Size(372, 281);
            rtb_contents.Dock = DockStyle.None;
            rtb_contents.Enabled = true;
            rtb_contents.Height = 285;
            rtb_contents.ImeMode = ImeMode.NoControl;
            rtb_contents.IsAccessible = false;
            rtb_contents.Left = 10;
            rtb_contents.Location = new Point(10, 65);
            rtb_contents.Name = "rtb_contents";
            rtb_contents.RightToLeft = RightToLeft.No;
            rtb_contents.Size = new Size(376, 285);
            rtb_contents.TabIndex = 0;
            rtb_contents.TabStop = true;
            rtb_contents.Top = 35;
            rtb_contents.UseWaitCursor = false;
            rtb_contents.Visible = true;
            rtb_contents.Width = 376;

            this.Widgets.Add(rtb_contents);
            rtb_contents.Show();
            lbtoplabel = new Label();
            lbtoplabel.AutoEllipsis = false;
            lbtoplabel.AutoSize = false;
            lbtoplabel.BackgroundImageLayout = ImageLayout.Tile;
            lbtoplabel.BorderStyle = BorderStyle.None;
            lbtoplabel.FlatStyle = FlatStyle.Standard;
            lbtoplabel.ImageAlign = ContentAlignment.MiddleCenter;
            lbtoplabel.ImageIndex = -1;
            lbtoplabel.ImageKey = "";
            lbtoplabel.ImeMode = ImeMode.NoControl;
            lbtoplabel.TabStop = false;
            lbtoplabel.TextAlign = ContentAlignment.TopLeft;
            lbtoplabel.UseMnemonic = true;
            lbtoplabel.UseCompatibleTextRendering = true;
            lbtoplabel.Text = "Enter each item on a separate line.";
            lbtoplabel.Alignment = (ContentAlignment)0;
            lbtoplabel.AccessibleDefaultActionDescription = "";
            lbtoplabel.AccessibleDescription = "";
            lbtoplabel.AccessibleName = "";
            lbtoplabel.AccessibleRole = AccessibleRole.Default;
            lbtoplabel.AllowDrop = false;
            lbtoplabel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lbtoplabel.AutoScrollOffset = new Point(0, 0);
            lbtoplabel.MaximumSize = new Size(0, 0);
            lbtoplabel.MinimumSize = new Size(0, 0);
            lbtoplabel.BackColor = Color.FromArgb(240, 240, 240);
            lbtoplabel.Capture = false;
            lbtoplabel.CausesValidation = true;
            lbtoplabel.ClientSize = new Size(189, 23);
            lbtoplabel.Dock = DockStyle.None;
            lbtoplabel.Enabled = true;
            lbtoplabel.Font = new Font("Microsoft Sans Serif", (float)8.25, (FontStyle)0);
            lbtoplabel.ForeColor = Color.FromArgb(0, 0, 0);
            lbtoplabel.Height = 23;
            lbtoplabel.IsAccessible = false;
            lbtoplabel.Left = 16;
            lbtoplabel.Location = new Point(16, 45);
            lbtoplabel.Name = "lbtoplabel";
            lbtoplabel.RightToLeft = RightToLeft.No;
            lbtoplabel.Size = new Size(189, 23);
            lbtoplabel.TabIndex = 1;
            lbtoplabel.Top = 15;
            lbtoplabel.UseWaitCursor = false;
            lbtoplabel.Visible = true;
            lbtoplabel.Width = 189;

            this.Widgets.Add(lbtoplabel);
            lbtoplabel.Show();
            btnok = new Button();
            btnok.Click += (o, a) =>
            {
                this.DialogResult = DialogResult.OK;
                lines = rtb_contents.Lines;
                this.Close();
            };
            btnok.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnok.DialogResult = DialogResult.None;
            btnok.AutoEllipsis = false;
            btnok.AutoSize = true;
            btnok.BackColor = Color.FromArgb(240, 240, 240);
            btnok.FlatStyle = FlatStyle.Standard;
            btnok.ImageAlign = ContentAlignment.MiddleCenter;
            btnok.ImageIndex = -1;
            btnok.ImageKey = "";
            btnok.ImeMode = ImeMode.Disable;
            btnok.Text = "OK";
            btnok.TextAlign = ContentAlignment.MiddleCenter;
            btnok.TextImageRelation = TextImageRelation.Overlay;
            btnok.UseCompatibleTextRendering = true;
            btnok.UseMnemonic = true;
            btnok.UseVisualStyleBackColor = true;
            btnok.Alignment = (ContentAlignment)0;
            btnok.AccessibleDefaultActionDescription = "";
            btnok.AccessibleDescription = "";
            btnok.AccessibleName = "";
            btnok.AccessibleRole = AccessibleRole.Default;
            btnok.AllowDrop = false;
            btnok.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnok.AutoScrollOffset = new Point(0, 0);
            btnok.MaximumSize = new Size(0, 0);
            btnok.MinimumSize = new Size(0, 0);
            btnok.BackgroundImageLayout = ImageLayout.Tile;
            btnok.Capture = false;
            btnok.CausesValidation = true;
            btnok.ClientSize = new Size(39, 23);
            btnok.Dock = DockStyle.None;
            btnok.Enabled = true;
            btnok.Font = new Font("Microsoft Sans Serif", (float)8.25, (FontStyle)0);
            btnok.ForeColor = Color.FromArgb(0, 0, 0);
            btnok.Height = 23;
            btnok.IsAccessible = false;
            btnok.Left = 11;
            btnok.Location = new Point(11, 355);
            btnok.Name = "btnok";
            btnok.RightToLeft = RightToLeft.No;
            btnok.Size = new Size(39, 23);
            btnok.TabIndex = 2;
            btnok.TabStop = true;
            btnok.Top = 325;
            btnok.UseWaitCursor = false;
            btnok.Visible = true;
            btnok.Width = 39;

            this.Widgets.Add(btnok);
            btnok.Show();

        }
        public RichTextBox rtb_contents = null;
        public Label lbtoplabel = null;
        public Button btnok = null;
    }

    public class ComboBoxEditorDialog : Form, IEditorDialog
    {
        ComboBox.ObjectCollection lines = null;

        public object Value
        {
            get {
                return lines;                
            }
        }

        public void ShowEditor()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowDialog();
        }

        public ComboBoxEditorDialog(ComboBox owner)
        {
            this.AllowTransparency = false;
            this.AutoScale = true;
            this.AutoScaleBaseSize = new Size(5, 13);
            this.AutoScroll = false;
            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            this.AutoValidate = AutoValidate.Inherit;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.ClientSize = new Size(397, 391);
            this.WidgetBox = true;
            this.DesktopLocation = new Point(0, 0);
            this.DialogResult = DialogResult.None;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.HelpButton = false;
            this.IsMdiContainer = false;
            this.KeyPreview = false;
            this.MaximizeBox = true;
            this.MaximumSize = new Size(0, 0);
            this.MinimizeBox = true;
            this.MinimumSize = new Size(0, 0);
            this.RightToLeftLayout = false;
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.Size = new Size(397, 391);
            this.SizeGripStyle = SizeGripStyle.Auto;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.TabIndex = 0;
            this.TabStop = true;
            this.TopLevel = true;
            this.TopMost = false;
            this.WindowState = FormWindowState.Normal;
            this.Text = "ComboBox item collection";
            this.Location = new Point(0, 0);
            this.AutoScaleMode = AutoScaleMode.Inherit;
            this.AutoScrollMargin = new Size(0, 0);
            this.AutoScrollMinSize = new Size(0, 0);
            this.AutoScrollPosition = new Point(0, 0);
            this.Alignment = (ContentAlignment)0;
            this.AccessibleDefaultActionDescription = "";
            this.AccessibleDescription = "";
            this.AccessibleName = "";
            this.AccessibleRole = AccessibleRole.Default;
            this.AllowDrop = false;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.AutoScrollOffset = new Point(0, 0);
            this.BackgroundImageLayout = ImageLayout.Tile;
            this.Capture = false;
            this.CausesValidation = true;
            this.Dock = DockStyle.None;
            this.Enabled = true;
            this.Font = new Font("Microsoft Sans Serif", (float)8.25, (FontStyle)0);
            this.ForeColor = Color.FromArgb(0, 0, 0);
            this.Height = 391;
            this.ImeMode = ImeMode.NoControl;
            this.IsAccessible = false;
            this.Left = 0;
            this.Name = "StringArrayDialog";
            this.RightToLeft = RightToLeft.No;
            this.Top = 0;
            this.UseWaitCursor = false;
            this.Visible = false;
            this.Width = 397;

            rtb_contents = new RichTextBox();
            rtb_contents.AllowDrop = false;
            rtb_contents.AutoSize = false;
            rtb_contents.AutoWordSelection = false;
            rtb_contents.BackgroundImageLayout = ImageLayout.Tile;
            rtb_contents.BulletIndent = 0;
            rtb_contents.DetectUrls = true;
            rtb_contents.EnableAutoDragDrop = false;
            rtb_contents.Font = new Font("Microsoft Sans Serif", (float)8.25, (FontStyle)0);
            rtb_contents.ForeColor = Color.FromArgb(0, 0, 0);
            rtb_contents.LanguageOption = RichTextBoxLanguageOptions.AutoFontSizeAdjust;
            rtb_contents.MaxLength = 2147483647;
            rtb_contents.Multiline = true;
            rtb_contents.RichTextShortcutsEnabled = true;
            rtb_contents.RightMargin = 0;
            rtb_contents.ScrollBars = RichTextBoxScrollBars.Both;
            rtb_contents.SelectedText = "";
            rtb_contents.SelectionAlignment = HorizontalAlignment.Left;
            rtb_contents.SelectionBackColor = Color.FromArgb(240, 240, 240);
            rtb_contents.SelectionBullet = false;
            rtb_contents.SelectionCharOffset = 0;
            rtb_contents.SelectionColor = Color.FromArgb(0, 0, 0);
            rtb_contents.SelectionFont = new Font("Microsoft Sans Serif", (float)8.25, (FontStyle)0);
            rtb_contents.SelectionHangingIndent = 0;
            rtb_contents.SelectionIndent = 0;
            rtb_contents.SelectionLength = 0;
            rtb_contents.SelectionProtected = false;
            rtb_contents.SelectionRightIndent = 0;
            rtb_contents.ShowSelectionMargin = false;
            rtb_contents.Text = "";
            rtb_contents.AcceptsTab = false;
            rtb_contents.BackColor = Color.FromArgb(255, 255, 255);
            rtb_contents.BorderStyle = BorderStyle.Fixed3D;
            rtb_contents.HideSelection = true;
            rtb_contents.Modified = false;
            rtb_contents.ReadOnly = false;
            rtb_contents.SelectionStart = 0;
            rtb_contents.ShortcutsEnabled = true;
            rtb_contents.WordWrap = true;
            rtb_contents.Alignment = (ContentAlignment)0;
            rtb_contents.AccessibleDefaultActionDescription = "";
            rtb_contents.AccessibleDescription = "";
            rtb_contents.AccessibleName = "";
            rtb_contents.AccessibleRole = AccessibleRole.Default;
            rtb_contents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtb_contents.AutoScrollOffset = new Point(0, 0);
            rtb_contents.MaximumSize = new Size(0, 0);
            rtb_contents.MinimumSize = new Size(0, 0);
            rtb_contents.Capture = false;
            rtb_contents.CausesValidation = true;
            rtb_contents.ClientSize = new Size(372, 281);
            rtb_contents.Dock = DockStyle.None;
            rtb_contents.Enabled = true;
            rtb_contents.Height = 285;
            rtb_contents.ImeMode = ImeMode.NoControl;
            rtb_contents.IsAccessible = false;
            rtb_contents.Left = 10;
            rtb_contents.Location = new Point(10, 65);
            rtb_contents.Name = "rtb_contents";
            rtb_contents.RightToLeft = RightToLeft.No;
            rtb_contents.Size = new Size(376, 285);
            rtb_contents.TabIndex = 0;
            rtb_contents.TabStop = true;
            rtb_contents.Top = 35;
            rtb_contents.UseWaitCursor = false;
            rtb_contents.Visible = true;
            rtb_contents.Width = 376;
            foreach(var line in owner.Items)
            {
                if (string.IsNullOrEmpty(rtb_contents.Text))
                {
                    rtb_contents.Text += "\r\n" + line.ToString();
                }
                else
                {
                    rtb_contents.Text += "\r\n" + line.ToString();
                }
            }

            this.Widgets.Add(rtb_contents);
            rtb_contents.Show();
            lbtoplabel = new Label();
            lbtoplabel.AutoEllipsis = false;
            lbtoplabel.AutoSize = false;
            lbtoplabel.BackgroundImageLayout = ImageLayout.Tile;
            lbtoplabel.BorderStyle = BorderStyle.None;
            lbtoplabel.FlatStyle = FlatStyle.Standard;
            lbtoplabel.ImageAlign = ContentAlignment.MiddleCenter;
            lbtoplabel.ImageIndex = -1;
            lbtoplabel.ImageKey = "";
            lbtoplabel.ImeMode = ImeMode.NoControl;
            lbtoplabel.TabStop = false;
            lbtoplabel.TextAlign = ContentAlignment.TopLeft;
            lbtoplabel.UseMnemonic = true;
            lbtoplabel.UseCompatibleTextRendering = true;
            lbtoplabel.Text = "Enter each item on a separate line.";
            lbtoplabel.Alignment = (ContentAlignment)0;
            lbtoplabel.AccessibleDefaultActionDescription = "";
            lbtoplabel.AccessibleDescription = "";
            lbtoplabel.AccessibleName = "";
            lbtoplabel.AccessibleRole = AccessibleRole.Default;
            lbtoplabel.AllowDrop = false;
            lbtoplabel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lbtoplabel.AutoScrollOffset = new Point(0, 0);
            lbtoplabel.MaximumSize = new Size(0, 0);
            lbtoplabel.MinimumSize = new Size(0, 0);
            lbtoplabel.BackColor = Color.FromArgb(240, 240, 240);
            lbtoplabel.Capture = false;
            lbtoplabel.CausesValidation = true;
            lbtoplabel.ClientSize = new Size(189, 23);
            lbtoplabel.Dock = DockStyle.None;
            lbtoplabel.Enabled = true;
            lbtoplabel.Font = new Font("Microsoft Sans Serif", (float)8.25, (FontStyle)0);
            lbtoplabel.ForeColor = Color.FromArgb(0, 0, 0);
            lbtoplabel.Height = 23;
            lbtoplabel.IsAccessible = false;
            lbtoplabel.Left = 16;
            lbtoplabel.Location = new Point(16, 45);
            lbtoplabel.Name = "lbtoplabel";
            lbtoplabel.RightToLeft = RightToLeft.No;
            lbtoplabel.Size = new Size(189, 23);
            lbtoplabel.TabIndex = 1;
            lbtoplabel.Top = 15;
            lbtoplabel.UseWaitCursor = false;
            lbtoplabel.Visible = true;
            lbtoplabel.Width = 189;

            this.Widgets.Add(lbtoplabel);
            lbtoplabel.Show();
            btnok = new Button();
            btnok.Click += (o, a) =>
            {
                this.DialogResult = DialogResult.OK;
                lines = new ComboBox.ObjectCollection(owner);
                foreach(var line in rtb_contents.Lines)
                {
                    lines.Add(line);
                }
                this.Close();
            };
            btnok.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnok.DialogResult = DialogResult.None;
            btnok.AutoEllipsis = false;
            btnok.AutoSize = true;
            btnok.BackColor = Color.FromArgb(240, 240, 240);
            btnok.FlatStyle = FlatStyle.Standard;
            btnok.ImageAlign = ContentAlignment.MiddleCenter;
            btnok.ImageIndex = -1;
            btnok.ImageKey = "";
            btnok.ImeMode = ImeMode.Disable;
            btnok.Text = "OK";
            btnok.TextAlign = ContentAlignment.MiddleCenter;
            btnok.TextImageRelation = TextImageRelation.Overlay;
            btnok.UseCompatibleTextRendering = true;
            btnok.UseMnemonic = true;
            btnok.UseVisualStyleBackColor = true;
            btnok.Alignment = (ContentAlignment)0;
            btnok.AccessibleDefaultActionDescription = "";
            btnok.AccessibleDescription = "";
            btnok.AccessibleName = "";
            btnok.AccessibleRole = AccessibleRole.Default;
            btnok.AllowDrop = false;
            btnok.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnok.AutoScrollOffset = new Point(0, 0);
            btnok.MaximumSize = new Size(0, 0);
            btnok.MinimumSize = new Size(0, 0);
            btnok.BackgroundImageLayout = ImageLayout.Tile;
            btnok.Capture = false;
            btnok.CausesValidation = true;
            btnok.ClientSize = new Size(39, 23);
            btnok.Dock = DockStyle.None;
            btnok.Enabled = true;
            btnok.Font = new Font("Microsoft Sans Serif", (float)8.25, (FontStyle)0);
            btnok.ForeColor = Color.FromArgb(0, 0, 0);
            btnok.Height = 23;
            btnok.IsAccessible = false;
            btnok.Left = 11;
            btnok.Location = new Point(11, 355);
            btnok.Name = "btnok";
            btnok.RightToLeft = RightToLeft.No;
            btnok.Size = new Size(39, 23);
            btnok.TabIndex = 2;
            btnok.TabStop = true;
            btnok.Top = 325;
            btnok.UseWaitCursor = false;
            btnok.Visible = true;
            btnok.Width = 39;

            this.Widgets.Add(btnok);
            btnok.Show();

        }
        public RichTextBox rtb_contents = null;
        public Label lbtoplabel = null;
        public Button btnok = null;

    }

}
