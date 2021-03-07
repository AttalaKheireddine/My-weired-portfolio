using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowSkill : MonoBehaviour
{
    [SerializeField] Text overviewText;
    string detailsScene;


    // Start is called before the first frame update
    public void ShowSkillType(SkillTypeData skillType)
    {
        overviewText.text = skillType.skillsInThisType;
        detailsScene = skillType.sceneForDetails;
    }

    public void OnDetailsButtonClick()
    {
        SceneManager.LoadScene(detailsScene);
    }
}
