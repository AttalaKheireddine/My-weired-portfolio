using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverviewDisplayManager : MonoBehaviour
{
    [SerializeField] GameObject popUp1, popUp2; //we do not care about which is which
    string lastSkillName = "";
    // Start is called before the first frame update
    public void DisplaySkill(SkillTypeData type)
    {
        if (lastSkillName == type.name) {
            return;   //no transition for same kind of skill click
        }
        lastSkillName = type.name;
        FlipPopUps();
        popUp2.SetActive(true);
        popUp2.GetComponent<ShowSkill>().ShowSkillType(type);
        popUp1.GetComponent<Animator>().Play("Skill overview out");
        popUp2.GetComponent<Animator>().Play("Skill overview in");   
    }

    void FlipPopUps()
    {
        GameObject sav = popUp1;
        popUp1 = popUp2;
        popUp2 = sav;
    }
    
}
