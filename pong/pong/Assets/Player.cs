using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

  // keys to respond to 
  // configured via editor
  public KeyCode up = KeyCode.W;
  public KeyCode down = KeyCode.W;

  // how fast our player moves
  // configured via editor
  public float speed;

  // the arena our player can move (up/down)
  // configured via editor
  public float boundTop;
  public float boundBottom;

  private Rigidbody2D body;

	void Start () {
    body = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
    /* for player velocity */
    var velo = body.velocity;
    if(Input.GetKey(up)) {
      velo.y = speed;
    }
    else if(Input.GetKey(down)) {
      velo.y = speed * -1;
    }
    else {
      velo.y = 0; /* no keys touched, stay still */
    }

    /* for position, don't let user exit boundY */
    /* transform is given to use via superclass, MonoBehaviour */
    var position = transform.position;
    if(position.y > boundTop) {
      position.y = boundTop;
    }
    else if(position.y < boundBottom) {
      position.y = boundBottom;
    }

    /* update our player and transform with new vars */
    body.velocity = velo;
    transform.position = position;
	}
}
