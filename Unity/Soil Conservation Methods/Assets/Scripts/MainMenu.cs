using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject Information;
    [SerializeField] GameObject SettingTab;
    [SerializeField] GameObject ControlText;
    [SerializeField] GameObject[] InfoTexts;

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowInformation()
    {
        if(Information.activeSelf)
            Information.SetActive(false);
        else
            Information.SetActive(true);
    }

    public void CloseInformation()
    {
        Information.SetActive(false);
    }

    public void ShowSettingTab()
    {
        if(SettingTab.activeSelf)
        {
            SettingTab.SetActive(false);
            ControlText.SetActive(true);
        }
        else
        {
            SettingTab.SetActive(true);
            ControlText.SetActive(false);
        }
    }

    public void CloseSettingTab()
    {
        SettingTab.SetActive(false);
        ControlText.SetActive(true);
    }

    public void ShowDetails()
    {
        GameObject dummy = GameObject.FindWithTag("Model");
        // Debug.Log(dummy.name);
        
        if(dummy == null)
        {
            // Do Nothing
        }
        else if(dummy.name == "Terrace Farming")
        {
            if(InfoTexts[0].activeSelf)
                InfoTexts[0].SetActive(false);
            else
                InfoTexts[0].SetActive(true);
        }

        else if(dummy.name == "Contour Ploughing")
        {
            if(InfoTexts[1].activeSelf)
                InfoTexts[1].SetActive(false);
            else
                InfoTexts[1].SetActive(true);
        }

        else if(dummy.name == "Shelter Belts")
        {
            if(InfoTexts[2].activeSelf)
                InfoTexts[2].SetActive(false);
            else
                InfoTexts[2].SetActive(true);
        }
    }
}
