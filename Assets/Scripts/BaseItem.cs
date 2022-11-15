using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface I_Consumable{
    void Consume(IActor target);
}

public interface I_Weapon{
    float MinDamage {get; set;}
    float MaxDamage {get; set;}

    string SkillName {get; set;}
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

    public BaseItem(string name, string desc, int value){
        this.name = name;
        this.desc = desc;
        this.value = value;
    }
}

public abstract class Potion : BaseItem, I_Consumable {

    public Potion(string name, string desc, int value) : base(name, desc, value){

    }
    public abstract void Consume(IActor target);
}

public abstract class Weapon : BaseItem, I_Weapon {
    private float minDamage;
    private float maxDamage;
    private string skillName;

    public Weapon(string name, string desc, string skillName, float minDamage, float maxDamage, int value) : base(name, desc, value){
        this.minDamage = minDamage;
        this.maxDamage = maxDamage;
        this.skillName = skillName;
    }

    public float MinDamage {
        get {return minDamage;}
        set {minDamage = value;}
    }

    public float MaxDamage {
        get {return maxDamage;}
        set {maxDamage = value;}
    }

    public string SkillName {
        get {return skillName;}
        set {skillName = value;}
    }
}

public class InventoryItem {
    BaseItem item;
    int quantity;

    public InventoryItem(BaseItem item, int quantity) {
        this.item = item;
        this.quantity = quantity;
    }

    public BaseItem Item {
        get {return item;}
    }

    public int Quantity {
        get {return quantity;}
        set {quantity = value;}
    }
}

public class Inventory {
    private List<InventoryItem> items;

    public Inventory() {
        items = new List<InventoryItem>();
    }

    public bool Contains(BaseItem item) {
        return items.Any(member => member.Item.Name == item.Name);
    }

    public void AddItem(BaseItem item, int amount) {
        InventoryItem target = items.SingleOrDefault(member => member.Item.Name == item.Name);
        if(target == null) {
            items.Add(new InventoryItem(item, amount));
        }
        else {
            target.Quantity += amount;
        }
    }

    public void TakeItem(BaseItem item, int amount) {
        InventoryItem target = items.SingleOrDefault(member => member.Item.Name == item.Name);
        if (target != null) {
            if (target.Quantity - amount <= 0) {
                items.Remove(target);
            }
            else{
                target.Quantity -= amount;
            }
        }
    }
}