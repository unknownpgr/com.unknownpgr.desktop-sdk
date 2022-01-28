using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
  private int counter = 0;

  public void OnCounterButtonClicked()
  {
    ++counter;
    DesktopSDK.Instance.ShowMessage("You clicked this button " + counter + " times.");
  }
}
