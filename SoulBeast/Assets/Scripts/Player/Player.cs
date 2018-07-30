using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour {

    //public GameObject ManagerScript;
    //public GameManager m1;
    public List<OwnedSpirits> ownedSpirits = new List<OwnedSpirits>();


    void Start()
    {
        //ManagerScript = GameObject.FindWithTag("GameManager");
       // m1 = ManagerScript.GetComponent<GameManager>();
       
}

}

[System.Serializable]
public class OwnedSpirits {

    public string nickName;
    public BaseSpirit spirit;
    public int level;
    public int currentHP;
    public Tech []ownedTechs;

}


