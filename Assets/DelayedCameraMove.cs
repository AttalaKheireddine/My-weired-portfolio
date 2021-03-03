using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedCameraMove : MonoBehaviour
{
    // will wait, move and rotate, then stop
    [SerializeField] float delay, moveTime;
    [SerializeField] Vector3 angularVelocity, speed;
    Rigidbody m_rigid;
    // Start is called before the first frame update
    void Start()
    {
        m_rigid = GetComponent<Rigidbody>();
        StartCoroutine(ReallyGo());
    }

    IEnumerator ReallyGo()
    {
        yield return new WaitForSeconds(delay);
        m_rigid.velocity = speed;
        m_rigid.AddTorque(angularVelocity);
        yield return new WaitForSeconds(moveTime);
        m_rigid.velocity = Vector3.zero;
        m_rigid.angularVelocity = Vector3.zero;
        m_rigid.freezeRotation = true;

    }

    IEnumerator Go()
    {
        yield return new WaitForSeconds(delay);
        m_rigid.velocity = speed;
        m_rigid.angularVelocity = angularVelocity;
        yield return new WaitForSeconds(moveTime);
        m_rigid.velocity = Vector3.zero;
        m_rigid.angularVelocity = Vector3.zero;
        m_rigid.freezeRotation = true;
    }
}
