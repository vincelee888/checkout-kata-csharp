Param([Int32]$snooze=60)

Clear-Host
Write-Host "Welcome to Baby Steps!"
Write-Host "----------------------"
Write-Host "Keeps the tests green and take baby steps!"
Start-Sleep -Seconds 2

$readySteadyGo = @("Ready...", "Set...", "Go!")

for($i = 0; $i -lt $readySteadyGo.Count; $i++) {
    Write-Host $readySteadyGo[$i]
    Start-Sleep -Seconds 1
}

$countdown = 5

while($true) {
    Start-Sleep -Seconds ($snooze - $countdown)

    Clear-Host

    for($i = $countdown; $i -gt 0; $i--) {
        Write-Host "${i}..."
        Start-Sleep -Seconds 1
    }

    Write-Host "Testing..."

    $testResults = Invoke-Expression "dotnet test --nologo -v quiet"

    if($testResults -like "*Passed!*") {
        Write-Host "Tests still passing; keep going!"
    }else {
        Write-Host "Tests failed; bye-bye code!"
        $null = Invoke-Expression "git clean -fd | git reset --hard"
    }
}