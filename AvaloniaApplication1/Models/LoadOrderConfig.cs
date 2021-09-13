﻿namespace AvaloniaApplication1.Models {
    using System;
    using System.IO;
    using System.Xml.Serialization;
    public class ItemInfo {
        public string Path { get; set; }
    }

    public class ModInfo : ItemInfo {
        public int LoadOrder;
    }

    public class AssetInfo : ItemInfo {
        public bool Excluded { get; set; }
        public string Author { get; set; }
        public string DateUpdated { get; set; }
        public string AssetName { get; set; }
        public string description { get; set; }
    }

    public class LoadOrderConfig {
        public const int DefaultLoadOrder = 1000;
        public const string FILE_NAME = "LoadOrderConfig.xml";

        public string WorkShopContentPath;
        public string GamePath;
        public string SteamPath;

        public bool TurnOffSteamPanels = true;
        public bool FastContentManager = true;
        public bool SoftDLLDependancy = false;
        public bool DeleteUnsubscribedItemsOnLoad = false;
        public bool AddHarmonyResolver = true;
        public bool LogAssetLoadingTimes = true;
        public bool LogPerModAssetLoadingTimes = false;
        public bool LogPerModOnCreatedTimes = false;

        public float StatusX = 1000;
        public float StatusY = 10;

        public ModInfo[] Mods = new ModInfo[0];
        public AssetInfo[] Assets = new AssetInfo[0];
        public string[] ExcludedDLCs = new string[0];

        public static string DIR => Environment.CurrentDirectory;

        public void Serialize(string dir = null) {
            dir ??= DIR;
            XmlSerializer ser = new XmlSerializer(typeof(LoadOrderConfig));
            using (FileStream fs = new FileStream(Path.Combine(dir, FILE_NAME), FileMode.Create, FileAccess.Write)) {
                ser.Serialize(fs, this);
            }
        }

        public static LoadOrderConfig Deserialize(string dir = null) {
            dir ??= DIR;
            try {
                XmlSerializer ser = new XmlSerializer(typeof(LoadOrderConfig));
                using (FileStream fs = new FileStream(Path.Combine(dir, FILE_NAME), FileMode.Open, FileAccess.Read)) {
                    return ser.Deserialize(fs) as LoadOrderConfig;
                }
            } catch {
                return null;
            }
        }
    }
}
