namespace AvaloniaApplication1 {
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    public class RangeEnabledObservableCollection<T> : ObservableCollection<T> {
        public RangeEnabledObservableCollection(IEnumerable<T> collection) : base(collection) { }

        public void InsertRange(IEnumerable<T> items) {
            this.CheckReentrancy();
            foreach (var item in items)
                this.Items.Add(item);
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public void ResetToRange(IEnumerable<T> items) {
            this.CheckReentrancy();
            this.Clear();
            foreach (var item in items)
                this.Items.Add(item);
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
