using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TimeTracker
{
    public class SortableBindingList<T> : BindingList<T>
    {
        private bool _isSorted;
        private ListSortDirection _sortDirection = ListSortDirection.Ascending;
        private PropertyDescriptor _sortProperty;

        public SortableBindingList() : base() { }

        public SortableBindingList(IList<T> list) : base(list) { }

        protected override bool SupportsSortingCore => true;
        protected override bool IsSortedCore => _isSorted;
        protected override ListSortDirection SortDirectionCore => _sortDirection;
        protected override PropertyDescriptor SortPropertyCore => _sortProperty;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            if (prop == null) return;

            var items = Items as List<T>;
            if (items == null) return;

            _sortProperty = prop;
            _sortDirection = direction;

            items.Sort((x, y) =>
            {
                object valueX = prop.GetValue(x);
                object valueY = prop.GetValue(y);

                if (valueX == null) return direction == ListSortDirection.Ascending ? -1 : 1;
                if (valueY == null) return direction == ListSortDirection.Ascending ? 1 : -1;

                // Явно приводим к корректному типу перед сравнением
                if (valueX is IComparable comparableX && valueY is IComparable comparableY)
                {
                    return direction == ListSortDirection.Ascending
                        ? comparableX.CompareTo(comparableY)
                        : comparableY.CompareTo(comparableX);
                }

                return 0;
            });

            _isSorted = true;
            ResetBindings();
        }

        protected override void RemoveSortCore()
        {
            _isSorted = false;
        }
    }
}
