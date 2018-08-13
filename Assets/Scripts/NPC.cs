using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States_Game
{
	Idle, Moving, Rotating, Attack
};

public class NPC : MonoBehaviour 
{

	bool start = false;
	int years = 0;
	public float speed = 0f;
	States_Game state;
	Vector3 rotation;

	void Update ()
	{
		if (!start)
		{
			Link_Start();
			start = true;            
		}
		StartCoroutine(SelectState());
	}

	public virtual void Link_Start()
	{
		Select_Years ();
		speed = ((100f - years) / 50f);
		StartCoroutine(SelectState());
	}



	public void Movement()
	{
		if(state == States_Game.Moving)
		{
			transform.position += transform.forward * speed * Time.deltaTime;
		}
		if (state == States_Game.Rotating)
		{
			transform.eulerAngles += rotation;
		}
		if (state == States_Game.Attack)
		{

		}
	}
    public void Select_Years()
    {
        years = Random.Range(15, 101);
    }
	IEnumerator SelectState()
	{
		yield return new WaitForSeconds(3);
		state = (States_Game)Random.Range(0, 3);
		StartCoroutine(SelectState());
		rotation.y = Random.Range(-1, 2);
	}

	public int Get_Years()
	{
		return years;
	}
}
