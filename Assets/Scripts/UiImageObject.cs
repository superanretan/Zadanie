using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiImageObject : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text nameText;
    [SerializeField] private Text timeSinceFileCreated;

    public void SetUiImageObject(Texture2D image, string nameText, string timeSinceFileCreated)
    {
        Material mat = new Material(Shader.Find("UI/Unlit/Transparent"));
        mat.mainTexture = image;
        this.image.material = mat;
        this.nameText.text = "Image name: " + nameText;
        this.timeSinceFileCreated.text = "Image was created " + timeSinceFileCreated + " ago";
    }
}