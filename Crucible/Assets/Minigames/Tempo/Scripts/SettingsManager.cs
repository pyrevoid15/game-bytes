using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public int selected = 0;
    public string side = "left";
    public float cooldown = 0.28f;
    public GameObject applyButtn;
    public GameObject returnButtn;
    public GameObject[] volumeSliderTool = new GameObject[3];
    public int blnorpble = 0;
    public GameObject[] calibratorTool = new GameObject[3];
    public GameObject eventCap;

    public int masterVolume = 60;
    public static int volume = 60;
    public float calibration = 0.0f;
    public static float calibra = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        applyButtn = GameObject.Find("Apply");    
        returnButtn = GameObject.Find("Return");
        volumeSliderTool[0] = null;
        volumeSliderTool[1] = null;
        volumeSliderTool[2] = null;
   
        volumeSliderTool[0] = GameObject.Find("volumeSlider0");    
        volumeSliderTool[1] = GameObject.Find("volumeSliderNote");    
        volumeSliderTool[2] = GameObject.Find("volumeSlider1");
        print(volumeSliderTool);
        calibratorTool[0] = GameObject.Find("calibrator0");
        calibratorTool[1] = GameObject.Find("calibratorNote");
        calibratorTool[2] = GameObject.Find("calibrator1");
        eventCap = GameObject.Find("EventSystem");
    }

    // Update is called once per frame
    void Update()
    {
        if (MinigameInputHelper.IsButton1Down(1))
        {
            if (selected == 0)
            {
                if (side == "left")
                {
                    calibration -= (calibration <= 0 ? 0.0f : 0.05f);
                }
                else if (side == "right")
                {
                    calibration += (calibration <= 1 ? 0.05f : 0.0f);
                }
                
            }
            else if (selected == 1)
            {
                if (side == "left")
                {
                    masterVolume -= (masterVolume <= 0 ? 0 : 1);
                }
                else if (side == "right")
                {
                    masterVolume += (masterVolume <= 100 ? 1 : 0);
                }
            }
            else if (selected == 2)
            {
                calibra = calibration;
                volume = masterVolume;
            }
            else if (selected == 3)
            {
                returnToMainMenu();
            }
        }

        float joystickx1, joystickx2;
        float joysticky1, joysticky2;
        bool sided = false;

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            joystickx1 = MinigameInputHelper.GetHorizontalAxis(1);
            joystickx2 = 0;
            joysticky1 = MinigameInputHelper.GetVerticalAxis(1);
            joysticky2 = 0;

            if (joysticky1 > 0 || joysticky2 > 0) //scroll up
            {
                selected = (selected + 1) % 4;
                cooldown = 0.28f;
            }
            else if (joysticky1 < 0 || joysticky2 < 0) //scroll down
            {
                selected = (selected - 1 + 4) % 4;
                cooldown = 0.28f;
            }

            if (selected < 2) {
                if (joystickx1 > 0 || joystickx2 > 0) //scroll up
                {
                    side = "left";
                    sided = true;
                    cooldown = 0.2f;
                    if (selected == 0) masterVolume -= (masterVolume <= 0 ? 0 : 1);
                    else calibration -= (calibration <= 0 ? 0.0f : 0.05f);
                }
                else if (joystickx1 < 0 || joystickx2 < 0) //scroll down
                {
                    side = "right";
                    sided = true;
                    cooldown = 0.2f;
                    if (selected == 0) masterVolume += (masterVolume <= 100 ? 1 : 0);
                    else calibration += (calibration <= 1 ? 0.05f : 0.0f);
                }
            }
        }

        //eventCap.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        if (!sided)
        {
            if (selected == 0)
            {
                volumeSliderTool[1].GetComponent<Button>().Select();
            }
            else if (selected == 1)
            {
                calibratorTool[1].GetComponent<Button>().Select();
            }
            else if (selected == 2)
            {
                applyButtn.GetComponent<Button>().Select();
            }
            else
            {
                returnButtn.GetComponent<Button>().Select();
            }
        }
        else
        {
            if (side == "left")
            {
                if (selected == 0)
                {
                    volumeSliderTool[0].GetComponent<Button>().Select();
                }
                else
                {
                    volumeSliderTool[2].GetComponent<Button>().Select();
                }
            }
            else
            {
                if (selected == 0)
                {
                    calibratorTool[0].GetComponent<Button>().Select();
                }
                else
                {
                    calibratorTool[2].GetComponent<Button>().Select();
                }
            }
        }

    }


    void returnToMainMenu()
    {
        SceneManager.LoadScene("Menu_Scene");
    }
}
