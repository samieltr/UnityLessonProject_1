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
    private AudioSource playerSound; //Ses Efektleri i�in ses kayna�� olu�turduk.
    public AudioClip targetSesleri;
    public AudioClip gameOverSes;
    // Start is called before the first frame update
    void Start()
    {
        float tork = Random.Range(-10, 10); //rastgele ne tarafa d�nece�ini ayarlad�k
        float speed = Random.Range(10, 15); // rastgele uygulanan kuvvetin h�z�n� ayarlad�k

        targetRB = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerSound = Camera.main.GetComponent<AudioSource>(); //Ana kamerada ki ses kayna��n� kulland�k
        targetRB.AddForce(Vector3.up * speed, ForceMode.Impulse);  //yukar� do�ru kuvvet uyguluyoruz
        targetRB.AddTorque(tork, tork, tork); //objemizin d�nmesi i�in tork ekledik x,y,z

        transform.position = randomPozisyon(); //Pozisyonunu ayarlad�k
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) //sensor nesnesine de�ince yok et
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
        return new Vector3(startPosx, startPosy, startPosz); //ba�lang�� pozisyonunu ayarlad�k
    }
}
