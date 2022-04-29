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
<<<<<<< HEAD
        Texture2D imageTexture = new Texture2D(imageLoad.texture.width,imageLoad.texture.height); 
=======
        Texture2D imageTexture = new Texture2D(2048, 2048); 
>>>>>>> ea5e2828c6622b7b2c886be18a0345180af19765
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
