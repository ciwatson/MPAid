@Echo OFF
REM	****************************
REM	This batch file is used to convert grammar file (Grammar/MPAid.gram) to word network file (WordNet/MPAid.wdnet) by WordNets/HParse
REM	****************************

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


REM	****************************
REM     if the folder "WordNet" does not exist, Create one
REM	****************************

IF NOT EXIST %WordNets% (mkdir %WordNets%)

REM	****************************
REM     create word network file (WordNet/MPAid.wdnet) by WordNets/HParse
REM	****************************
%Tools%HParse %Grammars%MPAid.gram %WordNets%MPAid.wdnet

Pause&Exit