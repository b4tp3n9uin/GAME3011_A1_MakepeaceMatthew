using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public static bool ExtractMode;
    public static int ExtractsLeft;
    public static int ScansLeft;
    public static int Score;

    [Header("Text Labels")]
    public TMPro.TextMeshProUGUI ModeText;
    public TMPro.TextMeshProUGUI ExtractText;
    public TMPro.TextMeshProUGUI ScanText;
    public TMPro.TextMeshProUGUI ScoreText;
    public Text FinalResult_Text;

    [Header("Pannels")]
    public GameObject HTP_Canvas;
    public GameObject InGame_Canvas;
    public GameObject Final_Canvas;

    [Header("Toggle Button")]
    public GameObject ToggleGame_Button;

    [Header("Audio Clips")]
    public AudioSource ExtractSFX;
    public AudioSource ScanSFX;

    // Start is called before the first frame update
    void Start()
    {
        ToggleGame_Button.SetActive(true);
        InGame_Canvas.SetActive(false);
        Final_Canvas.SetActive(false);

        ExtractsLeft = 3;
        ScansLeft = 6;
        Score = 0;

        ExtractMode = true;
        ModeText.text = "In Extract Mode";


        UpdateTexts();
        HTP_Canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchModes()
    {
        if (ExtractMode)
        {
            // Set to Scan Mode
            ScanSFX.Play();
            ExtractMode = false;
            ModeText.text = "In Scan Mode";
        }
        else
        {
            // Set to Extract Mode
            ExtractSFX.Play();
            ExtractMode = true;
            ModeText.text = "In Extract Mode";
        }
    }

    public void UpdateTexts()
    {
        ExtractText.text = "Extracts Remaining: " + ExtractsLeft;
        ScanText.text = "Scans Remaining: " + ScansLeft;
        ScoreText.text = "Resource Value: " + Score;
    }

    public void SetUpHtpCanvas()
    {
        HTP_Canvas.SetActive(true);
    }

    public void DecativateHtpCanvas()
    {
        HTP_Canvas.SetActive(false);
    }

    public void FinalResults()
    {
        FinalResult_Text.text = "Final Score: " + Score;
        Final_Canvas.SetActive(true);
    }

    public void ToggleGame()
    {
        InGame_Canvas.SetActive(true);
    }

    public void CloseGame()
    {
        InGame_Canvas.SetActive(false);
        ToggleGame_Button.SetActive(false);
        Debug.Log("Quit");
        Application.Quit();
    }
}
