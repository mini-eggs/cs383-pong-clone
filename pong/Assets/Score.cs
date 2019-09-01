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

  /* Used to display either help screen on game
   * Game is first put to help screen the user must press
   * play to continue to game. */
  private bool hasStarted;


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
    hasStarted = false;
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
    if(hasStarted) {
      /* scores */
      GUI.Label(new Rect(Screen.width / 2 - 140, Screen.height * 0.25f, 150, 150), "Left Player: " + PlayerOneScore);
      GUI.Label(new Rect(Screen.width / 2 + 50, Screen.height * 0.25f, 150, 150), "Right Player: " + PlayerTwoScore);

      if(Score.IsOver()) {
        /* show who won */
        string msg = PlayerOneScore >= self.top ? "Left Player" : "Right Player";
        GUI.Label(new Rect(Screen.width / 2 - 65, Screen.height * 0.4f, 150, 150), "Congrats " + msg + "!");

        /* give users a reset button */
        if ( GUI.Button( new Rect( Screen.width / 2 - 50, Screen.height * 0.6f, 100, 50 ), "Play Again!" ) ) {
          PlayerOneScore = 0;
          PlayerTwoScore = 0;
          ball.SendMessage("QueueAnotherRound", 1.0f, SendMessageOptions.RequireReceiver);
        }
      }
    }
    else {
      /* display help screen */
      GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height * 0.25f, 500, 500), @"
          HELP SCREEN

          LEFT PLAYER CONTROLS:
            Move up: 'w' key.
            Move down: 's' key.
          
          RIGHT PLAYER CONTROLS:
            Move up: '↑' arrow key.
            Move down: '↓' arrow key.

          RULES
            First player to score five points wins.
            A player scores a point by hitting the beach 
            ball into the wall behind the other player.
          ");

      /* give users a reset button */
      if ( GUI.Button( new Rect( Screen.width / 2 - 50, Screen.height * 0.6f, 100, 50 ), "Begin!") ) {
        hasStarted = true;
        ball.SendMessage("QueueBegin", 1.0f, SendMessageOptions.RequireReceiver);
      }
    }
  }
}
