using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopSDK : MonoBehaviour
{
  private static DesktopSDK instance = null;

  public static DesktopSDK Instance
  {
    get { return instance; }
  }

  public Canvas MainCanvas;
  public GameObject MessagePrefab;

  private bool isInitialized = false;

  private void Awake()
  {
    if (instance != null && instance != this)
    {
      Destroy(this.gameObject);
      return;
    }
    instance = this;
    DontDestroyOnLoad(this.gameObject);
  }

  public void Initialize()
  {
    if (isInitialized) return;

    GameObject messageObject = Instantiate(MessagePrefab, MainCanvas.transform);
    MessageManager messageManager = messageObject.GetComponent<MessageManager>();
    messageManager.SetText("SDK is initialized.");

    isInitialized = true;
  }
}
