using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour {
    public string[] scenas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void CambiarScena(int s)
    {
        StartCoroutine(CambioScena(scenas[s]));
    }

    IEnumerator CambioScena(string scene)
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(scene);
    }
}
