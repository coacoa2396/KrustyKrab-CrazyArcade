using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class SceneManager : Singleton<SceneManager>
{
    [SerializeField] Image fade;
    [SerializeField] Slider loadingBar;
    [SerializeField] float fadeTime;

    private BaseScene curScene;

    public BaseScene GetCurScene()
    {
        if (curScene == null)
        {
            curScene = FindObjectOfType<BaseScene>();
        }
        return curScene;
    }

    public T GetCurScene<T>() where T : BaseScene
    {
        if (curScene == null)
        {
            curScene = FindObjectOfType<BaseScene>();
        }
        return curScene as T;
    }

    public void LoadScene(string sceneName, bool master = true)
    {
        StartCoroutine(PhotonLoadingRoutine(sceneName, master));
    }

    IEnumerator LoadingRoutine(string sceneName)
    {
        fade.gameObject.SetActive(true);
        yield return FadeOut();

        Manager.Pool.ClearPool();        
        Manager.UI.ClearPopUpUI();
        Manager.UI.ClearWindowUI();
        Manager.UI.CloseInGameUI();

        Time.timeScale = 0f;
        loadingBar.gameObject.SetActive(true);

        AsyncOperation oper = UnitySceneManager.LoadSceneAsync(sceneName);
        while (oper.isDone == false)
        {
            loadingBar.value = oper.progress;
            yield return null;
        }

        Manager.UI.EnsureEventSystem();

        BaseScene curScene = GetCurScene();
        yield return curScene.LoadingRoutine();

        loadingBar.gameObject.SetActive(false);
        Time.timeScale = 1f;

        yield return FadeIn();
        fade.gameObject.SetActive(false);
    }

    IEnumerator FadeOut()
    {
        float rate = 0;
        Color fadeOutColor = new Color(fade.color.r, fade.color.g, fade.color.b, 1f);
        Color fadeInColor = new Color(fade.color.r, fade.color.g, fade.color.b, 0f);

        while (rate <= 1)
        {
            rate += Time.unscaledDeltaTime / fadeTime;
            fade.color = Color.Lerp(fadeInColor, fadeOutColor, rate);
            yield return null;
        }
    }

    IEnumerator FadeIn()
    {
        float rate = 0;
        Color fadeOutColor = new Color(fade.color.r, fade.color.g, fade.color.b, 1f);
        Color fadeInColor = new Color(fade.color.r, fade.color.g, fade.color.b, 0f);

        while (rate <= 1)
        {
            rate += Time.unscaledDeltaTime / fadeTime;
            fade.color = Color.Lerp(fadeOutColor, fadeInColor, rate);
            yield return null;
        }
    }

    //권새롬 추가 ---> 게임시작 동기화
    IEnumerator PhotonLoadingRoutine(string sceneName, bool master = true)
    {
        fade.gameObject.SetActive(true);
        yield return FadeOut();

        Manager.Pool.ClearPool();
        Manager.UI.ClearPopUpUI();
        Manager.UI.ClearWindowUI();
        Manager.UI.CloseInGameUI();

        loadingBar.gameObject.SetActive(true);

        if(master)
            PhotonNetwork.LoadLevel(sceneName);
        float oper = 0;
        while (oper < 0.7f)
        {
            loadingBar.value = oper;
            oper += 0.12f;
            float time = 0.3f;
            yield return new WaitForSecondsRealtime(time);
        }

        Manager.UI.EnsureEventSystem();

        BaseScene curScene = GetCurScene();
        yield return curScene.LoadingRoutine();

        while(PhotonNetwork.InRoom && curScene as GameScene)
        {
            Player[] players = PhotonNetwork.PlayerList;
            bool isAllConnect = true;
            for (int i = 0; i < players.Length; i++)
            {
                Hashtable ht = players[i].CustomProperties;
                if ((bool)ht["IsLoad"] == false)
                {
                    isAllConnect = false;
                    break;
                }
            }
            if (isAllConnect)
                break;
            else
                yield return null;
        }

        loadingBar.gameObject.SetActive(false);
        yield return FadeIn();
        fade.gameObject.SetActive(false);

    }

}
