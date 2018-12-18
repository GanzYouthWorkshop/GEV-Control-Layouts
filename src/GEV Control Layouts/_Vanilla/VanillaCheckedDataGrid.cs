using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts.Vanilla
{
    public class VanillaCheckedDataGrid : VanillaDataGrid
    {
        public interface ICheckable
        {
            [Browsable(false)]
            bool Checked { get; set; }
        }

        public new IEnumerable<ICheckable> DataSource
        {
            get { return this.m_DataSource as IEnumerable<ICheckable>; }
            set  { this.ManageNewDataSource(value); }
        }

        public List<ICheckable> CheckedItems
        {
           get { return this.m_CheckedItems.Cast<ICheckable>().ToList(); }
        }
        private List<object> m_CheckedItems = new List<object>();

        protected bool m_SuppressCellValueChanged = false;

        private DataGridViewCheckBoxColumn m_CheckboxColumn =  new DataGridViewCheckBoxColumn()
        {
            Name = "colChecked",
            DisplayIndex = -1,
            HeaderText = "",
            Width = 32,
            DataPropertyName = "Checked",
        };

        public VanillaCheckedDataGrid()
        {
            this.Columns.Add(this.m_CheckboxColumn);
        }

        protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        {
            if(!this.m_SuppressCellValueChanged)
            {
                base.OnCellValueChanged(e);

                var test  = this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                this.m_CheckedItems.Clear();

                foreach (DataGridViewRow row in this.Rows)
                {
                    if(e.ColumnIndex == 0 && this.Rows[e.RowIndex] == row)
                    {
                        (row.DataBoundItem as ICheckable).Checked = (bool)row.Cells["colChecked"].Value;
                    }

                    if((row.DataBoundItem as ICheckable).Checked)
                    {
                        this.m_CheckedItems.Add(row.DataBoundItem);
                    }
                }
            }
        }

        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
        }

        protected override void OnCellValuePushed(DataGridViewCellValueEventArgs e)
        {
            base.OnCellValuePushed(e);
        }

        protected new void ManageNewDataSource(object ds)
        {
            this.m_SuppressSelectionChanged = true;

            this.SetNewDataSource(ds);
            this.HandlePersistedSelection();
            this.HandleAutoScroll();
            this.HandlePersistedChecked();

            this.m_SuppressSelectionChanged = false;
            this.OnSelectionChanged(EventArgs.Empty);
        }

        protected void HandlePersistedChecked()
        {
            //Itt referencia szerint nem kell vizsgálni, mert ha a referencia stimmel triviálisan a Checked property is a helyes értékre van beállítva

            this.m_SuppressCellValueChanged = true;

            Type lastElementType = null;
            PropertyInfo[] propertySet = null;

            foreach (DataGridViewRow row in this.Rows)
            {
                List<object> matches = this.GetMatchingSourcseByKeyedValue(row, this.PersistenceKeys, this.m_CheckedItems, lastElementType, propertySet);
                if (matches.Count > 0)
                {
                    if ((matches[0] as ICheckable).Checked)
                    {
                        (row.DataBoundItem as ICheckable).Checked = true;
                        row.Cells["colChecked"].Value = true;
                    }
                }
            }
            this.m_SuppressCellValueChanged = false;
        }
    }
}
