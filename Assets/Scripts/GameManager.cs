using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public Button restartButton;
    public GameObject titleScreen;
    private int score;
    private float spawnSuresi = 1.5f;
    public bool oyunAktifmi;

    // Start is called before the first frame update
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator spawnGenerator()
    {
        while (oyunAktifmi==true)
        {
            yield return new WaitForSeconds(spawnSuresi); //kaç saniyede bir spawnlanacak
            int index = Random.Range(0, targets.Count); //targets listesinde rastgele seçim yapýyor
            Instantiate(targets[index]); //seçileni spawnlýyor
        }
    }

    public void SkorGuncelle(int skorEkle)
    {
        score += skorEkle; //score = score + skorEkle 
        scoreText.text = "Score : " + score;
    }

    public void gameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        oyunAktifmi = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int zorluk)
    {
        titleScreen.SetActive(false);
        spawnSuresi /= zorluk;
        oyunAktifmi = true;
        score = 0;

        StartCoroutine(spawnGenerator());
        SkorGuncelle(0);
    }

  
}
