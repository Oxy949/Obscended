//uScript Generated Code - Build 1.0.3024
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("Untitled", "")]
public class Room1Scene : uScriptLogic
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
   public UnityEngine.GameObject lever = default(UnityEngine.GameObject);
   UnityEngine.GameObject lever_previous = null;
   UnityEngine.Sprite local_16_UnityEngine_Sprite = default(UnityEngine.Sprite);
   public UnityEngine.GameObject tile = default(UnityEngine.GameObject);
   UnityEngine.GameObject tile_previous = null;
   
   //owner nodes
   UnityEngine.GameObject owner_Connection_6 = null;
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_SetActive logic_uScriptAct_SetActive_uScriptAct_SetActive_3 = new uScriptAct_SetActive( );
   UnityEngine.GameObject logic_uScriptAct_SetActive_Target_3 = default(UnityEngine.GameObject);
   System.Boolean logic_uScriptAct_SetActive_IsActive_3 = (bool) false;
   bool logic_uScriptAct_SetActive_Out_3 = true;
   //pointer to script instanced logic node
   uScriptAct_Rotate logic_uScriptAct_Rotate_uScriptAct_Rotate_4 = new uScriptAct_Rotate( );
   UnityEngine.GameObject[] logic_uScriptAct_Rotate_Target_4 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_Rotate_Degrees_4 = (float) 180;
   System.String logic_uScriptAct_Rotate_Axis_4 = "z";
   System.Single logic_uScriptAct_Rotate_Seconds_4 = (float) 0.1;
   System.Boolean logic_uScriptAct_Rotate_Loop_4 = (bool) false;
   bool logic_uScriptAct_Rotate_Out_4 = true;
   //pointer to script instanced logic node
   uScriptAct_LoadSprite logic_uScriptAct_LoadSprite_uScriptAct_LoadSprite_7 = new uScriptAct_LoadSprite( );
   System.String logic_uScriptAct_LoadSprite_name_7 = "Gfx/Hero/dialogue";
   System.Boolean logic_uScriptAct_LoadSprite_isMultiple_7 = (bool) true;
   System.Int32 logic_uScriptAct_LoadSprite_multipleIndex_7 = (int) 2;
   UnityEngine.Sprite logic_uScriptAct_LoadSprite_textureFile_7;
   bool logic_uScriptAct_LoadSprite_Out_7 = true;
   
   //event nodes
   
   //property nodes
   
   //method nodes
   System.String method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_text_5 = "Я ушла в закат";
   System.String method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_senderName_5 = "Крутая телка";
   UnityEngine.Sprite method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_senderImage_5 = default(UnityEngine.Sprite);
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( lever_previous != lever || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != lever_previous )
         {
            {
               InteractableObject component = lever_previous.GetComponent<InteractableObject>();
               if ( null != component )
               {
                  component.ObjectNear -= Instance_ObjectNear_2;
                  component.InteractionStarted -= Instance_InteractionStarted_2;
                  component.InteractionFinished -= Instance_InteractionFinished_2;
               }
            }
         }
         
         lever_previous = lever;
         
         //setup new listeners
         if ( null != lever )
         {
            {
               InteractableObject component = lever.GetComponent<InteractableObject>();
               if ( null != component )
               {
                  component.ObjectNear += Instance_ObjectNear_2;
                  component.InteractionStarted += Instance_InteractionStarted_2;
                  component.InteractionFinished += Instance_InteractionFinished_2;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( tile_previous != tile || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         tile_previous = tile;
         
         //setup new listeners
      }
      if ( null == owner_Connection_6 || false == m_RegisteredForEvents )
      {
         owner_Connection_6 = parentGameObject;
      }
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( lever_previous != lever || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != lever_previous )
         {
            {
               InteractableObject component = lever_previous.GetComponent<InteractableObject>();
               if ( null != component )
               {
                  component.ObjectNear -= Instance_ObjectNear_2;
                  component.InteractionStarted -= Instance_InteractionStarted_2;
                  component.InteractionFinished -= Instance_InteractionFinished_2;
               }
            }
         }
         
         lever_previous = lever;
         
         //setup new listeners
         if ( null != lever )
         {
            {
               InteractableObject component = lever.GetComponent<InteractableObject>();
               if ( null != component )
               {
                  component.ObjectNear += Instance_ObjectNear_2;
                  component.InteractionStarted += Instance_InteractionStarted_2;
                  component.InteractionFinished += Instance_InteractionFinished_2;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( tile_previous != tile || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         tile_previous = tile;
         
         //setup new listeners
      }
   }
   
   void SyncEventListeners( )
   {
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != lever )
      {
         {
            InteractableObject component = lever.GetComponent<InteractableObject>();
            if ( null != component )
            {
               component.ObjectNear -= Instance_ObjectNear_2;
               component.InteractionStarted -= Instance_InteractionStarted_2;
               component.InteractionFinished -= Instance_InteractionFinished_2;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_SetActive_uScriptAct_SetActive_3.SetParent(g);
      logic_uScriptAct_Rotate_uScriptAct_Rotate_4.SetParent(g);
      logic_uScriptAct_LoadSprite_uScriptAct_LoadSprite_7.SetParent(g);
      owner_Connection_6 = parentGameObject;
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
      
      logic_uScriptAct_Rotate_uScriptAct_Rotate_4.Update( );
   }
   
   public void OnDestroy()
   {
   }
   
   void Instance_ObjectNear_2(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_ObjectNear_2( );
   }
   
   void Instance_InteractionStarted_2(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_InteractionStarted_2( );
   }
   
   void Instance_InteractionFinished_2(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_InteractionFinished_2( );
   }
   
   void Relay_ObjectNear_2()
   {
      if (true == CheckDebugBreak("c7149ee5-92ab-45e8-8524-fe2c92320eea", "InteractableObject", Relay_ObjectNear_2)) return; 
   }
   
   void Relay_InteractionStarted_2()
   {
      if (true == CheckDebugBreak("c7149ee5-92ab-45e8-8524-fe2c92320eea", "InteractableObject", Relay_InteractionStarted_2)) return; 
   }
   
   void Relay_InteractionFinished_2()
   {
      if (true == CheckDebugBreak("c7149ee5-92ab-45e8-8524-fe2c92320eea", "InteractableObject", Relay_InteractionFinished_2)) return; 
      Relay_In_3();
   }
   
   void Relay_In_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f0768e42-f8f4-44a5-8f1f-bda80b371490", "Set_Active", Relay_In_3)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( tile_previous != tile || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     tile_previous = tile;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_SetActive_Target_3 = tile;
               
            }
            {
            }
         }
         logic_uScriptAct_SetActive_uScriptAct_SetActive_3.In(logic_uScriptAct_SetActive_Target_3, logic_uScriptAct_SetActive_IsActive_3);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetActive_uScriptAct_SetActive_3.Out;
         
         if ( test_0 == true )
         {
            Relay_In_4();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Room1Scene.uscript at Set Active.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_4()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("246f0388-95ec-490d-8687-559d5df66572", "Rotate", Relay_In_4)) return; 
         {
            {
               int index = 0;
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( lever_previous != lever || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     if ( null != lever_previous )
                     {
                        {
                           InteractableObject component = lever_previous.GetComponent<InteractableObject>();
                           if ( null != component )
                           {
                              component.ObjectNear -= Instance_ObjectNear_2;
                              component.InteractionStarted -= Instance_InteractionStarted_2;
                              component.InteractionFinished -= Instance_InteractionFinished_2;
                           }
                        }
                     }
                     
                     lever_previous = lever;
                     
                     //setup new listeners
                     if ( null != lever )
                     {
                        {
                           InteractableObject component = lever.GetComponent<InteractableObject>();
                           if ( null != component )
                           {
                              component.ObjectNear += Instance_ObjectNear_2;
                              component.InteractionStarted += Instance_InteractionStarted_2;
                              component.InteractionFinished += Instance_InteractionFinished_2;
                           }
                        }
                     }
                  }
               }
               if ( logic_uScriptAct_Rotate_Target_4.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_Rotate_Target_4, index + 1);
               }
               logic_uScriptAct_Rotate_Target_4[ index++ ] = lever;
               
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
         logic_uScriptAct_Rotate_uScriptAct_Rotate_4.In(logic_uScriptAct_Rotate_Target_4, logic_uScriptAct_Rotate_Degrees_4, logic_uScriptAct_Rotate_Axis_4, logic_uScriptAct_Rotate_Seconds_4, logic_uScriptAct_Rotate_Loop_4);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Rotate_uScriptAct_Rotate_4.Out;
         
         if ( test_0 == true )
         {
            Relay_In_7();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Room1Scene.uscript at Rotate.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_AddMessage_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("03beb78a-13f5-4e23-aa77-e020c8562661", "DialogueSystem", Relay_AddMessage_5)) return; 
         {
            {
            }
            {
            }
            {
               method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_senderImage_5 = local_16_UnityEngine_Sprite;
               
            }
         }
         {
            DialogueSystem component;
            component = owner_Connection_6.GetComponent<DialogueSystem>();
            if ( null != component )
            {
               component.AddMessage(method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_text_5, method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_senderName_5, method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_senderImage_5);
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Room1Scene.uscript at DialogueSystem.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("965dc7f9-ce7c-45c8-97e5-c02f48faa870", "Load_Sprite", Relay_In_7)) return; 
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
         logic_uScriptAct_LoadSprite_uScriptAct_LoadSprite_7.In(logic_uScriptAct_LoadSprite_name_7, logic_uScriptAct_LoadSprite_isMultiple_7, logic_uScriptAct_LoadSprite_multipleIndex_7, out logic_uScriptAct_LoadSprite_textureFile_7);
         local_16_UnityEngine_Sprite = logic_uScriptAct_LoadSprite_textureFile_7;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_LoadSprite_uScriptAct_LoadSprite_7.Out;
         
         if ( test_0 == true )
         {
            Relay_AddMessage_5();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Room1Scene.uscript at Load Sprite.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Room1Scene.uscript:lever", lever);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "4025843f-9dda-4047-939b-8cd2dfd28c97", lever);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Room1Scene.uscript:tile", tile);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "4d46f17c-71e6-4b67-9b73-5dc28b019d43", tile);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Room1Scene.uscript:16", local_16_UnityEngine_Sprite);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "f7b3af78-f951-4e2f-9be4-493465eb0bbf", local_16_UnityEngine_Sprite);
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
