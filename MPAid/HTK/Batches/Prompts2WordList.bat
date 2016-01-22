@Echo OFF
REM	****************************
REM	This batch file is used to generate a word list file by calling the Perl script named "prompts2wlist.pl"
REM     Author: Sgaoqing Yu(Shawn)  15/01/2016
REM	****************************

REM	****************************
REM     if the folder "WordNet" does not exist, Create one
REM	****************************
IF NOT EXIST "%cd%\..\WordLists\" (mkdir "%cd%\..\WordLists\")

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
REM	Generate word list file by Prompts.pmpt
REM	****************************
Perl "%Perls%prompts2wlist.pl" "%Dictionaries%Prompts.pmpt" "%Dictionaries%WordList.wlist"

pause & exit