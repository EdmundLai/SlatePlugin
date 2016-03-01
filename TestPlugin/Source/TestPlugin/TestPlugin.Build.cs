// Copyright 1998-2015 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.IO; //路径获取需要用到IO

public class TestPlugin : ModuleRules
{
    private string ModulePath //当前TestPlugin.Build.cs文件所在的路径
    {
        get { return Path.GetDirectoryName(RulesCompiler.GetModuleFilename(this.GetType().Name)); }
    }

    private string ThirdPartyPath //这个插件引用的第三方库的目录
    {
        get { return Path.GetFullPath(Path.Combine(ModulePath, "../../ThirdParty/")); }
    }

    private string MyTestLibPath //第三方库MyTestLib的目录
    {
        get { return Path.GetFullPath(Path.Combine(ThirdPartyPath, "MyTestLib")); }
    }

    public TestPlugin(TargetInfo Target)
	{
        PublicIncludePaths.AddRange( //公有文件搜索路径
			new string[] {
				"TestPlugin/Public"
				// ... add public include paths required here ...
			}
			);
				
		
		PrivateIncludePaths.AddRange(
			new string[] {
				"TestPlugin/Private" //私有文件搜索路径
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

        LoadThirdPartyLib(Target); //加载第三方库
    }

    public bool LoadThirdPartyLib(TargetInfo Target)
    {
        bool isLibrarySupported = false;
        if ((Target.Platform == UnrealTargetPlatform.Win64) || (Target.Platform == UnrealTargetPlatform.Win32))//平台判断
        {
            isLibrarySupported = true;
            System.Console.WriteLine("----- isLibrarySupported true");
            string PlatformSubPath = (Target.Platform == UnrealTargetPlatform.Win64) ? "Win64" : "Win32";
            string LibrariesPath = Path.Combine(MyTestLibPath, "Lib");
            PublicAdditionalLibraries.Add(Path.Combine(LibrariesPath, PlatformSubPath, "TestLib.lib"));//加载第三方静态库.lib
        }

        if (isLibrarySupported) //成功加载库的情况下，包含第三方库的头文件
        {
            // Include path
            System.Console.WriteLine("----- PublicIncludePaths.Add true"); 
            PublicIncludePaths.Add(Path.Combine(MyTestLibPath, "Include"));
        }
        return isLibrarySupported;
    }
}
