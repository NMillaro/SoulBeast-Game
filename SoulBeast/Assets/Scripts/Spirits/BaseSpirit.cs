using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpirit : MonoBehaviour {

    public string SName;
    public Sprite image;
    public int lvl;
    private int level;
    public BiomeList biomeFound;
    public SpiritType type1;
    public SpiritType type2;
    public Rarity rarity;
    public float HP;
    public float maxHP;
    public Tech[] ownedTechs;
    //public Stat AttStat;
    //public Stat DefStat;


    public SpiritStats spiritStats;

    public bool canAscend;
    public SpiritAscension AscendTo;

  


	void Start () {
        HP = maxHP;
	}

	void Update () {
		
	}

    public void AddMember(BaseSpirit bs)
    {
        this.SName = bs.SName;
        this.image = bs.image;
        this.biomeFound = bs.biomeFound;
        this.type1 = bs.type1;
        this.type2 = bs.type2;
        this.rarity = bs.rarity;
        this.HP = bs.HP;
        this.maxHP = bs.maxHP;
        //this.AttStat = bs.AttStat;
       // this.DefStat = bs.DefStat;
        this.spiritStats = bs.spiritStats;
        this.canAscend = bs.canAscend;
        this.AscendTo = bs.AscendTo;
        this.level = bs.level;

    }
}

public enum Rarity
{
    VeryCommon,
    Common,
    Uncommon,
    Rare,
    VeryRare
}

public enum SpiritType
{
    None,
    Earth,
    Air,
    Fire,
    Water,
    Metal,
    Magic,
    Light,
    Dark,
    Chaos,
    Energy
}


[System.Serializable]
public class SpiritAscension
{
    public BaseSpirit nextAscension;
    public int AscensionLevel;
}

[System.Serializable]
public class SpiritStats
{
    public int AttackStat;
    public int MagicStat;
    public int DefenceStat;
    public int WillpowerStat;
    public int SpeedStat;
    public int AgilityStat;

}