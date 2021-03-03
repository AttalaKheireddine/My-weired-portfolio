using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    [SerializeField] float timeStep = 0.1f;
    [SerializeField] int numSteps = 1000,stepToStartAnimation = 10;
    [SerializeField] float fallSpeed = 1;

    [SerializeField] Transform transformToFall;
    [SerializeField] DelayedCameraMove mover;
    [SerializeField] Animator treasureChestAnim;
    [SerializeField] ParticleSystem chestGlow;
    bool hasClicked = false;
    void timeSwitch()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0; 
    }
    // Start is called before the first frame update
    private void Start()
    {
        timeSwitch();
    }

    public void HandleClick()
    {
        
        if (hasClicked) return;
        timeSwitch();
        hasClicked = true;
        StartCoroutine(Fall());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }
    }

    IEnumerator Fall()
    {
        Vector2 startPosition = transformToFall.position;
        for (int i = 0; i < numSteps; i++)
        {
            transformToFall.position = (Vector3)startPosition + new Vector3(0, -fallSpeed, 0) * i*i*timeStep;
            if (i==stepToStartAnimation)
            {
                mover.StartCoroutine(mover.CameraAnimation());
                treasureChestAnim.Play("TreasureChest_OPEN");
                chestGlow.Play();
            }
            yield return new WaitForSeconds(timeStep);
        }
        gameObject.SetActive(false);
    }
}
