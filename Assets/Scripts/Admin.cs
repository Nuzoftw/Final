using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Admin : MonoBehaviour 
{
	public Text cant_ciu;
	public Text cant_enem;
	public Image image;
	public int numNPC;
	public GameObject[] Npcs;
	public static int NumEnemy;
	public static int NumCiudadano;
	public int life;
	public Canvas canvasGo;
	public Canvas canvasWin;
	public float max_img, min_img;

	void Start () 
	{
		Cursor.lockState = CursorLockMode.Locked;
		numNPC = Random.Range (10, 20);
		Npcs = new GameObject[numNPC];
		life = 400;
		max_img = life;

		for (int i = 0; i < numNPC; i++) 
		{
			GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
			cube.transform.position = Select_Position ();
			cube.AddComponent<Rigidbody> (); 

			int kind_npc = Random.Range (1, 3);
			if (kind_npc == 2) 
			{
				cube.AddComponent (typeof(Enemy));
				cube.tag = "Zombie";
			} 
			else 
			{
				cube.AddComponent (typeof(Ciudadano));
				cube.tag = "Ciudadano";
			}

			Npcs [i] = cube;
		}

		Enemy[] enemies = FindObjectsOfType<Enemy> ();
		NumEnemy = enemies.Length;
		cant_enem.text = NumEnemy.ToString ();

		Ciudadano[] ciudadanos = FindObjectsOfType<Ciudadano> ();
		NumCiudadano = ciudadanos.Length;
		cant_ciu.text = NumCiudadano.ToString ();

	}

	void Update () {
		if (NumEnemy <=0) 
		{
			canvasWin.gameObject.SetActive (true);
			Cursor.lockState = CursorLockMode.Confined;
		}
		if (NumCiudadano <= 0 || life <=0) 
		{
			canvasGo.gameObject.SetActive (true);
            Camera.main.transform.SetParent(null);
		}
	}

	Vector3 Select_Position()
	{
		Vector3 pos = new Vector3();
		pos.x = Random.Range(-20, 20);
		pos.y = 1.5f;
		pos.z = Random.Range(-20, 20);
		return pos;
	}

	public void KillEnemy()
	{
		NumEnemy--;
		cant_enem.text = NumEnemy.ToString ();
	}

	public void LoseLife()
	{
		life -= 30;
		image.fillAmount = (life) / max_img;
	}

	public void KillCiudadano()
	{
		NumCiudadano--;
		cant_ciu.text = NumCiudadano.ToString ();
	}

	public void BornZombie(){
		NumEnemy++;
		cant_enem.text = NumEnemy.ToString ();
	}
}
