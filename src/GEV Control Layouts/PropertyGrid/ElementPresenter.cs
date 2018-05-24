using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using GEV.Layouts.PropertyGrid.DisplayControls;

namespace GEV.Layouts.PropertyGrid
{
    [ToolboxItem(false)]
    internal partial  class ElementPresenter : UserControl
    {
        public Color ActiveColor { get; set; }
        public override Color BackColor { get; set; }
        public Color BorderColor { get; set; }

        public event EventHandler ElementSelected;
        public event EventHandler<int> GridChanging;

        public object DataSource { get; set; }

        public MemberInfo ReflectionInfo
        {
            get
            {
                return this.m_Info;
            }

            set
            {
                this.m_Info = value;
                this.BuildGUI();
            }
        }
        private MemberInfo m_Info;

        public bool IsSelected
        {
            get
            {
                return this.m_Selected;
            }
            set
            {
                if(this.m_Selected == true && value == false)
                {
                    this.ForceValidate();
                }
                this.m_Selected = value;
                this.Invalidate();
            }
        }
        private bool m_Selected;

        public ElementPresenter()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);

            this.BackColor = this.BorderColor;
        }

        public virtual void BuildGUI() { }

        public virtual void ForceValidate() { }

        public void SetGrid(int i)
        {
            this.container.SplitterDistance = i;
        }

        protected void PerformElementSelected(object sender, EventArgs e)
        {
            this.ElementSelected?.Invoke(this, e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.IsSelected)
            {
                e.Graphics.Clear(this.ActiveColor);
            }
            else
            {
                e.Graphics.Clear(this.BorderColor);
            }

            using (Brush b = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillRectangle(b, new Rectangle(0, this.Bounds.Height - 1, this.Bounds.Width, this.Bounds.Height));
            }
        }

        private void OnSplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            this.GridChanging?.Invoke(this, e.SplitX);
        }

        private void splitContainer1_Paint(object sender, PaintEventArgs e)
        {
            using (Brush b = new SolidBrush(GCLColors.SoftBorder))
            using (Pen p = new Pen(b, 2))
            {
                int x = this.container.SplitterRectangle.X;
                int h = this.container.SplitterRectangle.Height;
                e.Graphics.DrawLine(p, x, 0, x, h);
            }
        }
    }
}
