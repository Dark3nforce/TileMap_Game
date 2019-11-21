using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BasePokemon : MonoBehaviour {

    public string PName;
    public int level;
    public Sprite image;
    public BiomeList biomeFound;
    public PokemonType type;
    public Rarity rarity;
    public int HP;
    public int FullHP;
    public int maxHP;
    public Stat AttackStat;
    public Stat DefenceStat;

    public PokemonStats pokemonStats;

    public bool canEvolve;
    public PokemonEvolution evolveTo;

    // public Transform
    public Vector3 scalePos;
    public Vector3 pos;


	void Start () {
        maxHP = HP;
	}
	void Update () {
	
	}

    public void AddMember(BasePokemon bp)
    {
        this.PName = bp.PName;
        this.image = bp.image;
        this.biomeFound = bp.biomeFound;
        this.type = bp.type;
        this.rarity = bp.rarity;
        this.HP = bp.HP;
        this.maxHP = bp.maxHP;
        this.AttackStat = bp.AttackStat;
        this.DefenceStat = bp.DefenceStat;
        this.pokemonStats = bp.pokemonStats;
        this.canEvolve = bp.canEvolve;
        this.evolveTo = bp.evolveTo;
        this.level = bp.level;
    }
}

public enum Rarity
{
    VeryCommon,
    Common,
    SemiRare,
    Rare,
    VeryRare
}

public enum PokemonType
{
    // Flying,
    // Ground,
    // Rock,
    // Steel,
    // Fire,
    // Water,
    // Grass,
    // Ice,
    // Electric,
    // Psychic,
    // Dark,
    // Dragon,
    // Fighting,
    // Normal
    Fire = 0,
    Water = 1,
    Grass = 2,
    Electric = 3,
    Ice =4,
    Psychic=5,
    Normal=6,
    Fighting=7,
    Flying=8,
    Ground=9,
    Rock=10,
    Bug=11,
    Poison=12,
    Ghost=13,
    Dragon=14
}

[System.Serializable]
public class PokemonEvolution
{
    public BasePokemon nextEvolution;
    public int levelUpLevel;
}

[System.Serializable]
public class PokemonStats
{
    public int AttackStat;
    public int DefenceStat;
    public int SpeedStat;
    public int SpAttackStat;
    public int SpDefenceStat;
    public int EvasionStat;
    // public int HP;
}

[System.Serializable]
public class PokemonMoves
{
    public string Name;
    public MoveType category;
    public Stat moveStat;
    public PokemonType moveType;
    public int currentPP;
    public int PP;
    public float power;
    public float accuracy;

    // public override string ToString()
    // {
    //     return Name + category + moveStat.maximum + moveType + PP;
    // }
}

[System.Serializable]
public class Stat
{
    public float minimum;
    public float maximum;
}

public enum MoveType
{
    Physical,
    Special,
    Status
}
