cd ../Source
xcopy /E /I Service "../Deploy/PyhtonService/Service"
xcopy /E /I Executable "../Deploy/PyhtonService/Executable"
cd ../Test
xcopy /E /I CommandExecutionTests "../Deploy/PyhtonService/Tests/CommandExecutionTests"