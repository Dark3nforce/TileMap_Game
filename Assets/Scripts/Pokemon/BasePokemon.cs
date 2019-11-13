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
    private int maxHP;
    public Stat AttackStat;
    public Stat DefenceStat;

    public PokemonStats pokemonStats;

    public bool canEvolve;
    public PokemonEvolution evolveTo;


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
    Flying,
    Ground,
    Rock,
    Steel,
    Fire,
    Water,
    Grass,
    Ice,
    Electric,
    Psychic,
    Dark,
    Dragon,
    Fighting,
    Normal
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
