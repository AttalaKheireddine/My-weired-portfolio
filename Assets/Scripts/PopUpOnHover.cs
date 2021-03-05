using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUpOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Animator popUp;
    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData)
    {
        popUp.SetBool("Appear",true);
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        popUp.SetBool("Appear",false);
    }
}
