using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // 버튼에서 클릭할 때 전환할 씬의 이름을 설정할 변수
    public string sceneName;

    // 버튼 클릭 시 호출될 함수
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    // 게임 종료 함수
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        Debug.Log("게임을 종료합니다.");
    }
}
