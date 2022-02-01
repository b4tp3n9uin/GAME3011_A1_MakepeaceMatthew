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

    private bool isClicked;
    private int value = 0;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        isClicked = false;
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
            FindObjectOfType<AudioManager>().Play("Minimal");
            value = 0;
        }
        else if (rand > 113 && rand <= 173)
        {
            resource_Type = RESOURCE_TYPE.CONTROLLER;
            FindObjectOfType<AudioManager>().Play("Controller");
            value = 100;
        }
        else if (rand > 173 && rand <= 210)
        {
            resource_Type = RESOURCE_TYPE.MEDAL;
            FindObjectOfType<AudioManager>().Play("Medal");
            value = 500;
        }
        else if (rand > 210)
        {
            resource_Type = RESOURCE_TYPE.TROPHY;
            FindObjectOfType<AudioManager>().Play("Trophy");
            value = 1000;
        }

        ResourceTypeDetermined();
    }

    public void ScanNExtractResource()
    {
        // Scan
        if (!GameManager.ExtractMode)
        {
            if (!isClicked && GameManager.ScansLeft > 0)
            {
                // Scan Tile
                GameManager.ScansLeft--;
                gameManager.UpdateTexts();

                isClicked = true;
                DetermineResource();
                HiddenPic.sprite = real_ResourceIMG;
            }
            else
                FindObjectOfType<AudioManager>().Play("Error");
        }

        // Extract
        else if (GameManager.ExtractMode)
        {
            if (isClicked && GameManager.ExtractsLeft > 0)
            {
                GameManager.ExtractsLeft--;
                GameManager.Score += value;
                FindObjectOfType<AudioManager>().Play("Extract");

                gameManager.UpdateTexts();
                HiddenPic.color = Color.black;

                if (GameManager.ExtractsLeft == 0)
                    gameManager.FinalResults();
            }
            else
                FindObjectOfType<AudioManager>().Play("Error");
        }

    }
}
