using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
public int selected = 0; // index of selected button (0 start, 1 settings)

    public float coolDown = 0.3f; // separate the movements of the joystick
    public GameObject play;
    public GameObject settings;

    GameObject myEventSystem;

    public GameObject[] buttons = new GameObject[4];
    void Start(){
        buttons[0] = GameObject.Find("Beginner");
        buttons[1] = GameObject.Find("Intermediate");
        buttons[2] = GameObject.Find("Expert");
        buttons[3] = GameObject.Find("Back");
        myEventSystem = GameObject.Find("EventSystem");

    }
    void Update(){
        // load the level select menu if any button is pressed
        if(MinigameInputHelper.IsButton1Down(1) || 
            MinigameInputHelper.IsButton1Down(2) || 
            MinigameInputHelper.IsButton2Down(1) || 
            MinigameInputHelper.IsButton2Down(2)){
                if(selected == 3){
                    LoadMainMenu();
                } else {
                    PlayGame();
                }
        }


        if(coolDown <= 0){

            // are one or more of the joysticks being pushed
            float joystick1 = MinigameInputHelper.GetVerticalAxis(1);
            float joystick2 = MinigameInputHelper.GetVerticalAxis(2);

            bool joystick_up = joystick1 > 0 || joystick2 > 0;
            bool joystick_down = joystick1 < 0 || joystick2 < 0;

            // select the next item based on up or down, wrap if first or last
            if(selected == 0 && joystick_up)
            {
                selected = 3;
                coolDown = 0.3f;
            } else if(selected == 3 && joystick_down)
            {
                selected = 0;
                coolDown = 0.3f;
            } else if(joystick_down)
            {
                selected++;
                coolDown = 0.3f;
            } else if(joystick_up)
            {
                selected--;
                coolDown = 0.3f;
            }

            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
            buttons[selected].GetComponent<Button>().Select();
            
         
        } else if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }


    }

    public void LoadMainMenu()
    {
     SceneManager.LoadScene("Menu_Scene");
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Scene_Template");
    }
}
