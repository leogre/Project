using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

public class Player : MonoBehaviour 
{

	public GameObject[] deckrouge = new GameObject [29];
	public GameObject[] deckvert = new GameObject [29];
	public int i = 0;
	public int j = 0;
	public Transform origine;
	Ray ray;
	RaycastHit hit;
	public GameObject instancerouge;	
	public GameObject instancerouge2;
	public GameObject instancevert;
	List<Cartes> deck_rouge = new List<Cartes>();	
	List<Cartes> deck_vert = new List<Cartes>();	
	public int manarouge = 0;
	public int manavert = 0;
	public GameObject carte;
	public GameObject carte_ennemi;

	void Start () 
	{


	}


		
	void Update () 
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);



		if(Physics.Raycast(ray, out hit) && Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.gameObject.name == "Deckrouge")
		{
			instancevert = Instantiate (deckrouge[i], origine.position, origine.rotation) as GameObject;
			origine.position = new Vector3(origine.position.x +1.33F,origine.position.y,origine.position.z);
			i++;
			print("you have "+manavert+" mana left.");

		}

		if(Physics.Raycast(ray, out hit) && Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.gameObject.name == "Deckvert")
		{
				instancevert = Instantiate (deckvert[j], origine.position, origine.rotation) as GameObject;
				origine.position = new Vector3(origine.position.x +1.33F,origine.position.y,origine.position.z);
				j++;
			    print("you have "+manavert+" mana left.");
		}
		
		Debug.DrawLine(ray.origin, hit.point, Color.red); 


	}



}
