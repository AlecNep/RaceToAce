using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour {

    public Text winText;
    public Text time;
    public Text grade;
    public static float finishTime;

	// Use this for initialization
	void Start () {
	    if(finishTime >=0 && finishTime < 120) // t < 2 minutes
        {
            grade.text = "Grade: A";
            winText.text = "Nice report bro!";
        }
        else if(finishTime >= 120 && finishTime < 240) // 2 <= t < 4
        {
            grade.text = "Grade: B";
            winText.text = "Not bad, hombre, not bad.";
        }
        else if(finishTime >= 240 && finishTime < 360) // 4 <= t < 6
        {
            grade.text = "Grade: C";
            winText.text = "Punctuality isn't your thing, eh?";
        }
        else if(finishTime >= 360 && finishTime < 480) // 6 <= t < 8
        {
            grade.text = "Grade: D";
            winText.text = "Nice of you to actually show up!";
        }
        else // t > 8
        {
            grade.text = "Grade: F";
            winText.text = "I'm going to use this as TP later...";
        }
        time.text = "Time: " + finishTime + "s";

        
	}

    void Update()
    {
        if (Input.GetButtonDown("AButton"))
            SceneManager.LoadScene("ItemSelectionMenu");
        else if (Input.GetButtonDown("BButton"))
            Application.Quit();
    }
	
	public static void setFinishTime(float t)
    {
        finishTime = t;
    }
}
