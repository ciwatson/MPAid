@Echo OFF
REM	****************************
REM	This batch file is used to generate a prompts file based on the recordings stored in this folder
REM     Author: Sgaoqing Yu(Shawn)  14/01/2016
REM	****************************

set targetFile="Script.scp"
set targetFolder=%cd%

chcp 65001 >NUL

REM	****************************
REM	find all the files 
REM	****************************
forfiles /s /m *.scp /c "cmd /U /c type NUL > @file"

for /f %%n in ('forfiles /s /m *.wav /c "cmd /c echo @file"') do (
  for /f "tokens=1,2 delims=." %%a in ("%%~n") do (
  echo %cd%\%%~n %targetFolder%\%%a.mfc >> %targetFile%
)
)

pause & exit
