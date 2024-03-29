﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGUIMenu {
    void Show();
    void Hide();
    bool CanShow(GameObject guiItem);
    bool IsShown(GameObject guiItem);
    bool IsAvalibale(GameObject guiItem);
    bool CanButtonClick(GameObject button);
    void ButtonClick(GameObject button);
    void OnSourceChanged();
}
