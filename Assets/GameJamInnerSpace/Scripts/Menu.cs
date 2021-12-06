using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

	public Camera cam;
	public bool isAAEnable;
	
    // Start is called before the first frame update
    void Start()
    {
	    cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
	    if(isAAEnable)
	    {
		    cam.allowMSAA = true;
		    QualitySettings.antiAliasing = 4;
	    }
	    else
	    {
		    cam.allowMSAA = false;
		    QualitySettings.antiAliasing = 1;
	    }
    }
    
    //Main Menu Buttons
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
        Time.timeScale = 1f;
    }
    
    public void Close()
    {
	    Application.Quit();
    #if UNITY_EDITOR
	    UnityEditor.EditorApplication.isPlaying = false;
    #endif
	}
    
    // Options stuff

    public void antiAliasCheck(bool enabledAA)
    {
	    isAAEnable = enabledAA;
    }
}
