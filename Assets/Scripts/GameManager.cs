using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool first = true;
    [SerializeField] GameObject[] objecTOActivate, objectsToInactivate;
    [SerializeField] Transform mainCamera, chestLid;
    public Vector3 cameraPosition, chestLidPosition;
    public Quaternion cameraRotation, chestLidRotation;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelWasLoaded()
    {
        if (first)
        {
            return;
        }
        else
        {
            foreach (GameObject g in objecTOActivate)
            {
                g.SetActive(true);
            }
            foreach (GameObject g in objectsToInactivate)
            {
                g.SetActive(false);
            }
            mainCamera.position = cameraPosition;
            mainCamera.rotation = cameraRotation;
            chestLid.position = chestLidPosition;
            chestLid.rotation = chestLidRotation;
        }
    }
    public void registerValues()
    {
        chestLidPosition = chestLid.position;
        chestLidRotation = chestLid.rotation;
        cameraPosition = mainCamera.position;
        cameraRotation = mainCamera.rotation;
        first = false;
    }
}
