using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayProjectsOnTagButton : MonoBehaviour
{
    [SerializeField] ProjectTag projectTag;
    [SerializeField] DisplayProjects displayManager;
    // Start is called before the first frame update
    public void OnClick()
    {
        displayManager.DisplayProjectsWithTag(projectTag);
    }
}
