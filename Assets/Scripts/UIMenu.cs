using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class UIMenu : MonoBehaviour
{
    public InputField usernameInputField;
    private string username;

    // Start is called before the first frame update
    void Start()
    {
        usernameInputField.text = Manager.Instance.oldHighScoreUsername;
        usernameInputField.onEndEdit.AddListener(SubmitName);
    }

    private void SubmitName(string arg0)
    {
        username = arg0;
        Manager.Instance.username = username;
    }



    // Update is called once per frame
    void Update()
    {
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    

    }


}
