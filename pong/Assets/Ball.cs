using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

  /* to let users ready up before ball starts to move */
  public int pauseTime;

  /* speed at which ball spins */
  public int spinSpeed;

  private Rigidbody2D body;

	// Use this for initialization
	void Start () {
	  body = GetComponent<Rigidbody2D>();	

    /* begin the game with small delay 
     * to let our players get ready */
    Invoke("BeginRound", pauseTime);
	}

  void Update() {
    /* spin the ball like a true mac beach ball! */
    transform.Rotate(Vector3.forward * -1 * spinSpeed);
  }
	
  void BeginRound() {
    /* which way should ball go? randomize */
    /* TODO: randomize angle as well? */
    float r = Random.Range(0, 2);
    int ang = -10;
    if(r < 1) {
      body.AddForce(new Vector2(20, ang));
    }
    else { 
      body.AddForce(new Vector2(-20, ang));
    }
  }

  void QueueAnotherRound() {
    /* set initial ball position */
    body.velocity = Vector2.zero;
    transform.position = Vector2.zero;

    if(!Score.IsOver()) {
      /* delay to allow players to get ready again */
      Invoke("BeginRound", pauseTime);
    }
  }

  // @override
  void OnCollisionEnter2D(Collision2D item) {
    /* check if we've hit a paddle */
    if(item.collider.CompareTag("Player")) {
      /* we have hit a paddle! */
      Vector2 velocity;
      velocity.x = body.velocity.x;
      /* This next line is the real magic.
       * This makes it so when the ball hits a corner of the
       * paddle it'll shoot off in a faster/different direction. */
      velocity.y = ( body.velocity.y / 2 ) + ( item.collider.attachedRigidbody.velocity.y / 3 );
      body.velocity = velocity;
    }
  }
}
