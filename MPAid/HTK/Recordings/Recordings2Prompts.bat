@Echo OFF
REM	****************************
REM	This batch file is used to generate a prompts file based on the recordings stored in the input folder
REM     Author: Sgaoqing Yu(Shawn)  14/01/2016
REM	****************************

REM	****************************
REM	set up the environment varibles 
REM	****************************
pushd "%cd%"
cd ..
for /f %%i in ('dir "%cd%" /a:d /b /d') do (
  IF NOT DEFINED %%i (
	set %%i=%cd%\%%i\
  )
)
popd

set /p recordingFolder=Please enter the recording folder address:
set targetFile="Prompts.pmpt"

REM	****************************
REM	empty the prompts file 
REM	****************************
type NUL >%targetFile%

REM	****************************
REM	assign character set to utf-8
REM	****************************
REM     chcp 65001 >NUL

REM	****************************
REM	list all the recordings 
REM	****************************
for /f %%n in ('forfiles /p %recordingFolder% /s /m *.wav /c "cmd /c echo @fname"') do (
  for /f "tokens=1-4 delims=-" %%a in ("%%~n") do echo %%~n %%c >> %targetFile%
)

pause & exit
