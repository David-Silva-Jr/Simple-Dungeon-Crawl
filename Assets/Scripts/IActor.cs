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
