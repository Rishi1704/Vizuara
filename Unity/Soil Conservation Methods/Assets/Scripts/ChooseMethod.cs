using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseMethod : MonoBehaviour
{
    [SerializeField] GameObject[] models;
    [SerializeField] GameObject[] InfoTexts;
    [SerializeField] Button[] buttons;
    [SerializeField] GameObject ControlText;
    [SerializeField] GameObject MethodList;
    [SerializeField] GameObject ChooseFromList;
    [SerializeField] Color selectedColor;

    public void TerraceFarming()
    {
        GameObject terraceFarming = Instantiate(models[0]);
        terraceFarming.name = "Terrace Farming";
        terraceFarming.tag = "Model";
        terraceFarming.transform.position = new Vector3(0, 0, 0);

        ControlText.SetActive(false);
        MethodList.SetActive(false);
        ChooseFromList.SetActive(true);
        InfoTexts[0].SetActive(true);

        buttons[0].enabled = false;
        buttons[0].GetComponent<Image>().color = selectedColor;
    }

    public void ContourFarming()
    {
        GameObject contourFarming = Instantiate(models[1]);
        contourFarming.name = "Contour Ploughing";
        contourFarming.tag = "Model";
        contourFarming.transform.position = new Vector3(0, 0, 0);

        ControlText.SetActive(false);
        MethodList.SetActive(false);
        ChooseFromList.SetActive(true);
        InfoTexts[1].SetActive(true);

        buttons[1].enabled = false;
        buttons[1].GetComponent<Image>().color = selectedColor;
    }

    public void ShelterBelts()
    {
        GameObject shelterBelts = Instantiate(models[2]);
        shelterBelts.name = "Shelter Belts";
        shelterBelts.tag = "Model";
        shelterBelts.transform.position = new Vector3(0, 0, 0);

        ControlText.SetActive(false);
        MethodList.SetActive(false);
        ChooseFromList.SetActive(true);
        InfoTexts[2].SetActive(true);

        buttons[2].enabled = false;
        buttons[2].GetComponent<Image>().color = selectedColor;
    }
}
