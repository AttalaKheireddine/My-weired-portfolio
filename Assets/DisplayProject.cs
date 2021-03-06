using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayProject : MonoBehaviour
{
    [SerializeField] Text title, description;
    [SerializeField] Image image;

    public void DisplayProjectFromData(ProjectData projectData)
    {
        title.text = projectData.title;
        description.text = projectData.description;
        image.sprite = projectData.illustrativeImage;
    }
}
