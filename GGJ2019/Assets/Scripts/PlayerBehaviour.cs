using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed;

    private int score = 0;

    public int lives = 3;

    public RectTransform hearts;
    public GameObject scoreGO;
    public TextMeshProUGUI scoreTxt; 

    public bool die = false;

    public bool cantDie = false;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        scoreTxt = scoreGO.GetComponent<TextMeshProUGUI>();

        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float transHorz = Input.GetAxis("Horizontal") * speed;
        float transVert = Input.GetAxis("Vertical") * speed;

        transHorz *= Time.deltaTime;
        transVert *= Time.deltaTime;

        transform.Translate(transHorz, transVert, 0);
    }

    public void Hurt()
    {
        if (cantDie)
            return;

        Debug.Log("Hurt");
        lives--;
        anim.SetTrigger("die");

        hearts.sizeDelta = new Vector2(64*lives, 64); 

        if (lives == 0)
        {
            GameOver();
        }

        
        cantDie = true;
        StartCoroutine (StartInvince());
    }

    IEnumerator StartInvince()
    {
        yield return new WaitForSeconds(2);
        cantDie = false;
        anim.SetTrigger("respawn");
    }

    public void Win()
    {
        score++;

        scoreTxt.SetText("{0}", score);

    }

    void GameOver()
    {
        Debug.Log("LOST");
    }
}
