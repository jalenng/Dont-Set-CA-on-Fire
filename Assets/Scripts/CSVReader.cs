using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class CSVReader
{
    public static List<List<string>> readFromFilePath(string filepath)
    {
        if (!filepath.EndsWith(".csv")) return null;
        var fileData = System.IO.File.ReadAllText(filepath);
        var lines = fileData.Split('\n');
        
        List<List<string>> all = new List<List<string>>();
        for (int i = 0; i < lines.Length; i++) {
            var line = lines[i];
            if (line == "") break;
            List<string> texts = new List<string>();
            texts.Add(i.ToString());
            var tmp = line.Split(',');
            for (int j = 0; j < tmp.Length; j++) {
                texts.Add(tmp[j]);
            }
            all.Add(texts);
        }

        return all;
    }
}
