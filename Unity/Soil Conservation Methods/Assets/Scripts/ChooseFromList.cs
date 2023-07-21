using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseFromList : MonoBehaviour
{
    [SerializeField] GameObject[] models;
    [SerializeField] GameObject[] InfoTexts;
    [SerializeField] Button[] buttons;
    [SerializeField] Color defaultColor;
    [SerializeField] Color selectedColor;

    public void terraceFarming()
    {
        Destroy(GameObject.FindWithTag("Model"));
        GameObject terraceFarming = Instantiate(models[0]);
        terraceFarming.name = "Terrace Farming";
        terraceFarming.tag = "Model";
        terraceFarming.transform.position = new Vector3(0, 0, 0);

        buttons[0].enabled = false;
        buttons[1].enabled = true;
        buttons[2].enabled = true;

        buttons[0].GetComponent<Image>().color = selectedColor;
        buttons[1].GetComponent<Image>().color = defaultColor;
        buttons[2].GetComponent<Image>().color = defaultColor;

        InfoTexts[0].SetActive(true);
        InfoTexts[1].SetActive(false);
        InfoTexts[2].SetActive(false);
    }

    public void contourFarming()
    {
        Destroy(GameObject.FindWithTag("Model"));
        GameObject contourFarming = Instantiate(models[1]);
        contourFarming.name = "Contour Ploughing";
        contourFarming.tag = "Model";
        contourFarming.transform.position = new Vector3(0, 0, 0);

        buttons[0].enabled = true;
        buttons[1].enabled = false;
        buttons[2].enabled = true;

        buttons[0].GetComponent<Image>().color = defaultColor;
        buttons[1].GetComponent<Image>().color = selectedColor;
        buttons[2].GetComponent<Image>().color = defaultColor;

        InfoTexts[0].SetActive(false);
        InfoTexts[1].SetActive(true);
        InfoTexts[2].SetActive(false);
    }

    public void ShelterBelts()
    {
        Destroy(GameObject.FindWithTag("Model"));
        GameObject shelterBelts = Instantiate(models[2]);
        shelterBelts.name = "Shelter Belts";
        shelterBelts.tag = "Model";
        shelterBelts.transform.position = new Vector3(0, 0, 0);

        buttons[0].enabled = true;
        buttons[1].enabled = true;
        buttons[2].enabled = false;
        
        buttons[0].GetComponent<Image>().color = defaultColor;
        buttons[1].GetComponent<Image>().color = defaultColor;
        buttons[2].GetComponent<Image>().color = selectedColor;

        InfoTexts[0].SetActive(false);
        InfoTexts[1].SetActive(false);
        InfoTexts[2].SetActive(true);
    }
}
