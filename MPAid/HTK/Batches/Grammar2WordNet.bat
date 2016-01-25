@Echo OFF
REM	****************************
REM	This batch file is used to convert grammar file (Grammar/MPAid.gram) to word network file (WordNet/MPAid.wdnet) by WordNets/HParse
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
REM     create word network file WordNet.wdnet by WordNets/HParse
REM	****************************
"%Tools%HParse" "%Grammars%grammar.gram" "%Grammars%WordNet.wdnet"

Pause&Exit