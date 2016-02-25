// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Activete or diactivate GameObject")]
[NodeAuthor("Oxy949", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Active", "Tells a GameObject (target) to look at another GameObject (focus) transform or Vector3 position in a specified amount of time (seconds).")]
public class uScriptAct_SetActive : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject's name to change.")]
      GameObject Target,

      [FriendlyName("Active state", "The new state.")]
      bool IsActive
      )
   {
      Target.SetActive(IsActive);
   }
}