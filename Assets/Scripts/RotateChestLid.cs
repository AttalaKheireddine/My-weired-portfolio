using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateChestLid : MonoBehaviour
{
    [SerializeField] Transform[] chests;
    [SerializeField] float startRotation, endRotation, animationTime;
    [SerializeField] int numberOfSteps;
    // Start is called before the first frame update
    IEnumerator Open()
    {
        for (int i=0;i<=numberOfSteps;i++)
        {
           
            float xRotation = startRotation + (endRotation - startRotation) *i / numberOfSteps;
            foreach (Transform t in chests)
            {
                t.localRotation = Quaternion.Euler(xRotation, 0, 0);
            }
            yield return new WaitForSeconds(((float)animationTime/numberOfSteps));
        }
    }

    public void OpenChest()
    {
        StartCoroutine(Open());
    }
}
