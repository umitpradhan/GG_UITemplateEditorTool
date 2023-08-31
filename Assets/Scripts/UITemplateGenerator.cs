using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;


/// <summary>
/// The UITemplateGenerator class is responsible for managing UI templates in Unity.
/// It loads template data from a JSON file, allows selecting and instantiating templates,
/// and provides the ability to add new templates with customizable properties.
/// </summary>
public class UITemplateGenerator : MonoBehaviour
{
    // Public variables
    public int i = 0; // Counter for creating unique template names
    public string templateName; // Name of the selected template
    public string jsonFilePath = "D:\\unityProjects\\GreedyGamesAssignment\\Assets\\Resources\\UITemplates.json"; // Path to the JSON file
    public GameObject templatePrefab; // Prefab of the UI template
    public Transform parentTransform; // Parent transform to instantiate templates under
    public int selectedTemplateIndex = 0; // Index of the selected template
    public UITemplateRoot templateRoot = new UITemplateRoot(); // Root object for holding UI templates
    public UITemplate selectedTemplate; // Currently selected UI template
    public UITemplate templates = new UITemplate(); // UI template instance for adding new templates
   

    /// <summary>
    /// Called when the script instance is being loaded.
    /// Initializes by loading templates from the JSON file and outputs template names.
    /// </summary>
    private void Start()
    {
        templateRoot = UITemplateIO.LoadTemplates(jsonFilePath); // Load templates from JSON
        Debug.Log(JsonConvert.SerializeObject(templateRoot)); // Output loaded templates as JSON
        foreach (string k in templateRoot.uITemplatesDictionary.Keys)
        {
            Debug.Log(k); // Output template names
        }
    }

    /// <summary>
    /// Selects a template by its name from the loaded templates.
    /// Outputs the selected template's name if found, or a warning if not found.
    /// </summary>
    /// <param name="templateName">Name of the template to be selected</param>
    public void SelectTemplate(string templateName)
    {
        if (templateRoot.uITemplatesDictionary.TryGetValue(templateName, out selectedTemplate))
        {
            Debug.Log($"Selected template: {selectedTemplate.name}");
        }
        else
        {
            Debug.LogWarning($"Template not found: {templateName}");
        }
    }

    /// <summary>
    /// Instantiates the selected template as a GameObject under the specified parent transform.
    /// Sets the properties of the instantiated object based on the selected template's data.
    /// </summary>
    public void InstantiateSelectedTemplate()
    {
        GameObject templateObject = Instantiate(templatePrefab, parentTransform);
        templateObject.name = selectedTemplate.name;

        // Set templateObject's properties based on selectedTemplate...

        RectTransform rectTransform = templateObject.GetComponent<RectTransform>();
        Vector2 anchoredPosition = new Vector2(selectedTemplate.position.x, selectedTemplate.position.y);
        rectTransform.anchoredPosition = anchoredPosition;

        rectTransform.rotation = Quaternion.Euler(0, 0, selectedTemplate.rotation);
        rectTransform.localScale = new Vector2(selectedTemplate.scale.x, selectedTemplate.scale.y);
    }

    /// <summary>
    /// Adds a new template based on the selected template's data and saves it to the JSON file.
    /// </summary>
    public void AddNewTemplate()
    {
        ++i;

        UITemplate newTemplate = new UITemplate();
        newTemplate.name = selectedTemplate.name + i;
        newTemplate.position = new UITemplatePosition { x = selectedTemplate.position.x, y = selectedTemplate.position.x };
        newTemplate.rotation = selectedTemplate.rotation;
        newTemplate.scale = new UITemplateScale { x = 1, y = 1 };

        templates = newTemplate;
        templateRoot.uITemplatesDictionary.Add(newTemplate.name, newTemplate);

        UITemplateIO.SaveTemplates(newTemplate, templateRoot, jsonFilePath); // Save templates to JSON
        Debug.Log("New template added and templates saved.");
    }

    /// <summary>
    /// Edits the currently selected template with new data.
    /// </summary>
    /// <param name="editedTemplate">Updated template data</param>
    public void EditSelectedTemplate(UITemplate editedTemplate)
    {
        if (selectedTemplate != null)
        {
            selectedTemplate = editedTemplate;
        }
        else
        {
            Debug.LogWarning("No template selected.");
        }
    }
}


//public class UITemplateGenerator : MonoBehaviour
//{

//    public int i = 0;
//    public string templateName;
//    public string jsonFilePath = "D:\\\\unityProjects\\\\GreedyGamesAssignment\\\\Assets\\\\Resources\\\\UITemplates.json\"";
//    public GameObject templatePrefab;
//    public Transform parentTransform;

//    [SerializeField]
//    public UITemplateRoot templateRoot = new UITemplateRoot();
//    public List<UITemplate> templatesl = new List<UITemplate>();

//    public UITemplate selectedTemplate;
//    public UITemplate templates = new UITemplate();
//    public int selectedTemplateIndex = 0;



//    private void Start()
//    {
//        //templates = UITemplateIO.LoadTemplates(jsonFilePath);
//        templateRoot = UITemplateIO.LoadTemplates(jsonFilePath);
//        //templateRoot.uITemplatesDictionary.Clear();
//        Debug.Log(JsonConvert.SerializeObject(templateRoot));
//        foreach (string k in templateRoot.uITemplatesDictionary.Keys) {
//            Debug.Log(k);
//        }
//    }

//    public void SelectTemplate(string templateName)
//    {
//        if (templateRoot.uITemplatesDictionary.TryGetValue(templateName, out selectedTemplate))
//        {
//            Debug.Log($"Selected template: {selectedTemplate.name}");
//        }
//        else
//        {
//            Debug.LogWarning($"Template not found: {templateName}");
//        }
//    }

//    public void InstantiateSelectedTemplate()
//    {
//        //if (selectedTemplateIndex >= 0 && selectedTemplateIndex < templateRoot.uITemplatesDictionary.Count)
//        //{
//            //selectedTemplate = templates;
//            GameObject templateObject = Instantiate(templatePrefab, parentTransform);
//            templateObject.name = selectedTemplate.name;

//            // Set templateObject's properties based on selectedTemplate...
//            RectTransform rectTransform = templateObject.GetComponent<RectTransform>();

//            // Convert UITemplatePosition to Vector2
//            Vector2 anchoredPosition = new Vector2(selectedTemplate.position.x, selectedTemplate.position.y);
//            rectTransform.anchoredPosition = anchoredPosition;

//            rectTransform.rotation = Quaternion.Euler(0, 0, selectedTemplate.rotation);
//            rectTransform.localScale = new Vector2(selectedTemplate.scale.x, selectedTemplate.scale.y);

//            //Image image = templateObject.GetComponent<Image>();
//            //if (image != null)
//            //{
//            //    Color color = new Color((float)selectedTemplate.color.r, (float)selectedTemplate.color.g, (float)selectedTemplate.color.b);
//            //    image.color = color;
//            //}

//            //Text textComponent = templateObject.GetComponentInChildren<Text>();
//            //if (textComponent != null)
//            //{
//            //    textComponent.text = selectedTemplate.text;
//            //}
//            //fix this code

//        //}
//        //else
//        //{
//        //    Debug.LogWarning("Invalid selected template index.");
//        //}
//    }
//    public void AddNewTemplate()
//    {
//        //string jsonEntry = "";

//        ++i;

//        UITemplate newTemplate = new UITemplate();
//        newTemplate.name = selectedTemplate.name + i;
//        newTemplate.position = new UITemplatePosition { x = selectedTemplate.position.x, y = selectedTemplate.position.x };
//        newTemplate.rotation = selectedTemplate.rotation;
//        newTemplate.scale = new UITemplateScale { x = selectedTemplate.position.x, y = selectedTemplate.position.x };

//        templates = newTemplate;
//        //templateRoot.uITemplates.Add(newTemplate);
//        templateRoot.uITemplatesDictionary.Add(newTemplate.name, newTemplate);

//        //List<UITemplate> dataList = new List<UITemplate>();
//        //foreach (var kvp in templateRoot.uITemplatesDictionary)
//        //{
//        //    //dataList.Add(new UITemplate { key = kvp.Key, value = kvp.Value });
//        //    jsonEntry = $"\"{kvp.Key}\": {JsonUtility.ToJson(kvp.Value)}";
//        //}



//            UITemplateIO.SaveTemplates(newTemplate, templateRoot, jsonFilePath);
//            Debug.Log("New template added and templates saved.");




//    }

//    public void EditSelectedTemplate(UITemplate editedTemplate)
//    {
//        if (selectedTemplate != null)
//        {
//            selectedTemplate = editedTemplate;
//        }
//        else
//        {
//            Debug.LogWarning("No template selected.");
//        }
//    }


//    //public void SaveTemplatesToJson()
//    //{
//    //    string filePath = Path.Combine(Application.persistentDataPath, jsonFilePath);

//    //    UITemplateRoot root = new UITemplateRoot();
//    //    foreach (UITemplate selectedTemplate in templatesl)
//    //    {
//    //        root.uITemplatesDictionary = templates;
//    //    }



//    //    if (existingRoot != null && existingRoot.uITemplates != null)
//    //    {
//    //        foreach (UITemplate selectedTemplate in templates)
//    //        {
//    //            UITemplate existingTemplate = existingRoot.uITemplates.Find(t => t.name == selectedTemplate.name);
//    //            if (existingTemplate != null)
//    //            {
//    //                existingTemplate.position = selectedTemplate.position;
//    //                existingTemplate.rotation = selectedTemplate.rotation;
//    //                existingTemplate.scale = selectedTemplate.scale;
//    //                existingTemplate.prefabPath = selectedTemplate.prefabPath;
//    //                // Update other properties as needed
//    //            }
//    //            else
//    //            {
//    //                existingRoot.uITemplates.Add(selectedTemplate);
//    //            }
//    //        }
//    //    }
//    //    else
//    //    {
//    //        existingRoot = root;
//    //    }

//    //    string json = JsonUtility.ToJson(existingRoot, true);
//    //    File.WriteAllText(filePath, json);

//    //    Debug.Log("Templates saved to JSON.");
//    //}
//}

