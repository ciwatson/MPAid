@Echo OFF
REM	****************************
REM	This batch file is used to generate the phone level MLF file form dictionary and word level MLF file
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
REM	assign character set to utf-8
REM	****************************
REM     chcp 65001 >NUL

REM	****************************
REM     create the phone level MLF file named PhoneMLF0.mlf PhoneMLF1.mlf
REM	****************************

"%Tools%HLEd" -l * -d "%Dictionaries%dictionary" -i "%MLFs%PhoneMLF0.mlf" "%Params%mkphones0.led" "%MLFs%WordMLF.mlf"
"%Tools%HLEd" -l * -d "%Dictionaries%dictionary" -i "%MLFs%PhoneMLF1.mlf" "%Params%mkphones1.led" "%MLFs%WordMLF.mlf"

Pause&Exit