param($installPath, $toolsPath, $package, $project)

Import-Module (Join-Path $toolsPath dotTrace-Remote.psm1) | Out-Null

Initialize-DotTrace