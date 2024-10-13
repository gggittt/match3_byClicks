using _Project._Scripts._EditorTools.ToolbarButtons.Editor;
using UnityEditor;
using UnityEngine;

namespace _Project.Core.Pool.ToolbarButtons
{
//https://github.com/marijnz/unity-toolbar-extender
[InitializeOnLoad]
public class ToolbarLeftButtons
{
    static readonly GUIContent _btn1 = new GUIContent( "boot", "Launch from Bootstrap scene" );

    static ToolbarLeftButtons( )
    {
        ToolbarExtender.LeftToolbarGUI.Add( OnToolbarGUI );
    }

    static void OnToolbarGUI( )
    {
        GUILayout.FlexibleSpace();

        if ( GUILayout.Button( _btn1, ToolbarStyles.CommandButtonStyle ) )
            SceneHelper.StartScene( "Bootstrap" );
    }
}
}