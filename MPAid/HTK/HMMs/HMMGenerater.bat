@Echo OFF
REM	****************************
REM	This batch file is used to generate train code script (Script.scp) and the MFC files associated with audio         recordings
REM	****************************

REM	****************************
REM     if the folder "HMMs" does not exist, Create one
REM	****************************

IF NOT EXIST "%cd%\..\HMMs\" (mkdir "%cd%\..\HMMs\")

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

REM	****************************
REM     Generate train script in %HMMs% from %MFCs%
REM	****************************
Perl MFCs2Script.pl "%MFCs%\" mfc "%cd%"

REM	****************************
REM	assign character set to utf-8
REM	****************************
chcp 65001 >NUL

REM "%Tools%HCompV" -C config1 -f 0.01 -m -S train.scp -M hmm0 proto

"%Tools%HERest" -C config1 -I "%MLFs%PhoneMLF.mlf" -t 250.0 150.0 1000.0 -S train.scp -H hmm0/macros -H hmm0/hmmdefs -M hmm1 "%Dictionaries%monophones"

pause&exit