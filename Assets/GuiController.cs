using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiController : MonoBehaviour {

    public Text speedText;
    public Text pointsText;

    private GameObject player;
    private Rigidbody _rigi;
    private int speed;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _rigi = player.GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {

        pointsText.text = "6/6 Points";

        speedText.text = "Km/h";
	}
	
	// Update is called once per frame
	void Update () {
        
        if(_rigi.velocity.x < 0)
        {
            speedText.text = - _rigi.velocity.x + "Km/h";
        }


	}
}
