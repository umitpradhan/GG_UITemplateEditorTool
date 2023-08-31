
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

/// <summary>
/// Utility class for saving and loading UI template data to and from JSON files.
/// </summary>
public static class UITemplateIO
{
    /// <summary>
    /// Saves a single UI template and the root template data to a JSON file.
    /// </summary>
    /// <param name="templates">The UI template to save</param>
    /// <param name="root">The root template data containing the UI templates</param>
    /// <param name="filePath">The path to the JSON file</param>
    public static void SaveTemplates(UITemplate templates, UITemplateRoot root, string filePath)
    {

        string json = JsonUtility.ToJson(templates, true);
        string jsonD = JsonConvert.SerializeObject(root);// Convert root data to JSON
        string fullPath = Path.Combine(Application.dataPath, filePath);
        Debug.Log(json);
        Debug.Log(templates.ToString());
        System.IO.File.WriteAllText("D:\\unityProjects\\GreedyGamesAssignment\\Assets\\Resources\\UITemplates.json", jsonD);// Write JSON data to the specified file path

    }

    /// <summary>
    /// Loads UI template data from a JSON file.
    /// </summary>
    /// <param name="filePath">The path to the JSON file</param>
    /// <returns>The root template data containing the loaded UI templates</returns>
    public static UITemplateRoot LoadTemplates(string filePath)
    {
        if (System.IO.File.Exists(filePath))
        {
            string fullPath = Path.Combine(Application.dataPath, filePath);// Read JSON data from the specified file path
            string json = System.IO.File.ReadAllText("D:\\unityProjects\\GreedyGamesAssignment\\Assets\\Resources\\UITemplates.json");
            Debug.Log("json frpom file: " + json);
            return JsonConvert.DeserializeObject<UITemplateRoot>(json);// Deserialize JSON to UITemplateRoot 
        }
        else
        {
            Debug.LogError($"JSON file not found: {filePath}");
            return new UITemplateRoot();// Return an empty UITemplateRoot if the file is not found
        }
    }
    

   
}