using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(ScenePicker))]
public class BackToMainMenuOnClick : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene(GetComponent<ScenePicker>().scenePath);
    }
}