using UnityEngine;
using UnityEngine.UI;

public class RabbitTalk : MonoBehaviour
{
    public GameObject talkPromptText;  // "Press E to talk" 3D �ؽ�Ʈ ������Ʈ
    public Text dialogueText;  // ��縦 ǥ���� UI �ؽ�Ʈ
    private bool isPlayerInRange = false;
    private bool hasCarrot = false;  // ����� ȹ���ߴ��� ����
    private string[] dialogues = { "�� ��¥ �������?", "��������" };
    private int dialogueIndex = 0;

    void Start()
    {
        if (talkPromptText != null)
        {
            talkPromptText.SetActive(false);  // ó������ �ؽ�Ʈ�� ������ �ʰ� ����
        }

        if (dialogueText != null)
        {
            dialogueText.text = "";  // ó������ ��縦 �����
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (talkPromptText != null)
            {
                talkPromptText.SetActive(true);  // �÷��̾ ������ ������ �ؽ�Ʈ�� ���̰� ����
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (talkPromptText != null)
            {
                talkPromptText.SetActive(false);  // �÷��̾ ������ ����� �ؽ�Ʈ�� ������ �ʰ� ����
            }

            if (dialogueText != null)
            {
                dialogueText.text = "";  // �÷��̾ ������ ����� ��縦 ���
            }
        }
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!hasCarrot)
            {
                // ���� ����� ȹ������ ���� ���
                dialogueText.text = "���� ģ��! ������ϱ� ��� �� ��������!";
            }
            else
            {
                // ����� ȹ���� ���
                Talk();
            }
        }
    }

    void Talk()
    {
        if (dialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[dialogueIndex];
            dialogueIndex++;
        }
        else
        {
            // �䳢�� ��� ��ȭ�� ���� ��� ���� Ŭ���� ������ Ȯ���ϰ� ó���մϴ�.
            GameManager.Instance.CompleteGame();
        }
    }

    public void SetHasCarrot(bool value)
    {
        hasCarrot = value;
    }
}
