﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuScript : MonoBehaviour
{
    public int selected = 0; // index of selected button (0 start, 1 settings)

    public float coolDown = 0.3f; // separate the movements of the joystick
    public GameObject play;
    public GameObject settings;

    GameObject myEventSystem;
    void Start(){
        play = GameObject.Find("Play");
        settings = GameObject.Find("Settings");
        myEventSystem = GameObject.Find("EventSystem");
    }
    void Update(){
        // load the level select menu if any button is pressed
        if(MinigameInputHelper.IsButton1Up(1)) //|| 
            // MinigameInputHelper.IsButton1Up(2) || 
            // MinigameInputHelper.IsButton2Up(1) || 
            // MinigameInputHelper.IsButton2Up(2)
            {
                if(selected == 0) {
                    LoadLevelMenu();
                }
                else if (selected == 1) {
                    LoadSettings();
                }
        }
        if(coolDown <= 0){
            float joystick1 = MinigameInputHelper.GetVerticalAxis(1);
            float joystick2 = MinigameInputHelper.GetVerticalAxis(2);

    
            
            if(((joystick1 > 0 || joystick2 > 0 ||
                joystick1 < 0 || joystick2 < 0) && selected == 0))
            {
                    selected = 1;
                    coolDown = 0.3f;
            } else if(((joystick1 > 0 || joystick2 > 0 ||
                        joystick1 < 0 || joystick2 < 0) && selected == 1))
            {
                selected = 0;
                coolDown = 0.3f;
            }
        }

        

        if(selected == 0)
        {
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
            play.GetComponent<Button>().Select();
        } else if(selected == 1)
        {
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
            settings.GetComponent<Button>().Select();
        }

        if(coolDown > 0){
            coolDown -= Time.deltaTime;
        }


    }
    public void LoadLevelMenu()
    {

     SceneManager.LoadScene("Level_Select");
        
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }

}
