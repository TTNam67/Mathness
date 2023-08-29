using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string loadingSceneName = "SceneA";
    public string targetSceneName = "SceneB";

    /*
        public Scene loadingScene;
        public Scene targetScene;
     */

    public void onClickButton()
    {
        // Bắt đầu quá trình tải và chuyển sang Loading Scene
        SceneManager.LoadScene(loadingSceneName);
        UnityEngine.Debug.Log("da load scene a");
        // Gọi hàm để thực hiện tải và chuyển đổi Scene trong script Loading Scene
        StartCoroutine(LoadAsyncScene());
        UnityEngine.Debug.Log("da load scene b");
    }

    private IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetSceneName);
        // Ngăn chặn việc tự động chuyển đổi Scene khi việc tải hoàn thành
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            
            // Kiểm tra tiến trình tải và chuyển đổi Scene
            if (asyncLoad.progress >= 0.9f)
            {
                // Đạt đến mức tiến trình 90%, cho phép chuyển đổi Scene
                asyncLoad.allowSceneActivation = true;
                
            }
            yield return null;
        }

    }
}
