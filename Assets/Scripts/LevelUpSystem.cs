using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpSystem
{
    private int xp;
    private int xpToNextLevel;
    private int level;
    private int maxLevel;

    public LevelUpSystem(int maxLevel, int xpToNextLevel){
        this.xp = 0;
        this.xpToNextLevel = xpToNextLevel;
        this.level = 0;
        this.maxLevel = maxLevel;
    }

    public int XP {
        get {return xp;}
        set {
            xp = value;

            // If the value of xp is high enough to level up
            if (xp >= xpToNextLevel) {
                LevelUp();
            }
        }
    }

    public int XPToNextLevel {
        get {return xpToNextLevel;}
        set {xpToNextLevel = value;}
    }

    public int Level {
        get {return level;}
        set {level = value;}
    }

    public int MaxLevel {
        get {return maxLevel;}
        set {maxLevel = value;}
    }

    public void AddXP (int amount) {
        XP += amount;
    }

    private void LevelUp () {
        if(level < maxLevel){
            xp -= xpToNextLevel;
            level++;
            xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * 1.1f);
        }
        else{
            xp = xpToNextLevel;
        }
    }
}
