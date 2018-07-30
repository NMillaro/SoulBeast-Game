using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {


    private BattleStates currentState;


    public BattleMenu currentMenu;
    public GameManager gm;
    Player p1;
    public GameObject player;

    [Header("Selection")]
    public GameObject selectionMenu;
    public GameObject selectionInfo;
    public Text selectionInfoText;
    public Text fight;
    private string fightT;
    public Text inventory;
    private string inventoryT;
    public Text spirits;
    private string spiritsT;
    public Text flee;
    private string fleeT;

    [Header("Techs")]
    public GameObject techsMenu;
    public GameObject techsDetails;
    public Text tCost;
    private string tCostT;
    public Text tType;
    private string tTypeT;
    public Text tech0;
    private string tech0T;
    public Text techT;
    private string techTT;
    public Text techTH;
    private string techTHT;
    public Text techf;
    private string techfT;
    private int damage;
    private bool playerTurn;
    private bool enemyTurn;
    private bool playerAttacked;
    private bool enemyAttacked;
    private bool fleeAttempt;
   


    [Header("Info")]
    public GameObject infoMenu;
    public Text infoText;

    [Header("SpiritInfo")]
    public GameObject spiritInfo;
    public Text spiritName;
    private string spiritNameT;
    public Text spiritLvl;
    private string spiritLvlT;
    public Text spiritHealth;
    private string spiritHealthT;

    [Header("EnemyInfo")]
    public GameObject enemyInfo;
    public Text enemyName;
    private string enemyNameT;
    public Text enemyLvl;
    private string enemyLvlT;

    [Header("Misc")]
    public Slider playerHealthFill;
    public Slider enemyHealthFill;
    public int currentSelection;
    public int enemySelection;

	void Start () {

        currentState = BattleStates.Start;
        currentMenu = BattleMenu.Selection;
        fightT = fight.text;
        inventoryT = inventory.text;
        spiritsT = spirits.text;
        fleeT = flee.text;
        tech0T = tech0.text;
        techTT = techT.text;
        techTHT = techTH.text;
        techfT = techf.text;

        p1 = player.GetComponent<Player>();
        //enemyNameT = gm.battleSpirit.name;
        //enemyName.text = enemyNameT;
        //enemyLvlT = gm.battleSpirit.lvl.ToString();
        //enemyLvl.text = "Lvl " + enemyLvlT;

        

    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
    }
	
	void Update () {

        switch (currentState)
        {
            case (BattleStates.Start):
                spiritNameT = p1.ownedSpirits[0].nickName;
                spiritName.text = spiritNameT;
                spiritLvlT = p1.ownedSpirits[0].level.ToString();
                spiritLvl.text = "Lvl " + spiritLvlT;
                spiritHealthT = gm.playerHP.ToString();
                spiritHealth.text = gm.playerHP + "/" + gm.playerMaxHP;

                
                playerTurn = false;
                enemyTurn = false;
                playerAttacked = false;
                enemyAttacked = false;
                fleeAttempt = false;

                
                break;

            case (BattleStates.PlayerTurn):
                switch (currentSelection)
                {
                    case 1:
                        if (p1.ownedSpirits[0].ownedTechs.Length >= 1 && currentSelection == 1)
                        {
                            if (p1.ownedSpirits[0].ownedTechs[0].category == TechType.Physical)
                                {
                                    damage = ((((((2 * p1.ownedSpirits[0].level) / 5)+2) * (int)p1.ownedSpirits[0].ownedTechs[0].power * (gm.playerAtt/gm.enemyDef))/50)+2);
                                    ChangeEnemyHealth(damage);
                                    Debug.Log("1 Attack successful! " + damage.ToString() + " damage!");
                                    playerTurn = true;
                                    playerAttacked = true;
                                    currentState = BattleStates.Info;
                                    ChangeMenu(BattleMenu.Info);

                                

                            }
                            else if (p1.ownedSpirits[0].ownedTechs[0].category == TechType.Magical)
                                {
                                    damage = ((((((2 * p1.ownedSpirits[0].level) / 5) + 2) * (int)p1.ownedSpirits[0].ownedTechs[0].power * (gm.playerMag / gm.enemyWil)) / 50) + 2);
                                    ChangeEnemyHealth(damage);
                                    Debug.Log("1 Magic attack successful! " + damage.ToString() + " damage!");
                                    playerTurn = true;
                                    playerAttacked = true;
                                    currentState = BattleStates.Info;
                                    ChangeMenu(BattleMenu.Info);


                            }
                            
                        }

                        break;

                    case 2:
                        if (p1.ownedSpirits[0].ownedTechs.Length >= 2 && currentSelection == 2)
                        {
                            if (p1.ownedSpirits[0].ownedTechs[1].category == TechType.Physical)
                            {
                                damage = ((((((2 * p1.ownedSpirits[0].level) / 5) + 2) * (int)p1.ownedSpirits[0].ownedTechs[1].power * (gm.playerAtt / gm.enemyDef)) / 50) + 2);
                                ChangeEnemyHealth(damage);
                                Debug.Log("2 Attack successful! " + damage.ToString() + " damage!");
                                playerTurn = true;
                                playerAttacked = true;
                                currentState = BattleStates.Info;
                                ChangeMenu(BattleMenu.Info);
   
                            }
                            else if (p1.ownedSpirits[0].ownedTechs[1].category == TechType.Magical)
                            {
                                damage = ((((((2 * p1.ownedSpirits[0].level) / 5) + 2) * (int)p1.ownedSpirits[0].ownedTechs[1].power * (gm.playerMag / gm.enemyWil)) / 50) + 2);
                                ChangeEnemyHealth(damage);
                                Debug.Log("2 Magic attack successful! " + damage.ToString() + " damage!");
                                playerTurn = true;
                                playerAttacked = true;
                                currentState = BattleStates.Info;
                                ChangeMenu(BattleMenu.Info);

                            }
                        }


                        break;

                    case 3:

                        break;

                    case 4:

                        break;

                }


                break;
            case (BattleStates.EnemyTurn):
                if (gm.battleSpirit.ownedTechs.Length >= 1)
                {
                    if (gm.battleSpirit.ownedTechs[0].category == TechType.Physical)
                    {
                        damage = ((((((2 * gm.enemyLvl) / 5) + 2) * (int)gm.battleSpirit.ownedTechs[0].power * (gm.enemyAtt / gm.playerDef)) / 50) + 2);
                        ChangePlayerHealth(damage);
                        Debug.Log("Enemy attack successful! " + damage.ToString() + " damage!");
                        enemyTurn = true;
                        enemyAttacked = true;
                        currentState = BattleStates.Info;
                        ChangeMenu(BattleMenu.Info);

                        

                    }
                    else if (gm.battleSpirit.ownedTechs[0].category == TechType.Magical)
                    {
                        damage = ((((((2 * gm.enemyLvl) / 5) + 2) * (int)gm.battleSpirit.ownedTechs[0].power * (gm.enemyMag / gm.playerWil)) / 50) + 2);
                        ChangePlayerHealth(damage);
                        Debug.Log("Enemy attack successful! " + damage.ToString() + " damage!");
                        enemyTurn = true;
                        enemyAttacked = true;
                        currentState = BattleStates.Info;
                        ChangeMenu(BattleMenu.Info);
                    }

                }


                break;
            case (BattleStates.Win):
                gm.playerCamera.SetActive(true);
                gm.battleCamera.SetActive(false);
                gm.player.GetComponent<PlayerMovement>().isAllowedToMove = true;
                p1.ownedSpirits[0].currentHP = (int)gm.playerHP;

                Destroy(gm.EnemySpirit);
                currentState = BattleStates.Start;

                break;
            case (BattleStates.Lose):

                break;
            case (BattleStates.Info):

                break;
        }



        //p1 = player.GetComponent<Player>();
        enemyNameT = gm.battleSpirit.name;
        enemyName.text = enemyNameT;
        enemyLvlT = gm.battleSpirit.lvl.ToString();
        enemyLvl.text = "Lvl " + enemyLvlT;

        //spiritNameT = p1.ownedSpirits[0].nickName;
        //spiritName.text = spiritNameT; 
        //spiritLvlT = p1.ownedSpirits[0].level.ToString();
        //spiritLvl.text = "Lvl " + spiritLvlT;
        //if (p1.ownedSpirits[0].currentHP> gm.playerMaxHP)
        //{
        //    spiritHealthT = gm.playerMaxHP.ToString();
        //}else
        //{
        //    spiritHealthT = p1.ownedSpirits[0].currentHP.ToString();
        //}
        //spiritHealth.text = spiritHealthT + "/" + gm.playerMaxHP;



        if (p1.ownedSpirits[0].ownedTechs.Length >= 1)
        {
            tech0T = p1.ownedSpirits[0].ownedTechs[0].techName.ToString();
            tech0.text = tech0T;
        }

        if (p1.ownedSpirits[0].ownedTechs.Length >= 2)
        {
            techTT = p1.ownedSpirits[0].ownedTechs[1].techName.ToString();
            techT.text = techTT;
        }



        if (p1.ownedSpirits[0].ownedTechs.Length >= 3)
        {
            techTHT = p1.ownedSpirits[0].ownedTechs[2].techName.ToString();
            techTH.text = techTHT;
        }

        if (p1.ownedSpirits[0].ownedTechs.Length == 4)
        {
            techfT = p1.ownedSpirits[0].ownedTechs[3].techName.ToString();
            techf.text = techfT;
        }


            if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) && (currentMenu == BattleMenu.Fight || currentMenu == BattleMenu.Selection))
        {
            if(currentSelection == 1 || currentSelection == 2)
            {
                currentSelection = currentSelection + 2;
            }
        }

            if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && (currentMenu == BattleMenu.Fight || currentMenu == BattleMenu.Selection))
        {
            if (currentSelection == 1 || currentSelection == 3)
            {
                currentSelection++;
            }
        }

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && (currentMenu == BattleMenu.Fight || currentMenu == BattleMenu.Selection))
        {
            if (currentSelection == 3 || currentSelection == 4)
            {
                currentSelection = currentSelection - 2;
            }
        }

        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && (currentMenu == BattleMenu.Fight || currentMenu == BattleMenu.Selection))
        {
            if (currentSelection == 2 || currentSelection == 4)
            {
                currentSelection--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (currentMenu)
            {
                case BattleMenu.Fight:
                    switch (currentSelection)
                    {
                        case 1:
                            if (gm.playerSpe >= gm.enemySpe)
                            {
                                currentState = BattleStates.PlayerTurn;
                            }
                            else if (gm.playerSpe < gm.enemySpe)
                            {
                                currentState = BattleStates.EnemyTurn;
                            }

                            break;
                        case 2:
                            if (gm.playerSpe >= gm.enemySpe)
                            {
                                currentState = BattleStates.PlayerTurn;
                            }
                            else if (gm.playerSpe < gm.enemySpe)
                            {
                                currentState = BattleStates.EnemyTurn;
                            }

                            break;
                        case 3:
                           
                            break;
                        case 4:
                           
                            break;

                    }
                    break;

                case BattleMenu.Selection:
                    switch (currentSelection)
                    {
                        case 1:
                            ChangeMenu(BattleMenu.Fight);
                            break;
                        case 2:
                           
                            break;
                        case 3:
                            
                            break;
                        case 4:

                            if (gm.playerSpe > gm.enemySpe)
                            {

                                gm.playerCamera.SetActive(true);
                                gm.battleCamera.SetActive(false);
                                gm.player.GetComponent<PlayerMovement>().isAllowedToMove = true;
                                p1.ownedSpirits[0].currentHP = (int)gm.playerHP;

                                Destroy(gm.EnemySpirit);
                            }

                            else
                            {
                                float run = Random.Range(0, gm.enemySpe);

                                if ((gm.playerSpe + run) > gm.enemySpe)
                                {
                                    gm.playerCamera.SetActive(true);
                                    gm.battleCamera.SetActive(false);
                                    gm.player.GetComponent<PlayerMovement>().isAllowedToMove = true;
                                    p1.ownedSpirits[0].currentHP = (int)gm.playerHP;

                                    Destroy(gm.EnemySpirit);

                                }
                                else
                                {
                                    infoText.text = "Couldn't get away!";
                                    fleeAttempt = true;
                                    playerTurn = true;
                                    playerAttacked = true;
                                    currentState = BattleStates.Info;
                                    ChangeMenu(BattleMenu.Info);

                                }
                            }

                            break;

                    }
                    break;

                case BattleMenu.Info:

                    if (gm.enemyHP <= 0)
                    {
                        currentState = BattleStates.Win;
                    }
                    
                    else if (playerAttacked == true && enemyAttacked == true)
                    {
                        ChangeMenu(BattleMenu.Selection);
                        currentState = BattleStates.Start;
                    }
                    else if((playerAttacked == true && enemyAttacked== false) || fleeAttempt == true)
                    {
                        playerTurn = false;
                        currentState = BattleStates.EnemyTurn;
                    }
                    else if (playerAttacked == false && enemyAttacked == true)
                    {
                        enemyTurn = false;
                        currentState = BattleStates.PlayerTurn;
                    }


                    break;

            }

           
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentMenu == BattleMenu.Fight)
            {
                ChangeMenu(BattleMenu.Selection);
            }


        }

        if (currentSelection == 0)
        {
            currentSelection = 1;
        }


        switch (currentMenu)
        {
            case BattleMenu.Fight:
                switch (currentSelection)
                {
                    case 1:
                        tech0.text = "> " + tech0T;
                        techT.text = techTT;
                        techTH.text = techTHT;
                        techf.text = techfT;

                        if (p1.ownedSpirits[0].ownedTechs.Length >= 1) { 
                            tCost.text = p1.ownedSpirits[0].ownedTechs[0].cost.ToString();
                            tType.text = p1.ownedSpirits[0].ownedTechs[0].techType.ToString();
                        }
                        else {
                            tCost.text = "-";
                            tType.text = "-";
                        }
                        break;
                    case 2:
                        tech0.text = tech0T;
                        techT.text = "> " + techTT;
                        techTH.text = techTHT;
                        techf.text = techfT;

                        if (p1.ownedSpirits[0].ownedTechs.Length >= 2)
                        {
                            tCost.text = p1.ownedSpirits[0].ownedTechs[1].cost.ToString();
                            tType.text = p1.ownedSpirits[0].ownedTechs[1].techType.ToString();
                        }
                        else
                        {
                            tCost.text = "-";
                            tType.text = "-";
                        }
                        break;
                    case 3:
                        tech0.text = tech0T;
                        techT.text = techTT;
                        techTH.text = "> " + techTHT;
                        techf.text = techfT;

                        if (p1.ownedSpirits[0].ownedTechs.Length >= 3)
                        {
                            tCost.text = p1.ownedSpirits[0].ownedTechs[2].cost.ToString();
                            tType.text = p1.ownedSpirits[0].ownedTechs[2].techType.ToString();
                        }
                        else
                        {
                            tCost.text = "-";
                            tType.text = "-";
                        }
                        break;
                    case 4:
                        tech0.text = tech0T;
                        techT.text = techTT;
                        techTH.text = techTHT;
                        techf.text = "> " + techfT;

                        if (p1.ownedSpirits[0].ownedTechs.Length == 4)
                        {
                            tCost.text = p1.ownedSpirits[0].ownedTechs[3].cost.ToString();
                            tType.text = p1.ownedSpirits[0].ownedTechs[3].techType.ToString();
                        }
                        else
                        {
                            tCost.text = "-";
                            tType.text = "-";
                        }

                        break;

                }
                break;

            case BattleMenu.Selection:
                switch (currentSelection)
                {
                    case 1:
                        fight.text = "> " + fightT;
                        inventory.text = inventoryT;
                        spirits.text = spiritsT;
                        flee.text = fleeT;
                        break;
                    case 2:
                        fight.text = fightT;
                        inventory.text = "> " + inventoryT;
                        spirits.text = spiritsT;
                        flee.text = fleeT;
                        break;
                    case 3:
                        fight.text = fightT;
                        inventory.text = inventoryT;
                        spirits.text = "> " + spiritsT;
                        flee.text = fleeT;
                        break;
                    case 4:
                        fight.text = fightT;
                        inventory.text = inventoryT;
                        spirits.text = spiritsT;
                        flee.text = "> " + fleeT;
                        break;

                }
                break;

            case BattleMenu.Info:
                switch (currentSelection)
                {
                    case 1:
                        if (gm.enemyHP <= 0)
                        {
                            infoText.text = gm.battleSpirit.name + " was defeated!";
                        }
                        else if (playerTurn == true && fleeAttempt == false)
                        {
                            infoText.text = p1.ownedSpirits[0].nickName + " used " + p1.ownedSpirits[0].ownedTechs[0].techName + "!";
                        }
                        else if (enemyTurn == true)
                        {
                            infoText.text = gm.battleSpirit.name + " used " + gm.battleSpirit.ownedTechs[0].techName + "!";
                        }


                        break;
                    case 2:
                        if (gm.enemyHP <= 0)
                        {
                            infoText.text = gm.battleSpirit.name + " was defeated!";
                        }
                        else if (playerTurn == true && fleeAttempt == false)
                        {
                            infoText.text = p1.ownedSpirits[0].nickName + " used " + p1.ownedSpirits[0].ownedTechs[1].techName + "!";
                        }
                        else if (enemyTurn == true)
                        {
                            infoText.text = gm.battleSpirit.name + " used " + gm.battleSpirit.ownedTechs[1].techName + "!";
                            
                        }
                        break;
                    case 3:
                        
                        break;
                    case 4:
                        
                        break;

                }
                break;
        }

 
    }

    public void ChangePlayerHealth(int amount)
    {
        gm.playerHP -= amount;
        spiritHealthT = gm.playerHP.ToString();
        spiritHealth.text = spiritHealthT + "/" + gm.playerMaxHP;
        gm.playerHP = Mathf.Clamp(gm.playerHP, 0, gm.playerMaxHP);

        playerHealthFill.value = gm.playerHP / gm.playerMaxHP;
    }

    public void ChangeEnemyHealth(int amount)
    {
        gm.enemyHP -= amount;
        gm.enemyHP = Mathf.Clamp(gm.enemyHP, 0, gm.enemyMaxHP);

        enemyHealthFill.value = gm.enemyHP / gm.enemyMaxHP;
    }

    public void ChangeMenu(BattleMenu m)
    {
        currentMenu = m;
        switch (m)
        {
            case BattleMenu.Selection:
                currentSelection = 1;
                selectionMenu.gameObject.SetActive(true);
                selectionInfo.gameObject.SetActive(true);
                techsMenu.gameObject.SetActive(false);
                techsDetails.gameObject.SetActive(false);
                infoMenu.gameObject.SetActive(false);
                break;

            case BattleMenu.Fight:
                selectionMenu.gameObject.SetActive(false);
                selectionInfo.gameObject.SetActive(false);
                techsMenu.gameObject.SetActive(true);
                techsDetails.gameObject.SetActive(true);
                infoMenu.gameObject.SetActive(false);
                break;

            case BattleMenu.Info:
                selectionMenu.gameObject.SetActive(false);
                selectionInfo.gameObject.SetActive(false);
                techsMenu.gameObject.SetActive(false);
                techsDetails.gameObject.SetActive(false);
                infoMenu.gameObject.SetActive(true);
                break;
        }
    }
}

public enum BattleMenu
{
    Selection,
    Spirits,
    Inventory,
    Fight,
    Info
}

public enum BattleStates
{
    Start,
    PlayerTurn,
    EnemyTurn,
    Lose,
    Win,
    Info

}
