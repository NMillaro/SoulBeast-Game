using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour {

    public GameObject player;
    Vector3 position;
  


    public void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        Load();
		
	}
	
	
	public void Load () {
        if (PlayerPrefs.HasKey("PlayerX"))
        {
            position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));
            player.transform.position = position;
            Debug.Log(PlayerPrefs.GetFloat("PlayerX").ToString());
            Debug.Log(PlayerPrefs.GetFloat("PlayerY").ToString());
            Debug.Log(PlayerPrefs.GetFloat("PlayerZ").ToString());
        }
		
	}

    public void Save() {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        Debug.Log(player.transform.position.x.ToString());
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        Debug.Log(player.transform.position.y.ToString());
        PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);
        Debug.Log(player.transform.position.z.ToString());
        Debug.Log("Positions set!");
    }
}
