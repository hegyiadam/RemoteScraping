mkdir "../Deploy/_Globals"
copy settings.json "../Deploy/_Globals/settings.json"
cd ../Source
xcopy /E /I Service "../Deploy/PyhtonService/Service"
xcopy /E /I Executable "../Deploy/PyhtonService/Executable"
cd ../Test
xcopy /E /I ExecutableTests "../Deploy/PyhtonService/Tests/ExecutableTests"