# UITemplateEditor
A Unity tool that generates UI object templates using JSON data. Object templates are predefined configurations for object hierarchies that can be easily instantiated and customized in Unity scenes.

# Game Design Document: UI Template Editor 

 

# Table of Contents 

 

# 1. Overview 

* Concept 

* Target Platform 

* Genre 

* Target Audience 

 

# 2. Features and Mechanics 

* UI Template Management 

* Instantiating Templates 

* Creating New Templates 

 

# 3. User Interface 

* Main Editor Window 

* Load JSON Button 

* Save JSON Button 

* New Template Creation Section 

 

# 4. Art and Visuals 

* User Interface Visuals 

* Template Objects Visualization 

 

# 5. Controls 

* Mouse and Keyboard Controls

 

# 6. Technical Details 

* Unity Version 

* Third-Party Libraries 

* File Paths 

 

 

 

 

# 1. Overview 

 

## Concept  
UI Template Editor is a tool that allows users to manage and manipulate UI templates in a Unity project. Users can load JSON data, create, edit, and save UI templates visually using a custom editor interface. 

## Target Platform 
* PC (Windows, macOS) 

## Development 
* Unity Editor 

## Genre 
* Tool / Editor 

## Target Audience 
* Game developers using Unity 
* UI designers 

 

 

# 2. Features and Mechanics 

 

## UI Template Management 
* Load UI template data from JSON files. 
* Visualize existing UI templates. 
* Edit UI templates' properties including position, rotation, and scale. 
* Save UI templates' changes back to JSON files. 

 

## Instantiating Templates 
* Instantiate selected UI templates as GameObjects in the scene. 
* Set GameObject properties based on UI template data. 

 

## Creating New Templates 
* Create new UI templates with custom properties. 
* Specify template name, position, rotation, and scale. 

 

 

# 3. User Interface 

 

## Main Editor Window 
* Display UI Template Editor window accessible from Unity's "Window" menu. 
* Show JSON file path input field. 
* Show buttons for loading, saving, and creating templates. 

 
## Load JSON Button 
* Button to load JSON content from the specified file path. 
* Display JSON content in a text area for editing. 

 
## Save JSON Button 
* Button to save edited JSON content back to the specified file path. 

 

## New Template Creation Section 
* Fields for entering new template properties: name, position, rotation, and scale. 
* Button to create and add a new template. 

 
 


# 4. Art and Visuals 

 

## User Interface Visuals 

* Clear and intuitive interface design for easy navigation. 

* Distinct buttons and fields for different actions. 

 

## Template Objects Visualization 

* GameObjects in the scene visualize instantiated templates. 

* Template properties (position, rotation, scale) reflected in the visual representation. 

 

 

# 5. Controls 

 

## Mouse and Keyboard Controls 

* Mouse: Interact with buttons, fields, and the text area. 

* Keyboard: Input for text fields and numerical values. 

 
 

# 6. Technical Details 

 

## Unity Version 

* Developed using Unity [2021.3.29.f1] 

 

## Third-Party Libraries 

* Newtonsoft.Json for JSON serialization. 

 

## File Paths 

* JSON files are stored in the "Assets/Resources" folder within the Unity project. 

 

