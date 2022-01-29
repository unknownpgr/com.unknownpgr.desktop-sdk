using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
  public Text Text;

  public void SetText(string text)
  {
    Text.text = text;
  }

  public void OnClick()
  {
    Destroy(this.gameObject);
  }
}
