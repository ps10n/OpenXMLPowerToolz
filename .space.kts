// paths to tools
val nuget = "C:\\TeamCity\\buildAgent\\tools\\NuGet.CommandLine.6.3.1\\tools\\NuGet.exe"
val msbuild = "C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\BuildTools\\MSBuild\\Current\\Bin\\MsBuild.exe"

job("Build and test") {
    host("Run nuget, msbuild, nunit") {
        shellScript {
            // 1. Restore dependencies
            // 2. Build the solution (MySolution.sln)
            // 3. Run tests in the MainTests.csproj project
            // To escape spaces in command line, we use quotes e.g. "$msbuild"
            content = """
                "$nuget" restore
                "$msbuild" OpenXmlPowerToolz.sln
            """
        }

        // run this job only on
        // a Windows worker
        requirements {
            os {
                type = OSType.Windows
            }
        }
    }
}