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
}
