using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Ciudadano Ready
public enum NameCiudadanos
{
	mateo, juan, lucas, marcos, fredy, abraham, elkin, krillin, hitler, maria, judas, el_pirilo, vegeta77, elrubiosomg, justin, 
	magia_nrega, josejuaquin, willian, jhon, mario
}
	

public class Ciudadano : NPC 
{

	public NameCiudadanos names;

	// Use this for initialization
	void Start () 
	{
		Link_Start ();
		gameObject.GetComponent<Renderer> ().material.color = Color.white;
		Select_Name ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Movement ();
	}

	void Select_Name()
	{
		names = (NameCiudadanos)Random.Range (0, 20);
	}

	public static implicit operator Enemy(Ciudadano ciudadano)
	{
		Enemy enemi = ciudadano.gameObject.AddComponent<Enemy> ();
		Destroy (ciudadano);
		return enemi;
	}

}
