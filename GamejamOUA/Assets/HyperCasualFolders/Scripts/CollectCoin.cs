using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectCoin : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;
    public TextMeshProUGUI UnityText;
 
    public PlayerController PlayerController;
    public Slider g�revDurumu;
    public Animator PlayerAnim;
    public GameObject Player;
    public Transform _playerTransform;
    public AudioSource winMusic;
    public AudioSource coinSound;

    private void Start()
    {
        PlayerAnim = Player.GetComponentInChildren<Animator>();
        winMusic = GetComponent<AudioSource>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("true"))
        {
            winMusic.Play();
            score += 5;
            CoinText.text = "Ayl�k G�rev:" + "%" + score.ToString();
            g�revDurumu.value = score;
        }




        if (other.CompareTag("finish"))
        {
            winMusic.Play();
            score = 100;
            CoinText.text = "Ayl�k G�rev:" + "%" + score.ToString();
            g�revDurumu.value = score;
        }



        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
            winMusic.Play();
            
        }
        else if (other.CompareTag("End"))
        {
            
            PlayerController.runningSpeed = 0;
            transform.Rotate(transform.rotation.x, 180, transform.rotation.z);
            

            if (g�revDurumu.value == 100)
            {
                Debug.Log("you win");
                PlayerAnim.SetBool("win", true);

                
                UnityText.text = "Unity G�revleri: " + "Tamamlandi";
                UnityText.color = Color.green;
              
                winMusic.Play();


            }
            else
            {
                
                Debug.Log("You lose");
                PlayerAnim.SetBool("lose", true);
                UnityText.text = "Unity G�revleri: " + "Tamamlanmadi";
                UnityText.color = Color.red;
                
                
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collison"))
        {
            Debug.Log("De�di");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void AddCoin()
    {   
        if (score <100)
        {
            score++;
        }
        
        CoinText.text = "Ayl�k G�rev:" + "%" + score.ToString();
        g�revDurumu.value = score;
        Debug.Log(g�revDurumu.value);

    }
    

}
