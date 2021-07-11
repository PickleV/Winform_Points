using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Sunny.UI;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _20200907_DIYControlTest
{
    public enum UIDropDownStyle
    {
        DropDown,
        DropDownList
    }

    public enum UIDropItemPos
    {
        Top,
        Bottom
    }

    [ToolboxItem(false)]
    public partial class UIDropControl : UIPanel
    {
        public UIDropControl()
        {
            InitializeComponent();

            edit.Font = UIFontColor.Font;
            edit.Left = 3;
            edit.Top = 3;
            edit.Text = String.Empty;
            edit.ForeColor = UIFontColor.Primary;
            edit.BorderStyle = BorderStyle.None;
            edit.TextChanged += EditTextChanged;
            edit.KeyDown += EditOnKeyDown;
            edit.KeyUp += EditOnKeyUp;
            edit.KeyPress += EditOnKeyPress;
            edit.Invalidate();
            Controls.Add(edit);

            TextAlignment = ContentAlignment.MiddleLeft;
            fillColor = Color.White;
            edit.BackColor = Color.White;
        }

        public new event KeyEventHandler KeyDown;

        public new event KeyEventHandler KeyUp;

        public new event KeyPressEventHandler KeyPress;

        private void EditOnKeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPress?.Invoke(sender, e);
        }

        public event EventHandler DoEnter;

        private void EditOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DoEnter?.Invoke(sender, e);
            }

            KeyDown?.Invoke(sender, e);
        }

        private void EditOnKeyUp(object sender, KeyEventArgs e)
        {
            KeyUp?.Invoke(sender, e);
        }

        [DefaultValue(null)]
        public string Watermark
        {
            get => edit.Watermark;
            set => edit.Watermark = value;
        }

        private UIDropDown itemForm;

        protected UIDropDown ItemForm
        {
            get
            {
                if (itemForm == null)
                {
                    CreateInstance();

                    if (itemForm != null)
                    {
                        itemForm.ValueChanged += ItemForm_ValueChanged;
                        itemForm.VisibleChanged += ItemForm_VisibleChanged;
                    }
                }

                return itemForm;
            }
            set => itemForm = value;
        }

        private void ItemForm_VisibleChanged(object sender, EventArgs e)
        {
            dropSymbol = SymbolNormal;

            if (DroppedDown)
            {
                dropSymbol = SymbolDropDown;
            }

            Invalidate();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DroppedDown => itemForm != null && itemForm.Visible;

        private int symbolNormal = 61703;
        private int dropSymbol = 61703;

        [DefaultValue(61703)]
        public int SymbolNormal
        {
            get => symbolNormal;
            set
            {
                symbolNormal = value;
                dropSymbol = value;
            }
        }

        [DefaultValue(61702)]
        public int SymbolDropDown { get; set; } = 61702;

        protected virtual void CreateInstance()
        {
        }

        protected virtual void ItemForm_ValueChanged(object sender, object value)
        {
        }

        protected virtual int CalcItemFormHeight()
        {
            return 200;
        }

        private UIDropDownStyle _dropDownStyle = UIDropDownStyle.DropDown;

        [DefaultValue(UIDropDownStyle.DropDown)]
        public UIDropDownStyle DropDownStyle
        {
            get => _dropDownStyle;
            set
            {
                if (_dropDownStyle != value)
                {
                    _dropDownStyle = value;
                    edit.Visible = value == UIDropDownStyle.DropDown;
                    Invalidate();
                }
            }
        }

        [DefaultValue(UIDropItemPos.Bottom)]
        public UIDropItemPos DropItemPos { get; set; } = UIDropItemPos.Bottom;

        public event EventHandler ButtonClick;

        protected readonly TextBoxEx edit = new TextBoxEx();

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            edit.Text = Text;
            Invalidate();
        }

        private void EditTextChanged(object s, EventArgs e)
        {
            Text = edit.Text;
            Invalidate();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            edit.Font = Font;
            Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            SizeChange();
        }

        private void SizeChange()
        {
            TextBox edt = new TextBox();
            edt.Font = edit.Font;
            edt.Invalidate();
            Height = edt.Height;
            edt.Dispose();

            edit.Top = (Height - edit.Height) / 2;
            edit.Left = 3;
            edit.Width = Width - 30;
        }

        protected override void OnPaintFore(Graphics g, GraphicsPath path)
        {
            SizeChange();

            if (!edit.Visible)
            {
                base.OnPaintFore(g, path);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Padding = new Padding(0, 0, 30, 0);
            e.Graphics.FillRoundRectangle(GetFillColor(), new Rectangle(Width - 27, edit.Top, 25, edit.Height), Radius);
            Color color = GetRectColor();
            SizeF sf = e.Graphics.GetFontImageSize(dropSymbol, 24);
            e.Graphics.DrawFontImage(dropSymbol, 24, color, Width - 28 + (12 - sf.Width / 2.0f), (Height - sf.Height) / 2.0f);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            edit.Focus();
        }

        public void Clear()
        {
            edit.Clear();
        }

        [DefaultValue('\0')]
        public char PasswordChar
        {
            get => edit.PasswordChar;
            set => edit.PasswordChar = value;
        }

        [DefaultValue(false)]
        public bool ReadOnly
        {
            get => edit.ReadOnly;
            set
            {
                edit.ReadOnly = value;
                edit.BackColor = Color.White;
            }
        }

        [CategoryAttribute("文字"), Browsable(true)]
        [DefaultValue("")]
        public override string Text
        {
            get => edit.Text;
            set => edit.Text = value;
        }

        public bool IsEmpty => edit.Text == "";

        protected override void OnMouseDown(MouseEventArgs e)
        {
            ActiveControl = edit;
        }

        [DefaultValue(32767)]
        public int MaxLength
        {
            get => edit.MaxLength;
            set => edit.MaxLength = Math.Max(value, 1);
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectionLength
        {
            get => edit.SelectionLength;
            set => edit.SelectionLength = value;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectionStart
        {
            get => edit.SelectionStart;
            set => edit.SelectionStart = value;
        }

        public override void SetStyleColor(UIBaseStyle uiColor)
        {
            base.SetStyleColor(uiColor);
            if (uiColor.IsCustom()) return;

            foreColor = uiColor.DropDownControlColor;
            edit.BackColor = fillColor = Color.White;
            Invalidate();
        }

        protected override void AfterSetFillColor(Color color)
        {
            base.AfterSetFillColor(color);
            edit.BackColor = fillColor;
        }

        protected override void AfterSetForeColor(Color color)
        {
            base.AfterSetForeColor(color);
            edit.ForeColor = foreColor;
        }

        protected override void OnClick(EventArgs e)
        {
            if (!ReadOnly)
            {
                if (ItemForm != null)
                {
                    ItemForm.SetRectColor(rectColor);
                    ItemForm.SetFillColor(fillColor);
                    ItemForm.SetForeColor(foreColor);
                    ItemForm.SetStyle(UIStyles.ActiveStyleColor);
                }

                ButtonClick?.Invoke(this, e);
            }
        }

        //public event EventHandler DropDown;

        //public event EventHandler DropDownClosed;

        public void Select(int start, int length)
        {
            edit.Select(start, length);
        }

        public void SelectAll()
        {
            edit.SelectAll();
        }

        protected class TextBoxEx : TextBox
        {
            private string watermark;

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

            [DefaultValue(null)]
            public string Watermark
            {
                get => watermark;
                set
                {
                    watermark = value;
                    SendMessage(Handle, 0x1501, (int)IntPtr.Zero, value);
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UIDropControl
            // 
            this.Name = "UIDropControl";
            this.Click += new System.EventHandler(this.UIDropControl_Click);
            this.ResumeLayout(false);

        }

        private void UIDropControl_Click(object sender, EventArgs e)
        {

        }
    }
}
