using GEV.Layouts.Designer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace GEV.Layouts
{
    public class GCLComboBox : ListControl
    {
        #region Variables

        private bool hovered = false;
        private bool pressed = false;
        private bool resize = false;

        private int _dropDownHeight = 200;
        private int _dropDownWidth = 0;
        private int _maxDropDownItems = 8;

        private int _selectedIndex = -1;

        private bool _isDroppedDown = false;

        private ComboBoxStyle _dropDownStyle = ComboBoxStyle.DropDown;

        private Rectangle rectBtn = new Rectangle(0, 0, 1, 1);
        private Rectangle rectContent = new Rectangle(0, 0, 1, 1);

        private ToolStripControlHost _controlHost;
        private ListBox m_listBox;
        private ToolStripDropDown _popupControl;
        private TextBox _textBox;

        #endregion

        #region Delegates

        [Category("Behavior"), Description("Occurs when IsDroppedDown changed to True.")]
        public event EventHandler DroppedDown;

        [Category("Behavior"), Description("Occurs when the SelectedIndex property changes.")]
        public event EventHandler SelectedIndexChanged;

        [Category("Behavior"), Description("Occurs whenever a particular item/area needs to be painted.")]
        public event DrawItemEventHandler DrawItem;

        [Category("Behavior"), Description("Occurs whenever a particular item's height needs to be calculated.")]
        public event MeasureItemEventHandler MeasureItem;

        #endregion

        #region Properties

        public string[] SimpleItems
        {
            get { return this.m_SimpleItems; }
            set { this.m_SimpleItems = value; this.DataSource = this.m_SimpleItems; }
        }
        private string[] m_SimpleItems;

        public int ItemHeight
        {
            get { return this.m_listBox.ItemHeight; }
            set { this.m_listBox.ItemHeight = value; }
        }

        public int DropDownHeight { get; set; }
        public int DropDownWidth { get; set; }
        public int MaxDropDownItems { get; set; }

        [Editor(typeof(StringCollectionEditor), typeof(UITypeEditor))]
        public ListBox.ObjectCollection Items
        {
            get { return m_listBox.Items; }
            set
            {
                this.DataSource = value;
            }
        }

        public new object DataSource
        {
            get { return base.DataSource; }
            set
            {
                m_listBox.DataSource = value;
                base.DataSource = value;
                OnDataSourceChanged(System.EventArgs.Empty);
            }
        }

        public bool Soreted
        {
            get
            {
                return m_listBox.Sorted;
            }
            set
            {
                m_listBox.Sorted = value;
            }
        }

        [Category("Behavior"), Description("Indicates whether the code or the OS will handle the drawing of elements in the list.")]
        public DrawMode DrawMode
        {
            get { return m_listBox.DrawMode; }
            set
            {
                m_listBox.DrawMode = value;
            }
        }

        public ComboBoxStyle DropDownStyle
        {
            get { return _dropDownStyle; }
            set
            {
                _dropDownStyle = value;

                if (_dropDownStyle == ComboBoxStyle.DropDownList)
                {
                    _textBox.Visible = false;
                }
                else
                {
                    _textBox.Visible = true;
                }
                Invalidate(true);
            }
        }

        public bool IsDroppedDown
        {
            get { return _isDroppedDown; }
            set
            {
                if (_isDroppedDown == true && value == false)
                {
                    if (_popupControl.IsDropDown)
                    {
                        _popupControl.Close();
                    }
                }

                _isDroppedDown = value;

                if (_isDroppedDown)
                {
                    _controlHost.Control.Width = this.Width;

                    m_listBox.Width = this.Width;
                    m_listBox.Refresh();

                    if (m_listBox.Items.Count > 0)
                    {
                        int h = 0;
                        int i = 0;
                        int maxItemHeight = 0;
                        int highestItemHeight = 0;
                        foreach (object item in m_listBox.Items)
                        {
                            int itHeight = m_listBox.GetItemHeight(i);
                            if (highestItemHeight < itHeight)
                            {
                                highestItemHeight = itHeight;
                            }
                            h = h + itHeight;
                            if (i <= (_maxDropDownItems - 1))
                            {
                                maxItemHeight = h;
                            }
                            i = i + 1;
                        }

                        if (maxItemHeight > _dropDownHeight)
                            m_listBox.Height = _dropDownHeight + 3;
                        else
                        {
                            if (maxItemHeight > highestItemHeight)
                                m_listBox.Height = maxItemHeight + 3;
                            else
                                m_listBox.Height = highestItemHeight + 3;
                        }
                    }
                    else
                    {
                        m_listBox.Height = 15;
                    }

                    _popupControl.Show(this, CalculateDropPosition(), ToolStripDropDownDirection.BelowRight);
                }

                Invalidate();
                if (_isDroppedDown)
                    OnDroppedDown(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Constructor
        public GCLComboBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ContainerControl, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserMouse, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.Selectable, true);

            //base.BackColor = Color.Transparent;

            this.Height = 21;
            this.Width = 95;

            this.SuspendLayout();
            _textBox = new TextBox();
            _textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            _textBox.Location = new System.Drawing.Point(3, 4);
            _textBox.Size = new System.Drawing.Size(60, 13);
            _textBox.TabIndex = 0;
            _textBox.WordWrap = false;
            _textBox.Margin = new Padding(0);
            _textBox.Padding = new Padding(0);
            _textBox.TextAlign = HorizontalAlignment.Left;
            this.Controls.Add(_textBox);
            this.ResumeLayout(false);

            AdjustControls();

            m_listBox = new ListBox();
            m_listBox.IntegralHeight = true;
            m_listBox.BorderStyle = BorderStyle.FixedSingle;
            m_listBox.BackColor = GCLColors.Shadow;
            m_listBox.SelectionMode = SelectionMode.One;
            m_listBox.BindingContext = new BindingContext();

            _controlHost = new ToolStripControlHost(m_listBox);
            _controlHost.Padding = new Padding(0);
            _controlHost.Margin = new Padding(0);
            _controlHost.BackColor = GCLColors.Shadow;
            _controlHost.AutoSize = false;

            _popupControl = new ToolStripDropDown();
            _popupControl.Padding = new Padding(0);
            _popupControl.Margin = new Padding(0);
            _popupControl.AutoSize = true;
            _popupControl.BackColor = GCLColors.Shadow;
            _popupControl.DropShadowEnabled = false;
            _popupControl.Items.Add(_controlHost);

            _dropDownWidth = this.Width;

            m_listBox.MeasureItem += new MeasureItemEventHandler(_listBox_MeasureItem);
            m_listBox.DrawItem += new DrawItemEventHandler(_listBox_DrawItem);
            m_listBox.MouseClick += new MouseEventHandler(_listBox_MouseClick);
            m_listBox.MouseMove += new MouseEventHandler(_listBox_MouseMove);

            _popupControl.Closed += new ToolStripDropDownClosedEventHandler(_popupControl_Closed);

            _textBox.Resize += new EventHandler(_textBox_Resize);
            _textBox.TextChanged += new EventHandler(_textBox_TextChanged);
        }



        #endregion

        #region Overrides

        protected override void OnDataSourceChanged(EventArgs e)
        {
            this.SelectedIndex = 0;
            base.OnDataSourceChanged(e);
        }

        protected override void OnDisplayMemberChanged(EventArgs e)
        {
            m_listBox.DisplayMember = this.DisplayMember;
            this.SelectedIndex = this.SelectedIndex;
            base.OnDisplayMemberChanged(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            Invalidate(true);
            base.OnEnabledChanged(e);
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            _textBox.ForeColor = this.ForeColor;
            base.OnForeColorChanged(e);
        }

        protected override void OnFormatInfoChanged(EventArgs e)
        {
            m_listBox.FormatInfo = this.FormatInfo;
            base.OnFormatInfoChanged(e);
        }

        protected override void OnFormatStringChanged(EventArgs e)
        {
            m_listBox.FormatString = this.FormatString;
            base.OnFormatStringChanged(e);
        }

        protected override void OnFormattingEnabledChanged(EventArgs e)
        {
            m_listBox.FormattingEnabled = this.FormattingEnabled;
            base.OnFormattingEnabledChanged(e);
        }

        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                resize = true;
                _textBox.Font = value;
                base.Font = value;
                Invalidate(true);
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            e.Control.MouseDown += new MouseEventHandler(Control_MouseDown);
            e.Control.MouseEnter += new EventHandler(Control_MouseEnter);
            e.Control.MouseLeave += new EventHandler(Control_MouseLeave);
            e.Control.GotFocus += new EventHandler(Control_GotFocus);
            e.Control.LostFocus += new EventHandler(Control_LostFocus);
            base.OnControlAdded(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            hovered = true;
            this.Invalidate(true);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (!this.RectangleToScreen(this.ClientRectangle).Contains(MousePosition))
            {
                hovered = false;
                Invalidate(true);
            }

            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _textBox.Focus();
            if ((this.RectangleToScreen(rectBtn).Contains(MousePosition) || (DropDownStyle == ComboBoxStyle.DropDownList)))
            {
                pressed = true;
                this.Invalidate(true);
                if (this.IsDroppedDown)
                {
                    this.IsDroppedDown = false;
                }
                this.IsDroppedDown = true;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            pressed = false;

            if (!this.RectangleToScreen(this.ClientRectangle).Contains(MousePosition))
                hovered = false;
            else
                hovered = true;

            Invalidate();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta < 0)
                this.SelectedIndex = this.SelectedIndex + 1;
            else if (e.Delta > 0)
            {
                if (this.SelectedIndex > 0)
                    this.SelectedIndex = this.SelectedIndex - 1;
            }

            base.OnMouseWheel(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            Invalidate(true);
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if (!this.ContainsFocus)
            {
                Invalidate();
            }

            base.OnLostFocus(e);
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (SelectedIndexChanged != null)
                SelectedIndexChanged(this, e);

            base.OnSelectedIndexChanged(e);
        }

        protected override void OnValueMemberChanged(EventArgs e)
        {
            m_listBox.ValueMember = this.ValueMember;
            this.SelectedIndex = this.SelectedIndex;
            base.OnValueMemberChanged(e);
        }

        protected override void OnResize(EventArgs e)
        {
            if (resize)
            {

                resize = false;
                AdjustControls();

                Invalidate(true);
            }
            else
                Invalidate(true);

            if (DesignMode)
                _dropDownWidth = this.Width;
        }

        public override string Text
        {
            get
            {
                return _textBox.Text;
            }
            set
            {
                _textBox.Text = value;
                base.Text = _textBox.Text;
                OnTextChanged(EventArgs.Empty);
            }
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            m_listBox.BackColor = GCLColors.Shadow;
            Color borderColor = (this.pressed || this.IsDroppedDown) ? GCLColors.AccentColor1 : GCLColors.SoftBorder;
            Color buttonColor = (this.hovered || this.pressed) ? GCLColors.AccentColor1 : GCLColors.SoftBorder;
            using (Brush border = new SolidBrush(borderColor))
            using (Brush button = new SolidBrush(buttonColor))
            using (Brush background = new SolidBrush(GCLColors.Shadow))
            using (Brush arrow = new SolidBrush(GCLColors.PrimaryText))
            using (Pen borderPen = new Pen(border, 2))
            {
                e.Graphics.Clear(borderColor);
                Rectangle bounds = this.ClientRectangle;
                bounds.X += 2;
                bounds.Y += 2;
                bounds.Width -= 4;
                bounds.Height -= 4;
                e.Graphics.FillRectangle(background, bounds);
                e.Graphics.FillRectangle(button, new Rectangle(this.Width - 30, 2, 28, this.Height - 4));

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;


                int x = this.Width - 20;
                int y = (this.Height / 2) - 3;
                GraphicsPath arrowPath = new GraphicsPath();
                PointF[] arrowPoints = new PointF[3];
                arrowPoints[0] = new PointF(x, y);
                arrowPoints[1] = new PointF(x + 10, y);
                arrowPoints[2] = new PointF(x + 5, y + 6);
                arrowPath.AddLine(arrowPoints[0], arrowPoints[1]);
                arrowPath.AddLine(arrowPoints[1], arrowPoints[2]);
                arrowPath.CloseFigure();
                e.Graphics.FillPath(arrow, arrowPath);

                //text
                if (DropDownStyle == ComboBoxStyle.DropDownList)
                {
                    StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);
                    sf.Alignment = StringAlignment.Near;

                    Rectangle rectText = _textBox.Bounds;
                    rectText.Offset(-3, 0);

                    SolidBrush foreBrush = new SolidBrush(ForeColor);
                    if (Enabled)
                    {
                        e.Graphics.DrawString(_textBox.Text, this.Font, foreBrush, rectText.Location);
                    }
                    else
                    {
                        ControlPaint.DrawStringDisabled(e.Graphics, _textBox.Text, Font, BackColor, rectText, sf);
                    }
                }
            }
        }


        #region ListControlOverrides

        public override int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (m_listBox != null)
                {
                    if (m_listBox.Items.Count == 0)
                        return;

                    if ((this.DataSource != null) && value == -1)
                        return;

                    if (value <= (m_listBox.Items.Count - 1) && value >= -1)
                    {
                        m_listBox.SelectedIndex = value;
                        _selectedIndex = value;
                        _textBox.Text = m_listBox.GetItemText(m_listBox.SelectedItem);
                        OnSelectedIndexChanged(EventArgs.Empty);
                    }
                }
            }
        }

        public object SelectedItem
        {
            get { return m_listBox.SelectedItem; }
            set
            {
                m_listBox.SelectedItem = value;
                this.SelectedIndex = m_listBox.SelectedIndex;
                this.Invalidate();
            }
        }

        public new object SelectedValue
        {
            get { return base.SelectedValue; }
            set
            {
                base.SelectedValue = value;
            }
        }

        protected override void RefreshItem(int index)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        protected override void RefreshItems()
        {
            //base.RefreshItems();
        }

        protected override void SetItemCore(int index, object value)
        {
            //base.SetItemCore(index, value);
        }

        protected override void SetItemsCore(System.Collections.IList items)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region NestedControlsEvents

        void Control_LostFocus(object sender, EventArgs e)
        {
            OnLostFocus(e);
        }

        void Control_GotFocus(object sender, EventArgs e)
        {
            OnGotFocus(e);
        }

        void Control_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave(e);
        }

        void Control_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(e);
        }

        void Control_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }


        void _listBox_MouseMove(object sender, MouseEventArgs e)
        {
            int i;
            for (i = 0; i < (m_listBox.Items.Count); i++)
            {
                if (m_listBox.GetItemRectangle(i).Contains(m_listBox.PointToClient(MousePosition)))
                {
                    m_listBox.SelectedIndex = i;
                    return;
                }
            }
        }

        void _listBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (m_listBox.Items.Count == 0)
            {
                return;
            }

            if (m_listBox.SelectedItems.Count != 1)
            {
                return;
            }

            this.SelectedIndex = m_listBox.SelectedIndex;

            if (DropDownStyle == ComboBoxStyle.DropDownList)
            {
                this.Invalidate(true);
            }

            IsDroppedDown = false;
        }

        void _listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                if (DrawItem != null)
                {
                    DrawItem(this, e);
                }
            }
        }

        void _listBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (MeasureItem != null)
            {
                MeasureItem(this, e);
            }
        }


        void _popupControl_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            _isDroppedDown = false;
            pressed = false;
            if (!this.RectangleToScreen(this.ClientRectangle).Contains(MousePosition))
            {
                hovered = false;
            }
            Invalidate(true);
        }



        void _textBox_Resize(object sender, EventArgs e)
        {
            this.AdjustControls();
        }

        void _textBox_TextChanged(object sender, EventArgs e)
        {
            OnTextChanged(e);
        }

        #endregion

        #region PrivateMethods

        private void AdjustControls()
        {
            this.SuspendLayout();

            resize = true;
            _textBox.Top = 4;
            _textBox.Left = 5;
            this.Height = _textBox.Top + _textBox.Height + _textBox.Top;

            rectBtn =
                    new System.Drawing.Rectangle(this.ClientRectangle.Width - 18,
                    this.ClientRectangle.Top, 18, _textBox.Height + 2 * _textBox.Top);


            _textBox.Width = rectBtn.Left - 1 - _textBox.Left;

            rectContent = new Rectangle(ClientRectangle.Left, ClientRectangle.Top,
                ClientRectangle.Width, _textBox.Height + 2 * _textBox.Top);

            this.ResumeLayout();

            Invalidate(true);
        }

        private Point CalculateDropPosition()
        {
            Point point = new Point(0, this.Height);
            if ((this.PointToScreen(new Point(0, 0)).Y + this.Height + _controlHost.Height) > Screen.PrimaryScreen.WorkingArea.Height)
            {
                point.Y = -this._controlHost.Height - 7;
            }
            return point;
        }

        private Point CalculateDropPosition(int myHeight, int controlHostHeight)
        {
            Point point = new Point(0, myHeight);
            if ((this.PointToScreen(new Point(0, 0)).Y + this.Height + controlHostHeight) > Screen.PrimaryScreen.WorkingArea.Height)
            {
                point.Y = -controlHostHeight - 7;
            }
            return point;
        }

        #endregion

        #region VirtualMethods

        public virtual void OnDroppedDown(object sender, EventArgs e)
        {
            if (DroppedDown != null)
            {
                DroppedDown(this, e);
            }
        }

        #endregion
    }
}
