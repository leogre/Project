using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class card : MonoBehaviour
{
    public bool CanUnzoom = true;
	public bool cant_attack = false;
	
	public static AudioClip Hit;
	public static AudioClip HitBySpell;
	public static AudioClip Healed;
	
	public AudioClip sfxMove0;
	public AudioClip sfxMove1;
	
	public AudioClip sfxEntry; // sound effect to be played when card is cast
	public AudioClip sfxAbility0; // sound effect for creature ability 0
	

	public bool Secret = false;
	public bool faceDown = false;
	
	//public bool SpellUnresolved = false;
	
	public Sprite Art;
	public int Index = 0;
	public int Level = 0;
	public string GrowID = "";
	
	public int DiscardCost = 0; // a card can require a number of cards to be discarded as additional cost
	
	public int CostInCurrency = 0; //this is for buying cards from the shop, it doesn't affect gameplay
	
	public Dictionary<string, int> CustomInts = new Dictionary<string, int>();
	public Dictionary<string, string> CustomStrings = new Dictionary<string, string>();
	
	public GameObject highlight = null;
	
	public int Type = 0;
	public int Subtype = 0;
	

	public int CreatureOffense = 0;
	public int CreatureDefense = 0;
	
	
	


	
	public int CreatureStartingOffense = 0;
	public int CreatureStartingDefense = 0;
	

	
	public int CritChance = 0;
	public float CritDamageMultiplier = 2.5f;
	
	public bool FirstTurnInGame = true;
	
	public bool IsTurned = false;
	public bool ControlledByPlayer = false;
	
	public bool DoubleDamage = false;
	public bool TakesHalfDamage = false;
	
	public Transform healfx;
	public Transform firefx;
	
	public bool Dead = false;
	public bool ShowedByEnemy = false;
	
	
	public int AttackedThisTurn = 0;
	
	//Z-s
	public bool Ranged = false;
	public int MovedThisTurn = 0;
	//Z-s
	
	public static float ZoomHeight;
	
	public float Zoom;
	
	public static float ZoomEditDeckMode = 1.7f;
	public string Name = "";
	
	
	public int id_ingame;
	
	public bool Hero = false;
	
	//variables for edit deck mode:
	public int Amount;
	public bool FilteredOut = false;
	public bool InCollection = false;
	
	
	public bool IsZoomed = false;
	bool IsRotatedForZoom = false;
	bool IsMovedForZoom = false;
	
	public bool isDragged = false;
	
	public bool checked_for_highlight = false;
	
	public static bool WaitABit = false;
	//for zoom/unzoom:
	float old_y;
	int old_sortingorder;
	
	// Seconds the mouse is hovering over a card
	float mouseHoverSeconds = 0;
	float mouseHoverZoomTime = 0.5f; // amount of time of mousehover before showing full card
	
	static List<int> NoTargetEffects = new List<int> { 2, 12, 15 };
	


	


	void OnMouseOver()
	{

		
		mouseHoverSeconds += Time.deltaTime;
		//Debug.Log("onmouseover: "+ Name +", for time: "+mouseHoverSeconds);
		if (ShowedByEnemy)
			return;
		
		if (IsZoomed == false && mouseHoverSeconds >= mouseHoverZoomTime)
		{
			ZoomCard();
		}
		
		
		if (Input.GetMouseButtonDown(1))
		{
			Debug.Log("right click");
		}        
	}
	
	
	
	
	
	
	
	
	void OnMouseExit()
	{
		if (IsZoomed == true)
		{
			//UnZoom();
			Debug.Log("OnMouseExit starting to unzoom if we're allowed");
			UnZoom();
		}
	}
	
	
	
	
	
	
	
	
	void ZoomCard()
	{
		BoxCollider2D thiscollider = GetComponent<BoxCollider2D>() as BoxCollider2D;
			if (transform.parent != null) Zoom = ZoomHeight / (thiscollider.size.y * transform.localScale.y * transform.parent.localScale.y);
			else Zoom = ZoomHeight / (thiscollider.size.y * transform.localScale.y); //all cards should be the same size when zoomed, no matter their slot/zone size
			Debug.Log("zoomheight:" + ZoomHeight + "collider height:" + (thiscollider.size.y * transform.localScale.y));
			
			
			//if (transform.position.y <= 0f) {IsMovedForZoom = true; old_y = transform.position.y; transform.position=new Vector3 (transform.position.x, 0f, transform.position.z);}
			if (transform.position.y <= -2.7f) { IsMovedForZoom = true; old_y = transform.position.y; transform.position = new Vector3(transform.position.x, -2.3f, transform.position.z); }
			if (transform.position.y >= 4f) { IsMovedForZoom = true; old_y = transform.position.y; transform.position = new Vector3(transform.position.x, 3f, transform.position.z); }

		
		


		
		
		Vector3 theScale = transform.localScale;
		theScale.x *= Zoom; //make  bigger
		theScale.y *= Zoom; //make bigger
		

		
		transform.localScale = theScale;
		
		
		old_sortingorder = GetComponent<SpriteRenderer>().sortingOrder;
		
		IsZoomed = true;
		
	}
	
	
	
	
	
	
	
	public IEnumerator WaitBeforeUnZoom()
	{
		yield return new WaitForSeconds(0.8f);
		CanUnzoom = true;
	}
	
	
	
	
	
	
	
	
	
	
	public void UnZoom()
	{
		//while (Player.CanUnzoom==false) yield return new WaitForSeconds (0.2f);
		if (CanUnzoom)
		{
			
			Debug.Log("unzooming card:" + Name);
			
			gameObject.layer = 0; //default layer
			foreach (Transform child in transform) child.gameObject.layer = 0;  //the offense/defense text 
			IsRotatedForZoom = false;
			
			if (IsMovedForZoom == true)
			{
				transform.position = new Vector3(transform.position.x, old_y, transform.position.z);
			}
			IsMovedForZoom = false;
			
			Vector3 theScale = transform.localScale;
			
			Debug.Log("scaling back after zoom");
			theScale.x /= Zoom;
			theScale.y /= Zoom;
			
			transform.localScale = theScale;
			
			
			IsZoomed = false;
			ShowedByEnemy = false;
			mouseHoverSeconds = 0; // reset mouse hover seconds
			//yield return new WaitForSeconds (0.1f);
		}
		//else {
		//	yield return 0f;
		//	Debug.Log ("can't unzoom yet");
		//}
	}
	
	  
	
	


	
	
	
	
	

	
	public void Grow(card upgrade, bool AI = false)
	{
		//Debug.Log ("growing, iszoomed:"+IsZoomed);
		Index = upgrade.Index;
		
		//if (IsZoomed) UnZoom();
		collider2D.enabled = false;
		
		foreach (Transform child in transform) Destroy(child.gameObject); //destroying additional gameobjects for art, card name, description text, etc


		Destroy(upgrade.gameObject);
		collider2D.enabled = true;
		

	}
	
	
	
	
	
	

}
