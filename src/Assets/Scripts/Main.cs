using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
  public void OnInitializeButtonClick()
  {
    DesktopSDK.Instance.Initialize();
  }
}
