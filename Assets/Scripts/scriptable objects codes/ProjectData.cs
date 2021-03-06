using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ProjectData", order = 1)]
public class ProjectData : ScriptableObject
{
    public string title;
    public Sprite illustrativeImage;
    public string description;
    public ProjectTag[] tags;
}
