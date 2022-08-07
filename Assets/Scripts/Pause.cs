using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public float timer; 
    public bool ispuse;
    public bool guipuse;
    [SerializeField] private Text killsText;
    [SerializeField] private Text pauseText;
    // Start is called before the first frame update
    void Start()
    {
        ispuse = true;
        pauseText.text = "Press Enter to play";
        killsText.text = "Kills: 0";
    }

    // Update is called once per frame
    void Update()
    {
        killsText.text = "KIlls: " + EnemyHP.getKills();
        Time.timeScale = timer; 
        if (Input.GetKeyDown(KeyCode.Escape) && ispuse == false) 
        {
            ispuse = true; 
        } else if (Input.GetKeyDown(KeyCode.Return) && ispuse == true)
        { 
            ispuse = false;
        }

        if (ispuse == true) 
        {
            timer = 0; guipuse = true;
            pauseText.text = "Press Enter to play";
        }

        else if (ispuse == false)
        {
            timer = 1f; guipuse = false;
            pauseText.text = "";
        }


    }
}
