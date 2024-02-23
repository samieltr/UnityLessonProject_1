using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private GameManager gameManager;
    public int hedefPuan;
    public ParticleSystem patlamaParcacigi;
    private AudioSource playerSound; //Ses Efektleri için ses kaynaðý oluþturduk.
    public AudioClip targetSesleri;
    public AudioClip gameOverSes;
    // Start is called before the first frame update
    void Start()
    {
        float tork = Random.Range(-10, 10); //rastgele ne tarafa döneceðini ayarladýk
        float speed = Random.Range(10, 15); // rastgele uygulanan kuvvetin hýzýný ayarladýk

        targetRB = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerSound = Camera.main.GetComponent<AudioSource>(); //Ana kamerada ki ses kaynaðýný kullandýk
        targetRB.AddForce(Vector3.up * speed, ForceMode.Impulse);  //yukarý doðru kuvvet uyguluyoruz
        targetRB.AddTorque(tork, tork, tork); //objemizin dönmesi için tork ekledik x,y,z

        transform.position = randomPozisyon(); //Pozisyonunu ayarladýk
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) //sensor nesnesine deðince yok et
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("bad"))
        {
            gameManager.gameOver();
            playerSound.PlayOneShot(gameOverSes, 2.0f);
        }
       
    }
    public void DestroyTarget()
    {
        if (gameManager.oyunAktifmi == true)
        {
            Destroy(gameObject);
            Instantiate(patlamaParcacigi, transform.position, patlamaParcacigi.transform.rotation);
            gameManager.SkorGuncelle(hedefPuan);
            playerSound.PlayOneShot(targetSesleri, 2.0f);
        }
    }

   /* private void OnMouseDown()
    {
     
        if (gameManager.oyunAktifmi == true)
        {
            Destroy(gameObject);
            Instantiate(patlamaParcacigi, transform.position, patlamaParcacigi.transform.rotation);
            gameManager.SkorGuncelle(hedefPuan);
            playerSound.PlayOneShot(targetSesleri, 2.0f);
        }
    } */

  

    Vector3 randomPozisyon () //Rastgele Pozisyon Belirleme
    {
        float startPosx = Random.Range(-4, 4), startPosy = -2, startPosz = 0;
        return new Vector3(startPosx, startPosy, startPosz); //baþlangýç pozisyonunu ayarladýk
    }
}
