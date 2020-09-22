cd ../Source
xcopy /E /I Service "../Deploy/PyhtonService/Service"
xcopy /E /I Executable "../Deploy/PyhtonService/Executable"
cd ../Test
xcopy /E /I ExecutableTests "../Deploy/PyhtonService/Tests/ExecutableTests"