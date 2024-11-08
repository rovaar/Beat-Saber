using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static SceneLoader instance;

    private void Awake()

    {

        if (instance != null && instance != this)

        {

            Destroy(this.gameObject);

            return;

        }

        instance = this;

        DontDestroyOnLoad(gameObject);

    }
    public IEnumerator ShowOverlayAndLoad(string sceneName)
    {
        yield return new WaitForSeconds(3f);
        AsyncOperation asyncLoad;
        asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        yield return null;
    }
}
