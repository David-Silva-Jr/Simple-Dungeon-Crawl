using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_Consumable{
    void Consume(IActor target);
}

public interface I_Weapon{
    float GetDamage();
}

public abstract class BaseItem
{
    string name;
    string desc;
    int value;
    int stackSize;

    public string Name{
        get {return name;}
        set {name = value;}
    }

    public string Description{
        get {return desc;}
        set {desc = value;}
    }

    public int Value{
        get {return value;}
        set {this.value = value;}
    }

    public int StackSize{
        get {return stackSize;}
        set {stackSize = value;}
    }

    public BaseItem(string name, string desc, int value, int stackSize){
        this.name = name;
        this.desc = desc;
        this.value = value;
        this.stackSize = stackSize;
    }
}

public abstract class Potion : BaseItem, I_Consumable {

    public Potion(string name, string desc, int value, int stackSize) : base(name, desc, value, stackSize){

    }
    public abstract void Consume(IActor target);
}

public abstract class Weapon : BaseItem, I_Weapon {
    public Weapon(string name, string desc, int value, int stackSize) : base(name, desc, value, stackSize){

    }
    public abstract float GetDamage();
}

public class Sword : Weapon {
    float maxDamage;
    float minDamage;
    
    public Sword(string name, string desc, int value, int stackSize, float minDamage, float maxDamage) : base(name, desc, value, stackSize){
        this.minDamage = minDamage;
        this.maxDamage = maxDamage;
    }

    public override float GetDamage(){
        return Random.Range(minDamage, maxDamage);
    }
}

public class NormalSword : Weapon {
    float mean;
    float dev;
    public NormalSword(string name, string desc, int value, int stackSize, float mean, float dev) : base(name, desc, value, stackSize){
        this.mean = mean;
        this.dev = dev;
    }

    public override float GetDamage()
    {
        return mean;
    }
}