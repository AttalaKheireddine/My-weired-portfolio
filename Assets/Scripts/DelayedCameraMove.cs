using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedCameraMove : MonoBehaviour
{
    // will wait, move and rotate, then stop
    [SerializeField] float delay, moveTime;
    [SerializeField] Vector3 angularVelocity, speed;
    [SerializeField] GameObject ScrollOfPresentaion;
    [SerializeField] float delayBeforeNextAnimation;
    Rigidbody m_rigid;
    // Start is called before the first frame update
    void Start()
    {
        m_rigid = GetComponent<Rigidbody>();
    }

    public IEnumerator CameraAnimation()
    {
        yield return new WaitForSeconds(delay);
        m_rigid.velocity = speed;
        m_rigid.AddTorque(angularVelocity);
        yield return new WaitForSeconds(moveTime);
        m_rigid.velocity = Vector3.zero;
        m_rigid.angularVelocity = Vector3.zero;
        m_rigid.freezeRotation = true;
        yield return new WaitForSeconds(delayBeforeNextAnimation);
        ScrollOfPresentaion.SetActive(true);

    }
}
