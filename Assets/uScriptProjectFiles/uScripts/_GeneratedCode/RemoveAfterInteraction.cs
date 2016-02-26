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
   UnityEngine.Sprite local_HeroHappySprite_UnityEngine_Sprite = default(UnityEngine.Sprite);
   UnityEngine.GameObject local_Scene_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_Scene_UnityEngine_GameObject_previous = null;
   
   //owner nodes
   UnityEngine.GameObject owner_Connection_0 = null;
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_4 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_4 = UnityEngine.KeyCode.A;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_4 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_4 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_4 = true;
   //pointer to script instanced logic node
   uScriptAct_SetActive logic_uScriptAct_SetActive_uScriptAct_SetActive_6 = new uScriptAct_SetActive( );
   UnityEngine.GameObject logic_uScriptAct_SetActive_Target_6 = default(UnityEngine.GameObject);
   System.Boolean logic_uScriptAct_SetActive_IsActive_6 = (bool) false;
   bool logic_uScriptAct_SetActive_Out_6 = true;
   //pointer to script instanced logic node
   uScriptAct_LoadSprite logic_uScriptAct_LoadSprite_uScriptAct_LoadSprite_9 = new uScriptAct_LoadSprite( );
   System.String logic_uScriptAct_LoadSprite_name_9 = "Gfx/Hero/dialogue";
   System.Boolean logic_uScriptAct_LoadSprite_isMultiple_9 = (bool) true;
   System.Int32 logic_uScriptAct_LoadSprite_multipleIndex_9 = (int) 0;
   UnityEngine.Sprite logic_uScriptAct_LoadSprite_textureFile_9;
   bool logic_uScriptAct_LoadSprite_Out_9 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_3 = default(UnityEngine.GameObject);
   
   //property nodes
   
   //method nodes
   System.String method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_tag_1 = "Scene";
   UnityEngine.GameObject method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_Return_1 = default(UnityEngine.GameObject);
   System.String method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_text_7 = "выавыа а ыва ыва ыва ывавы а ыв аыв аыв авы авы аы ва ыв аыв авыаываыва ыв аыв авыа ыва ывавыа выаыв аы ва ыв а  выаываываыва выаыва ываыв ава ыв аа ыв аыв ";
   System.String method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_senderName_7 = "Главный Герой";
   UnityEngine.Sprite method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_senderImage_7 = default(UnityEngine.Sprite);
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
                  component.ObjectNear += Instance_ObjectNear_5;
                  component.InteractionStarted += Instance_InteractionStarted_5;
                  component.InteractionFinished += Instance_InteractionFinished_5;
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
                  component.ObjectNear += Instance_ObjectNear_5;
                  component.InteractionStarted += Instance_InteractionStarted_5;
                  component.InteractionFinished += Instance_InteractionFinished_5;
               }
            }
         }
      }
   }
   
   void SyncEventListeners( )
   {
      if ( null == event_UnityEngine_GameObject_Instance_3 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_3 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_3 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_3.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_3.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_3;
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
               component.ObjectNear -= Instance_ObjectNear_5;
               component.InteractionStarted -= Instance_InteractionStarted_5;
               component.InteractionFinished -= Instance_InteractionFinished_5;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_3 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_3.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_3;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_4.SetParent(g);
      logic_uScriptAct_SetActive_uScriptAct_SetActive_6.SetParent(g);
      logic_uScriptAct_LoadSprite_uScriptAct_LoadSprite_9.SetParent(g);
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
   
   void Instance_KeyEvent_3(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_3( );
   }
   
   void Instance_ObjectNear_5(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_ObjectNear_5( );
   }
   
   void Instance_InteractionStarted_5(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_InteractionStarted_5( );
   }
   
   void Instance_InteractionFinished_5(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_InteractionFinished_5( );
   }
   
   void Relay_FindGameObjectWithTag_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a3a78b9f-2c6c-47b1-adf8-ea93cc66c673", "UnityEngine_GameObject", Relay_FindGameObjectWithTag_1)) return; 
         {
            {
            }
            {
            }
         }
         method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_Return_1 = UnityEngine.GameObject.FindGameObjectWithTag(method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_tag_1);
         local_Scene_UnityEngine_GameObject = method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_Return_1;
         {
            //if our game object reference was changed then we need to reset event listeners
            if ( local_Scene_UnityEngine_GameObject_previous != local_Scene_UnityEngine_GameObject || false == m_RegisteredForEvents )
            {
               //tear down old listeners
               
               local_Scene_UnityEngine_GameObject_previous = local_Scene_UnityEngine_GameObject;
               
               //setup new listeners
            }
         }
         Relay_In_9();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript RemoveAfterInteraction.uscript at UnityEngine.GameObject.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_3()
   {
      if (true == CheckDebugBreak("a249b081-58db-4994-b979-04a28d2108cf", "Input_Events", Relay_KeyEvent_3)) return; 
      Relay_In_4();
   }
   
   void Relay_In_4()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b624bbb9-c71b-409e-b8e6-5c8a2ac4aac8", "Input_Events_Filter", Relay_In_4)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_4.In(logic_uScriptAct_OnInputEventFilter_KeyCode_4);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript RemoveAfterInteraction.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ObjectNear_5()
   {
      if (true == CheckDebugBreak("ae6078ff-ddc7-4260-9346-1dc75b76f1f9", "InteractableObject", Relay_ObjectNear_5)) return; 
   }
   
   void Relay_InteractionStarted_5()
   {
      if (true == CheckDebugBreak("ae6078ff-ddc7-4260-9346-1dc75b76f1f9", "InteractableObject", Relay_InteractionStarted_5)) return; 
   }
   
   void Relay_InteractionFinished_5()
   {
      if (true == CheckDebugBreak("ae6078ff-ddc7-4260-9346-1dc75b76f1f9", "InteractableObject", Relay_InteractionFinished_5)) return; 
      Relay_FindGameObjectWithTag_1();
   }
   
   void Relay_In_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e63a89f1-e340-4b2b-b7f1-688399a8d690", "Set_Active", Relay_In_6)) return; 
         {
            {
               logic_uScriptAct_SetActive_Target_6 = owner_Connection_0;
               
            }
            {
            }
         }
         logic_uScriptAct_SetActive_uScriptAct_SetActive_6.In(logic_uScriptAct_SetActive_Target_6, logic_uScriptAct_SetActive_IsActive_6);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript RemoveAfterInteraction.uscript at Set Active.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_AddMessage_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9a034d62-1793-4543-8c9b-666341bc30bf", "DialogueSystem", Relay_AddMessage_7)) return; 
         {
            {
            }
            {
            }
            {
               method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_senderImage_7 = local_HeroHappySprite_UnityEngine_Sprite;
               
            }
         }
         {
            DialogueSystem component;
            component = local_Scene_UnityEngine_GameObject.GetComponent<DialogueSystem>();
            if ( null != component )
            {
               component.AddMessage(method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_text_7, method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_senderName_7, method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_senderImage_7);
            }
         }
         Relay_In_6();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript RemoveAfterInteraction.uscript at DialogueSystem.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("551b1880-d84b-4f29-b84c-7d0eea8de286", "Load_Sprite", Relay_In_9)) return; 
         {
            {
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_LoadSprite_uScriptAct_LoadSprite_9.In(logic_uScriptAct_LoadSprite_name_9, logic_uScriptAct_LoadSprite_isMultiple_9, logic_uScriptAct_LoadSprite_multipleIndex_9, out logic_uScriptAct_LoadSprite_textureFile_9);
         local_HeroHappySprite_UnityEngine_Sprite = logic_uScriptAct_LoadSprite_textureFile_9;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_LoadSprite_uScriptAct_LoadSprite_9.Out;
         
         if ( test_0 == true )
         {
            Relay_AddMessage_7();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript RemoveAfterInteraction.uscript at Load Sprite.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "RemoveAfterInteraction.uscript:Scene", local_Scene_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "73dd65ad-227d-4186-a9f8-bb6a03f24824", local_Scene_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "RemoveAfterInteraction.uscript:HeroHappySprite", local_HeroHappySprite_UnityEngine_Sprite);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "9353c686-664d-4ffa-8f6c-e2cd15c21196", local_HeroHappySprite_UnityEngine_Sprite);
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
