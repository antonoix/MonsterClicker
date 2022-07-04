using UnityEngine.SceneManagement;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _restart;

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ActivateRestart()
    {
        _restart.SetActive(true);
    }
}
