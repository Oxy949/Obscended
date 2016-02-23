//uScript Generated Code - Build 1.0.3024
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("Untitled", "")]
public class SetScale : uScriptLogic
{

   #pragma warning disable 414
   GameObject parentGameObject = null;
   uScript_GUI thisScriptsOnGuiListener = null; 
   bool m_RegisteredForEvents = false;
   delegate void ContinueExecution();
   ContinueExecution m_ContinueExecution;
   bool m_Breakpoint = false;
   const int MaxRelayCallCount = 1000;
   int relayCallCount = 0;
   
   //externally exposed events
   
   //external parameters
   
   //local nodes
   
   //owner nodes
   UnityEngine.GameObject owner_Connection_3 = null;
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_0 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_0 = UnityEngine.KeyCode.A;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_0 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_0 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_0 = true;
   //pointer to script instanced logic node
   uScriptAct_SetRandomScale logic_uScriptAct_SetRandomScale_uScriptAct_SetRandomScale_2 = new uScriptAct_SetRandomScale( );
   UnityEngine.GameObject[] logic_uScriptAct_SetRandomScale_Target_2 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_SetRandomScale_MinX_2 = (float) 0.5;
   System.Single logic_uScriptAct_SetRandomScale_MaxX_2 = (float) 2;
   System.Single logic_uScriptAct_SetRandomScale_MinY_2 = (float) 0.5;
   System.Single logic_uScriptAct_SetRandomScale_MaxY_2 = (float) 2;
   System.Single logic_uScriptAct_SetRandomScale_MinZ_2 = (float) 0.5;
   System.Single logic_uScriptAct_SetRandomScale_MaxZ_2 = (float) 2;
   System.Boolean logic_uScriptAct_SetRandomScale_PreserveX_Axis_2 = (bool) false;
   System.Boolean logic_uScriptAct_SetRandomScale_PreserveY_Axis_2 = (bool) false;
   System.Boolean logic_uScriptAct_SetRandomScale_PreserveZ_Axis_2 = (bool) false;
   System.Boolean logic_uScriptAct_SetRandomScale_Uniform_2 = (bool) true;
   bool logic_uScriptAct_SetRandomScale_Out_2 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_1 = default(UnityEngine.GameObject);
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      if ( null == owner_Connection_3 || false == m_RegisteredForEvents )
      {
         owner_Connection_3 = parentGameObject;
      }
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
   }
   
   void SyncEventListeners( )
   {
      if ( null == event_UnityEngine_GameObject_Instance_1 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_1 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_1 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_1.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_1.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_1;
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != event_UnityEngine_GameObject_Instance_1 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_1.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_1;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_0.SetParent(g);
      logic_uScriptAct_SetRandomScale_uScriptAct_SetRandomScale_2.SetParent(g);
      owner_Connection_3 = parentGameObject;
   }
   public void Awake()
   {
      
   }
   
   public void Start()
   {
      SyncUnityHooks( );
      m_RegisteredForEvents = true;
      
   }
   
   public void OnEnable()
   {
      RegisterForUnityHooks( );
      m_RegisteredForEvents = true;
   }
   
   public void OnDisable()
   {
      UnregisterEventListeners( );
      m_RegisteredForEvents = false;
   }
   
   public void Update()
   {
      //reset each Update, and increments each method call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      if ( null != m_ContinueExecution )
      {
         ContinueExecution continueEx = m_ContinueExecution;
         m_ContinueExecution = null;
         m_Breakpoint = false;
         continueEx( );
         return;
      }
      UpdateEditorValues( );
      
      //other scripts might have added GameObjects with event scripts
      //so we need to verify all our event listeners are registered
      SyncEventListeners( );
      
   }
   
   public void OnDestroy()
   {
   }
   
   void Instance_KeyEvent_1(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_1( );
   }
   
   void Relay_In_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("68b21206-9a56-443a-974d-4a763fcf3fce", "Input_Events_Filter", Relay_In_0)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_0.In(logic_uScriptAct_OnInputEventFilter_KeyCode_0);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_0.KeyDown;
         
         if ( test_0 == true )
         {
            Relay_In_2();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SetScale.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_1()
   {
      if (true == CheckDebugBreak("e17b45ea-964e-4cce-8f86-c75a24f6d807", "Input_Events", Relay_KeyEvent_1)) return; 
      Relay_In_0();
   }
   
   void Relay_In_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c09cf152-1dc6-47c4-b270-cfb94109c04e", "Set_Random_Scale", Relay_In_2)) return; 
         {
            {
               int index = 0;
               if ( logic_uScriptAct_SetRandomScale_Target_2.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_SetRandomScale_Target_2, index + 1);
               }
               logic_uScriptAct_SetRandomScale_Target_2[ index++ ] = owner_Connection_3;
               
            }
            {
            }
            {
            }
            {
            }
            {
            }
            {
            }
            {
            }
            {
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SetRandomScale_uScriptAct_SetRandomScale_2.In(logic_uScriptAct_SetRandomScale_Target_2, logic_uScriptAct_SetRandomScale_MinX_2, logic_uScriptAct_SetRandomScale_MaxX_2, logic_uScriptAct_SetRandomScale_MinY_2, logic_uScriptAct_SetRandomScale_MaxY_2, logic_uScriptAct_SetRandomScale_MinZ_2, logic_uScriptAct_SetRandomScale_MaxZ_2, logic_uScriptAct_SetRandomScale_PreserveX_Axis_2, logic_uScriptAct_SetRandomScale_PreserveY_Axis_2, logic_uScriptAct_SetRandomScale_PreserveZ_Axis_2, logic_uScriptAct_SetRandomScale_Uniform_2);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SetScale.uscript at Set Random Scale.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
   }
   bool CheckDebugBreak(string guid, string name, ContinueExecution method)
   {
      if (true == m_Breakpoint) return true;
      
      if (true == uScript_MasterComponent.FindBreakpoint(guid))
      {
         if (uScript_MasterComponent.LatestMasterComponent.CurrentBreakpoint == guid)
         {
            uScript_MasterComponent.LatestMasterComponent.CurrentBreakpoint = "";
         }
         else
         {
            uScript_MasterComponent.LatestMasterComponent.CurrentBreakpoint = guid;
            UpdateEditorValues( );
            UnityEngine.Debug.Log("uScript BREAK Node:" + name + " ((Time: " + Time.time + "");
            UnityEngine.Debug.Break();
            #if (!UNITY_FLASH)
            m_ContinueExecution = new ContinueExecution(method);
            #endif
            m_Breakpoint = true;
            return true;
         }
      }
      return false;
   }
}
