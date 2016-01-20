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
REM	Generate a monophone list file with sp named "Monophones1"
REM	****************************
"%Tools%HDMan" -m -w "%WordLists%WordList.wlist" -g "%Params%global.ded" -n Monophones1 -i -l HDMan.Log dictionary lexicon.txt
echo sil >> Monophones1

REM	****************************
REM	Generate a monophone list file without sp named "Monophones0"
REM	****************************
(type Monophones1 | findstr /v sp)>Monophones0

pause & exit