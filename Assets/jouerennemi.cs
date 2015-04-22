using UnityEngine;
using System.Collections;

public class jouerennemi : MonoBehaviour {

	public Transform Origine;
	public GameObject instance;
	public Transform Origine2;
	public GameObject instance2;
	public Transform Origine3;
	public GameObject instance3;
	public GameObject ManaGUI;
	public Transform originemana;
	public GameObject instancemana;	
	public int nbmanaen=0;
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
		if (Physics.Raycast (ray, out hit) && Input.GetKeyDown (KeyCode.Mouse0) && hit.collider.gameObject.name != "Deckrouge" && hit.collider.gameObject.name != "Deckvert" && hit.collider.gameObject.name != "Plane") 
		{
			
			if(hit.collider.gameObject.name == "Montagne(Clone)")
			{
				Destroy(hit.collider.gameObject);
				instance2 = Instantiate(hit.collider.gameObject, Origine2.position, Origine2.rotation) as GameObject;
				Origine2.position = new Vector3(Origine2.position.x +1.5F,Origine2.position.y,Origine2.position.z);
			}
			else
			{
				if(hit.collider.gameObject.name == "Montagne(Clone)(Clone)" || hit.collider.gameObject.name == "Montagne(Clone)(Clone)(Clone)")
				{
					Destroy(hit.collider.gameObject);
					instance3 = Instantiate(hit.collider.gameObject, Origine3.position, Origine3.rotation) as GameObject;
					Origine3.position = new Vector3(Origine3.position.x +1.5F,Origine3.position.y,Origine3.position.z);
					nbterrain.Add(instance3);

					instancemana = Instantiate(ManaGUI.gameObject, originemana.position, originemana.rotation) as GameObject;
					originemana.position = new Vector3(originemana.position.x+1.5F, originemana.position.y, originemana.position.z);
					nbmanaen++;
					crystaux_mana.Add(instancemana);
				}
				else
				{
					if(hit.collider.gameObject.name == "Escouflenfer d'utvara(Clone)" || hit.collider.gameObject.name == "Goblin chariot(Clone)" || hit.collider.gameObject.name == "Diables d'émeutes(Clone)" || hit.collider.gameObject.name == "Berserker(Clone)" || hit.collider.gameObject.name == "Piquier goblin(Clone)")
					{
						Destroy(hit.collider.gameObject);
						instance = Instantiate(hit.collider.gameObject, Origine.position, Origine.rotation) as GameObject;
						Origine.position = new Vector3(Origine.position.x +1.5F,Origine.position.y,Origine.position.z);
					}
				}
			}
			
			
		}

		if (Physics.Raycast (ray, out hit) && Input.GetKeyDown (KeyCode.Mouse0) && hit.collider.gameObject.name == "Deckrouge") 
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
			
		}
	}
}
