@Echo OFF
REM	****************************
REM	This batch file is used to generate train code script (Script.scp) and the MFC files associated with audio         recordings
REM	****************************

REM	****************************
REM     Set the environment varibles by the folder names in parent directory
REM	****************************

pushd %cd%
cd ..
for /f "delims=" %%i in ('dir /b /a:d "%CD%\"') do (
    set %%~nxi=%CD%\%%i\
)
popd


REM	****************************
REM     if the folder "MFCs" does not exist, Create one
REM	****************************

IF NOT EXIST %MFCs% (mkdir %MFCs%)

REM	****************************
REM     create train code script (Script.scp) with a filter suffix "wav"
REM	****************************

Perl Recordings2Script.pl . wav

chcp 65001 >NUL

REM	****************************
REM     Generate MFC files by train code script
REM	****************************

%Tools%HCopy -T 1 -C config0 -S Script.scp

Pause&Exit