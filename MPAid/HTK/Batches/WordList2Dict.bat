@Echo OFF
REM	****************************
REM	This batch file is used to create a monophone list file with sp, and then delete sp inside
REM     Author: Sgaoqing Yu(Shawn)  15/01/2016
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

REM	****************************
REM	Generate a monophone list file with sp named "monophones1"
REM	****************************
"%Tools%HDMan" -m -w "%Dictionaries%WordList.wlist" -g "%Params%global.ded" -n "%Dictionaries%monophones1" -i -l HDMan.Log "%Dictionaries%dictionary" "%Dictionaries%lexicon.txt"

REM	****************************
REM	Generate a monophone list file without sp named "monophones0"
REM	****************************
(type "%Dictionaries%monophones1" | findstr /v sp)>"%Dictionaries%monophones0"

pause & exit