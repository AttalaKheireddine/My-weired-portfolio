using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestnaughtOpen : MonoBehaviour
{
    Animator m_anim;
    // Start is called before the first frame update
    void Start()
    {
        m_anim = GetComponent<Animator>();
        m_anim.Play("TreasureChest_OPEN");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
