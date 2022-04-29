using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class LoadFromFolder
{
    public static List<string> imagesPaths = new List<string>();

    public static void GetImagesNamesList(string folderPath)
    {
        imagesPaths.Clear();
        string[] fileNames = Directory.GetFiles(folderPath, "*.png");
        imagesPaths.AddRange(fileNames);
    }

    public static Texture2D LoadImageToTexture(string path)
    {
        WWW imageLoad = new WWW(path);
        Texture2D imageTexture = new Texture2D(imageLoad.texture.width,imageLoad.texture.height); 
        imageLoad.LoadImageIntoTexture(imageTexture);
        return imageTexture;
    }

    public static string GetImageName(string path)
    {
        return Path.GetFileName(path);
    }
    
    public static string GetImageCreationTime(string path)
    {
        var timeDif = DateTime.Now - Directory.GetCreationTime(path);
        return timeDif.Days + " Days " + timeDif.Hours + " Hours " + timeDif.Minutes + " Minutes ";
    }
    
}
