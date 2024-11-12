using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // ��ư���� Ŭ���� �� ��ȯ�� ���� �̸��� ������ ����
    public string sceneName;

    // ��ư Ŭ�� �� ȣ��� �Լ�
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    // ���� ���� �Լ�
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        Debug.Log("������ �����մϴ�.");
    }
}
