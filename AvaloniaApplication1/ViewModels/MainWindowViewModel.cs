namespace AvaloniaApplication1.ViewModels {
    using AvaloniaApplication1.Models;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using System.Diagnostics;

    public class MainWindowViewModel : ViewModelBase {
        public List<AssetInfo> assets_;
        public RangeEnabledObservableCollection<AssetInfo> Assets { get; set; }

        public MainWindowViewModel() {
            assets_ = GenerateData().ToList();
            Assets = new RangeEnabledObservableCollection<AssetInfo>(assets_);
        }

        public void OnClickCommand() {
            var sw = Stopwatch.StartNew();
            foreach (var item in assets_) {
                if (!item.AssetName.Contains("BIG")) {
                    Assets.Remove(item);
                    assets_.Remove(item);
                }
            }
            sw.Stop();
            Console.WriteLine("OnClickCommand took ms:" + sw.ElapsedMilliseconds);
        }

        private IEnumerable<AssetInfo> GenerateData() {
            var config = LoadOrderConfig.Deserialize();
            return config.Assets;
        }
    }
}

