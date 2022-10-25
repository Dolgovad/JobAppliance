using UnityEngine;
using UnityEngine.SceneManagement;



public class UIManager : MonoBehaviour {
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelWin;
    [SerializeField] private GameObject panelLose;

    private void Start() {
        panelLose.SetActive(false);
        panelPause.SetActive(false);
        panelWin.SetActive(false);
    }

    public void PauseOn() {
        panelPause.SetActive(true);
        Time.timeScale = 0;
    }

    public void PauseOff() {
        panelPause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Win() {
        panelWin.SetActive(true);
        Time.timeScale = 0;
    }

    public void Lose() {
        panelLose.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResetScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
