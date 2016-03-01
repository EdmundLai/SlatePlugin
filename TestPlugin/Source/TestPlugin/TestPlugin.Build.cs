// Copyright 1998-2015 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.IO; //·����ȡ��Ҫ�õ�IO

public class TestPlugin : ModuleRules
{
    private string ModulePath //��ǰTestPlugin.Build.cs�ļ����ڵ�·��
    {
        get { return Path.GetDirectoryName(RulesCompiler.GetModuleFilename(this.GetType().Name)); }
    }

    private string ThirdPartyPath
    {
        get { return Path.GetFullPath(Path.Combine(ModulePath, "../../ThirdParty/")); }
    }

    private string TestPluginPath
    {
        get { return Path.GetFullPath(Path.Combine(ThirdPartyPath, "TestPlugin")); }
    }

    public TestPlugin(TargetInfo Target)
	{
        PublicIncludePaths.AddRange( //�����ļ�����·��
			new string[] {
				"TestPlugin/Public"
				// ... add public include paths required here ...
			}
			);
				
		
		PrivateIncludePaths.AddRange(
			new string[] {
				"TestPlugin/Private" //˽���ļ�����·��
				// ... add other private include paths required here ...
			}
            );
			
		
		PublicDependencyModuleNames.AddRange(
			new string[]
			{
				"Core"
				// ... add other public dependencies that you statically link with here ...
			}
			);
			
		
		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				"CoreUObject",
				"Engine",
				"Slate",
				"SlateCore",
				// ... add private dependencies that you statically link with here ...	
			}
			);
		
		
		DynamicallyLoadedModuleNames.AddRange(
			new string[]
			{
				// ... add any modules that your module loads dynamically here ...
			}
			);

        LoadLib(Target);
    }

    public bool LoadLib(TargetInfo Target)
    {
        bool isLibrarySupported = false;
        if ((Target.Platform == UnrealTargetPlatform.Win64) || (Target.Platform == UnrealTargetPlatform.Win32))
        {
            isLibrarySupported = true;
            System.Console.WriteLine("----- isLibrarySupported true");
            string PlatformSubPath = (Target.Platform == UnrealTargetPlatform.Win64) ? "Win64" : "Win32";
            string LibrariesPath = Path.Combine(TestPluginPath, "Lib");
            PublicAdditionalLibraries.Add(Path.Combine(LibrariesPath, PlatformSubPath, "TestLib.lib"));
        }

        if (isLibrarySupported)
        {
            // Include path
            System.Console.WriteLine("----- PublicIncludePaths.Add true"); 
            PublicIncludePaths.Add(Path.Combine(ThirdPartyPath, "TestPlugin", "Include"));
        }
        return isLibrarySupported;
    }
}
