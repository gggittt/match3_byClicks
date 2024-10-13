using _Project._Scripts._EditorTools.ToolbarButtons.Editor;
using UnityEditor;
using UnityEngine;

namespace _Project.Core.Pool.ToolbarButtons
{
//https://github.com/marijnz/unity-toolbar-extender
[InitializeOnLoad]
public class ToolbarLeftButtons
{
    static readonly GUIContent _bootBtn = new GUIContent( "boot", "Launch from Bootstrap scene" );
    static readonly GUIContent _gameBtn = new GUIContent( "game", "Launch from Gameplay scene" );

    static ToolbarLeftButtons( )
    {
        ToolbarExtender.LeftToolbarGUI.Add( OnToolbarGUI );
    }

    static void OnToolbarGUI( )
    {
        GUILayout.FlexibleSpace();

        if ( GUILayout.Button( _bootBtn, ToolbarStyles.CommandButtonStyle ) )
            SceneHelper.StartScene( "Bootstrap" );

        if ( GUILayout.Button( _gameBtn, ToolbarStyles.CommandButtonStyle ) )
        {
            SceneHelper.StartScene( "Gameplay" );
            Debug.LogWarning( $"<color=orange> loaded without ProjectContext! </color>" );
        }
    }
}
}