function Get-DotTracePath {
    if ((Test-Path "hklm:\Software\Wow6432Node\JetBrains\dotTrace\v5.1") -eq $True) {
        return (Get-ItemProperty hklm:\Software\Wow6432Node\JetBrains\dotTrace\v5.1).InstallDir + "\Remote\RemoteAgent.WebService";
    }
    if ((Test-Path "hklm:\Software\Wow6432Node\JetBrains\dotTrace\v5.2") -eq $True) {
        return (Get-ItemProperty hklm:\Software\Wow6432Node\JetBrains\dotTrace\v5.2).InstallDir + "\Remote\RemoteAgent.WebService";
    }
    if ((Test-Path "hklm:\Software\Wow6432Node\JetBrains\dotTrace\v5.3") -eq $True) {
        return (Get-ItemProperty hklm:\Software\Wow6432Node\JetBrains\dotTrace\v5.3).InstallDir + "\Remote\RemoteAgent.WebService";
    }
    if ((Test-Path "hklm:\Software\Wow6432Node\JetBrains\dotTrace\v5.4") -eq $True) {
        return (Get-ItemProperty hklm:\Software\Wow6432Node\JetBrains\dotTrace\v5.4).InstallDir + "\Remote\RemoteAgent.WebService";
    }
    if ((Test-Path "hklm:\Software\Wow6432Node\JetBrains\dotTrace\v5.5") -eq $True) {
        return (Get-ItemProperty hklm:\Software\Wow6432Node\JetBrains\dotTrace\v5.5).InstallDir + "\Remote\RemoteAgent.WebService";
    }
}

function Find-DotTraceAssemblies {
    return Get-ChildItem -Path ((Get-DotTracePath) + "\bin\*.dll");
}

function Enable-DotTrace {
    (Get-Project).Object.Project.ProjectItems.AddFromFileCopy((Get-DotTracePath) + "\AgentService.asmx") | Out-Null
    (Get-Project).Object.Project.ProjectItems.AddFromFileCopy((Get-DotTracePath) + "\Authenticate.aspx") | Out-Null

    Find-DotTraceAssemblies | %{ (Get-Project).Object.References.Add( $_.FullName ) | Out-Null }
}

function Disable-DotTrace {
    (Get-Project).Object.Project.ProjectItems | Where-Object { $_.Name -eq "AgentService.asmx" } | %{ $_.Delete() | Out-Null }
    (Get-Project).Object.Project.ProjectItems | Where-Object { $_.Name -eq "Authenticate.aspx" } | %{ $_.Delete() | Out-Null }

    Find-DotTraceAssemblies | %{
        $reference = $_.Name;
        (Get-Project).Object.References | Where-Object { $_.Name + ".dll" -eq $reference } | %{ $_.Remove() | Out-Null }
    }
}

function Initialize-DotTrace {
    if ((Test-Path Get-DotTracePath -IsValid) -eq $False) {
        [System.Reflection.Assembly]::LoadWithPartialName("System.Windows.Forms") | Out-Null
        $result = [Windows.Forms.MessageBox]::Show("You currently do not have JetBrains dotTrace Performance installed. Would you like to download it now?", "JetBrains dotTrace", [Windows.Forms.MessageBoxButtons]::YesNo, [Windows.Forms.MessageBoxIcon]::Information);
        if ($result -eq [Windows.Forms.DialogResult]::Yes) {
            Start-Process -FilePath "http://www.jetbrains.com/profiler/download/index.html"
        }
    }
}

Export-ModuleMember -Function *