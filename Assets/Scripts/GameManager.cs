using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Vector3 position;
    Quaternion rotation;
    public void RegisterPosition(Transform trackedObject)
    {
        position = trackedObject.position;
        rotation = trackedObject.rotation;
    }

    public void GivePositionFromRegistered(Transform objectToPosition)
    {
        objectToPosition.position = position;
        objectToPosition.rotation = rotation;
    }

    private void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
    }
}
