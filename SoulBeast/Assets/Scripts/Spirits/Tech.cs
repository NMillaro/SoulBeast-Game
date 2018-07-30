using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tech  {

	
        public TechName techName;
        public TechType category;
        public SpiritType techType;
        public int cost;
        public float power;


}

public enum TechType
{
    Physical,
    Magical,
    Condition
}

public enum TechName
{
    Stomp,
    Spitboil,
    Slash
}
