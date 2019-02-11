using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YinYangBullet : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float movSpeed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private GameObject desEffect;
    public GameObject[] bulletSoundEffects;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance != null)
        {
            movSpeed = GameManager.instance.bulletSpeed;
        }
        rb2D = GetComponent<Rigidbody2D>();
        
      
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        rb2D.velocity = Vector2.right * movSpeed*Time.fixedDeltaTime;
        transform.Rotate(Vector3.forward*rotationSpeed*Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Enemy")
        {
            Destroy(gameObject);
            Instantiate(desEffect,transform.position,Quaternion.identity);
            GameManager.instance.SoundPlayer(bulletSoundEffects);
            GameManager.instance.scorePoint++;
        }
    }
}
