using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public bool jump = false;
    public bool slide = false;
    public Animator anim;
    public GameObject trigger;
    public float score = 0;
    
    public bool boost = false;
    public Rigidbody rbody;
    public CapsuleCollider myCollider;
    public bool death = false;
    public Image gameOver;
    public Text scoreText;
    public float lastScore;
    public Text bestScoreText;
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        myCollider = GetComponent<CapsuleCollider>();
        lastScore = PlayerPrefs.GetFloat("MyScore");
    }

    // Update is called once per frame
    void Update()
    {   
        scoreText.text = score.ToString();

        if (score > lastScore)
        {
            bestScoreText.text ="Best Score: "+ score.ToString();
        }
        else
        {
            bestScoreText.text ="Your Score: "+ score.ToString();
        }


        if (death == true)
        {
            gameOver.gameObject.SetActive(true);
        }


        if (score >= 18 && death != true)
        {
            transform.Translate(0, 0, 0.2f);
        }
        else if(score >=36 && death != true)
        {
            transform.Translate(0, 0, 0.3f);
        }
        else if (score >= 54 && death != true)
        {
            transform.Translate(0, 0, 0.4f);
        }
        else if (score >= 72 && death != true)
        {
            transform.Translate(0, 0, 0.5f);
        }
        else if (score >= 90 && death != true)
        {
            transform.Translate(0, 0, 0.6f);
        }
        else if(death == true)
        {
            transform.Translate(0, 0, 0);
        }
        else
        {
            transform.Translate(0, 0, 0.1f);
        }

        if (boost == true)
        {
            transform.Translate(0, 0, 1f);
            myCollider.enabled = false;
            rbody.isKinematic = true;
        } else
        {
            myCollider.enabled = true;
            rbody.isKinematic = false;
        }



        if (Input.GetKey(KeyCode.Space))
        {
            jump = true;
        }
        else
        {
            jump = false;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            slide = true;
        }
        else
        {
            slide = false;
        }


        if (jump == true)
        {
            anim.SetBool("isJump", jump);
            transform.Translate(0, 0.3f, 0.1f);
        }
        else if (jump==false)
        {
            anim.SetBool("isJump", jump);           
        }

        if (slide == true)
        {
            anim.SetBool("isSlide", slide);
            transform.Translate(0, 0, 0.1f);
            myCollider.height = 1f;
        }
        else if (slide == false)
        {
            anim.SetBool("isSlide", slide);
            myCollider.height = 2f;
        }

        trigger = GameObject.FindGameObjectWithTag("Obstacle");

    }

    void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject,0.5f);
            score += 1f;
        }

        if (other.gameObject.tag == "Boost")
        {
            Destroy(other.gameObject);
            StartCoroutine(BoostController());
        }

        if (other.gameObject.tag == "Death")
        {
            death = true;
            if (score > lastScore)
            {
                PlayerPrefs.SetFloat("MyScore",score);
            }
        }
    }

    IEnumerator BoostController()
    {
        boost = true;
        yield return new WaitForSeconds(3);
        boost = false;
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
}
