using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum RESOURCE_TYPE {
    CONTROLLER,
    MEDAL, 
    TROPHY,
    MINIMAL
};

public class TileScript : MonoBehaviour
{
    [SerializeField]
    Image HiddenPic;

    [SerializeField]
    Sprite real_ResourceIMG;

    [SerializeField, Header("Resource Type")]
    RESOURCE_TYPE resource_Type;

    [Header("Resource Rewards")]
    public Sprite minimal;
    public Sprite quarter;
    public Sprite half;
    public Sprite max;

    private bool isClicked = false;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ResourceTypeDetermined()
    {
        switch (resource_Type)
        {
            case RESOURCE_TYPE.TROPHY:
                real_ResourceIMG = max;
                break;
            case RESOURCE_TYPE.MEDAL:
                real_ResourceIMG = half;
                break;
            case RESOURCE_TYPE.CONTROLLER:
                real_ResourceIMG = quarter;
                break;
            default:
                real_ResourceIMG = minimal;
                break;
        }
    }

    void DetermineResource()
    {
        int rand = Random.RandomRange(1, 225);

        if (rand <= 113)
        {
            resource_Type = RESOURCE_TYPE.MINIMAL;
        }
        else if (rand > 113 && rand <= 173)
        {
            resource_Type = RESOURCE_TYPE.CONTROLLER;
        }
        else if (rand > 173 && rand <= 210)
        {
            resource_Type = RESOURCE_TYPE.MEDAL;
        }
        else if (rand > 210)
        {
            resource_Type = RESOURCE_TYPE.TROPHY;
        }

        ResourceTypeDetermined();
    }

    public void ScanResource()
    {
        if (GameManager.ScansLeft > 0)
        {
            if (!isClicked)
            {
                GameManager.ScansLeft--;
                gameManager.UpdateTexts();

                isClicked = true;
                DetermineResource();
                HiddenPic.sprite = real_ResourceIMG;
            }
        }

        
    }
}
