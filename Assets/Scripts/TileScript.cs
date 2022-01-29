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

    // Start is called before the first frame update
    void Start()
    {
        DetermineResource();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DetermineResource()
    {
        switch(resource_Type)
        {
            case RESOURCE_TYPE.TROPHY:
                real_ResourceIMG = max;
                break;
            case RESOURCE_TYPE.MEDAL:
                real_ResourceIMG = half;
                break;
            default:
                real_ResourceIMG = quarter;
                break;
        }
    }

    public void ScanResource()
    {
        Debug.Log("CLick");
        HiddenPic.sprite = real_ResourceIMG;
    }
}
