using UnityEngine;

namespace PlayFab.PfEditor
{
    public class PlayFabEditorMenu : UnityEditor.Editor
    {
        #region panel variables
        internal enum MenuStates
        {
            Sdks = 0,
            Settings = 1,
            Data = 2,
            Help = 3,
            Tools = 4,
            Packages = 5,
            Logout = 6
        }

        internal static MenuStates _menuState = MenuStates.Sdks;
        #endregion

        public static void DrawMenu()
        {
            if (PlayFabEditorSDKTools.IsInstalled && PlayFabEditorSDKTools.isSdkSupported)
                _menuState = (MenuStates)PlayFabEditorPrefsSO.Instance.curMainMenuIdx;

            var sdksImageButtontyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton");
            var settingsImageButtontyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton");
            var dataImageButtontyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton");
            var helpImageButtontyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton");
            var logoutImageButtontyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton");
            var toolsImageButtontyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton");
            var packagesImageButtontyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton");

            if (_menuState == MenuStates.Sdks)
                sdksImageButtontyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton_selected");
            if (_menuState == MenuStates.Settings)
                settingsImageButtontyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton_selected");
            if (_menuState == MenuStates.Logout)
                logoutImageButtontyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton_selected");
            if (_menuState == MenuStates.Data)
                dataImageButtontyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton_selected");
            if (_menuState == MenuStates.Help)
                helpImageButtontyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton_selected");
            if (_menuState == MenuStates.Packages)
                packagesImageButtontyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton_selected");
            if (_menuState == MenuStates.Tools)
                toolsImageButtontyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton_selected");

            using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1"), GUILayout.Height(25), GUILayout.ExpandWidth(true)))
            {
                GUILayout.Space(5);

                if (GUILayout.Button("SDK", sdksImageButtontyle, GUILayout.MaxWidth(35)))
                {
                    OnSdKsClicked();
                }

                if (PlayFabEditorSDKTools.IsInstalled && PlayFabEditorSDKTools.isSdkSupported)
                {
                    if (GUILayout.Button("SETTINGS", settingsImageButtontyle, GUILayout.MaxWidth(65)))
                        OnSettingsClicked();
                    if (GUILayout.Button("DATA", dataImageButtontyle, GUILayout.MaxWidth(45)))
                        OnDataClicked();
                    if (GUILayout.Button("TOOLS", toolsImageButtontyle, GUILayout.MaxWidth(45)))
                        OnToolsClicked();
                    if(GUILayout.Button("PACKAGES", packagesImageButtontyle, GUILayout.MaxWidth(72)))
                        OnPackagesClicked();
                }

                if (GUILayout.Button("HELP", helpImageButtontyle, GUILayout.MaxWidth(45)))
                    OnHelpClicked();
                GUILayout.FlexibleSpace();

                if (GUILayout.Button("LOGOUT", logoutImageButtontyle, GUILayout.MaxWidth(55)))
                    OnLogoutClicked();
            }
        }

        public static void OnToolsClicked()
        {
            _menuState = MenuStates.Tools;
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnMenuItemClicked, MenuStates.Tools.ToString());
            PlayFabEditorPrefsSO.Instance.curMainMenuIdx = (int)_menuState;
        }

        public static void OnDataClicked()
        {
            _menuState = MenuStates.Data;
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnMenuItemClicked, MenuStates.Data.ToString());
            PlayFabEditorPrefsSO.Instance.curMainMenuIdx = (int)_menuState;
        }

        public static void OnHelpClicked()
        {
            _menuState = MenuStates.Help;
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnMenuItemClicked, MenuStates.Help.ToString());
            PlayFabEditorPrefsSO.Instance.curMainMenuIdx = (int)_menuState;
        }

        public static void OnSdKsClicked()
        {
            _menuState = MenuStates.Sdks;
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnMenuItemClicked, MenuStates.Sdks.ToString());
            PlayFabEditorPrefsSO.Instance.curMainMenuIdx = (int)_menuState;
        }

        public static void OnSettingsClicked()
        {
            _menuState = MenuStates.Settings;
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnMenuItemClicked, MenuStates.Settings.ToString());
            PlayFabEditorPrefsSO.Instance.curMainMenuIdx = (int)_menuState;
        }

        public static void OnPackagesClicked()
        {
            _menuState = MenuStates.Packages;
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnMenuItemClicked, MenuStates.Packages.ToString());
            PlayFabEditorPrefsSO.Instance.curMainMenuIdx = (int)_menuState;
        }

        public static void OnLogoutClicked()
        {
            _menuState = MenuStates.Logout;
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnMenuItemClicked, MenuStates.Logout.ToString());
            PlayFabEditorAuthenticate.Logout();

            _menuState = MenuStates.Sdks;
            PlayFabEditorPrefsSO.Instance.curMainMenuIdx = (int)_menuState;
        }
    }
}
