using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  

    void Awake()
    {
        // �ν��Ͻ��� �������� ������ �ڱ� �ڽ����� �����ϰ�, �׷��� ������ �ߺ��� �ν��Ͻ��� �ı��մϴ�.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // ���� ����Ǿ �����ǵ��� ����
        }
        else
        {
            Destroy(gameObject);
            return;
        }

    }

    // �������� ȹ���� �� ȣ��Ǵ� �޼���
    public void PickupCarrot()
    {
        // �䳢 ��ȭ ��ũ��Ʈ�� ã�Ƽ� �÷��̾ ����� ȹ�������� �˸��ϴ�.
        RabbitTalk rabbitDialogue = FindObjectOfType<RabbitTalk>();
        if (rabbitDialogue != null)
        {
            rabbitDialogue.SetHasCarrot(true);
        }
    }

    // ���� Ŭ���� �� ȣ��Ǵ� �޼���
    public void CompleteGame()
    {
        // ���� Ŭ���� ó��
        Debug.Log("Congratulations! You completed the game!");

        // EndingScene���� ��ȯ�մϴ�.
        SceneManager.LoadScene("EndingScene");
    }
}
