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
    public GameObject[] volumeSlider = new GameObject[3];
    public int blnorpble = 0;
    public GameObject[] calibrator = new GameObject[3];
    GameObject eventCap;

    public int masterVolume = 60;
    public static int volume = 60;
    public float calibration = 0.0f;
    public static float calibra = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        applyButtn = GameObject.Find("Apply");    
        returnButtn = GameObject.Find("Return");
        volumeSlider[0] = null;
        volumeSlider[1] = null;
        volumeSlider[2] = null;
   
        volumeSlider[0] = GameObject.Find("volumeSlider0");    
        volumeSlider[1] = GameObject.Find("volumeSliderNote");    
        volumeSlider[2] = GameObject.Find("volumeSlider1");
        print(volumeSlider);
        calibrator[0] = GameObject.Find("calibrator0");
        calibrator[1] = GameObject.Find("calibratorNote");
        calibrator[2] = GameObject.Find("calibrator1");
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
            joystickx2 = MinigameInputHelper.GetHorizontalAxis(2);
            joysticky1 = MinigameInputHelper.GetVerticalAxis(1);
            joysticky2 = MinigameInputHelper.GetVerticalAxis(2);

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
                volumeSlider[1].GetComponent<Button>().Select();
            }
            else if (selected == 1)
            {
                calibrator[1].GetComponent<Button>().Select();
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
                    volumeSlider[0].GetComponent<Button>().Select();
                }
                else
                {
                    volumeSlider[2].GetComponent<Button>().Select();
                }
            }
            else
            {
                if (selected == 0)
                {
                    calibrator[0].GetComponent<Button>().Select();
                }
                else
                {
                    calibrator[2].GetComponent<Button>().Select();
                }
            }
        }

    }


    void returnToMainMenu()
    {
        SceneManager.LoadScene("Menu_Scene");
    }
}
