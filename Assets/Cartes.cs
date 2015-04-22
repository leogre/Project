using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


public class Cartes : MonoBehaviour {

	public string nom;
	public string couleur;
	public int cout;
	public int nb_mana;
	public int point_vie;


	public Cartes(string couleur, string nom, int cout)
	{
		this.nom = nom;
		this.couleur = couleur;
		this.cout = cout;
	}
	

	public void terrain()
	{
		nb_mana = nb_mana + 1;
	}
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
