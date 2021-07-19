using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneAsync : MonoBehaviour
{
	public static AsyncOperation async;
	public GameObject continueButton = null;
    public GameObject levelMananger;
	private float loadTimer = 0;
    private float timer = 3;

	void Start()
	{
        levelMananger = GameObject.Find("levelManager");
		loadTimer = 0;
		continueButton.SetActive(false);
        async = SceneManager.LoadSceneAsync(levelMananger.GetComponent<levelManagerScript>().nextLevel);
		async.allowSceneActivation = false;
        changeText();
    }

	public void Load()
    {
		async.allowSceneActivation = true;
	}

    public void changeText()
    {
        Text LoadText;
        LoadText = GameObject.Find("Canvas/bbText").GetComponent<Text>();
        switch (Random.Range(0, 6))
        {
            case 0:
                LoadText.text = "    岩浆很危险！但碰到水就会\n转化成石头";
                break;
            case 1:
                LoadText.text = "    毒气比空气密度小，所以会\n向上飘";
                break;
            case 2:
                LoadText.text = "    水是无害的，但如果水吸收\n了毒气就会变成致命的毒水";
                break;
            case 3:
                LoadText.text = "    毒水也会与岩浆反应，化为\n石头后，毒气会被蒸发出来要\n小心！";
                break;
            case 4:
                LoadText.text = "    狗没什么头脑，看到鼹鼠便\n会冲上来攻击，即使前面有一\n池岩浆";
                break;
            case 5:
                LoadText.text = "    鼹鼠很贪心，看到宝石和宝\n箱就会跑去吃，完全无视路上\n的陷阱";
                break;
            case 6:
                LoadText.text = "    有的拉杆，可以来回拉动，\n而有的只能拉一次";
                break;
        }

    }

	void Update()
	{
        if (loadTimer <= 0.5f)
        {
            loadTimer += Time.deltaTime * Random.Range(1.2f, 2);
        }
        else if (loadTimer <= 1)
        {
            loadTimer += Time.deltaTime * Random.Range(0.5f, 0.75f);
        }
        else if (loadTimer <= 1.5f)
        {
            loadTimer += Time.deltaTime * Random.Range(1.2f, 2);
        }

        string load = (loadTimer * 20).ToString("f0");

        Text LoadText;
        LoadText = GameObject.Find("Canvas/LoadingText").GetComponent<Text>();
        if (loadTimer < 1.5f)
        {
            LoadText.text = "加载中" + load + "%";
        }
        else
        {
            LoadText.text = "点击屏幕继续";
            continueButton.SetActive(true);
        }

        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 3;
            changeText();
        }

    }
}
