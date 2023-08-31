using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[System.Serializable]
//public class UITemplate
//{
//    public string name;
//    public Vector2 position;
//    public float rotation;
//    public Vector2 scale;
//    public Color color;
//    public string text;
//}
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

[System.Serializable]
public class UITemplatePosition
{
    public float x ; 
    public float y ;
}
[System.Serializable]
public class UITemplateRoot
{
    
    public Dictionary<string, UITemplate> uITemplatesDictionary = new Dictionary<string, UITemplate>();
}
[System.Serializable]
public class UITemplateScale
{
    public float x ;
    public float y ;
}
[System.Serializable]
public class UITemplate
{
    public string name ;
    public UITemplatePosition position ;
    public float rotation ;
    public UITemplateScale scale ;
    
}


