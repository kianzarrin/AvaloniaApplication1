namespace AvaloniaApplication1.ViewModels {
    using AvaloniaApplication1.Models;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using System.Diagnostics;

    public class MainWindowViewModel : ViewModelBase {
        /// <summary>
        /// The view model info of the available assets in the grid. 
        /// </summary>
        public RangeEnabledObservableCollection<AssetInfo> Assets { get; set; }
        // TRACKS THE VIEW DATA
        // WE WILL NEED TO ADD A SEPARATE PROPERTY TO TRACK THE DATA ENTRIES
        // USE THE DATA LAYER TO CONFIGURATE THE DISPLAYED DATA IN THE VIEW MODEL 

        public MainWindowViewModel() {
            Assets = new RangeEnabledObservableCollection<AssetInfo>(GenerateData().ToList());
        }

        public void OnClickCommand() {
            var sw = Stopwatch.StartNew();
            // when iterating over a collection, do not change items in the collection!
            //foreach (var item in assets_) {
            //    if (!item.AssetName.Contains("BIG")) {
            //        Assets.Remove(item);
            //        assets_.Remove(item);
            //    }
            //}
            // you can do a temporary variable in the iterator instead, but this is no less efficient in this scenario 
            // if it gets weird you may want to troubleshoot LINQ vs. a manually optmized query; but that usually applies to a data source like SQL 
            // where it can generate weird queries
            var filteredAssets = Assets.Where(i => !string.IsNullOrEmpty(i.AssetName) && i.AssetName.Contains("BIG")).ToList();
            Assets.ResetToRange(filteredAssets);

            sw.Stop();
            Console.WriteLine("OnClickCommand took ms:" + sw.ElapsedMilliseconds);
        }

        private IEnumerable<AssetInfo> GenerateData() {
            var config = LoadOrderConfig.Deserialize();
            return config.Assets;
        }
    }
}

