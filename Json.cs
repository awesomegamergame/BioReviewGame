﻿using System.IO;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Environment;
using System.Collections.Generic;

namespace BioReviewGame
{
    internal class Json
    {
        public static List<string> questionlist = new List<string>();
        public static List<string> a1List = new List<string>();
        public static List<string> a2List = new List<string>();
        public static List<string> a3List = new List<string>();
        public static List<string> a4List = new List<string>();
        public static List<string> cList = new List<string>();
        public static int JsonReader()
        {
            int size = 0;
            try
            {
                dynamic obj = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText($@"{CurrentDirectory}\Data.json"));
                dynamic json = obj.Questions;
                foreach (JProperty data in json)
                {
                    questionlist.Add(ReadJson(data.Name, "question", "Data", "Questions"));
                    a1List.Add(ReadJson(data.Name, "a1", "Data", "Questions"));
                    a2List.Add(ReadJson(data.Name, "a2", "Data", "Questions"));
                    a3List.Add(ReadJson(data.Name, "a3", "Data", "Questions"));
                    a4List.Add(ReadJson(data.Name, "a4", "Data", "Questions"));
                    cList.Add(ReadJson(data.Name, "c", "Data", "Questions"));
                    size++;
                }
            }
            catch (JsonSerializationException ex)
            {
                MessageBox.Show($"Something is wrong with the json file.\n\nError Code: {ex}");
                Application.Current.Shutdown();
            }
            return size;
        }
        public static string ReadJson(string GVersion, string Property, string FileName, string TopLevel)
        {
            JObject rss = JObject.Parse(File.ReadAllText($@"{CurrentDirectory}\{FileName}.json"));
            return (string)rss[TopLevel][GVersion][Property];
        }
    }
}
