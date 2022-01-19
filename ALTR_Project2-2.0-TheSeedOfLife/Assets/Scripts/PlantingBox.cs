using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingBox : MonoBehaviour
{
    //get the nutrition and the soil
    public bool nutritionGet;
    public bool soilGet;

    //public bool plantingReady;

    public NutritionPourDetector nutritionPour;
    public SoilPourDetector soilPour;

    public GameObject nutritionResource;
    public GameObject soilResource;

    private void Awake()
    {
        nutritionResource.SetActive(false);
        soilResource.SetActive(false);
    }

    private void Update()
    {
        //get the pouring status of the nutrition and the soil
        nutritionGet = nutritionPour.nutritionReady;
        soilGet = soilPour.soilReady;

        //if nutrition and soil are all being added,planting box is ready
        if (nutritionGet == true)
        {
            nutritionResource.SetActive(true);
        }
        if (soilGet == true)
        {
            soilResource.SetActive(true);
        }
    }
}
