using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Telegram : EventArgs 
{
    public List<ButtonBase> TargetList { get; private set; }
    public ButtonBase Target { get; private set; }

    public Telegram(ButtonBase target)
    {
        Target = target;
    }

    public Telegram(List<ButtonBase> target)
    {
        TargetList = target;
    }
}
