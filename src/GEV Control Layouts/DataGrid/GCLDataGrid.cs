using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Collections;
using GEV.Layouts.Vanilla;

namespace GEV.Layouts.DataGrid
{
    public class GCLDataGrid : DataGridView
    {
        public new object DataSource
        {
            get { return this.m_DataSource; }
            set { this.ManageNewDataSource(value); }
        }
        private object m_DataSource;

        public object SelectedItem { get; set; } = null;
        public int ScrollRow { get; set; } = 0;
        public int ScrollColumn { get; set; } = 0;

        [DefaultValue(true)]
        public bool AttemptUserDataPersistence { get; set; } = true;

        [DefaultValue(false)]
        public bool Autoscroll { get; set; } = false;

        public GCLDataGrid() : base()
        {
            this.DoubleBuffered = true;

            //this.BackgroundColor = GCLColors.Shadow;
            //this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //this.EnableHeadersVisualStyles = false;
            //this.GridColor = GCLColors.SoftBorder;
            //this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //this.RowHeadersVisible = false;
            //this.RowTemplate.Height = 24;

            //this.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            //{
            //    Alignment = DataGridViewContentAlignment.MiddleLeft,
            //    BackColor = Color.FromArgb(51, 51, 51),
            //    Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0),
            //    ForeColor = GCLColors.PrimaryText,
            //    Padding = new Padding(3),
            //    SelectionBackColor = GCLColors.AccentColor1,
            //    SelectionForeColor = GCLColors.PrimaryText,
            //    WrapMode = DataGridViewTriState.True,
            //};

            //this.DefaultCellStyle = new DataGridViewCellStyle()
            //{
            //    Alignment = DataGridViewContentAlignment.MiddleLeft,
            //    BackColor = GCLColors.Button,
            //    Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0),
            //    ForeColor = GCLColors.PrimaryText,
            //    SelectionBackColor = GCLColors.AccentColor1,
            //    SelectionForeColor = GCLColors.PrimaryText,
            //    WrapMode = DataGridViewTriState.False,
            //};

            //this.RowHeadersDefaultCellStyle = new DataGridViewCellStyle()
            //{
            //    Alignment = DataGridViewContentAlignment.MiddleLeft,
            //    BackColor = Color.FromArgb(51, 51, 51),
            //    Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0),
            //    ForeColor = GCLColors.PrimaryText,
            //    SelectionBackColor = GCLColors.AccentColor1,
            //    SelectionForeColor = GCLColors.PrimaryText,
            //    WrapMode = DataGridViewTriState.True,
            //};
        }

        protected override void OnSelectionChanged(EventArgs e)
        {
            base.OnSelectionChanged(e);

            if(this.SelectedRows.Count > 0)
            {
                this.SelectedItem = this.SelectedRows[0].DataBoundItem;
            }
        }

        protected override void OnScroll(ScrollEventArgs e)
        {
            base.OnScroll(e);

            this.ScrollRow = this.FirstDisplayedScrollingRowIndex;
            this.ScrollColumn = this.FirstDisplayedScrollingRowIndex;
        }

        private void ManageNewDataSource(object ds)
        {
            object result = null;
            if(ds is ISortableBindingList)
            {
                result = ds;
            }
            if (ds is IEnumerable)
            {
                Type type = typeof(SortableBindingList<>);
                Type[] typeArgs = { ((IEnumerable)ds).GetType().GetGenericArguments()[0] };
                Type constructed = type.MakeGenericType(typeArgs);

                if(this.DataSource is ISortableBindingList)
                {
                    ISortableBindingList tmp = (ISortableBindingList)this.DataSource;
                    result = Activator.CreateInstance(constructed, ds, tmp.SortDirection, tmp.SortProperty);
                }
                else
                {
                    result = Activator.CreateInstance(constructed, ds);
                }
            }

            base.DataSource = this.m_DataSource = result;

            if(this.AttemptUserDataPersistence)
            {
                foreach (DataGridViewRow row in this.Rows)
                {
                    if (row.DataBoundItem == this.SelectedItem)
                    {
                        this.ClearSelection();
                        row.Selected = true;
                    }
                }

                if(this.RowCount > this.ScrollRow)
                {
                    this.FirstDisplayedScrollingRowIndex = this.ScrollRow;
                }

                if (this.ColumnCount > this.ScrollColumn)
                {
                    this.FirstDisplayedScrollingRowIndex = this.ScrollColumn;
                }
            }

            if(this.Autoscroll)
            {
                this.FirstDisplayedScrollingRowIndex = this.RowCount;
                this.FirstDisplayedScrollingRowIndex = this.ScrollColumn;

            }
        }
    }
}
