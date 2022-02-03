using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptManager : MessageManager
{
  public delegate bool OnAcceptHandler(string userInput);

  public InputField Input;
  public OnAcceptHandler OnAccept = null;

  public void OnAcceptClicked()
  {
    if (OnAccept != null)
    {
      bool shouldClose = OnAccept(Input.text);
      if (!shouldClose) return;
    }
    Destroy(this.gameObject);
  }
}
