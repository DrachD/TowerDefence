// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class GUIImpl : MonoBehaviour
// {
//     [System.Serializable]
//     public class MenuPanel : GUIMenuBase {
//     public GameObject SettingsButton;
//     public GameObject CancelButton;
//     public GameObject ExitButton;   
//     public GameObject ResetButton;

//     public override void Init() {
//         associateButton(NewGameButton, new NewGameCommand(this));
//         associateButton(SettingsButton, new SettingsCommand(this));
//         associateButton(CancelButton, new CancelCommand(this));
//         associateButton(ExitButton, new ExitCommand(this));
//     }
//     public override void Show() {
//         base.Show();
//     }
//     public override void Hide() {
//         base.Hide();
//     }
// }
