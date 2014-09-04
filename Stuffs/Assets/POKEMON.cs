using UnityEngine;
using System.Collections;

public class POKEMON : MonoBehaviour {

	//the poke ball
	public GameObject ball;

	//pokemon that would come out of the ball
	public GameObject doge;

	public GameObject lights;

	//initial position of the ball
	public float initialPosition = 0.0f;

	//check to make sure that the ball isn't being held
	public bool held = false;


	//collision function for bringing out the pokemon
	void OnCollisionEnter(Collision rog)
	{
		//if the ball hits the floor after it is held...
		if(rog.gameObject.name == "Cube" && held)
		{
			//bring out a pokemon
			Instantiate(doge,this.transform.position,Quaternion.identity);
			//SendOut (doge);
			//holding the ball is false
			held = false;
		}
	}

	void Start()
	{
		//starting position of the poke ball
		initialPosition = ball.transform.position.y;

		lights.SetActive (false);
	}

	void Update()
	{
		if(ball.transform.position.y - initialPosition > 0)
		{
			held = true;
		}

	}

	//this one needs fixing
	void SendOut(GameObject pokemon)
	{
		Instantiate(pokemon,ball.transform.position,Quaternion.identity);
	}

}
