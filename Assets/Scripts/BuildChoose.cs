using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildChoose : MonoBehaviour
{
    [SerializeField] GameObject[] Builds;
    [SerializeField] GameObject[] Slots;

    [SerializeField] GameObject[] BuildPreviews;

    public Sprite SelectedSlot, EmptySlot;


    void Update()
    {
        buildChoose(); 
    }

    void buildChoose()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            for (int i = 0; i < BuildPreviews.Length; i++)
            {
                BuildPreviews[i].SetActive(false);
            }

            Builds[0].SetActive(true);
            Builds[1].SetActive(false);
            Builds[2].SetActive(false);

            SetIcon(0);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            for (int i = 0; i < BuildPreviews.Length; i++)
            {
                BuildPreviews[i].SetActive(false);
            }

            Builds[0].SetActive(false);
            Builds[1].SetActive(true);
            Builds[2].SetActive(false);

            SetIcon(1);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            for (int i = 0; i < BuildPreviews.Length; i++)
            {
                BuildPreviews[i].SetActive(false);
            }

            Builds[0].SetActive(false);
            Builds[1].SetActive(false);
            Builds[2].SetActive(true);

            SetIcon(2);

        }
    }

    void SetIcon(int SlotNumber)
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            Slots[i].GetComponent<Image>().sprite = EmptySlot;     
        }

        Slots[SlotNumber].GetComponent<Image>().sprite = SelectedSlot;
    }
}
