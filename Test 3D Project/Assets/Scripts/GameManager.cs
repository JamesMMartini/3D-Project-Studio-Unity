using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // This is private, so that we can show an error if its not set up yet
    private static GameManager staticInstance;

    [SerializeField] TMP_Text scoreBox;
    [SerializeField] TMP_Text messageBox;

    int score;

    public bool started;

    public static GameManager Instance
    {
        get
        {
            // If the static instance isn't set yet, throw an error
            if (staticInstance is null)
            {
                Debug.LogError("Game Manager is NULL");
            }

            return staticInstance;
        }
    }

    private void Awake()
    {
        // Set the static instance to this instance
        staticInstance = this;
        started = false;
        score = 0;
    }

    public void StartGame()
    {
        started = true;
        scoreBox.gameObject.SetActive(true);
        StartCoroutine(ShowMessage("Help all the residents in the town!"));
    }

    public IEnumerator ShowMessage(string message)
    {
        messageBox.text = message;
        messageBox.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        messageBox.gameObject.SetActive(false);
    }

    public void IncreaseScore()
    {
        score++;

        scoreBox.text = "Residents Helped: " + score + "/5";

        if (score == 5)
        {
            StartCoroutine(ShowMessage("Congratulations! You helped all the citizens!"));
        }
    }
}
