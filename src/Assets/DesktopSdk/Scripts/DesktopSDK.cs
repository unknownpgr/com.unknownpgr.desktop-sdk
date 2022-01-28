using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

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

  public void ShowMessage(string message)
  {
    if (!isInitialized) return;

    GameObject messageObject = Instantiate(MessagePrefab, MainCanvas.transform);
    MessageManager messageManager = messageObject.GetComponent<MessageManager>();
    messageManager.SetText(message);
  }

  public void Initialize()
  {
    if (isInitialized) return;
    isInitialized = true;
    ShowMessage("SDK is initialized. It will get some information from server in few seconds.");
    StartCoroutine(ServerCall());
  }

  IEnumerator ServerCall()
  {
    yield return new WaitForSeconds(3);

    UnityWebRequest request = UnityWebRequest.Get("https://checkip.amazonaws.com");
    yield return request.SendWebRequest();

    if (request.result != UnityWebRequest.Result.Success)
    {
      ShowMessage("Error occurred while connecting to server.");
      yield break;
    }

    string data = request.downloadHandler.text;
    ShowMessage("Your IP is " + data);
  }
}
