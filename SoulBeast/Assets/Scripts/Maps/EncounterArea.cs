using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterArea : MonoBehaviour {

    public BiomeList biomeType;

    private GameManager gm;


	void Start () {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		
	}
	
	
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            //P = x / 187.5
            // VC 10, C, 8.5, UC 6.75, r 3.33, vr 1.25
            float vc = 10f / 187.5f;
            float c = 8.5f / 187.5f;
            float uc = 6.75f / 187.5f;
            float r = 3.33f / 187.5f;
            float vr = 1.25f / 187.5f;

            float p = Random.Range(0.0f, 100.0f);
            Debug.Log("p = " + p);

            if (p < vr*100)
            {
                if(gm != null)
                {
                    gm.EnterBattle(Rarity.VeryRare);
                }

            }
            else if (p < r*100)
            {
                if (gm != null)
                {
                    gm.EnterBattle(Rarity.Rare);
                }

            }
            else if (p < uc*100)
            {
                if (gm != null)
                {
                    gm.EnterBattle(Rarity.Uncommon);
                }

            }
            else if (p < c*100)
            {
                if (gm != null)
                {
                    gm.EnterBattle(Rarity.Common);
                }

            }
            else if (p < vc * 100)
            {
                if (gm != null)
                {
                    gm.EnterBattle(Rarity.VeryCommon);
                }

            }


        }
    }
}
