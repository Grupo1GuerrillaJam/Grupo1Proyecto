using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
	Rigidbody2D _rigi;

	[SerializeField]
	private float speed;					//Velocidad actual
	public float slowSpeed;					//Velocidad normal
	public float fastSpeed;					//Velocidad con sprint


	float speedX, speedY, sprintX, sprintY;	//Velocidad en coordenada X e Y, ademas de el sprint
	bool sprint;							//El sprint se activa;

	private void Awake()
	{
		_rigi = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {


		sprint = false;
		speed = slowSpeed;
		speedX = speed;
		speedY = 0;
	}

	// Update is called once per frame
	void FixedUpdate () {


		//Si se pulsa el espacio, se pone el boleano a true y se activa el sprint
		//Si se suelta el espacio, se pone el boleano a false
		if (Input.GetKey (KeyCode.Space)) {
			sprint = true;
		} else if (Input.GetKeyUp (KeyCode.Space)) {
			sprint = false;
		}

		//Se iguala la velocidad con la velocidad de sprint de coordenadas
		if (sprint) 
			sprintX = sprintY = fastSpeed;
		else
			sprintX = sprintY = slowSpeed;

		//Al clickar las flechas se cambia la velocidad entre la velocidad en X y en Y
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			speedY = speed;
			speedX = 0;
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			speedY = 0;
			speedX = -speed;
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			speedY = -speed;
			speedX = 0;
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			speedY = 0;
			speedX = speed;
		}

		//Movimiento calculado por la velocidad en la cordenada, el sprint y el Time.DeltaTime
		Vector2 move = new Vector2 (speedX * sprintX *Time.deltaTime, speedY * sprintY* Time.deltaTime);
		_rigi.MovePosition (_rigi.position + move);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Drug")
        {
            DrugEffect();
        }
        if (collision.gameObject.tag == "Alcohol")
        {
            AlcoholEffect();
        }
        if (collision.gameObject.tag == "Sleep")
        {
            SleepEffect();
        }
    }


    //Aquí habrá que desarrollar los diferentes efectos negativos. Por el momento sólo muestra un mensaje.
    private void DrugEffect()
    {
        Debug.Log("Yo no consumo nada ¿sabes? Yo me meto todaaaaaa");
    }

    private void SleepEffect()
    {
        Debug.Log("Tengo más sueño que una cestica gaticos al lado de la estufa");
    }

    private void AlcoholEffect()
    {
        Debug.Log("Ciento y pico de venas en alcohol");
    }
}
