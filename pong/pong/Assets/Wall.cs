using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

  /* When we collide with something
   * of this tag we'll count it as a point
   * for one of the players */
  public string triggerName;

  // @override
  void OnTriggerEnter2D(Collider2D item) {
    if(item.name == triggerName) { /* the item that collided with us */
      /* The ball has hit us!
       * Send a message of our tag name
       * (either East, or West) so the
       * point can be given to the correct player. */

      string name = transform.name; /* the wall name */
      Score.Hit(name);

      item.gameObject.SendMessage(
          "QueueAnotherRound", 
          1.0f, 
          SendMessageOptions.RequireReceiver
      );
    }
  }
}
