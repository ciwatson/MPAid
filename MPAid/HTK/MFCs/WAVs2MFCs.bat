@Echo OFF
REM	****************************
REM	This batch file is used to convert word network file (WordNet/MPAid.gram) to word network file (WordNet/MPAid.wdnet) by WordNets/HParse
REM	****************************

chcp 65001 >NUL

setlocal EnableDelayedExpansion
IF NOT DEFINED Root (
	set Root=%CD%\..\
	echo Root: !Root! 
)
endlocal & set Root=%Root%

setlocal EnableDelayedExpansion
IF NOT DEFINED Tools (
	set Tools=%Root%Tools\
	echo Tools: !Tools! 
)
endlocal & set Tools=%Tools%

setlocal EnableDelayedExpansion
IF NOT DEFINED Grammars (
	set Grammars=%Root%Grammars\
	echo Grammars: !Grammars! 
)
endlocal & set Grammars=%Grammars%

setlocal EnableDelayedExpansion
IF NOT DEFINED WordNets (
	set WordNets=%Root%WordNets\
	echo WordNets: !WordNets! 
)
endlocal & set WordNets=%WordNets%

setlocal EnableDelayedExpansion
IF NOT DEFINED Dictionaries (
	set Dictionaries=%Root%Dictionaries\
	echo Dictionaries: !Dictionaries! 
)
endlocal & set Dictionaries=%Dictionaries%

setlocal EnableDelayedExpansion
IF NOT DEFINED MLFs (
	set MLFs=%Root%MLFs\
	echo MLFs: !MLFs! 
)
endlocal & set MLFs=%MLFs%

setlocal EnableDelayedExpansion
IF NOT DEFINED MFCs (
	set MFCs=%Root%MLFs\
	echo MFCs: !MFCs! 
)
endlocal & set MFCs=%MFCs%

REM	****************************
REM     if the folder "WordNet" does not exist, Create one
REM	****************************

IF NOT EXIST %MFCs% (mkdir %MFCs%)

REM	****************************
REM     create word network file (WordNet/MPAid.wdnet) by WordNets/HParse
REM	****************************


%Tools%HCopy -T 1 -C config0 -S Script.scp

Pause&Exit