using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] Hearts;
    public Sprite FullHeart;
    public Sprite HalfHeart;
    public Sprite EmptyHeart;
    public FloatValue HeartContainers;
    public FloatValue PlayerCurrentHealth;

 	// Use this for initialization
	void Start ()
    {
        InitHearts();
	}
	
	public void InitHearts()
    {
        // Loops through heart containers and turns them on and full either at the beginning of the game or when a new heart is recieved.
        for (int i = 0; i < HeartContainers.InitialValue; i++)
        {
            Hearts[i].gameObject.SetActive(true);
            Hearts[i].sprite = FullHeart;
        }
    }

    // Checks players health and decides what sprites the heart container uses.
    public void UpdateHearts()
    {
        // PlayerCurrentHealth is divided by 2 as half a heart is 1 health point.
        float tempHealth = PlayerCurrentHealth.RuntimeValue / 2;
        // Loops through heart containers and compares current health to what is displayed in the heart containers
        for (int i = 0; i < HeartContainers.InitialValue; i++)
        {
            // -1 because i starts at 0 in indexing.
            if (i <= tempHealth -1)
            {
                Hearts[i].sprite = FullHeart;
            }
            else if (i >= tempHealth)
            {
                Hearts[i].sprite = EmptyHeart;
            }
            else
            {
                Hearts[i].sprite = HalfHeart;
            }
        }
    }
}
