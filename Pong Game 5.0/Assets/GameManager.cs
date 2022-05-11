using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 3;

    public GUISkin layout;

    GameObject theBall;
    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }

    public static void Score(string wallID) {
        if (wallID == "ScorePaddle1" || wallID =="ScorePaddle2" || wallID == "ScorePaddle3" || wallID == "ScorePaddle4")
        {
            PlayerScore1++;
        } else if (wallID == "ScorePaddle5" || wallID == "ScorePaddle6" || wallID == "ScorePaddle7" || wallID == "ScorePaddle8")
        {
            PlayerScore1--;
        }
    }

    void OnGUI () {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width/2 - 12, Screen.height/2, 300, 300), "" + PlayerScore1);

        if (GUI.Button(new Rect(Screen.width/2 - 60, 35, 120, 53), "RESTART")) {
            PlayerScore1 = 3;
            theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if (PlayerScore1 == 0) {
            GUI.Label(new Rect(Screen.width/2 - 100, 100, 2000, 1000), "YOU LOSE!");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        } else if (PlayerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width/2 - 100, 100, 2000, 1000), "YOU WIN!");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }
}
