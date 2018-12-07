using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartRoutine : MonoBehaviour
{
    //carga la escena 
    public void MethodGameUI()
    {
        SceneManager.LoadScene("GameTest"); 
	}
	
}
