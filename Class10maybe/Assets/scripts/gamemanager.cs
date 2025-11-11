using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.InputSystem;

public class gamemanager : MonoBehaviour
{

    //variables
    //add a number
    public int score;

    //add a text
    public TextMeshProUGUI text;

    //add a text for scores
    public TextMeshProUGUI scores;

    //add a input reference
    public InputActionReference interact;

    //add a end reference
    public InputActionReference end;

    public InputActionReference clear;

    //sets the folder
    private const string DIR_RES = "/Resources";

    //sets the file
    private const string FILE_SAVES = DIR_RES + "/Saves.txt";

    //creates path to file
    private string FILE_PATH_SAVES;

    //string to add to .txt
    public string inputnum;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        score = 0;
        //declare file path
        FILE_PATH_SAVES = Application.dataPath + FILE_SAVES;

        scores.text = File.ReadAllText(FILE_PATH_SAVES);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + score;

        if (interact.action.WasPressedThisFrame())
        {
            score++;
        }

        if (end.action.WasPressedThisFrame())
        {
            SaveScore(score);

            score = 0;
        }

        if (clear.action.WasPressedThisFrame())
        {
            ClearSaves();
        }
    }

    public void SaveScore(int s)
    {
        inputnum = s.ToString();

        string fileContents = File.ReadAllText(FILE_PATH_SAVES);

        fileContents += inputnum + "\n";

        File.WriteAllText(FILE_PATH_SAVES, fileContents);
    }
    public void ClearSaves()
    {
        File.WriteAllText(FILE_PATH_SAVES, "");
    }

}
