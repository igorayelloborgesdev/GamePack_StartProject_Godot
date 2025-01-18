using Godot;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

public class SaveLoad {
    #region const
    private static string path = ProjectSettings.GlobalizePath("user://");
    private static string configFileName = "config.json";
    private static string pathData = ProjectSettings.GlobalizePath("res://");
    private static string pathDataName = "Data\\";
    private static string[] langArray = { "LangENG.xml", "LangPOR.xml" };
    #endregion
    #region Methods
    public static bool SaveConfig<T>(T configObj)
    {
        var json = JsonConvert.SerializeObject(configObj);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        var savePath = Path.Join(path, configFileName);
        try
        {
            File.WriteAllText(savePath, json);
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }
    public static T LoadConfig<T>()
    {
        try
        {
            var loadPath = Path.Join(path, configFileName);
            var file = File.ReadAllText(loadPath);
            return JsonConvert.DeserializeObject<T>(file);
        }
        catch (Exception ex)
        {
            return default(T);
        }

    }
    public static void DeleteConfigFile()
    {
        try
        {
            var loadPath = Path.Join(path, configFileName);
            File.Delete(loadPath);
        }
        catch (Exception ex)
        {
        }
    }
    public static bool SaveData<T>(T dataObj, string path)
    {
        var json = JsonConvert.SerializeObject(dataObj);
        var savePath = Path.Join(pathData, path);
        try
        {
            File.WriteAllText(savePath, json);
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }    
    public static T LoadData<T>(string path)
    {
        try
        {
            var loadPath = Path.Join(pathData, path);
            var file = File.ReadAllText(loadPath);
            return JsonConvert.DeserializeObject<T>(file);
        }
        catch (Exception ex)
        {
            return default(T);
        }

    }

    public static List<Dictionary<string, string>> LoadXML(string val, string aId)
    {
        var loadPath = Path.Join(pathData, pathDataName);
        List<Dictionary<string, string>> langList = new List<Dictionary<string, string>>();
        foreach (var lang in langArray)
        { 
            var pathFinal = Path.Join(loadPath, lang);
            XDocument doc = XDocument.Load(pathFinal);
            var textElements = doc.Descendants(val);
            Dictionary<string, string> langDict = new Dictionary<string, string>();            
            foreach (var element in textElements)
            {
                string id = element.Attribute(aId)?.Value;
                string value = element.Value;
                if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(value))
                {
                    langDict[id] = value;
                }
            }
            langList.Add(langDict);
        }
        return langList;
    }
    #endregion
}
