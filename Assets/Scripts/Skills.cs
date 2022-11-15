using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Skill {
    private string name;
    private LevelUpSystem leveler;

    public Skill(string name) {
        this.name = name;
        this.leveler = new LevelUpSystem(100, 100);
    }

    public string Name {
        get {return name;}
    }

    public int Level {
        get {return leveler.Level;}
    }

    public int CurrentXp {
        get {return leveler.XP;}
    }

    public int XpToNextLevel {
        get {return leveler.XPToNextLevel;}
    }

    public void GiveXp(int amount){
        leveler.AddXP(amount);
    }
}

public class Skills
{
    private List<Skill> skills;

    public Skills() {
        skills = new List<Skill>();
    }

    public Skill this[string name]{
        get {return skills.SingleOrDefault(skill => skill.Name == name);}
    }

    public void AddSkill(string name) {
        if(this[name] == null){
            skills.Add(new Skill(name));
        }
    }
}
