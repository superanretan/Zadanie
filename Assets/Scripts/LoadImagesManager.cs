using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Unity.Jobs;

public class LoadImagesManager : MonoBehaviour
{
    public UiImageObject uiObjectPrefab;

    [Header("---Buttons---")] public Button loadFromFolderButton;
    public Button getFolderPathButton;

    [Header("----------------------")] public Transform listGrid;
    public List<UiImageObject> imagesObjectsList = new List<UiImageObject>();

    private string folderPath;

    private void Start()
    {
        SetupButtons();
    }

    private void SetupButtons()
    {
        getFolderPathButton.onClick.AddListener(() =>
        {
            folderPath = EditorUtility.OpenFolderPanel("Select Directory", "", "");
        });

        loadFromFolderButton.onClick.AddListener(LoadImagesFromFolderPath);
    }

    private void LoadImagesFromFolderPath()
    {
        if (!string.IsNullOrEmpty(folderPath))
            StartCoroutine(LoadImagesFromFileIe());
        else
            Debug.LogError("Select folder!");
    }

    private IEnumerator LoadImagesFromFileIe() //coroutine for prevent unity freeze when there are loaded a lot of images for example 1200
    {
        if (imagesObjectsList != null && imagesObjectsList.Any())
        {
            foreach (var image in imagesObjectsList)
            {
                Destroy(image.gameObject);
            }
            imagesObjectsList.Clear();
        }

        LoadFromFolder.GetImagesNamesList(folderPath);

        if (LoadFromFolder.imagesPaths.Any() && LoadFromFolder.imagesPaths != null)
        {
            foreach (var imagesPaths in LoadFromFolder.imagesPaths)
            {
                UiImageObject uiObject = Instantiate(uiObjectPrefab, parent: listGrid).GetComponent<UiImageObject>();
                
                uiObject.SetUiImageObject(LoadFromFolder.LoadImageToTexture(imagesPaths),
                    LoadFromFolder.GetImageName(imagesPaths)
                    , LoadFromFolder.GetImageCreationTime(imagesPaths));
                
                imagesObjectsList.Add(uiObject);
                yield return new WaitForEndOfFrame();
            } 
        }
        else
        {
            Debug.LogError("No PNG files found in folder");
        }
       
    }
}