using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiffucltyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int zorluk;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager =GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(ZorlukAyarla);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void ZorlukAyarla()
    {
        Debug.Log(button.gameObject.name + " butonuna týklandý");
        gameManager.StartGame(zorluk);
    }
}
