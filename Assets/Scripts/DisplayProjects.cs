using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayProjects : MonoBehaviour
{
    [SerializeField] RectTransform contentRect;
    [SerializeField] GameObject projectPrefabImgRight, projectPrefabImgLeft;
    [SerializeField] ProjectData[] allProjectDatas;
    [SerializeField] Scrollbar scrollbar;

    float projectImageRightHeight, projectImageLeftHeight;
    void Start()
    {
        projectImageLeftHeight = projectPrefabImgLeft.GetComponent<RectTransform>().rect.height;
        projectImageRightHeight = projectPrefabImgRight.GetComponent<RectTransform>().rect.height;
        DisplayAllProjects();
    }
    
    void displayProjects(ProjectData[] projects)
    {
        // we assume we start from a "right" one, we could have picked the opposite case but anyway
        foreach (Transform t in contentRect.transform)
        {
            Destroy(t.gameObject);
        }
        float startHeight = projectImageRightHeight / 2;
        float currHeight = startHeight;
        
        bool indexIsPair = false; //will help us know the pair and impair indexes in foreach
        foreach (ProjectData pData in projects)
        {
            if (indexIsPair)
            {
                RectTransform instance = Instantiate(projectPrefabImgLeft, contentRect).GetComponent<RectTransform>();
                Vector3 position = instance.localPosition;
                instance.localPosition = new Vector3(position.x, -currHeight, position.z);
                instance.GetComponent<DisplayProject>().DisplayProjectFromData(pData);

            }

            else
            {
                RectTransform instance = Instantiate(projectPrefabImgRight, contentRect).GetComponent<RectTransform>();
                Vector3 position = instance.localPosition;
                instance.localPosition = new Vector3(position.x, -currHeight, position.z);
                instance.GetComponent<DisplayProject>().DisplayProjectFromData(pData);
            }
            
            currHeight += projectImageRightHeight;
            indexIsPair = !indexIsPair;
        }
        Rect rect = contentRect.rect;
        scrollbar.value = 1; //reset the scrollBar to the top
        contentRect.sizeDelta = new Vector2(0, currHeight);
    }

    public void DisplayAllProjects()
    {
        displayProjects(allProjectDatas);
    }

    public void DisplayProjectsWithTag(ProjectTag tag)
    {
        List<ProjectData> filteredList = new List<ProjectData>();
        foreach(ProjectData pd in allProjectDatas)
        {
            foreach(ProjectTag t in pd.tags)
            {
                if (t==tag)
                {
                    filteredList.Add(pd);
                }
            }
        }
        displayProjects(filteredList.ToArray());
    }

    public void DisplayCustomContent(GameObject contentPrefab)
    {
        foreach (Transform t in contentRect.transform)
        {
            Destroy(t.gameObject);
        }
        float contenHeight = contentPrefab.GetComponent<RectTransform>().rect.height;
        RectTransform instance = Instantiate(contentPrefab, contentRect).GetComponent<RectTransform>();
        Vector3 position = instance.localPosition;
        instance.localPosition = new Vector3(position.x, -contenHeight/2, position.z);
        Rect rect = contentRect.rect;
        scrollbar.value = 1; //reset the scrollBar to the top
        contentRect.sizeDelta = new Vector2(0, contenHeight);
    }
}
