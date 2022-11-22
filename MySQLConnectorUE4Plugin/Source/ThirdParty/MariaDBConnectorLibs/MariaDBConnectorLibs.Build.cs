// Fill out your copyright notice in the Description page of Project Settings.
using System;
using System.IO;
using UnrealBuildTool;

public class MariaDBConnectorLibs: ModuleRules
{
	public MariaDBConnectorLibs(ReadOnlyTargetRules Target) : base(Target)
	{
		Type = ModuleType.External;
        
        // 添加需要设置的宏
        PublicDefinitions.Add("WITH_MYTHIRDPARTYLIBRARY=1");

        // 添加插件的包含路径
        PublicIncludePaths.Add(Path.Combine(ModuleDirectory, "MariaDB_Connector_C_64-bit", "include"));

        // 添加导入库或静态库
        //PublicAdditionalLibraries.Add(Path.Combine(ModuleDirectory, "MariaDB_Connector_C_64_bit", "lib"));
        
        if (Target.Platform == UnrealTargetPlatform.Win64)
        {
            // Add the import library
            PublicAdditionalLibraries.Add(Path.Combine(ModuleDirectory, "MariaDB_Connector_C_64-bit", "lib", "mariadbclient.lib")); //

            // Delay-load the DLL, so we can load it from the right place first
            //PublicDelayLoadDLLs.Add("mariadbclient.lib");

            // Ensure that the DLL is staged along with the executable
            //RuntimeDependencies.Add("$(PluginDir)/Binaries/Win64/mariadbclient.lib");
        }
        else if (Target.Platform == UnrealTargetPlatform.Mac)
        {
            //PublicDelayLoadDLLs.Add(Path.Combine(ModuleDirectory, "Mac", "Release", "libExampleLibrary.dylib"));
            //RuntimeDependencies.Add("$(PluginDir)/Source/ThirdParty/firstPluginsLibrary/Mac/Release/libExampleLibrary.dylib");
        }
        else if (Target.Platform == UnrealTargetPlatform.Linux)
        {
            //string ExampleSoPath = Path.Combine("$(PluginDir)", "Binaries", "ThirdParty", "firstPluginsLibrary", "Linux", "x86_64-unknown-linux-gnu", "libExampleLibrary.so");
            //PublicAdditionalLibraries.Add(ExampleSoPath);
            //PublicDelayLoadDLLs.Add(ExampleSoPath);
            //RuntimeDependencies.Add(ExampleSoPath);
        }

        //PublicIncludePaths.Add(Path.Combine(ModuleDirectory, "MariaDB_Connector_C_64-bit", "include"));
        //PublicIncludePaths.Add(Path.Combine(ModuleDirectory, "MariaDB_Connector_C_64-bit", "inc"));
        /*
        if (Target.Platform == UnrealTargetPlatform.Win64)
		{
            // Add the import library
            //PublicAdditionalLibraries.Add(Path.Combine(ModuleDirectory, "MariaDB_Connector_C_64-bit", "lib", "foo.a"));
            //PublicLibraryPaths.Add(Path.Combine(ModuleDirectory, "MariaDB_Connector_C_64-bit", "lib")); 
			//PublicAdditionalLibraries.Add("libmariadb.lib");
			PublicAdditionalLibraries.Add("mariadbclient.lib");	
			
			// Delay-load the DLL, so we can load it from the right place first	
			//PublicDelayLoadDLLs.Add("libmariadb.dll");				
			
			//PublicLibraryPaths.Add(Path.Combine(ModuleDirectory, "MariaDB Connector C 64-bit", "lib", "plugin"));
			// Delay-load the DLL, so we can load it from the right place first		
			//PublicDelayLoadDLLs.Add("dialog.dll");
			//PublicDelayLoadDLLs.Add("mysqlclearpassword.dll");
					
		}	
		*/
    }
}
