using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;
	public Button Play;
	public Button Quit;
	public Button Options;

    // Start is called before the first frame update
    void Start()
    {
		Play.onClick.AddListener(PlayMaze);
		Quit.onClick.AddListener(QuitMaze);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayMaze()
    {
		Debug.Log("Button pressed");

        if (colorblindMode.isOn)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }
		else
		{
			trapMat.color = Color.red;
			goalMat.color = Color.green;
		}
        SceneManager.LoadScene("Maze");
    }

    public void QuitMaze()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}