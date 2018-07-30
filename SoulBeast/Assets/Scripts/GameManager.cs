using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject playerCamera;
    public GameObject battleCamera;

    public GameObject player;

    public GameObject pauseMenu;
    public Text Spirits;
    private string SpiritsT;
    public Text Save;
    private string SaveT;
    public Text ExitMenu;
    private string ExitMenuT;
    public Text ExitGame;
    private string ExitGameT;
    public int currentSelection;

    public GameObject EnemySpirit;
    public GameObject PlayerSpirit;
    public BaseSpirit battleSpirit;

    public List<BaseSpirit> allSpirits = new List<BaseSpirit>();


    public List<Tech> allTechs = new List<Tech>();

    public List<OwnedSpirits> ownedSpirits = new List<OwnedSpirits>();

    public Transform PlayerPodium;
    public Transform EnemyPodium;
    public GameObject emptySpirit;


    public BattleManager bm;

    Player p1;

    [Header("EnemyStats")]
    public int lvlMin;
    public int lvlMax;
    public int enemyLvl;
    public float enemyHP;
    public float enemyMaxHP;
    public int enemyAtt;
    public int enemyMag;
    public int enemyDef;
    public int enemyWil;
    public int enemySpe;

    [Header("PlayerStats")]
    public int playerLvl;
    public float playerHP;
    public float playerMaxHP;
    public int playerAtt;
    public int playerMag;
    public int playerDef;
    public int playerWil;
    public int playerSpe;

    void Start () {

        SpiritsT = Spirits.text;
        SaveT = Save.text;
        ExitMenuT = ExitMenu.text;
        ExitGameT = ExitGame.text;

        playerCamera.SetActive(true);
        battleCamera.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        
    }
	

	void Update () {
        if (playerCamera.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape) & !pauseMenu.gameObject.activeInHierarchy)
            {
                pauseMenu.gameObject.SetActive(true);
                player.GetComponent<PlayerMovement>().isAllowedToMove = false;
                


            }else if (Input.GetKeyDown(KeyCode.Escape) & pauseMenu.gameObject.activeInHierarchy)
            {
                pauseMenu.gameObject.SetActive(false);
                player.GetComponent<PlayerMovement>().isAllowedToMove = true;
            }

            if (Input.GetKeyDown(KeyCode.F1))
            {
                player.GetComponent<SaveSystem>().Load();
                Debug.Log("Loaded!");
            }

            if (Input.GetKeyDown(KeyCode.F2))
            {
                EnterBattle(Rarity.VeryRare);
                Debug.Log("Battle force started!");
            }

            if (pauseMenu.gameObject.activeInHierarchy)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    if (currentSelection < 4)
                    {
                        currentSelection++;
                    }
                }

                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    if (currentSelection > 1)
                    {
                        currentSelection--;
                    }
                }

                switch (currentSelection)
                {
                    case 1:
                        Spirits.text = "> " + SpiritsT;
                        Save.text = SaveT;
                        ExitMenu.text = ExitMenuT;
                        ExitGame.text = ExitGameT;
                        
                        break;
                    case 2:
                        Spirits.text =SpiritsT;
                        Save.text = "> " +  SaveT;
                        ExitMenu.text = ExitMenuT;
                        ExitGame.text = ExitGameT;

                        break;
                    case 3:
                        Spirits.text =SpiritsT;
                        Save.text = SaveT;
                        ExitMenu.text = "> " +  ExitMenuT;
                        ExitGame.text = ExitGameT;

                        break;
                    case 4:
                        Spirits.text =SpiritsT;
                        Save.text = SaveT;
                        ExitMenu.text = ExitMenuT;
                        ExitGame.text = "> " +  ExitGameT;

                        break;

                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    switch (currentSelection)
                    {
                        case 1:

                            break;
                        case 2:
                            player.GetComponent<SaveSystem>().Save();
                            Debug.Log("Saved!");
                            break;
                        case 3:
                            pauseMenu.gameObject.SetActive(false);
                            player.GetComponent<PlayerMovement>().isAllowedToMove = true;
                            break;
                        case 4:
                            //application.quit here
                            break;

                    }
                }
            }
        }

		
	}

    public void EnterBattle(Rarity rarity)
    {
        playerCamera.SetActive(false);
        battleCamera.SetActive(true);
        player.GetComponent<PlayerMovement>().isAllowedToMove = false;

        battleSpirit = GetRandomSpiritFromList(GetSpiritByRarity(rarity));
        p1 = player.GetComponent<Player>();
        

        Debug.Log(battleSpirit.name);
                
        if (battleSpirit.biomeFound == BiomeList.Route1)
        {
            lvlMin = 1;
            lvlMax = 5;
        }

        enemyLvl = Random.Range(lvlMin, lvlMax);
        battleSpirit.lvl = enemyLvl;

        enemyMaxHP = ((3 * enemyLvl)/100 + enemyLvl + 10);
        enemyHP = enemyMaxHP;
        bm.enemyHealthFill.value = 1;
        enemyAtt = ((((battleSpirit.spiritStats.AttackStat * 2) * enemyLvl) / 100) + 5);
        enemyMag = ((((battleSpirit.spiritStats.MagicStat * 2) * enemyLvl) / 100) + 5);
        enemyDef = ((((battleSpirit.spiritStats.DefenceStat * 2) * enemyLvl) / 100) + 5);
        enemyWil = ((((battleSpirit.spiritStats.WillpowerStat * 2) * enemyLvl) / 100) + 5);
        enemySpe = ((((battleSpirit.spiritStats.SpeedStat * 2) * enemyLvl) / 100) + 5);
        playerMaxHP = ((3 * p1.ownedSpirits[0].level) / 100 + p1.ownedSpirits[0].level + 10);

        if (p1.ownedSpirits[0].currentHP > playerMaxHP)
        {
            playerHP = (int)playerMaxHP;
        }
        else
        {
            playerHP = p1.ownedSpirits[0].currentHP;
        }


        bm.playerHealthFill.value = playerHP / playerMaxHP;
        playerAtt = ((((p1.ownedSpirits[0].spirit.spiritStats.AttackStat * 2) * p1.ownedSpirits[0].level) / 100) + 5);
        playerMag = ((((p1.ownedSpirits[0].spirit.spiritStats.MagicStat * 2) * p1.ownedSpirits[0].level) / 100) + 5);
        playerDef = ((((p1.ownedSpirits[0].spirit.spiritStats.DefenceStat * 2) * p1.ownedSpirits[0].level) / 100) + 5);
        playerWil = ((((p1.ownedSpirits[0].spirit.spiritStats.WillpowerStat * 2) * p1.ownedSpirits[0].level) / 100) + 5);
        playerSpe = ((((p1.ownedSpirits[0].spirit.spiritStats.SpeedStat * 2) * p1.ownedSpirits[0].level) / 100) + 5);

        Debug.Log(enemyHP);
        Debug.Log(enemyAtt);
        Debug.Log(enemyMag);
        Debug.Log(enemyDef);
        Debug.Log(enemyWil);
        Debug.Log(enemySpe);

        EnemySpirit = Instantiate(emptySpirit, EnemyPodium.transform.position, Quaternion.identity) as GameObject;
        PlayerSpirit = Instantiate(emptySpirit, PlayerPodium.transform.position, Quaternion.identity) as GameObject;

       
        Vector3 SpiritLocalPos = new Vector3(0, 1, 0);

        EnemySpirit.transform.parent = EnemyPodium;
        EnemySpirit.transform.localPosition = SpiritLocalPos;
        PlayerSpirit.transform.parent = PlayerPodium;
        PlayerSpirit.transform.localPosition = SpiritLocalPos;

        BaseSpirit tempSpirit = EnemySpirit.AddComponent<BaseSpirit>() as BaseSpirit;
        tempSpirit.AddMember(battleSpirit);

        PlayerSpirit.GetComponent<SpriteRenderer>().sprite = p1.ownedSpirits[0].spirit.image;
        PlayerSpirit.GetComponent<SpriteRenderer>().flipX = true;
        EnemySpirit.GetComponent<SpriteRenderer>().sprite = battleSpirit.image;

        bm.ChangeMenu(BattleMenu.Selection);
       

    }

    public List<BaseSpirit> GetSpiritByRarity(Rarity rarity)
    {
        List<BaseSpirit> returnSpirit = new List<BaseSpirit>();
        foreach(BaseSpirit Spirit in allSpirits)
        {
            if(Spirit.rarity == rarity)
            {
                returnSpirit.Add(Spirit);
            }
        }

        return returnSpirit;
    }

    public BaseSpirit GetRandomSpiritFromList(List<BaseSpirit> spiritList)
    {
        BaseSpirit spirit = new BaseSpirit();
        int spiritIndex = Random.Range(0, spiritList.Count - 1);
        spirit = spiritList[spiritIndex];

        return spirit;
    }

}
