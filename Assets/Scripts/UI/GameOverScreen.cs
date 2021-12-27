using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    public UnityEvent OnGameOver;
    public UnityEvent OnRestartGame;

    public void ActivateRestartButton()
    {
        OnGameOver?.Invoke();
        _restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        StartCoroutine(RestartGameCorutine());
    }

    IEnumerator RestartGameCorutine()
    {
        OnGameOver?.Invoke();
        yield return new WaitForSeconds(2);
        OnRestartGame?.Invoke();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}


