using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    [SerializeField] GameManager manager;
    [SerializeField] float timeStep = 0.1f;
    [SerializeField] int numSteps = 1000,stepToStartAnimation = 10;
    [SerializeField] Animator chestAnimator;
    [SerializeField] float fallSpeed = 1;
    [SerializeField] float startAnimationTime = 3f; //user has to see start animation before he can click

    [SerializeField] Transform transformToFall;
    [SerializeField] DelayedCameraMove mover;
    [SerializeField] ParticleSystem chestGlow;
    bool canClick = false;
    bool hasClicked = false;
    void timeSwitch()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
    // Start is called before the first frame update
    private void Start()
    {
         StartCoroutine(GiveTimeToStartAnimation());
    }

    IEnumerator GiveTimeToStartAnimation()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponentInChildren<Animator>().Play("Mask Show UI");
        yield return new WaitForSeconds(startAnimationTime);
        canClick = true;
    }

    public void HandleClick()
    {
        if (!canClick) return;
        if (hasClicked) return;
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
                chestAnimator.Play("open chest in all lods");
                chestGlow.Play();
            }
            yield return new WaitForSeconds(timeStep);
        }
        gameObject.SetActive(false);
    }
}
