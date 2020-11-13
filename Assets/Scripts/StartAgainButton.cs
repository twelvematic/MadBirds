using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartAgainButton : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable()
    {
        button.onClick.AddListener(() =>
        {
            GameObject musicObject = GameObject.FindGameObjectsWithTag("Music").FirstOrDefault();
            AudioSource music;
            musicObject.TryGetComponent<AudioSource>(out music);
            music.Stop();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameStats.ResetStats();
            music.Play();
        });
    }

}
