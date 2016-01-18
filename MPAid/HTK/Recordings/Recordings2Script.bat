@Echo OFF
REM	****************************
REM	This batch file is used to generate a script file based on the recordings stored in the input folder
REM     Author: Sgaoqing Yu(Shawn)  14/01/2016
REM	****************************

REM	****************************
REM     if the folder "MFCs" does not exist, Create one
REM	****************************

IF NOT EXIST "%cd%\..\MFCs\" (mkdir "%cd%\..\MFCs\")

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

REM	****************************
REM     create train code script (Script.scp) with a filter suffix "wav" in %MFCs%
REM	****************************

Perl Recordings2Script.pl "%recordingFolder%" wav "%MFCs%\"

pause&exit