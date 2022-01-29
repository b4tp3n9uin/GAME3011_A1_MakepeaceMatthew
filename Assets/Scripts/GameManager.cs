using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool ExtractMode = true;
    public static int ExtractsLeft = 3;
    public static int ScansLeft = 6;
    public static int Score = 0;

    public TMPro.TextMeshProUGUI ModeText;
    public TMPro.TextMeshProUGUI ExtractText;
    public TMPro.TextMeshProUGUI ScanText;
    public TMPro.TextMeshProUGUI ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        SwitchModes();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTexts();
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
}
