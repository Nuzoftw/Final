using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Hero listo
public class Hero : MonoBehaviour 
{

	public float life = 100f;


	// Use this for initialization
	void Start () {
		//GameObject player = Instantiate (Resources.Load ("Kirito_final", typeof(GameObject))) as GameObject;
		this.gameObject.GetComponent<Renderer> ().material.color = Color.black;
		this.gameObject.tag = "Player";
		Camera.main.transform.localPosition = transform.position;
		Camera.main.transform.SetParent (gameObject.transform);
		Camera.main.gameObject.AddComponent<FPSAim> ();
	}
	
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Zombie")
		{
			FindObjectOfType<Admin>().LoseLife();
			Debug.Log ("Waaaarrrr soy un Zombie y quiero comer " + collision.gameObject.GetComponent<Enemy> ().partBody);
		}
		else if (collision.gameObject.tag == "Ciudadano")
		{
			
			int years = collision.gameObject.GetComponent<Ciudadano>().Get_Years();
			Debug.Log("Hola soy  " + collision.gameObject.GetComponent<Ciudadano>().names + " y tengo " + years + " años." );
		}

	}
}
