using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SkillType", order = 1)]
public class SkillTypeData : ScriptableObject
{
    public string skillTypeName;
    public string skillsInThisType;
    public Scene sceneForDetails;
}