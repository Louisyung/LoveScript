using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using UnityEngine.SceneManagement;

public class MovieCHandler : MonoBehaviour
{
    FlowerSystem fs;
    private string RoleCName;
    private int progress = 0;
    private bool isGameEnd = false;
    private bool isLocked = false;
    void Start()
    {
        RoleCName = "角色C";

        fs = FlowerManager.Instance.CreateFlowerSystem("MovieCScene", false);
        fs.SetupDialog();
        fs.SetupUIStage();
        fs.SetVariable("RoleCName", RoleCName);
    }

    void Update()
    {
        if (fs.isCompleted && !isGameEnd && !isLocked)
        {
            switch (progress)
            {
                case 0:
                    fs.ReadTextFromResource("Txtfiles/MovieCText1");
                    break;
                case 1:
                    fs.SetupButtonGroup();
                    fs.SetupButton("那我們再比較一下其他的電影，看看有沒有更好的。", () => {
                        fs.Resume();
                        fs.RemoveButtonGroup();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmCQ2A1Action");
                        isLocked = false;
                    });
                    fs.SetupButton("我覺得這部電影已經是個不錯的選擇了，何必猶豫呢？", () => {
                        fs.Resume();
                        fs.RemoveButtonGroup();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmCQ2A2Action");
                        isLocked = false;
                    });
                    fs.SetupButton("要不要用動態規劃（Dynamic Programming）來解決這個問題？", () => {
                        fs.Resume();
                        fs.RemoveButtonGroup();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmCQ2A3Action");
                        isLocked = false;
                    });
                    isLocked = true;
                    break;
                case 2:
                    fs.ReadTextFromResource("Txtfiles/MovieCText2");
                    break;
                default:
                    isGameEnd = true;
                    break;
            }
            progress++;
        }

        if(!isGameEnd)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                fs.Next();
            }
        }

        if (fs.isCompleted && isGameEnd)
        {
            SceneManager.LoadScene("ShoppingCScene");
        }
    }
}