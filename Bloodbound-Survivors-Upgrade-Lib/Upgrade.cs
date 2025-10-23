using System;
using System.Collections.Generic;

namespace Upgrade_Lib
{
    public enum Rarity
    {
        Common, 
        Rare,
        Epic,
        Legendary
    }

    [Serializable]
    public class Upgrade
    {
        public Upgrade(
            string Name,
            string Description,
            Rarity Rarity,
            int Weight,
            List<SerializableModifier> Modifiers)
        {
            this.Name = Name;
            this.Description = Description;
            this.Rarity = Rarity;
            this.Weight = Weight;
            this.Modifiers = Modifiers;
        }

        public string Name;
        public string Description;
        public Rarity Rarity;
        public int Weight;
        public List<SerializableModifier> Modifiers;
    }

    [Serializable]
    public class SerializableModifier
    {
        public string Key;
        public float Value;
    }
}
