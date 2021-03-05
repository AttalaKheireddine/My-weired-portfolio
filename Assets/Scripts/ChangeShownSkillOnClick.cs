using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShownSkillOnClick : MonoBehaviour
{
    [SerializeField] SkillTypeData skillType;
    [SerializeField] OverviewDisplayManager manager;
    // Start is called before the first frame update
    public void Change() {
        manager.DisplaySkill(skillType);
    }
}
