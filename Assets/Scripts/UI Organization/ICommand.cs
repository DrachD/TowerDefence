using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    void Execute        (GameObject context);
    bool CanExecute     (GameObject context);
}
