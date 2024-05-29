using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float enemySpeed = 0.1f;
    public int attackDistance;
    public int attackDamage;
    public float attackCooldown;
    public int enemyLife;
    public int bulletSpeed; //solamente el enemigo tipo A dispara.
    public int currencyDrop;

    //creo que tendríamos que agregar de variable el path en el que aparece (izquierda, derecha, abajo, arriba) y en base a eso le agregamos la velocidad al rigid body)
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * enemySpeed;
    }

    private void OnTriggerEnter2D(Collider2D bullet)
    {
      //enemyLife -= bullet.damage //calculo que en algo así vamos a storear la cantidad de daño que hace cada bala.  
    }

    private void OnCollisionStay2D(Collision2D other)
    {
      if (other.gameObject.tag == "Player")
        {
          //  other.gameObject.GetComponent<UnitHealth>().UpdateHealth(-attackDamage);//calculo que vamos a usar
                                                                                    //funciones de ese estilo en la torreta para recibir el ataque.
                                                                                    //Usé este tutorial https://youtu.be/VOdYtqV_meo?t=366
            attackCooldown = 0f; 
        } else
        {
            attackCooldown += Time.deltaTime; 
        }
    }
}

