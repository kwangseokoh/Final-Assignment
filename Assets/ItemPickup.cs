using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    [SerializeField]
    private GameObject pickupText; // UI �ؽ�Ʈ ����
    private bool isPlayerInRange = false;
    public RawImage carrotimage;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered item range.");
            isPlayerInRange = true;

            GameManager.Instance.PickupCarrot();

            if (pickupText != null)
            {
                pickupText.gameObject.SetActive(true); // �ؽ�Ʈ Ȱ��ȭ
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exited item range.");
            isPlayerInRange = false;

            if (pickupText != null)
            {
                pickupText.gameObject.SetActive(false); // �ؽ�Ʈ ��Ȱ��ȭ
            }
        }
    }

    void Start()
    {
        Debug.Log("Script success");
        carrotimage.enabled = false;

        if (pickupText != null)
        {
            pickupText.gameObject.SetActive(false); // �ؽ�Ʈ ��Ȱ��ȭ
        }
    }

    void Update()
    {
        // E Ű�� ������ �������� ȹ��
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed while player is in range.");
            Pickup();
        }
    }

    void Pickup()
    {
        // ������ ȹ�� ������ ���⿡ ����
        Debug.Log("�������� ȹ���߽��ϴ�!");

        carrotimage.enabled = true;

        gameObject.SetActive(false); //������ ��Ȱ��ȭ

        if (pickupText != null)
        {
            pickupText.gameObject.SetActive(false); // �ؽ�Ʈ ��Ȱ��ȭ
        }
        
    }
}
