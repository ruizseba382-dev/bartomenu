# Barto Menu - source base v1.0

This is a source project, NOT a compiled plugin DLL.

## Included
- BepInEx 5 plugin entry point.
- PC menu toggle on Q.
- VR toggle on the right controller's primary button (A on common OpenXR mappings).
- Draggable Unity IMGUI window with Movement / Player / Settings tabs.

## Not implemented yet
WalkSim, Platforms, Invisible and Gun are deliberately marked as pending. They require inspection and integration with the exact Gorilla Tag game APIs. This starter does not claim those features work.

## Build
1. Put the supplied reference DLLs in `References/`:
   - BepInEx.dll
   - 0Harmony.dll
   - UnityEngine.CoreModule.dll
   - UnityEngine.IMGUIModule.dll
   - UnityEngine.InputLegacyModule.dll
   - UnityEngine.XRModule.dll
2. Build with the .NET Framework 4.7.2 targeting pack and a compatible MSBuild/.NET SDK:
   `dotnet build BartoMenu.csproj`
3. If successful, copy `bin/BartoMenu.dll` to:
   `Gorilla Tag/BepInEx/plugins/`

A compiler is required. Visual Studio IDE is not required, but a compatible .NET build toolchain is.

## Compatibility note
The A button mapping depends on the active VR runtime/controller profile. Verify it in-game. No multiplayer-disruptive features are included.
