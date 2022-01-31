using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [Header("Pannels")]
    public GameObject HTP_Canvas;
    public GameObject Final_Canvas;
    public Text FinalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ExtractsLeft = 3;
        ScansLeft = 6;
        Score = 0;
        ExtractMode = true;

        SwitchModes();

        Final_Canvas.SetActive(false);
        HTP_Canvas.SetActive(false);

        UpdateTexts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchModes()
    {
        // Set to Scan Mode
        if (ExtractMode)
        {
            ExtractMode = false;
            ModeText.text = "In Scan Mode";
        }
        else
        {
            // Set to Extract Mode
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

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void FinishGame()
    {
        FinalScoreText.text = "Final Score: " + Score;
        Final_Canvas.SetActive(true);
    }
}
