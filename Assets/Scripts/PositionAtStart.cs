using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAtStart : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("Game Manager").GetComponent<GameManager>().GivePositionFromRegistered(transform);
    }
}
