using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditor.UIElements;

/// <summary>
/// Custom editor window for managing UI template data using a graphical interface.
/// Allows loading, editing, and saving JSON data for UI templates.
/// </summary>
public class UITemplateEditorWindow : EditorWindow
{
    private string jsonFilePath = "D:\\unityProjects\\GreedyGamesAssignment\\Assets\\Resources\\UITemplates.json";
    private string jsonContent = "";

    private static string newTemplateName = "";
    private static UITemplatePosition newTemplatePosition = new UITemplatePosition();
    private static UITemplateScale newTemplateScale = new UITemplateScale();
    private static float newTemplateRotation = 0;
    

    [MenuItem("Window/UI Template Editor")]
    public static void ShowWindow()
    {
        GetWindow<UITemplateEditorWindow>("UI Template Editor");
    }

    private void OnGUI()
    {
        GUILayout.Label("UI Template Editor", EditorStyles.boldLabel);

        // Input field for JSON file path
        jsonFilePath = EditorGUILayout.TextField("JSON File Path:", jsonFilePath);

        EditorGUILayout.Space();
        GUILayout.Label("Create New Template", EditorStyles.boldLabel);

        // Fields for creating a new template
        newTemplateName = EditorGUILayout.TextField("Name:", newTemplateName);
        newTemplatePosition.x = EditorGUILayout.FloatField("Position X:", newTemplatePosition.x);
        newTemplatePosition.y = EditorGUILayout.FloatField("Position Y:", newTemplatePosition.y);
        newTemplateScale.x = EditorGUILayout.FloatField("Scale X:", newTemplateScale.x);
        newTemplateScale.y = EditorGUILayout.FloatField("Scale Y:", newTemplateScale.y);
        newTemplateRotation = EditorGUILayout.FloatField("Rotation", newTemplateRotation);

        // Load and Save buttons
        if (GUILayout.Button("Load JSON"))
        {
            LoadJSON();
        }
        if (GUILayout.Button("Save JSON"))
        {
            SaveJSON();
        }

        // Text area for displaying and editing JSON content
        jsonContent = EditorGUILayout.TextArea(jsonContent, GUILayout.Height(position.height - 100));

        
    }

    /// <summary>
    /// Loads JSON content from the specified file path and displays it in the text area.
    /// </summary>
    private void LoadJSON()
    {
        try
        {
            jsonContent = File.ReadAllText(jsonFilePath);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error loading JSON: {e.Message}");
        }
    }


    /// <summary>
    /// Saves the edited JSON content to the specified file path.
    /// </summary>
    private void SaveJSON()
    {
        try
        {
            File.WriteAllText(jsonFilePath, jsonContent);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error saving JSON: {e.Message}");
        }
    }

   
}
