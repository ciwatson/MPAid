@Echo OFF
REM	****************************
REM	This batch file is used to generate the word level MLF file by calling the Perl script named "prompts2mlf.pl"
REM     Author: Sgaoqing Yu(Shawn)  15/01/2016
REM	****************************

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
REM	Generate word level MLF file by Prompts.pmpt
REM	****************************
Perl prompts2mlf.pl %MLFs%WordMLF.mlf Prompts.pmpt

pause & exit