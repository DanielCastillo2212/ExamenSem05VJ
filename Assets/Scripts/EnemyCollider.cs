using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    public bool enemyColision = false;

    public bool enemyDead(){
        if(enemyColision){
            return true;
        }
        return false;
    }

    public void validationEnemy(){
        enemyColision = false;
    }

    public void OnCollisionEnter2D(Collision2D other){
        enemyColision = true;
    }
}
