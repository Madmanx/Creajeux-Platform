using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Score : NetworkBehaviour
{
    [SyncVar]
	public int score = 0;					// The player's score.

	private int previousScore = 0;			// The score in the previous frame.


	void Update ()
	{
		// Set the score text.
		GetComponent<GUIText>().text = "Score: " + score;

		// If the score has changed...
		if(previousScore != score)
        {

           var heroes = GameObject.FindGameObjectsWithTag("Player");
           foreach(var hero in heroes)
            {
                var playerControl = hero.GetComponent<PlayerControl>();
                // ... play a taunt.
                playerControl.StartCoroutine(playerControl.Taunt());
            }
        }

		// Set the previous score to this frame's score.
		previousScore = score;
	}

}
