using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject Information;
    [SerializeField] GameObject SettingTab;
    [SerializeField] GameObject ControlText;
    [SerializeField] GameObject StartFireText;
    [SerializeField] GameObject FireParticles;
    [SerializeField] GameObject CamControler;
    [SerializeField] AudioSource Click;

    public void RestartGame()
    {
        Click.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowInformation()
    {
        Click.Play();
        if(Information.activeSelf)
            Information.SetActive(false);
        else
            Information.SetActive(true);
    }

    public void CloseInformation()
    {
        Click.Play();
        Information.SetActive(false);
    }

    public void ShowSettingTab()
    {
        Click.Play();
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
        Click.Play();
        SettingTab.SetActive(false);
        ControlText.SetActive(true);
    }

    public void ActivateFire()
    {
        Click.Play();
        StartFireText.SetActive(false);
        FireParticles.SetActive(true);
        CamControler.SetActive(true);
    }
}
