using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    [SerializeField] int scoreValue = 5;
    [SerializeField] AudioClip pointsEarnedSound;
    [SerializeField] [Range(0, 1)] float pointsEarnedSoundVolume = 1f;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.GetComponent<PolygonCollider2D>() != null)
        {
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
            AudioSource.PlayClipAtPoint(pointsEarnedSound, Camera.main.transform.position, pointsEarnedSoundVolume);
        }
        //destroys the bullets
        Destroy(otherObject.gameObject);
    }

}
