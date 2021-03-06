// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Assets")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Loads a Sprite")]
[NodeAuthor("Oxy949", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Load Sprite", "Loads a Sprite file from your Resources directory.")]
public class uScriptAct_LoadSprite : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Asset Path", "The Sprite file to load.  The supported file formats are: \"psd\", \"tiff\", \"jpg\", \"tga\", \"png\", \"gif\", \"bmp\", \"iff\", and \"pict\"")]
      string name,

      [FriendlyName("Is Multiple", "")]
      bool isMultiple,

      [FriendlyName("Multiple index", "")]
      int multipleIndex,

      [FriendlyName("Loaded Asset", "The Sprite loaded from the specified file path.")]
      out Sprite textureFile
   )
   {
   	  if (isMultiple)
		textureFile = Resources.LoadAll<Sprite>(name)[multipleIndex] as Sprite;
   	  else
        textureFile = Resources.Load<Sprite>(name);

      if ( null == textureFile )
      {
         uScriptDebug.Log( "Asset " + name + " couldn't be loaded, are you sure it's in a Resources folder?", uScriptDebug.Type.Warning );
      }
   }

   
#if UNITY_EDITOR
   public override Hashtable EditorDragDrop( object o )
   {
      if ( typeof(Sprite).IsAssignableFrom( o.GetType() ) )
      {
         Sprite ac = (Sprite)o;

         string path = UnityEditor.AssetDatabase.GetAssetPath( ac.GetInstanceID( ) );

         int index = path.IndexOf( "Resources/" );
         
         if ( index > 0 )
         {
            path = path.Substring( index + "Resources/".Length );

            int dot = path.LastIndexOf( '.' );
            if ( dot >= 0 ) path = path.Substring( 0, dot );

            Hashtable hashtable = new Hashtable( );
            hashtable[ "name" ] = path;

            return hashtable;
         }
      }

      return null;
   }
#endif
}