using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BodyParts
{
	Cabeza, Brazos, Piernas, Nalgas, Abdomen
}

public class Enemy : NPC 
{

	public BodyParts partBody;
	GameObject[] obj;
	void Start () 
	{
		Link_Start ();
		obj = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];
	}
	void Update () 
	{
		Movement ();
		Search ();
	}

	public override void Link_Start()
	{
		base.Link_Start ();
		Select_Colors ();
		partBody = (BodyParts)Random.Range (0, 5);
	}

	public Color Select_Colors()
	{
		Color color = Color.white;
		int Rcolor = Random.Range (0, 4);
		switch (Rcolor) 
		{
		case 0:
			color = Color.green;
			break;
		case 1:
			color = Color.blue;
			break;
		case 2:
			color = Color.cyan;
			break;
		case 3:
			color = Color.red;
			break;
		}
		gameObject.GetComponent<Renderer> ().material.color = color;
		return color;
	}


	public void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Sword")
		{
			FindObjectOfType<Admin>().KillEnemy();
			Destroy(collision.gameObject);
			Destroy(gameObject);

		}

		if (collision.gameObject.tag == "Ciudadano")
		{
			Ciudadano ciu = collision.gameObject.GetComponent<Ciudadano>();    
			Enemy enem = ciu;
			enem.tag = "Zombie";            
			FindObjectOfType<Admin>().BornZombie();
			FindObjectOfType<Admin>().KillCiudadano();
		}

	}



	void Search()
	{
		foreach (GameObject go in obj)
		{
			if (go != null)
			{      
				if (go.GetComponent<Hero>() || go.GetComponent<Ciudadano>())
				{
					float dist = Vector3.Distance(go.transform.position, transform.position);

					if (dist < 5f)
					{
						Vector3 direccion = go.transform.position - transform.position;
						dist = direccion.magnitude;
						transform.LookAt(go.transform.position);
						transform.position += Vector3.Normalize(go.transform.position - transform.position) * speed * Time.deltaTime;
					}
				}
			}

		}
	}
}
