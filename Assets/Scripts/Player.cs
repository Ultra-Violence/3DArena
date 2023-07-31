using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health;
    private int _maxHealth;

    private int _power;
    private int _maxPower;

    public int health => _health;
    public int maxHealth => _maxHealth;

    public int power => _power;
    public int maxPower => _maxPower;

    public int enemyKilled;
    public GameObject menu;

    private void Awake() {
        _health = 100;
        _maxHealth = 100;

        _power = 50;
        _maxPower = 100;
    }

    private void Update() {
        if(health > maxHealth){
            _health = _maxHealth;
        }
        else if(power > maxPower){
            _power = _maxPower;
        }
        else if(power < 0){
            _power = 0;
        }

        if(health <= 0){
            menu.SetActive(true);
        }
    }

    public void GetPower(int killPower){
        _power += killPower;
    }

    public void LossPower(int lossPower){
        _power -= lossPower;
    }

    public void GetHeal(int heal){
        _health += heal;
    }

    public void Damage(int damage){
        _health -= damage;
    }

    public void GetKill(){
        enemyKilled++;
    }

}
