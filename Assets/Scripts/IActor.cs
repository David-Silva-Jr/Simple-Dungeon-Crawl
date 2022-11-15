using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActor
{
    float MoveSpeed {get; set;}
    float TurnSpeed {get; set;}
    float MaxHp {get; set;}
    float Hp {get; set;}

    string ActorName {get; set;}
}

public abstract class BaseActor : IActor {
    private float moveSpeed;
    private float turnSpeed;
    private float maxHp;
    private float hp;
    private string name;

    public BaseActor(float moveSpeed, float turnSpeed, float maxHp, float hp, string name) {
        this.moveSpeed = moveSpeed;
        this.turnSpeed = turnSpeed;
        this.maxHp = maxHp;
        this.hp = hp;
        this.name = name;
    }

    public float MoveSpeed {
        get {return moveSpeed;}
        set {moveSpeed = value;}
    }

    public float TurnSpeed {
        get {return turnSpeed;}
        set {turnSpeed = value;}
    }

    public float MaxHp {
        get {return maxHp;}
        set {maxHp = value;}
    }

    public float Hp {
        get {return hp;}
        set {hp = value;}
    }

    public string ActorName {
        get {return name;}
        set {name = value;}
    }
}