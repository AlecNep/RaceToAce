using UnityEngine;
using System.Collections;

public class Fist : MonoBehaviour {

    AudioSource[] sounds;
    AudioSource punch1;
    AudioSource punch2;
    float defaultPunchPower = 100;
    static float punchPower;

    // Use this for initialization
    void Awake () {
        sounds = GetComponents<AudioSource>();
        punch1 = sounds[0];
        punch2 = sounds[1];
        randomPunchSound();
		if (gameObject.CompareTag("Gloves"))
		{
			if (Player.getPowerUpType() == 2)
			{
				punchPower = (defaultPunchPower*2)*2;
				//splatter animation
			}
			else punchPower = 200;
		}
		else if (Player.getPowerUpType() == 2)
			punchPower = defaultPunchPower * 2;
		else
		{
			punchPower = defaultPunchPower;
		}
		print("Punch power: " + punchPower);
    }

    //so the player doesn't hear the same sound repeatedly
    void randomPunchSound()
    {
        if (Random.value < 0.5)
        {
            punch1.Play();
        }
        else punch2.Play();
    }

	public static void setPunchPower(int pow)
	{
		punchPower = pow;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("MainFloor"))
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up*punchPower, ForceMode2D.Impulse);
        }
    }
}
