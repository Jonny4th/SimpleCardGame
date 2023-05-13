using Cards;
using Decks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Helper
{
    public class JsonFileHelper
    {
        public static string deckPath = Path.Combine(Application.persistentDataPath, "Decks");

        public void SaveToJson(SimpleDeck deck)
        {
            var date = DateTime.Now.ToString("dd'-'MM'-'yyyy'_'HH''mm''ss");
            var path = Path.Combine(deckPath, "SimpleDeck_"+ date + ".json");
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            var stream = File.Create(path);
            stream.Close();
            File.WriteAllText(path, JsonConvert.SerializeObject(deck.Cards, Formatting.Indented));
            Debug.Log("Write to " + path);
        }

        public List<SimpleCard> LoadDeckFromJson(string fileName)
        {
            var path = Path.Combine(deckPath, fileName);
            var json = File.ReadAllText(path);
            var deck = JsonConvert.DeserializeObject<List<SimpleCard>>(json);

            return deck;
        }
    }
}
