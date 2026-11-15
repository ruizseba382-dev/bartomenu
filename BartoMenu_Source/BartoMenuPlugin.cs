using BepInEx;
using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

namespace BartoMenu
{
    [BepInPlugin("seba.bartomenu", "Barto Menu", "1.0.0")]
    public class BartoMenuPlugin : BaseUnityPlugin
    {
        private bool menuOpen;
        private bool previousRightPrimary;
        private Rect windowRect = new Rect(40f, 40f, 330f, 390f);
        private int selectedTab;

        private readonly string[] tabs = { "MOVEMENT", "PLAYER", "SETTINGS" };

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                menuOpen = !menuOpen;

            bool rightPrimary = IsRightPrimaryPressed();
            if (rightPrimary && !previousRightPrimary)
                menuOpen = !menuOpen;

            previousRightPrimary = rightPrimary;
        }

        private bool IsRightPrimaryPressed()
        {
            try
            {
                var devices = new List<InputDevice>();
                InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);

                for (int i = 0; i < devices.Count; i++)
                {
                    bool pressed;
                    if (devices[i].isValid &&
                        devices[i].TryGetFeatureValue(CommonUsages.primaryButton, out pressed))
                        return pressed;
                }
            }
            catch
            {
                // XR may not be initialized when the game starts.
            }

            return false;
        }

        private void OnGUI()
        {
            if (!menuOpen)
                return;

            windowRect = GUI.Window(741902, windowRect, DrawWindow, "BARTO MENU  |  v1.0");
        }

        private void DrawWindow(int id)
        {
            GUILayout.Space(4);
            GUILayout.BeginHorizontal();
            for (int i = 0; i < tabs.Length; i++)
            {
                if (GUILayout.Toggle(selectedTab == i, tabs[i], GUI.skin.button))
                    selectedTab = i;
            }
            GUILayout.EndHorizontal();

            GUILayout.Space(12);

            if (selectedTab == 0)
            {
                GUILayout.Label("MOVEMENT");
                GUILayout.Label("WalkSim: pendiente de integrar con la API del juego.");
                GUILayout.Label("Platforms: pendiente de integrar con la API del juego.");
            }
            else if (selectedTab == 1)
            {
                GUILayout.Label("PLAYER");
                GUILayout.Label("Invisible: no implementado en esta version.");
                GUILayout.Label("Gun: no implementado en esta version.");
            }
            else
            {
                GUILayout.Label("SETTINGS");
                GUILayout.Label("PC: Q para abrir/cerrar.");
                GUILayout.Label("VR: boton primario del mando derecho (A).");
                GUILayout.Label("Arrastra esta barra para mover el menu.");
            }

            GUILayout.FlexibleSpace();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Barto Menu - interfaz base");
            if (GUILayout.Button("CERRAR", GUILayout.Width(90)))
                menuOpen = false;
            GUILayout.EndHorizontal();

            GUI.DragWindow(new Rect(0, 0, 10000, 24));
        }
    }
}
