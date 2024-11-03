using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int score = 0;
    public int first_target;
    public int second_target;
    public int third_target;
    public int victory_score;
    public Text score_label;
    public GameObject victory_label;
    public GameObject defeat_label;
    public GameObject first_removable;  
    public GameObject second_removable;
    public GameObject third_removable;

    private string main_scene;
    private bool can_restart = false;

    // Gets the current scene so it can later be reloaded on player death
    // Start is called before the first frame update
    void Start()
    {
        main_scene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        // Will restart the scene if the player has lost 
        if (Input.GetKeyUp(KeyCode.Space) && can_restart == true)
        {
            //print("Restart");
            score = 0;
            SceneManager.LoadScene(main_scene);
        }
        
    }

    // Brings up the defeat label and allows the player to restart
    public void Defeated()
    {
        defeat_label.SetActive(true);
        can_restart = true;
    }

    // Increases the player's score and will remove a section of wall corresponing to the amount of collectibles gathered
    public void IncreaseScore()
    {
        score += 1;
        score_label.text = score.ToString();

        if (score >= first_target)
        {
            first_removable.SetActive(false);
        }
        
        if (score >= second_target)
        {
            second_removable.SetActive(false);
        }
        
        if (score >= third_target)
        {
            third_removable.SetActive(false);
        }
        
        if (score >= victory_score)
        {
            victory_label.SetActive(true);
        }
    }

}
