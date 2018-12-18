using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GEV.Layouts.Vanilla
{
    /// <summary>
    /// Placeholder a type-checkingnek hogy ne kelljen generikus.
    /// </summary>
    public interface ISortableBindingList
    {
        ListSortDirection SortDirection { get; set; }
        PropertyDescriptor SortProperty { get; set; }
    }

    public class SortableBindingList<T> : BindingList<T>, ISortableBindingList
    {
        private static Dictionary<string, Func<List<T>, IEnumerable<T>>> cachedOrderByExpressions = new Dictionary<string, Func<List<T>, IEnumerable<T>>>();

        private List<T> m_OriginalList;
        public ListSortDirection SortDirection { get; set; }
        public PropertyDescriptor SortProperty { get; set; }

        private Action<SortableBindingList<T>, List<T>> m_PopulateBaseList = (a, b) => a.ResetItems(b);

        public SortableBindingList()
        {
            this.m_OriginalList = new List<T>();
        }

        public SortableBindingList(IEnumerable<T> enumerable)
        {
            this.m_OriginalList = enumerable.ToList();
            m_PopulateBaseList(this, this.m_OriginalList);
        }

        public SortableBindingList(List<T> list)
        {
            this.m_OriginalList = list;
            m_PopulateBaseList(this, this.m_OriginalList);
        }

        public SortableBindingList(IEnumerable<T> enumerable, ListSortDirection sorting, PropertyDescriptor sortProperty)
        {
            this.m_OriginalList = enumerable.ToList();
            m_PopulateBaseList(this, this.m_OriginalList);
            this.ApplySortCore(sortProperty, sorting);
        }


        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            this.SortProperty = prop;

            string orderByMethodName = this.SortDirection == ListSortDirection.Ascending ? "OrderBy" : "OrderByDescending";
            string cacheKey = typeof(T).GUID + prop.Name + orderByMethodName;

            if (!cachedOrderByExpressions.ContainsKey(cacheKey))
            {
                this.CreateOrderByMethod(prop, orderByMethodName, cacheKey);
            }

            this.ResetItems(cachedOrderByExpressions[cacheKey](m_OriginalList).ToList());
            this.ResetBindings();
            this.SortDirection = SortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
        }


        private void CreateOrderByMethod(PropertyDescriptor prop, string orderByMethodName, string cacheKey)
        {
            var sourceParameter = Expression.Parameter(typeof(List<T>), "source");
            var lambdaParameter = Expression.Parameter(typeof(T), "lambdaParameter");
            var accesedMember = typeof(T).GetProperty(prop.Name);
            var propertySelectorLambda = Expression.Lambda(Expression.MakeMemberAccess(lambdaParameter, accesedMember), lambdaParameter);

            var orderByMethod = typeof(Enumerable).GetMethods().Where(a => a.Name == orderByMethodName && a.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(T), prop.PropertyType);
            var orderByExpression = Expression.Lambda<Func<List<T>, IEnumerable<T>>>( Expression.Call(orderByMethod, new Expression[] { sourceParameter, propertySelectorLambda }), sourceParameter);

            cachedOrderByExpressions.Add(cacheKey, orderByExpression.Compile());
        }

        protected override void RemoveSortCore()
        {
            this.ResetItems(m_OriginalList);
        }

        private void ResetItems(List<T> items)
        {

            base.ClearItems();

            for (int i = 0; i < items.Count; i++)
            {
                base.InsertItem(i, items[i]);
            }
        }

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return this.SortDirection; }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get { return this.SortProperty; }
        }

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            m_OriginalList = base.Items.ToList();
        }
    }
}
