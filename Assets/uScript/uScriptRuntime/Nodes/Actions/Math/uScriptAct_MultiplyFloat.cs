// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Float")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Multiplies two float variables together and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[NodeDeprecated(typeof(uScriptAct_MultiplyFloat_v2))]
[FriendlyName("Multiply Float (OLD)", "Multiplies float variables together and returns the result." +
 "\n\n[ A * B ]" +
 "\n\nIf more than one variable is connected to A, they will be multiplied together before being multiplied by B." +
 "\n\nIf more than one variable is connected to B, they will be multiplied together before being multiplied by A.")]
public class uScriptAct_MultiplyFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first variable or variable list."), AutoLinkType(typeof(float))]
      float[] A,

      [FriendlyName("B", "The second variable or variable list."), AutoLinkType(typeof(float))]
      float[] B,

      [FriendlyName("Result", "The floating-point result of the operation.")]
      out float FloatResult,

      [FriendlyName("Int Result", "The integer result of the operation.")]
      [SocketState(false, false)]
      out int IntResult
      )
   {
      float aTotals = 1;
      float bTotals = 1;

      foreach (float currentA in A)
      {
         aTotals *= currentA;
      }
      foreach (float currentB in B)
      {
         bTotals *= currentB;
      }

      FloatResult = aTotals * bTotals;
      IntResult = System.Convert.ToInt32(FloatResult);
   }
}
