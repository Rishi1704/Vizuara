using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject infoText;
    [SerializeField] private GameObject startingInstruction;
    [SerializeField] private GameObject[] objectNames;
    [SerializeField] private AudioSource click;
    [SerializeField] private Animator animator;
    [SerializeField] private int noOfObjects;

    private void Start()
    {
        startingInstruction.SetActive(true);
        infoText.SetActive(false);
    }
    
    public void RestartGame()
    {
        click.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowInfo()
    {
        click.Play();
        if(infoText.activeSelf)
            infoText.SetActive(false);
        else
            infoText.SetActive(true);
    }

    public void TriggerCloseAnimation()
    {
        click.Play();
        animator.SetTrigger("Close");
    }

    public void ShowVisibility()
    {
        click.Play();
        for(int i = 0; i < noOfObjects; i++)
        {
            if(objectNames[i].activeSelf)
                objectNames[i].SetActive(false);
            else
                objectNames[i].SetActive(true);
        }
    }
}
