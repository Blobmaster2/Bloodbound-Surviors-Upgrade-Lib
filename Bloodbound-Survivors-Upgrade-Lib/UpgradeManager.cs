using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Upgrade_Lib
{
    public static class UpgradeManager
    {
        private static List<Upgrade> upgrades;
        private static Random rng = new Random();

        public static void LoadUpgrades(string json)
        {
            if (json == null)
            {
                return;
            }

            upgrades = JsonConvert.DeserializeObject<List<Upgrade>>(json);
        }

        public static Upgrade GetRandomUpgrade()
        {
            if (upgrades == null || upgrades.Count == 0)
            {
                throw new Exception("Upgrades not loaded");
            }

            int totalWeight = upgrades.Sum(u => u.Weight);
            int roll = rng.Next(totalWeight);

            foreach (var upgrade in upgrades)
            {
                if (roll < upgrade.Weight)
                {
                    return upgrade;
                }

                roll -= upgrade.Weight;
            }

            //rng rolls max number case
            return upgrades.Last();
        }
    }
}
