@Echo OFF
REM	****************************
REM	This batch file is used to generate a prompts file based on the recordings stored in this folder
REM     Author: Sgaoqing Yu(Shawn)  14/01/2016
REM	****************************

set targetFile="Prompts.pmpt"

REM	****************************
REM	find all the files 
REM	****************************
forfiles /s /m *.pmpt /c "cmd /c type NUL > @file"

for /f %%n in ('forfiles /s /m *.wav /c "cmd /c echo @fname"') do (
  for /f "tokens=1-4 delims=-" %%a in ("%%~n") do echo %%~n %%c >> %targetFile%
)

pause & exit


