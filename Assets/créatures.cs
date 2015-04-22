using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

public class créatures : Cartes 
{
	public Ray rayMouse;
	protected Transform position;
	public bool bloqueur;
	protected Transform origine;
	protected GameObject Card;
	protected GameObject Card2;

	public créatures(string couleur, string nom, int cout, int atk, int vie)
		: base(couleur, nom, cout)
	{		
		
	}

	void Start () 
	{

	}
	
	void Update () 
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		RaycastHit hit2;
		Attaque attackscript;
		Vie viescript;
		Cout coutscript;
		if (Physics.Raycast(ray, out hit))
		{
			Card = hit.transform.gameObject;
			attackscript = Card.GetComponent<Attaque>();      
			viescript = Card.GetComponent<Vie>();
			coutscript = Card.GetComponent<Cout>();
			Debug.Log(hit.collider.gameObject.name + " has " + attackscript.attak + " attack" +", " + viescript.vie+ " life and he cost " + coutscript.cout);

		}





		if (Physics.Raycast (ray, out hit) && Input.GetKeyDown (KeyCode.Mouse0))
		{
			Card = hit.transform.gameObject;
			Card2 = hit2.transform.gameObject;
			attackscript = Card.GetComponent<Attaque>();      
			viescript = Card2.GetComponent<Vie>();

			if(Convert.ToInt32(attackscript) >= Convert.ToInt32(viescript))
			{
				Destroy(hit2.collider.gameObject);
			}
		}



	}
}










