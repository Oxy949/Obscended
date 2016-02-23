//uScript Generated Code - Build 1.0.3024
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("Untitled", "")]
public class RemoveAfterInteraction : uScriptLogic
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
   public UnityEngine.Sprite D1Sprite = default(UnityEngine.Sprite);
   UnityEngine.GameObject local_Scene_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_Scene_UnityEngine_GameObject_previous = null;
   
   //owner nodes
   UnityEngine.GameObject owner_Connection_0 = null;
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_5 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_5 = UnityEngine.KeyCode.A;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_5 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_5 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_5 = true;
   //pointer to script instanced logic node
   uScriptAct_SetActive logic_uScriptAct_SetActive_uScriptAct_SetActive_7 = new uScriptAct_SetActive( );
   UnityEngine.GameObject logic_uScriptAct_SetActive_Target_7 = default(UnityEngine.GameObject);
   System.Boolean logic_uScriptAct_SetActive_IsActive_7 = (bool) false;
   bool logic_uScriptAct_SetActive_Out_7 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_4 = default(UnityEngine.GameObject);
   
   //property nodes
   
   //method nodes
   System.String method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_text_1 = "Lal";
   System.String method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_buttontext_1 = "lol";
   System.String method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_tag_2 = "Scene";
   UnityEngine.GameObject method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_Return_2 = default(UnityEngine.GameObject);
   System.String method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_text_8 = "dsffdsf";
   System.String method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_buttontext_8 = "sdfdsfsdfsdfsdf";
   System.String method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_text_9 = "sdfsdfsdf";
   System.String method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_senderName_9 = "dsfsdfsdfdsf";
   UnityEngine.Sprite method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_senderImage_9 = default(UnityEngine.Sprite);
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_Scene_UnityEngine_GameObject_previous != local_Scene_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_Scene_UnityEngine_GameObject_previous = local_Scene_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == owner_Connection_0 || false == m_RegisteredForEvents )
      {
         owner_Connection_0 = parentGameObject;
         if ( null != owner_Connection_0 )
         {
            {
               InteractableObject component = owner_Connection_0.GetComponent<InteractableObject>();
               if ( null != component )
               {
                  component.ObjectNear += Instance_ObjectNear_6;
                  component.InteractionStarted += Instance_InteractionStarted_6;
                  component.InteractionFinished += Instance_InteractionFinished_6;
               }
            }
         }
      }
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_Scene_UnityEngine_GameObject_previous != local_Scene_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_Scene_UnityEngine_GameObject_previous = local_Scene_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //reset event listeners if needed
      //this isn't a variable node so it should only be called once per enabling of the script
      //if it's called twice there would be a double event registration (which is an error)
      if ( false == m_RegisteredForEvents )
      {
         if ( null != owner_Connection_0 )
         {
            {
               InteractableObject component = owner_Connection_0.GetComponent<InteractableObject>();
               if ( null != component )
               {
                  component.ObjectNear += Instance_ObjectNear_6;
                  component.InteractionStarted += Instance_InteractionStarted_6;
                  component.InteractionFinished += Instance_InteractionFinished_6;
               }
            }
         }
      }
   }
   
   void SyncEventListeners( )
   {
      if ( null == event_UnityEngine_GameObject_Instance_4 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_4 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_4 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_4.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_4.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_4;
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != owner_Connection_0 )
      {
         {
            InteractableObject component = owner_Connection_0.GetComponent<InteractableObject>();
            if ( null != component )
            {
               component.ObjectNear -= Instance_ObjectNear_6;
               component.InteractionStarted -= Instance_InteractionStarted_6;
               component.InteractionFinished -= Instance_InteractionFinished_6;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_4 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_4.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_4;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_5.SetParent(g);
      logic_uScriptAct_SetActive_uScriptAct_SetActive_7.SetParent(g);
      owner_Connection_0 = parentGameObject;
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
   
   void Instance_KeyEvent_4(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_4( );
   }
   
   void Instance_ObjectNear_6(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_ObjectNear_6( );
   }
   
   void Instance_InteractionStarted_6(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_InteractionStarted_6( );
   }
   
   void Instance_InteractionFinished_6(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_InteractionFinished_6( );
   }
   
   void Relay_AddMessage_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3b0cc47c-b906-4dc1-b662-b5c88d2200bb", "NotesSystem", Relay_AddMessage_1)) return; 
         {
            {
            }
            {
            }
         }
         {
            NotesSystem component;
            component = local_Scene_UnityEngine_GameObject.GetComponent<NotesSystem>();
            if ( null != component )
            {
               component.AddMessage(method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_text_1, method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_buttontext_1);
            }
         }
         Relay_AddMessage_8();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript RemoveAfterInteraction.uscript at NotesSystem.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_FindGameObjectWithTag_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a3a78b9f-2c6c-47b1-adf8-ea93cc66c673", "UnityEngine_GameObject", Relay_FindGameObjectWithTag_2)) return; 
         {
            {
            }
            {
            }
         }
         method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_Return_2 = UnityEngine.GameObject.FindGameObjectWithTag(method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_tag_2);
         local_Scene_UnityEngine_GameObject = method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_Return_2;
         {
            //if our game object reference was changed then we need to reset event listeners
            if ( local_Scene_UnityEngine_GameObject_previous != local_Scene_UnityEngine_GameObject || false == m_RegisteredForEvents )
            {
               //tear down old listeners
               
               local_Scene_UnityEngine_GameObject_previous = local_Scene_UnityEngine_GameObject;
               
               //setup new listeners
            }
         }
         Relay_AddMessage_1();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript RemoveAfterInteraction.uscript at UnityEngine.GameObject.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_4()
   {
      if (true == CheckDebugBreak("a249b081-58db-4994-b979-04a28d2108cf", "Input_Events", Relay_KeyEvent_4)) return; 
      Relay_In_5();
   }
   
   void Relay_In_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b624bbb9-c71b-409e-b8e6-5c8a2ac4aac8", "Input_Events_Filter", Relay_In_5)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_5.In(logic_uScriptAct_OnInputEventFilter_KeyCode_5);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript RemoveAfterInteraction.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ObjectNear_6()
   {
      if (true == CheckDebugBreak("ae6078ff-ddc7-4260-9346-1dc75b76f1f9", "InteractableObject", Relay_ObjectNear_6)) return; 
   }
   
   void Relay_InteractionStarted_6()
   {
      if (true == CheckDebugBreak("ae6078ff-ddc7-4260-9346-1dc75b76f1f9", "InteractableObject", Relay_InteractionStarted_6)) return; 
   }
   
   void Relay_InteractionFinished_6()
   {
      if (true == CheckDebugBreak("ae6078ff-ddc7-4260-9346-1dc75b76f1f9", "InteractableObject", Relay_InteractionFinished_6)) return; 
      Relay_FindGameObjectWithTag_2();
   }
   
   void Relay_In_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e63a89f1-e340-4b2b-b7f1-688399a8d690", "Set_Active", Relay_In_7)) return; 
         {
            {
               logic_uScriptAct_SetActive_Target_7 = owner_Connection_0;
               
            }
            {
            }
         }
         logic_uScriptAct_SetActive_uScriptAct_SetActive_7.In(logic_uScriptAct_SetActive_Target_7, logic_uScriptAct_SetActive_IsActive_7);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript RemoveAfterInteraction.uscript at Set Active.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_AddMessage_8()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e288dcce-6df4-445d-9867-437560c4d9c6", "NotesSystem", Relay_AddMessage_8)) return; 
         {
            {
            }
            {
            }
         }
         {
            NotesSystem component;
            component = local_Scene_UnityEngine_GameObject.GetComponent<NotesSystem>();
            if ( null != component )
            {
               component.AddMessage(method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_text_8, method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_buttontext_8);
            }
         }
         Relay_AddMessage_9();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript RemoveAfterInteraction.uscript at NotesSystem.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_AddMessage_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9a034d62-1793-4543-8c9b-666341bc30bf", "DialogueSystem", Relay_AddMessage_9)) return; 
         {
            {
            }
            {
            }
            {
               method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_senderImage_9 = D1Sprite;
               
            }
         }
         {
            DialogueSystem component;
            component = local_Scene_UnityEngine_GameObject.GetComponent<DialogueSystem>();
            if ( null != component )
            {
               component.AddMessage(method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_text_9, method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_senderName_9, method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_senderImage_9);
            }
         }
         Relay_In_7();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript RemoveAfterInteraction.uscript at DialogueSystem.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "RemoveAfterInteraction.uscript:Scene", local_Scene_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "73dd65ad-227d-4186-a9f8-bb6a03f24824", local_Scene_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "RemoveAfterInteraction.uscript:D1Sprite", D1Sprite);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "9353c686-664d-4ffa-8f6c-e2cd15c21196", D1Sprite);
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
