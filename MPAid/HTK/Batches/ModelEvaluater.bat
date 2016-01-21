@Echo OFF
REM	****************************
REM	This batch file is used to evaluate the model we have built by audio recordings
REM	****************************

REM	****************************
REM     if the folder "Evaluations" does not exist, Create one
REM	****************************
IF NOT EXIST "%cd%\..\Evaluations\" (mkdir "%cd%\..\Evaluations\")

REM	****************************
REM     if the folder "MLFs" does not exist, Create one
REM	****************************
IF NOT EXIST "%cd%\..\MLFs\" (mkdir "%cd%\..\MLFs\")

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
REM     Generate evaluation script in %Evaluations% from %MFCs%
REM	****************************
type NUL> "%Evaluations%evaluation.scp"
for /f "tokens=1,2" %%a in (%MFCs%script.scp) do (
    echo %%b>> "%Evaluations%evaluation.scp"
)

REM	****************************
REM	Recognize the recordings on evaluation.scp and then output the transcript "RecMLF.mlf"
REM	****************************
"%Tools%HVite" -H -C "%Params%HMMs.conf" "%HMMs%hmm15/macros" -H "%HMMs%hmm15/hmmdefs" -S "%Evaluations%evaluation.scp" -l * -T 4 -i "%MLFs%RecMLF.mlf" -w "%WordNets%MPAid.wdnet" -p 0.0 -s 5.0 "%Dictionaries%dictionary" "%HMMs%tiedlist"> HVite.log

REM "%Tools%HResults" -I "%MLFs%WordMLF.mlf" "%HMMs%tiedlist" "%MLFs%RecMLF.mlf"

exit