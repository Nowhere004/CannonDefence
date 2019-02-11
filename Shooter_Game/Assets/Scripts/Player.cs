using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    [SerializeField]
    private GameObject yinyangBullet;
    private float vertical;
    private bool isMoving;
    private bool isShooting;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float yMax;
    [SerializeField]
    private int yMin;
    private Animator playerAnim;
    private int spaceCount=0;
    [SerializeField]
    private Transform shotPoint;
    [SerializeField]
    private GameObject moveEffect;
    [SerializeField]
    private GameObject shootEffect;
    public GameObject[] cannonMoveEffects;
    public GameObject[] cannonShootEffects;

    // Start is called before the first frame update
    void Start()
    {
  
        targetPos = transform.position;
        playerAnim = GetComponent<Animator>();
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    private void FixedUpdate()
    {
        ShootBullet();
        StartCoroutine(Move());
    }
    IEnumerator Move()
    {
        
        transform.position = Vector2.MoveTowards(transform.position,targetPos,speed*Time.fixedDeltaTime);
        if (!isShooting && Input.GetKeyDown(KeyCode.W) && (transform.position.y<yMax) && transform.position.y!=4f)
        {
            Instantiate(moveEffect,transform.position,Quaternion.identity);
            GameManager.instance.SoundPlayer(cannonMoveEffects);
            isMoving = true;
          targetPos=transform.position = new Vector2(transform.position.x,transform.position.y+2);
            yield return new WaitForSeconds(1f);
            isMoving = false;
        }
        if (!isShooting && Input.GetKeyDown(KeyCode.S) && (transform.position.y > yMin) && transform.position.y != -4f)
        {
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            GameManager.instance.SoundPlayer(cannonMoveEffects);
            isMoving = true;
            targetPos = transform.position = new Vector2(transform.position.x, transform.position.y - 2);
            yield return new WaitForSeconds(1f);
            isMoving = false;
        }

    }

    private void ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving && spaceCount==0)
        {
            isShooting = true;
            playerAnim.SetTrigger("shootCannon");
            spaceCount++;
            Instantiate(yinyangBullet,shotPoint.position,Quaternion.identity);
            GameManager.instance.SoundPlayer(cannonShootEffects);
            Instantiate(shootEffect, shotPoint.position, Quaternion.identity);
        }
    }

    public void EnableMovment()
    {
        isShooting = false;
        spaceCount = 0;
    }


}
