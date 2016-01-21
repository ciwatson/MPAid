@Echo OFF
REM	****************************
REM	This batch file is used to generate train code script (Script.scp) and the MFC files associated with audio recordings
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

set /p recordingFolder=Please enter the recording folder address or full recording name:

REM	****************************
REM     create train code script (Script.scp) with a filter suffix "wav" in %MFCs%
REM	****************************
Perl ScriptGenerater.pl "%recordingFolder%" wav "%MFCs%\"

REM	****************************
REM	assign character set to utf-8
REM	****************************
REM     chcp 65001 >NUL

REM	****************************
REM     Generate MFC files by train code script
REM	****************************
"%Tools%HCopy" -T 1 -C "%Params%MFCs.conf" -S "%MFCs%script.scp"

Exit