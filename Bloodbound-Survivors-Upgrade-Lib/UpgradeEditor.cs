using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace Upgrade_Lib.JsonWriter
{
#if UNITY_EDITOR

    public class UpgradeEditor : MonoBehaviour
    {
        public static UpgradeEditor Instance;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(Instance);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        [SerializeField] private List<Upgrade> upgradeList;

        public void WriteUpgrades(string filepath)
        {
            UpgradeJSONWriter.WriteToJson(upgradeList, filepath);
        }
    }

    public static class UpgradeJSONWriter
    {
        public static void WriteToJson<T>(T data, string filepath)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filepath, json);
        }
    }
#endif
}