// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// [System.Serializable]
// public abstract class GUIMenuBase : IGUIMenu {  
//     public GameObject Instance; 
//     protected Dictionary<GameObject, ICommand> associations = new Dictionary<GameObject, ICommand>();
//     protected List<GameObject> activeButtons;

//     public GUIMenuBase() {
//     }
//     public abstract void Init();
//     public GameObject GetGOInstance() {
//         return Instance;
//     }
//     public virtual void Show() {
//         GUILogic.ShowMenu(this);
//     }
//     public virtual void Hide() {
//         GUILogic.HideMenu(this);
//     }
//     public virtual bool CanShow(GameObject guiItem) {
//         return true;
//     }
//     public virtual bool IsShown(GameObject guiItem) {
//         return true;
//     }
//     public virtual bool IsAvalibale(GameObject guiItem) {
//         return true;
//     }
//     public virtual bool CanButtonClick(GameObject button) {
//         if (!associations.ContainsKey(button))
//             return false;

//         return associations[button].CanExecute(button);
//     }
//     public virtual void ButtonClick(GameObject button) {
//         if (!associations.ContainsKey(button))
//             return;

//         if (associations[button].CanExecute(button))        
//             associations[button].Execute(button);
//     }
//     public virtual void OnSourceChanged() {
//         foreach(var item in associations) {
//             UIButton buttonScript = item.Key.GetComponent<UIButton>();
//             if (buttonScript != null) {
//                 buttonScript.isEnabled = item.Value.CanExecute(item.Key);
//                 buttonScript.enabled = true;
//             }
//         }
//     }
//     protected virtual void adjustPanelButtons() {
//     }
//     protected virtual void associateButton(GameObject guiItem, ICommand command) {
//         associate(guiItem, command);
//         UIEventListener.Get(guiItem).onClick += ButtonClick;
//     }
//     protected virtual void associate(GameObject guiItem, ICommand command) {
//         associations.Add(guiItem, command);
//     }
//     protected virtual void removeAssociation(GameObject guiItem) {      
//         if (associations.ContainsKey(guiItem))
//             associations.Remove(guiItem);
//     }
// }
