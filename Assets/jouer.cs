using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

public class jouer : MonoBehaviour 
{
	public GUISkin GameSkin;
	public Camera GameCamera;
	private bool action_menu = false;

	public Transform Origine;
	public GameObject instance;
	public Transform Origine2;
	public GameObject instance2;
	public Transform Origine3;
	public GameObject instance3;
	public GameObject ManaGUI;
	public Transform originemana;
	public GameObject instancemana;	
	public int nbmana=0;
	Cout coutscript;
	protected GameObject Card;
	//public GameObject[] crystaux_mana = new GameObject [29];
	public ArrayList crystaux_mana = new ArrayList();
	public ArrayList nbterrain = new ArrayList();
	public GameObject instance4;
	public Transform Origine4;
	public GameObject terrain;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit) && Input.GetKeyDown (KeyCode.Mouse0) && hit.collider.gameObject.name != "Deckvert" && hit.collider.gameObject.name != "Deckrouge" && hit.collider.gameObject.name != "Plane") 
		{

			if(hit.collider.gameObject.name == "Foret(Clone)")
			{
				Destroy(hit.collider.gameObject);
				instance2 = Instantiate(hit.collider.gameObject, Origine2.position, Origine2.rotation) as GameObject;
				Origine2.position = new Vector3(Origine2.position.x +1.5F,Origine2.position.y,Origine2.position.z);

			}
			else
			{
				if(hit.collider.gameObject.name == "Foret(Clone)(Clone)" || hit.collider.gameObject.name == "Foret(Clone)(Clone)(Clone)")
				{
					Destroy(hit.collider.gameObject);
					instance3 = Instantiate(hit.collider.gameObject, Origine3.position, Origine3.rotation) as GameObject;
					Origine3.position = new Vector3(Origine3.position.x +1.5F,Origine3.position.y,Origine3.position.z);
					nbterrain.Add(instance3);

					instancemana = Instantiate(ManaGUI.gameObject, originemana.position, originemana.rotation) as GameObject;
					originemana.position = new Vector3(originemana.position.x+1.5F, originemana.position.y, originemana.position.z);
					nbmana++;
				    crystaux_mana.Add(instancemana);
				}
				else
				{
					if(hit.collider.gameObject.name == "Baloth Luth(Clone)" || hit.collider.gameObject.name == "Coursier centaure(Clone)" || hit.collider.gameObject.name == "Elfes de Lianowar(Clone)" || hit.collider.gameObject.name == "Piétinneur terrestre(Clone)" || hit.collider.gameObject.name == "Terrocorne kalonien(Clone)")
					{

						Card = hit.collider.transform.gameObject;
						coutscript = Card.GetComponent<Cout>();

						if(nbmana >= Convert.ToInt32(coutscript.cout))
						{
							Destroy(hit.collider.gameObject);
							instance = Instantiate(hit.collider.gameObject, Origine.position, Origine.rotation) as GameObject;
							Origine.position = new Vector3(Origine.position.x +1.5F,Origine.position.y,Origine.position.z);
							nbmana = nbmana - Convert.ToInt32(coutscript.cout);

														
							//for(int i = 0; i < Convert.ToInt32(coutscript); i++)
							//{
							//Destroy(crystaux_mana.ElementAt(i));
							//	crystaux_mana[i];
							//	crystaux_mana.RemoveAt(i);
							//} 
							
													
							nbmana = nbmana - Convert.ToInt32(coutscript.cout);
							
							foreach(GameObject a in crystaux_mana)
							{
								Destroy(a);
							}
							for(int i = 0; i < nbmana; i++)
							{
								instancemana = Instantiate(ManaGUI.gameObject, originemana.position, originemana.rotation) as GameObject;
								originemana.position = new Vector3(originemana.position.x+1.5F, originemana.position.y, originemana.position.z);
								crystaux_mana.Add(instancemana);
							}
						}
					}
					else
					{
						if(hit.collider.gameObject.name == "Baloth Luth(Clone)(Clone)" || hit.collider.gameObject.name == "Coursier centaure(Clone)(Clone)" || hit.collider.gameObject.name == "Elfes de Lianowar(Clone)(Clone)" || hit.collider.gameObject.name == "Piétinneur terrestre(Clone)(Clone)" || hit.collider.gameObject.name == "Terrocorne kalonien(Clone)(Clone)")
						{
							action_menu = true;
						}
					}
				}				
			}
		}


		if (Physics.Raycast (ray, out hit) && Input.GetKeyDown (KeyCode.Mouse0) && hit.collider.gameObject.name == "Deckvert") 
		{
			foreach(GameObject a in nbterrain)
			{
				instance4 = Instantiate(terrain.gameObject, Origine4.position, Origine4.rotation) as GameObject;
				Origine4.position = new Vector3(Origine4.position.x +1.5F,Origine4.position.y,Origine4.position.z);
			}


			foreach(GameObject a in crystaux_mana)
			{
				Destroy(a);
			}
			foreach(GameObject a in nbterrain)
			{
				Destroy(a);
			}
			for(int i = 0; i <= nbterrain.Count; i++)
			{
				nbterrain.RemoveAt(i);
			} 

		}
	}

	void actionmenu()
	{
		if(action_menu)
		{
			
			if(GUI.Button(new Rect(Screen.width/100, Screen.width/200, Screen.width / 2 - 150, Screen.height - 300), "Block"))
			{
				
			}
			if(GUI.Button(new Rect(100, 200, Screen.width / 2 - 150, Screen.height - 300), "Engage"))
			{
				
			}
			if(GUI.Button(new Rect(100, 200, Screen.width / 2 - 150, Screen.height - 300), "Attack"))
			{
				
			}
			if(GUI.Button(new Rect(100, 200, Screen.width / 2 - 150, Screen.height - 300), "Close"))
			{
				action_menu = false;
			}
		}
	}
}
