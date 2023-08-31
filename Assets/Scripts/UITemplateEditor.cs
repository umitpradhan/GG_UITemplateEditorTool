using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using System;


/// <summary>
/// Custom editor for the UITemplateGenerator class.
/// Provides an interface for interacting with UI templates in the Unity editor.
/// </summary>
[CustomEditor(typeof(UITemplateGenerator))]
public class UITemplateEditor : Editor
{
    /// <summary>
    /// Overrides the default inspector GUI and adds custom UI elements.
    /// </summary>
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        // Get the target UITemplateGenerator instance
        UITemplateGenerator generator = (UITemplateGenerator)target;

        GUILayout.Space(10);

        // Button to instantiate the selected template
        if (GUILayout.Button("Instantiate Selected Template"))
        {
            generator.InstantiateSelectedTemplate();
        }

        // Button to add a new template based on the selected template's data
        if (GUILayout.Button("Add Selected Template"))
        {
            generator.AddNewTemplate();
        }

        GUILayout.Space(10);

        if (generator.templateRoot.uITemplatesDictionary.Count > 0)
        {
            // Display a dropdown with available template names
            string[] templateNames = new string[generator.templateRoot.uITemplatesDictionary.Count];
            generator.templateRoot.uITemplatesDictionary.Keys.CopyTo(templateNames, 0);

            // Allow selecting a template from the dropdown
            int selectedTemplateIndex = EditorGUILayout.Popup("Selected Template", generator.selectedTemplateIndex, templateNames);

            if (selectedTemplateIndex >= 0 && selectedTemplateIndex < templateNames.Length)
            {
                generator.selectedTemplateIndex = selectedTemplateIndex;
                string selectedTemplateName = templateNames[selectedTemplateIndex];
                generator.SelectTemplate(selectedTemplateName);

                GUILayout.Space(10);

                if (generator.selectedTemplate != null)
                {
                    GUILayout.Label("Edit Selected Template:");

                    // Display fields for editing the selected template's properties
                    float rot = generator.selectedTemplate.rotation;
                    generator.selectedTemplate.name = EditorGUILayout.TextField("Name", generator.selectedTemplate.name);
                    generator.selectedTemplate.position.x = EditorGUILayout.FloatField("Position X:", generator.selectedTemplate.position.x);
                    generator.selectedTemplate.position.y = EditorGUILayout.FloatField("Position Y:", generator.selectedTemplate.position.y);
                    GUILayout.Label("Rotation");
                    generator.selectedTemplate.rotation = EditorGUILayout.FloatField(rot);
                    generator.selectedTemplate.scale.x = EditorGUILayout.FloatField("Scale X:", generator.selectedTemplate.scale.x);
                    generator.selectedTemplate.scale.y = EditorGUILayout.FloatField("Scale Y:", generator.selectedTemplate.scale.y);

                    // Apply changes button
                    if (GUILayout.Button("Apply Changes"))
                    {
                        generator.EditSelectedTemplate(generator.selectedTemplate);
                    }
                }
                else
                {
                    GUILayout.Label("No template selected.");
                }
            }
        }
        else
        {
            GUILayout.Label("No templates available.");
        }
    }
}






//[CustomEditor(typeof(UITemplateGenerator))]
//public class UITemplateEditor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        DrawDefaultInspector();

//        UITemplateGenerator generator = (UITemplateGenerator)target;

//        GUILayout.Space(10);

//        //if (GUILayout.Button("Load Templates"))
//        //{
//        //    generator.LoadTemplates();
//        //}

//        if (GUILayout.Button("Instantiate Selected Template"))
//        {
//            generator.InstantiateSelectedTemplate();
//        }

//        if (GUILayout.Button("Add Selected Template"))
//        {
//            generator.AddNewTemplate();
//        }

//        GUILayout.Space(10);

//        //// Display template selection dropdown
//        //string[] templateNames = generator.EditSelectedTemplate();
//        //generator.SelectedTemplateIndex = EditorGUILayout.Popup("Selected Template", generator.SelectedTemplateIndex, templateNames);
//        if (generator.templateRoot.uITemplatesDictionary.Count > 0)
//        {
//            string[] templateNames = new string[generator.templateRoot.uITemplatesDictionary.Count];
//            generator.templateRoot.uITemplatesDictionary.Keys.CopyTo(templateNames, 0);

//            int selectedTemplateIndex = EditorGUILayout.Popup("Selected Template", generator.selectedTemplateIndex, templateNames);

//            if (selectedTemplateIndex >= 0 && selectedTemplateIndex < templateNames.Length)
//            {
//                generator.selectedTemplateIndex = selectedTemplateIndex;
//                string selectedTemplateName = templateNames[selectedTemplateIndex];
//                generator.SelectTemplate(selectedTemplateName);

//                GUILayout.Space(10);

//                if (generator.selectedTemplate != null)
//                {
//                    GUILayout.Label("Edit Selected Template:");
//                    float rot = generator.selectedTemplate.rotation;

//                    generator.selectedTemplate.name = EditorGUILayout.TextField("Name", generator.selectedTemplate.name);
//                    generator.selectedTemplate.position.x = EditorGUILayout.IntField("Position X:", generator.selectedTemplate.position.x);
//                    generator.selectedTemplate.position.y = EditorGUILayout.IntField("Position Y:", generator.selectedTemplate.position.y);
//                    GUILayout.Label("Rotation");
//                    generator.selectedTemplate.rotation = EditorGUILayout.IntField(Convert.ToInt32(rot));
//                    generator.selectedTemplate.scale.x = EditorGUILayout.IntField("Scale X:", generator.selectedTemplate.scale.x);
//                    generator.selectedTemplate.scale.y = EditorGUILayout.IntField("Scale Y:", generator.selectedTemplate.scale.y);

//                    if (GUILayout.Button("Apply Changes"))
//                    {
//                        generator.EditSelectedTemplate(generator.selectedTemplate);
//                    }
//                }
//                else
//                {
//                    GUILayout.Label("No template selected.");
//                }
//            }
//        }
//        else
//        {
//            GUILayout.Label("No templates available.");
//        }
//    }
//}
