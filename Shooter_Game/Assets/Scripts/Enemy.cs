using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


[Serializable]
public class DieZoneArea
{
    public GameObject[] balanceSoundEffects;
    public Color[] balanceChangeColor;
}

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField]
    private float movSpeed;
    [SerializeField]
    private GameObject desEffect;
    public GameObject[] enemyDeathEffects;

    public DieZoneArea[] dieAreaEffect;
    private GameObject DieAreaObject;



    // Start is called before the first frame update
    void Start()
    {
        DieAreaObject = GameObject.FindGameObjectWithTag("DieZone");
        if (GameManager.instance!=null)
        {
            movSpeed = GameManager.instance.enemySpeed;
        }    
        rb2D = GetComponent<Rigidbody2D>();      
    }

    private void Update()
    {

      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2D.velocity = Vector2.left * movSpeed * Time.fixedDeltaTime;        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Bullet")
        {
            Destroy(gameObject);
            Instantiate(desEffect,transform.position,Quaternion.identity);
            GameManager.instance.SoundPlayer(enemyDeathEffects);
        }

        if (other.tag == "DieZone")
        {
            Destroy(gameObject);
            Instantiate(desEffect, transform.position, Quaternion.identity);
            if (GameManager.instance.dieAreaCount < dieAreaEffect.Length) {
                Instantiate(dieAreaEffect[GameManager.instance.dieAreaCount].balanceSoundEffects[Random.Range(0, dieAreaEffect[GameManager.instance.dieAreaCount].balanceSoundEffects.Length)]);
                DieAreaObject.GetComponent<Renderer>().material.color = dieAreaEffect[GameManager.instance.dieAreaCount].balanceChangeColor[0];
                GameManager.instance.dieAreaCount++;
            }
            if (GameManager.instance.dieAreaCount==dieAreaEffect.Length)
            {
                GameManager.instance.GameOver();              
            }
            
        }
    }


}
