using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEV.Layouts.Vanilla
{
    public class VanillaDataGrid : DataGridView
    {
        public enum PersistenceCheckTypes
        {
            DatagridDefault,
            ByReference,
            ByKey,
            Both,
        }

        public new object DataSource
        {
            get { return this.m_DataSource; }
            set { this.ManageNewDataSource(value); }
        }
        protected object m_DataSource;

        public List<object> SelectedItems { get; } = new List<object>();

        public int ScrollRow { get; set; } = 0;
        public int ScrollColumn { get; set; } = 0;

        [DefaultValue(PersistenceCheckTypes.ByReference)]
        public PersistenceCheckTypes UserDataPersistence { get; set; } = PersistenceCheckTypes.ByReference;

        public List<string> PersistenceKeys { get; set; } = null;

        [DefaultValue(false)]
        public bool Autoscroll { get; set; } = false;

        public VanillaDataGrid() : base()
        {
            this.DoubleBuffered = true;
            this.RowHeadersVisible = false;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        protected bool m_SuppressSelectionChanged = false;

        protected override void OnSelectionChanged(EventArgs e)
        {
            if(!m_SuppressSelectionChanged)
            {
                base.OnSelectionChanged(e);

                if (this.SelectedRows.Count > 0)
                {
                    this.SelectedItems.Clear();

                    foreach (DataGridViewRow row in this.SelectedRows)
                    {
                        this.SelectedItems.Add(row.DataBoundItem);
                    }
                }
            }
        }

        protected override void OnCellContentClick(DataGridViewCellEventArgs e)
        {
            base.OnCellContentClick(e);

            if (this.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell)
            {
                this.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        protected override void OnScroll(ScrollEventArgs e)
        {
            base.OnScroll(e);

            this.ScrollRow = this.FirstDisplayedScrollingRowIndex;
            this.ScrollColumn = this.FirstDisplayedScrollingRowIndex;
        }

        protected virtual void ManageNewDataSource(object ds)
        {
            this.m_SuppressSelectionChanged = true;

            this.SetNewDataSource(ds);
            this.HandlePersistedSelection();
            this.HandleAutoScroll();

            this.m_SuppressSelectionChanged = false;
            this.OnSelectionChanged(EventArgs.Empty);
        }

        protected void SetNewDataSource(object ds)
        {
            object result = null;
            if (ds is ISortableBindingList)
            {
                result = ds;
            }
            if (ds is IEnumerable)
            {
                result = ds;

                //Egy rohadt faja kód de nem kell, de megtartom, DE NEM KELL
                //Type type = typeof(SortableBindingList<>);
                //Type[] typeArgs = { ((IEnumerable)ds).GetType().GetGenericArguments()[0] };
                //Type constructed = type.MakeGenericType(typeArgs);

                //if (this.DataSource is ISortableBindingList)
                //{
                //    ISortableBindingList tmp = (ISortableBindingList)this.DataSource;
                //    result = Activator.CreateInstance(constructed, ds, tmp.SortDirection, tmp.SortProperty);
                //}
                //else
                //{
                //    result = ds;
                //    result = Activator.CreateInstance(constructed, ds);
                //}
            }

            base.DataSource = this.m_DataSource = result;
        }

        protected void HandlePersistedSelection()
        {
            if (this.UserDataPersistence != PersistenceCheckTypes.DatagridDefault)
            {
                Type lastElementType = null;
                PropertyInfo[] propertySet = null;

                List<DataGridViewRow> newRows = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in this.Rows)
                {
                    if (this.UserDataPersistence == PersistenceCheckTypes.ByReference || this.UserDataPersistence == PersistenceCheckTypes.Both)
                    {
                        #region Check by reference
                        if (this.CheckRowByReference(row))
                        {
                            newRows.Add(row);
                        }
                        #endregion
                    }
                    else if (this.UserDataPersistence == PersistenceCheckTypes.ByKey || this.UserDataPersistence == PersistenceCheckTypes.Both)
                    {
                        #region Check by keyed values
                        if (!newRows.Contains(row) && row.DataBoundItem != null)
                        {
                            if (this.CheckRowByKeyedValues(row, this.PersistenceKeys, this.SelectedItems, lastElementType, propertySet))
                            {
                                newRows.Add(row);
                            }
                        }
                        #endregion
                    }
                }

                this.ClearSelection();
                foreach (DataGridViewRow row in newRows)
                {
                    row.Selected = true;
                }

                if (this.RowCount >= this.ScrollRow)
                {
                    this.FirstDisplayedScrollingRowIndex = this.ScrollRow;
                }

                if (this.ColumnCount >= this.ScrollColumn)
                {
                    this.FirstDisplayedScrollingRowIndex = this.ScrollColumn;
                }
            }
        }

        protected void HandleAutoScroll()
        {
            if (this.Autoscroll)
            {
                this.FirstDisplayedScrollingRowIndex = this.RowCount;
                this.FirstDisplayedScrollingRowIndex = this.ScrollColumn;
            }
        }

        protected bool CheckRowByReference(DataGridViewRow row)
        {
            return this.SelectedItems.Contains(row.DataBoundItem);
        }

        protected bool CheckRowByKeyedValues(DataGridViewRow row, List<string> keyList, List<object> formerElements, Type lastElementType, PropertyInfo[] lastPropertySet)
        {
            return this.GetMatchingSourcseByKeyedValue(row, keyList, formerElements, lastElementType, lastPropertySet).Count > 0;
        }

        protected List<object> GetMatchingSourcseByKeyedValue(DataGridViewRow row, List<string> keyList, List<object> formerElements, Type lastElementType, PropertyInfo[] lastPropertySet)
        {
            if(keyList == null)
            {
                return new List<object>();
            }

            if (row.DataBoundItem.GetType() != lastElementType)
            {
                lastElementType = row.DataBoundItem.GetType();
                lastPropertySet = lastElementType.GetProperties(BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.Public);
            }

            List<object> possibleFormerSelected = new List<object>(formerElements);

            foreach (string propertyName in keyList)
            {
                if (possibleFormerSelected.Count == 0)
                {
                    return possibleFormerSelected; // -> üres lista
                }

                PropertyInfo pi = lastPropertySet.FirstOrDefault(p => p.Name == propertyName);
                if (pi != null)
                {
                    List<object> newList = new List<object>(possibleFormerSelected);
                    foreach (object selected in possibleFormerSelected)
                    {
                        object p1 = pi.GetValue(selected);
                        object p2 = pi.GetValue(row.DataBoundItem);
                        if (p1 == null || !p1.Equals(p2))
                        {
                            newList.Remove(selected);
                        }
                    }
                    possibleFormerSelected = newList;
                }
            }

            return possibleFormerSelected;
        }
    }
}
