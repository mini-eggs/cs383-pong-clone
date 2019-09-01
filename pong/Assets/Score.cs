using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

  public static int PlayerOneScore = 0;
  public static int PlayerTwoScore = 0;

  /* Walls that when hit score a user
   * a point.
   * targetOne -> inc PlayerOneScore */
  public string targetOne;
  public string targetTwo;

  /* max score 
   * first to this wins game */
  public int top;

  /* fellow game object */
  GameObject ball;

  /* Make singleton, for accessing targetOne
   * and targetTwo. There will *always* be one
   * and only one of this instance alive. 
   * Doing this due to Unity complaing about
   * target(One|Two). */
  public static Score self;

  void Awake() {
    self = this;
  }
  
  void Start() {
    ball = GameObject.FindGameObjectWithTag("Ball");
  }

  /* so ball can tell when to stop moving */
  public static bool IsOver() {
    return PlayerOneScore >= self.top || PlayerTwoScore >= self.top;
  }

  public static void Hit(string wall) {
    if(wall == self.targetOne) {
      PlayerOneScore++;
    }
    else if(wall == self.targetTwo) {
      PlayerTwoScore++;
    }
  }

  // @override
  // Not actually sure what calls this or why
  // but here's where we can update points 
  // and end of game messages/buttons.
  // Oh nevermind, This is called like a ticker
  // as `update` is.
  void OnGUI() {
    /* scores */
    GUI.Label(new Rect(Screen.width / 2 - 140, 200, 150, 150), "Left Player: " + PlayerOneScore);
    GUI.Label(new Rect(Screen.width / 2 + 50, 200, 150, 150), "Right Player: " + PlayerTwoScore);

    /* directions */
    GUI.Label(new Rect(Screen.width / 2 - 50, 460, 150, 150), "First to " + top + " wins!");

    if(Score.IsOver()) {
      /* show who won */
      string msg = PlayerOneScore >= self.top ? "Left Player" : "Right Player";
      GUI.Label(new Rect(Screen.width / 2 - 65, 300, 150, 150), "Congrats " + msg + "!");

      /* give users a reset button */
      if ( GUI.Button( new Rect( Screen.width / 2 - 50, 380, 100, 50 ), "Play Again!" ) ) {
        PlayerOneScore = 0;
        PlayerTwoScore = 0;
        ball.SendMessage("QueueAnotherRound", 1.0f, SendMessageOptions.RequireReceiver);
      }
    }
  }
}
