using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour 
{
	public GUISkin GameSkin;
	
	private bool _isMenu = true;
	private bool _isDeckSelectionMenu = false;
	private bool _isCreditsMenu = false;
	private bool _isOptionsMenu = false;
	private bool _isPlayMenu = false;
	private bool _isAudioOptions = false;
	private bool _isGraphicOptions = false;
	public GameObject mainmusic;
	public GameObject endingmusic;
	
	private string _playerName = "";
	private float _GameVolume = 0.6f;
	private float _GameFOV = 60.0f;
	public Camera GameCamera;
	// Use this for initialization
	void Start () 
	{
		_GameVolume = PlayerPrefs.GetFloat ("Game Volume", _GameVolume);
		_GameFOV = PlayerPrefs.GetFloat ("Game FOV", _GameFOV);
		if (PlayerPrefs.HasKey ("Game Volume")) {
			AudioListener.volume = PlayerPrefs.GetFloat ("Game Volume");
		} else {
			PlayerPrefs.SetFloat ("Game Volume", _GameVolume);
		}
		if (PlayerPrefs.HasKey ("Game FOV")) 
		{
			GameCamera.fieldOfView = PlayerPrefs.GetFloat ("GameFOV");
		} 
		else 
		{
			PlayerPrefs.SetFloat ("Game FOV", _GameFOV);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnGUI()
	{
		GUI.skin = GameSkin;
		
		MainMenu();
		CreditsMenu();
		DeckSelectionMenu();
		OptionsMenu();
		NewGameOptions();
		AudioOptionsDisplay();
		GraphicOptionsDisplay();
		
		if(_isDeckSelectionMenu == true || _isCreditsMenu == true || _isOptionsMenu == true || _isPlayMenu == true)
		{
			if(GUI.Button(new Rect(10, Screen.height - 35, 150, 25), "Back"))
			{
				_isDeckSelectionMenu = false;
				_isCreditsMenu = false;
				_isOptionsMenu = false;
				_isPlayMenu = false;
				_isAudioOptions = false;
				bool _isGraphicOptions = false;

				endingmusic.SetActive(false);
				mainmusic.SetActive(true);
				_isMenu = true;
			}
		}
	}
	
	void MainMenu()
	{
		if(_isMenu)
		{
			if(GUI.Button(new Rect(Screen.width/2 - 75, Screen.height / 2 - 100, 150, 25), "Play"))
			{
				_isMenu = false;
				_isPlayMenu = true;
			}
			
			if (GUI.Button(new Rect(Screen.width/2 - 75, Screen.height / 2 - 65, 150, 25), "Deck Selection"))
			{
				_isMenu = false;
				_isDeckSelectionMenu = true;
			}
			
			if (GUI.Button(new Rect(Screen.width/2 - 75, Screen.height / 2 - 30, 150, 25), "Credits"))
			{
				_isMenu = false;
				_isCreditsMenu = true;
				endingmusic.SetActive(true);
				mainmusic.SetActive(false);
			}
			
			if (GUI.Button(new Rect(Screen.width/2 - 75, Screen.height / 2 + 5, 150, 25), "Options"))
			{
				_isMenu = false;
				_isOptionsMenu = true;
			}
			
			if (GUI.Button(new Rect(Screen.width/2 - 75, Screen.height / 2 + 40, 150, 25), "Quit Game"))
			{
				Application.Quit();
			}
		}
	}
	
	void NewGameOptions()
	{
		if (_isPlayMenu) 
		{	
			Application.LoadLevel("Projet");
		}
	}
	
	void CreditsMenu()
	{
		if(_isCreditsMenu)
		{
			GUI.Box(new Rect(10, Screen.height / 2 - 100, Screen.width / 2 + 100, Screen.height - 450), "Credits");
		}
	}
	
	void DeckSelectionMenu()
	{
		if(_isDeckSelectionMenu)
		{
			GUI.Label(new Rect(10, 100, 200, 50), "Choose a deck");

			if(GUI.Button(new Rect(100, 200, Screen.width / 2 - 150, Screen.height - 300), "Green deck"))
			{
				
			}
			
			if(GUI.Button(new Rect(Screen.width / 2 + 50, 200, Screen.width / 2 - 150, Screen.height - 300), "Red deck"))
			{
				
			}
		}
	}
	
	void OptionsMenu()
	{
		if(_isOptionsMenu)
		{
			GUI.Label(new Rect(10, Screen.height / 2 - 200, 200, 50), "Options");
			GUI.Box(new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height), "");
			
			if (GUI.Button(new Rect(10, Screen.height / 2 - 30, 150, 25), "Audio Options"))
			{
				_isAudioOptions = true;
				_isGraphicOptions = false;
			}
			
			if (GUI.Button(new Rect(10, Screen.height / 2 + 5, 150, 25), "Graphics Options"))
			{
				_isAudioOptions = false;
				_isGraphicOptions = true;
			}
		}
	}
	public void AudioOptionsDisplay()
	{
		if (_isAudioOptions) 
		{
			GUI.Label(new Rect(Screen.width / 2 + 10, 30, 200, 25), "Volume:");
			_GameVolume = GUI.HorizontalSlider(new Rect(Screen.width / 2 + 10, 150, Screen.width / 2 - 55, 25), _GameVolume, 0.0f, 1.0f);
			GUI.Label (new Rect(Screen.width - 35, 145, 50, 25), "" + (System.Math.Round(_GameVolume, 2)));
			AudioListener.volume = _GameVolume;
			if(GUI.Button(new Rect (Screen.width / 2 + 10, Screen.height - 35, 150, 25), "Apply"))
			{
				PlayerPrefs.SetFloat("Game Volume", _GameVolume);
			}
		}
	}
	public void GraphicOptionsDisplay()
	{
		if(_isGraphicOptions)
		{
			GUI.Label(new Rect(Screen.width / 2 + 20, 30, 200, 50), "Video");
			
			GUI.Label(new Rect(Screen.width / 2 + 10, 115, 200, 25), "Game FOV:");
			_GameFOV = GUI.HorizontalSlider(new Rect(Screen.width / 2 + 10, 150, Screen.width / 2 - 55, 25), _GameFOV, 40.0f, 100.0f);
			GUI.Label(new Rect(Screen.width - 35, 145, 50, 25), "" + (int)_GameFOV);
			GameCamera.fieldOfView = _GameFOV;
			if (GUI.Button(new Rect(Screen.width / 2 + 10, Screen.height - 35, 150, 25), "Apply"))
			{
				PlayerPrefs.SetFloat("Game FOV", _GameFOV);
			}
		}
	}
}
