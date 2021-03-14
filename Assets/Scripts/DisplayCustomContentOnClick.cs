using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCustomContentOnClick : MonoBehaviour
{
    [SerializeField] DisplayProjects display;
    [SerializeField] GameObject customContentPrefab;
    public void Display()
    {
        display.DisplayCustomContent(customContentPrefab);
    }
}
